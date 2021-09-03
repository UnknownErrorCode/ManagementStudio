using System.Collections.Generic;

namespace Structs.Pk2
{
    public class Pk2Folder
    {
        public string name;
        public long position;
        public List<Pk2File> files;
        public List<Pk2Folder> subfolders;
    }
}