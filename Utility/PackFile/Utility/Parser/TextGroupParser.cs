using System.Collections.Generic;
using System.Linq;

namespace PackFile.Utility
{
    public class TextGroupParser
    {
        #region Fields

        /// <summary>
        /// Consists of all filenames inside the TextGroup.
        /// </summary>
        public Dictionary<string, string[][]> GroupFiles = new Dictionary<string, string[][]>();

        #endregion Fields

        #region Methods

        /// <summary>
        /// Merges only allowed textfiles into the group.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="rawFile"></param>
        /// <param name="columnSize"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public bool Merge(string file, byte[] rawFile, byte columnSize, char[] splitChar)
        {
            if (GroupFiles.ContainsKey(file))
                GroupFiles[file] = TextParser.ConvertByteArrayToStructedTextArray(rawFile, columnSize, splitChar).ToArray();

            return GroupFiles.ContainsKey(file);
        }

        public void Read(byte[] sourceFile)
        {
            string[] TextFiles = TextParser.ConvertByteArrayToTextArray(sourceFile);

            if (TextFiles.Length != 0)
            {
                foreach (string file in TextFiles)
                {
                    GroupFiles.Add(file, new string[0][]);
                }
            }
        }

        #endregion Methods
    }
}