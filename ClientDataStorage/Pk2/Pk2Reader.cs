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
    public class Pk2Reader : Pk2Data
    {
        public  Pk2Folder StaticFile { get => base.Pk2File; }
        public Pk2Reader(string path)
        {
            base.Pk2DataPath = path;
            base.Blowfish.Initialize(base.bKey);
            base.Pk2File = new Pk2Folder() { name = Path.GetFileNameWithoutExtension(path) };
        }

      

        /// <summary>
        /// All folder from the first EntryBlock are subFolder from base.Pk2File.
        /// All Files from the first EntryBlock are files from base.Pk2File.
        /// </summary>
        public override void Read()
        {
            if (!File.Exists(Pk2DataPath))
                return;

            using (BinaryReader reader = new BinaryReader(File.OpenRead(base.Pk2DataPath)))
            {
                Pk2Folder tempFolder = new Pk2Folder() { parentFolder = base.Pk2File , name = base.Pk2File.name};

                if (TryReadFolder(reader, 256, tempFolder, out Pk2Folder newFolder))
                    base.Pk2File = newFolder;        
            }
        }

        public byte[] GetFileByExtract(Pk2File file)
        {
            using (BinaryReader reader = new BinaryReader(File.OpenRead(base.Pk2DataPath)))
            {
                reader.BaseStream.Position = file.position;
                return reader.ReadBytes((int)file.size);
            }
        }
        private bool TryReadFolder(BinaryReader reader, Int64 position, Pk2Folder parentFolder, out Pk2Folder unusedMainFolder)
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
                            
                            if (TryReadFolder(reader, entry.Position, new Pk2Folder(entry) { parentFolder = unusedMainFolder.parentFolder }, out Pk2Folder sub))
                                unusedMainFolder.subfolders.Add(sub);
                            break;

                        case Pk2EntryType.File:
                            unusedMainFolder.files.Add(new Pk2File(entry, unusedMainFolder.parentFolder));
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

        internal object BufferToStruct(byte[] buffer, Type returnStruct)
        {
            IntPtr pointer = Marshal.AllocHGlobal(buffer.Length);
            Marshal.Copy(buffer, 0, pointer, buffer.Length);

            return Marshal.PtrToStructure(pointer, returnStruct);
        }
    }
}
