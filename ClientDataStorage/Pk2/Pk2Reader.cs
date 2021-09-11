using Structs.Pk2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataStorage.Pk2
{
    public  class Pk2Reader : Pk2Data
    {
        /// <summary>
        /// The Reader is one .pk2 file. Here you can read all informations from the files inside the abstract base class Pk2Data.
        /// </summary>
        /// <param name="path"></param>
        public Pk2Reader(string path)
        {
            base.Pk2DataPath = path;
            base.Blowfish.Initialize(base.bKey);
            this.Read();
        }

        /// <summary>
        /// All folder from the first EntryBlock are subFolder from base.Pk2File.
        /// All Files from the first EntryBlock are files from base.Pk2File.
        /// </summary>
        public override void Read()
        {
            base.Pk2File = new Pk2Folder() { name = Path.GetFileNameWithoutExtension(base.Pk2DataPath) };

            if (!File.Exists(Pk2DataPath))
                return;

            using (BinaryReader reader = new BinaryReader(File.OpenRead(base.Pk2DataPath)))
            {
                Pk2Folder tempFolder = new Pk2Folder() { parentFolder = base.Pk2File , name = base.Pk2File.name};

                if (GenerateFolder(reader, 256, tempFolder, out Pk2Folder newFolder))
                    base.Pk2File = newFolder;        
            }
        }

        /// <summary>
        /// Refreshes the Pk2 File
        /// </summary>
        /// <returns>bool : Weather if refreshing succeeded or not.</returns>
        public override bool Refresh()
        {
            base.Pk2File = null;
            this.Read();
            return base.Pk2File != null;
        }

        /// <summary>
        /// Returns file as byte array with parameter Pk2File.
        /// </summary>
        /// <param name="file">Pk2File from Pk2Data.</param>
        /// <returns>byte[] : Raw bytes from Pk2File. </returns>
        public byte[] GetByteArrayByFile(Pk2File file)
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(base.Pk2DataPath)))
            {
                reader.BaseStream.Position = file.position;
                return reader.ReadBytes((int)file.size);
            }
        }

        /// <summary>
        /// Returns file as byte array with parameter Pk2File.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>Pk2File from FolderDirectory</returns>
        public Pk2File GetFileByDirectory(string dir)
        {
            string[] splittedDirectory = dir.Split('\\');
            Pk2Folder tempFodler = new Pk2Folder() { subfolders = base.Pk2File.subfolders, files = base.Pk2File.files};
           
            for (int i = 0; i < splittedDirectory.Length; i++)
            {
                if (i == splittedDirectory.Length - 1 && tempFodler.files.Exists(file => file.name == splittedDirectory[i]))
                    return tempFodler.files.First(fi => fi.name == splittedDirectory[i]);

                if (tempFodler.subfolders.Exists(sub => sub.name == splittedDirectory[i+1]))
                    tempFodler = tempFodler.subfolders.First(subF => subF.name == splittedDirectory[i+1]);
            }
            return new Pk2File();
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
                                unusedMainFolder.subfolders.Add(sub);
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
    }
}
