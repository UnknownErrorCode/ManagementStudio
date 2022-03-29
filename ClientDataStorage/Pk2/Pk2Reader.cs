using Structs.Pk2;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace ClientDataStorage.Pk2
{
    public class Pk2Reader : Pk2Data
    {
        /// <summary>
        /// The Reader is one .pk2 file. Here you can read all informations from the files inside the abstract base class Pk2Data.
        /// </summary>
        /// <param name="path"></param>
        public Pk2Reader(string path)
        {
            Initialized = File.Exists(path);
            base.Pk2DataPath = path;
            base.Blowfish.Initialize(base.bKey);
            Read();
        }

        public bool Initialized { get; }

        /// <summary>
        /// Check if file exists in certain pk2 data.
        /// </summary>
        /// <param name="dir">Directory of file inside the pk2 data.</param>
        /// <returns>bool exists</returns>
        public override bool FileExists(string dir)
        {
            string[] splittedDirectory = dir.Split('\\');
            Pk2Folder tempFodler = new Pk2Folder() { subfolders = base.Pk2File.subfolders, files = base.Pk2File.files };

            for (int i = 0; i < splittedDirectory.Length; i++)
            {
                if (i == splittedDirectory.Length - 1)
                {
                    if (tempFodler.files.Exists(file => file.name == splittedDirectory[i]))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (tempFodler.subfolders.Exists(sub => sub.name == splittedDirectory[i + 1]))
                {
                    tempFodler = tempFodler.subfolders.First(subF => subF.name == splittedDirectory[i + 1]);
                }
            }
            return false;
        }

        /// <summary>
        /// Seek the file by directory and returns it as raw byte array
        /// </summary>
        /// <param name="directory">Directory of the file inside the pk2 data.</param>
        /// <param name="fileArray">out byte[] array</param>
        /// <returns>byte[] raw array</returns>
        public override bool GetByteArrayByDirectory(string directory, out byte[] fileArray)
        {
            fileArray = null;
            Pk2File file = GetFileByDirectory(directory);
            if (file.name == null)
            {
                return false;
            }

            fileArray = GetByteArrayByFile(file);
            return true;
        }

        /// <summary>
        /// Returns file as byte array with parameter Pk2File.
        /// </summary>
        /// <param name="file">Pk2File from Pk2Data.</param>
        /// <returns>byte[] : Raw bytes from Pk2File. </returns>
        public override byte[] GetByteArrayByFile(Pk2File file)
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(base.Pk2DataPath)))
            {
                reader.BaseStream.Position = file.position;
                return reader.ReadBytes((int)file.size);
            }
        }

        /// <summary>
        /// Returns file by directory of pk2 file.
        /// </summary>
        /// <param name="dir"></param>
        /// <returns>Pk2File from FolderDirectory</returns>
        public override Pk2File GetFileByDirectory(string dir)
        {
            string[] splittedDirectory = dir.Split('\\');
            Pk2Folder tempFodler = new Pk2Folder() { subfolders = base.Pk2File.subfolders, files = base.Pk2File.files };

            for (int i = 0; i < splittedDirectory.Length; i++)
            {
                if (i == splittedDirectory.Length - 1)
                {
                    if (tempFodler.files.Exists(file => file.name == splittedDirectory[i]))
                    {
                        return tempFodler.files.First(fi => fi.name == splittedDirectory[i]);
                    }
                    else
                    {
                        return new Pk2File();
                    }
                }

                if (tempFodler.subfolders.Exists(sub => sub.name == splittedDirectory[i + 1]))
                {
                    tempFodler = tempFodler.subfolders.First(subF => subF.name == splittedDirectory[i + 1]);
                }
            }
            return new Pk2File();
        }

        public bool GetFilesInFolder(string filePath, out Structs.Pk2.Pk2File[] filesInFolder)
        {
            Pk2Folder tempFolder = base.Pk2File;
            string[] folders = filePath.Split('\\');
            filesInFolder = null;
            for (int i = 0; i < folders.Length - 1; i++)
            {
                if (tempFolder.subfolders.Exists(fold => fold.name.Equals(folders[i + 1])))
                {
                    tempFolder = tempFolder.subfolders.First(fol => fol.name.Equals(folders[i + 1]));
                }
                else
                {
                    return false;
                }
            }
            filesInFolder = tempFolder.files.Count > 0 ? tempFolder.files.ToArray() : null;
            return true;
        }

        /// <summary>
        /// All folder from the first EntryBlock are subFolder from base.Pk2File.
        /// All Files from the first EntryBlock are files from base.Pk2File.
        /// </summary>
        public override void Read()
        {
            base.Pk2File = new Pk2Folder() { name = Path.GetFileNameWithoutExtension(base.Pk2DataPath) };

            if (!File.Exists(Pk2DataPath))
            {
                return;
            }

            using (BinaryReader reader = new BinaryReader(File.OpenRead(base.Pk2DataPath)))
            {
                Pk2Folder tempFolder = new Pk2Folder() { parentFolder = base.Pk2File, name = base.Pk2File.name };

                if (GenerateFolder(reader, 256, tempFolder, out Pk2Folder newFolder))
                {
                    base.Pk2File = newFolder;
                }
            }
        }

        /// <summary>
        /// Refreshes the Pk2 File
        /// </summary>
        /// <returns>bool : Weather if refreshing succeeded or not.</returns>
        public override bool Refresh()
        {
            base.Pk2File = null;
            Read();
            return base.Pk2File != null;
        }

        /// <summary>
        /// Converts a byte array to required type by marshaling the buffer.
        /// </summary>
        /// <param name="buffer">Byte Array to convert.</param>
        /// <param name="returnStruct">Struct to return</param>
        /// <returns>object : object of Type from Byte[].</returns>
        private object BufferToStruct(byte[] buffer, Type returnStruct)
        {
            IntPtr pointer = Marshal.AllocHGlobal(buffer.Length);
            Marshal.Copy(buffer, 0, pointer, buffer.Length);

            return Marshal.PtrToStructure(pointer, returnStruct);
        }

        /// <summary>
        /// Generates a pk2 Folder with empty SubFolders and Files
        /// </summary>
        /// <param name="reader">Required for reading bianry pk2 file.</param>
        /// <param name="position">Indicates the start possition of EntryBlock.</param>
        /// <param name="parentFolder">ParentFolder required for navigation in file.</param>
        /// <param name="unusedMainFolder">Generated Folder for "out" method.</param>
        /// <returns>bool : Weather if Generating succeeded or not.</returns>
        private bool GenerateFolder(BinaryReader reader, Int64 position, Pk2Folder parentFolder, out Pk2Folder unusedMainFolder)
        {
            reader.BaseStream.Position = position;
            try
            {
                unusedMainFolder = new Pk2Folder() { parentFolder = parentFolder.parentFolder, name = parentFolder.name, position = parentFolder.position };

            EntryBlockReader:
                Pk2EntryBlock entryBlock = (Pk2EntryBlock)BufferToStruct(base.Blowfish.Decode(reader.ReadBytes(Marshal.SizeOf(typeof(Pk2EntryBlock)))), typeof(Pk2EntryBlock));

                for (int entity = 0; entity < entryBlock.entries.Length; entity++)
                {
                    Pk2Entry entry = entryBlock.entries[entity];

                    switch (entry.type)
                    {
                        case Pk2EntryType.Exit:
                            break;

                        case Pk2EntryType.Folder when entry.name != "." && entry.name != "..":

                            if (GenerateFolder(reader, entry.Position, new Pk2Folder(entry) { parentFolder = unusedMainFolder.parentFolder }, out Pk2Folder sub))
                            {
                                unusedMainFolder.subfolders.Add(sub);
                            }

                            break;

                        case Pk2EntryType.File:
                            unusedMainFolder.files.Add(new Pk2File(entry, unusedMainFolder));
                            break;

                        default:
                            break;
                    }
                }
                if (entryBlock.entries[19].nChain != 0)
                {
                    reader.BaseStream.Position = entryBlock.entries[19].nChain;
                    goto EntryBlockReader;
                }
            }
            catch (Exception)
            {
                unusedMainFolder = null;
                return false;
            }
            return true;
        }
    }
}