using Structs.Pk2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataStorage.Client.Textdata
{
    class TextGroupParser : TextParser
    {
        /// <summary>
        /// Consists of all filenames inside the TextGroup. 
        /// </summary>
        private string[] TextFiles { get; set; }

        public Dictionary<string, string[][]> GroupFiles;

        /// <summary>
        /// Constructor equals the byte[] from raw text group file inside pk2 data.
        /// </summary>
        /// <param name="sourceFile"></param>
        public TextGroupParser(byte[] sourceFile) : base()
        {
            TextFiles = base.ConvertByteArrayToTextArray(sourceFile);

            if (TextFiles.Length!=0)
            {

            }
        }
    }
}
