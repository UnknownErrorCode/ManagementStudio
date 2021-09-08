using System.Collections.Generic;

namespace Structs.Pk2
{
    public class Pk2Folder
    {
        public string name;
        public long position;
        public Pk2Folder parentFolder;
        public List<Pk2File> files;
        public List<Pk2Folder> subfolders;

        public Pk2Folder() 
        {
            files = new List<Pk2File>();
            subfolders = new List<Pk2Folder>();
        }

        public Pk2Folder(Pk2Entry entry)
        {
            name = entry.name;
            position = entry.Position;
            files = new List<Pk2File>();
            subfolders = new List<Pk2Folder>();
        }
    }
}