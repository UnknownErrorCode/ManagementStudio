using Structs.Pk2.Media;
using System.Collections.Generic;

namespace ClientDataStorage.Client.Textdata
{
    public class TextDataName
    {
        private readonly TextGroupParser Group;

        public Dictionary<string, TextDataNameStruct> TextDataNames;

        public TextDataName(byte[] array)
        {
            Group = new TextGroupParser(array, "Media\\server_dep\\silkroad\\textdata", 9, "\t".ToCharArray());
        }
    }
}