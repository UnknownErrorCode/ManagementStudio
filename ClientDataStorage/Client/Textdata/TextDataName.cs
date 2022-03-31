using Structs.Pk2.Media;
using System.Collections.Generic;

namespace ClientDataStorage.Client.Textdata
{
    public class TextDataName
    {
        #region Fields

        public Dictionary<string, TextDataNameStruct> TextDataNames;
        private readonly TextGroupParser Group;

        #endregion Fields

        #region Constructors

        public TextDataName(byte[] array)
        {
            Group = new TextGroupParser(array, "Media\\server_dep\\silkroad\\textdata", 9, "\t".ToCharArray());
        }

        #endregion Constructors
    }
}