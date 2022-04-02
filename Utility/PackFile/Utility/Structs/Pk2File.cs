namespace PackFile
{
    public struct Pk2File
    {
        public string name { get; set; }
        public long position { get; set; }
        public uint size { get; set; }
        public Pk2Folder parentFolder { get; set; }

        public Pk2File(Pk2Entry entry, Pk2Folder pFolder)
        {
            name = entry.name;
            position = entry.Position;
            size = entry.Size;
            parentFolder = pFolder;
        }
    }
}
