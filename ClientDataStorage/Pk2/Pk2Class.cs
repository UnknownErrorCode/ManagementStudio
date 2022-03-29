using Structs.Pk2;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace ClientDataStorage.Pk2
{
    public class Pk2Class
    {
        public List<Pk2File> Files = new List<Pk2File>();

        public List<Pk2Folder> Folders = new List<Pk2Folder>();

        private readonly ConcurrentDictionary<string, Pk2File> AllFiles = new ConcurrentDictionary<string, Pk2File>();

        /// <summary>
        /// This bKey is used to parse the security blowfish of the pk2 File
        /// </summary>
        private readonly byte[] bKey = new byte[] { 0x32, 0xCE, 0xDD, 0x7C, 0xBC, 0xA8 };

        /// <summary>
        /// Used to encrypt and decrypt the pk2 stream
        /// </summary>
        private readonly Blowfish blowfish = new Blowfish();

        private Pk2Folder currentFolder;
        private readonly List<Pk2EntryBlock> EntryBlocks = new List<Pk2EntryBlock>();
        private readonly FileStream fileStream;
        private Pk2Header header;
        private readonly Pk2Folder mainFolder;

        public Pk2Class(string pk2FilePath)
        {
            if (File.Exists(pk2FilePath))
            {
                fileStream = new FileStream(pk2FilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                blowfish.Initialize(bKey);
                using (BinaryReader reader = new BinaryReader(fileStream))
                {
                    header = (Pk2Header)BufferToStruct(reader.ReadBytes(256), typeof(Pk2Header));
                    currentFolder = new Pk2Folder
                    {
                        name = pk2FilePath,
                        files = new List<Pk2File>(),
                        subfolders = new List<Pk2Folder>()
                    };

                    mainFolder = currentFolder;
                    read(reader.BaseStream.Position);
                }
            }
        }

        public void ExtractSingleFile(string CreatePath, Pk2File file)
        {
            string pathToCreateFile = Path.Combine(CreatePath, file.name);
            byte[] byteArrayOfSelectedFile = GetFileByExtract(file);

            using (FileStream str = File.Create(pathToCreateFile, byteArrayOfSelectedFile.Length, FileOptions.Asynchronous))
            {
                str.Write(byteArrayOfSelectedFile, 0, byteArrayOfSelectedFile.Length);
                str.Close();
            }
        }

        public bool fileExists(string name)
        {
            Pk2File file = Files.Find(item => item.name.ToLower() == name.ToLower());

            if (file.position != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public byte[] GetFile(string name)
        {
            if (fileExists(name))
            {
                using (BinaryReader reader = new BinaryReader(fileStream))
                {
                    Pk2File file = Files.Find(item => item.name.ToLower() == name.ToLower());
                    reader.BaseStream.Position = file.position;
                    return reader.ReadBytes((int)file.size);
                }
            }
            else
            {
                return null;
            }
        }

        public byte[] GetFileByExtract(Pk2File file)
        {
            using (BinaryReader reader = new BinaryReader(fileStream))
            {
                reader.BaseStream.Position = file.position;
                return reader.ReadBytes((int)file.size);
            }
        }

        public List<string> GetFileNames()
        {
            List<string> tmpList = new List<string>();

            foreach (Pk2File file in Files)
            {
                tmpList.Add(file.name);
            }

            return tmpList;
        }

        public List<Pk2Folder> GetFoldersFromCurrentFolder()
        {
            List<Pk2Folder> tempList = new List<Pk2Folder>();

            foreach (Pk2Folder subFolder in mainFolder.subfolders)
            {
                tempList.Add(subFolder);
            }

            return tempList;
        }

        internal object BufferToStruct(byte[] buffer, Type returnStruct)
        {
            IntPtr pointer = Marshal.AllocHGlobal(buffer.Length);
            Marshal.Copy(buffer, 0, pointer, buffer.Length);

            return Marshal.PtrToStructure(pointer, returnStruct);
        }

        private void read(Int64 position)
        {
            BinaryReader reader = new BinaryReader(fileStream);
            reader.BaseStream.Position = position;
            List<Pk2Folder> tmpFolders = new List<Pk2Folder>();

            Pk2EntryBlock entryBlock = (Pk2EntryBlock)BufferToStruct(blowfish.Decode(reader.ReadBytes(Marshal.SizeOf(typeof(Pk2EntryBlock)))), typeof(Pk2EntryBlock));

            for (int i = 0; i < 20; i++)
            {
                Pk2Entry entry = entryBlock.entries[i];

                switch (entry.type)
                {
                    case Pk2EntryType.Exit:
                        break;

                    case Pk2EntryType.Folder:
                        if (entry.name != "." && entry.name != "..")
                        {
                            Pk2Folder tmpFolder = new Pk2Folder
                            {
                                name = entry.name,
                                position = BitConverter.ToInt64(entry.position, 0)
                            };
                            tmpFolders.Add(tmpFolder);
                            Folders.Add(tmpFolder);

                            if (tmpFolder != null && currentFolder.subfolders == null)
                            {
                                currentFolder.subfolders = new List<Pk2Folder>();
                            }

                            currentFolder.subfolders.Add(tmpFolder);
                        }
                        break;

                    case Pk2EntryType.File:
                        {
                            Pk2File tmpFile = new Pk2File
                            {
                                position = entry.Position,
                                name = entry.name,
                                size = entry.Size,
                                parentFolder = currentFolder
                            };
                            Files.Add(tmpFile);

                            currentFolder.files.Add(tmpFile);
                            AllFiles.TryAdd(Path.Combine(tmpFile.parentFolder.name, tmpFile.name), tmpFile);
                        }
                        break;
                }
            }

            if (entryBlock.entries[19].nChain != 0)
            {
                read(entryBlock.entries[19].nChain);
            }

            foreach (Pk2Folder folder in tmpFolders)
            {
                currentFolder = folder;

                if (folder.files == null)
                {
                    folder.files = new List<Pk2File>();
                }
                else if (folder.subfolders == null)
                {
                    folder.subfolders = new List<Pk2Folder>();
                }

                read(folder.position);
            }
        }
    }
}