using System.Collections.Generic;
using System.Linq;

namespace ClientDataStorage.Client.Textdata
{
    public class TextGroupParser
    {
        #region Fields

        /// <summary>
        /// Consists of all filenames inside the TextGroup.
        /// </summary>
        public Dictionary<string, string[][]> GroupFiles = new Dictionary<string, string[][]>();

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Constructor equals the byte[] from raw text group file inside pk2 data.
        /// </summary>
        /// <param name="sourceFile"></param>
        public TextGroupParser(byte[] sourceFile, string groupDirectory, byte columnSize, char[] splitChar)
        {
            string[] TextFiles = TextParser.StaticTextParser.ConvertByteArrayToTextArray(sourceFile);

            if (TextFiles.Length != 0)
            {
                foreach (string file in TextFiles)
                {
                    if (Media.MediaPk2.GetByteArrayByDirectory($"{groupDirectory}\\{file}", out byte[] rawFile))
                    {
                        GroupFiles.Add(file, TextParser.StaticTextParser.ConvertByteArrayToStructedTextArray(rawFile, columnSize, splitChar).ToArray());
                    }
                }
            }
        }

        #endregion Constructors
    }
}