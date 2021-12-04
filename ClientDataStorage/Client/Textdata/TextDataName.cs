using Structs.Pk2.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataStorage.Client.Textdata
{
    public class TextDataName
    {

        private TextGroupParser Group;


        public Dictionary<string, TextDataNameStruct> TextDataNames;

        public TextDataName(byte[] array)
            => Group = new TextGroupParser(array, "Media\\server_dep\\silkroad\\textdata", 9, "\t".ToCharArray());
    }
}
