using Structs.BinaryFiles;
using System.Collections.Generic;
using System.Linq;

namespace PackFile.Data.Navmesh
{
    public abstract partial class ObjectStringIFOData
    {
        private List<ObjectStringIFOStruct> _list;

        public List<ObjectStringIFOStruct> List { get => _list; }
        public bool Initialized;
        public ObjectStringIFOData(byte[] file)
        {
            try
            {
                string t45 = Utility.TextParser.ConvertByteArrayToAsciiText(file);
                string[] t5 = Utility.TextParser.ConvertTextToTextArray(t45);
                var dungeonInfoRows = Utility.TextParser.ConvertTextArrayToStructedText(t5, 9, " ".ToCharArray());
                _list = new List<ObjectStringIFOStruct>(dungeonInfoRows.Count());

                foreach (var item in dungeonInfoRows)
                {
                    _list.Add(new ObjectStringIFOStruct(item));
                }
                Initialized = true;
            }
            catch (System.Exception ex)
            {
                Initialized = false;
            }
        }

    }
}
