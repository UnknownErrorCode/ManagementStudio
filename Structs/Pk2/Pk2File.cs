namespace Structs.Pk2
{
    public struct Pk2File
    {
        public string name;
        public long position;
        public uint size;
        public Pk2Folder parentFolder;

        public Pk2File(Pk2Entry entry, Pk2Folder pFolder)
        {
            name = entry.name;
            position = entry.Position;
            size = entry.Size;
            parentFolder = pFolder;
        }
    }
}
