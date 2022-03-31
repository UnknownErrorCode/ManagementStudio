using BinaryFiles.Utility;
using System.Linq;

namespace BinaryFiles.PackFile.Media.Textdata
{
    public abstract class Tile2dIFOFileData
    {
        #region Fields

        public string[] TexturePaths;

        #endregion Fields

        #region Constructors

        public Tile2dIFOFileData(byte[] array)
        {
            //if (Map.MapPk2.GetByteArrayByDirectory("Map\\tile2d.ifo", out byte[] array))
            //{
            string t45 = TextParser.ConvertByteArrayToAsciiText(array);
            string[] t5 = TextParser.ConvertTextToTextArray(t45).Where(text => text.Length > 24).ToArray();
            int counter = 0;
            TexturePaths = new string[t5.Length];
            foreach (string arrays in t5)
            {
                string ID = arrays.Substring(0, 5);
                string unk = arrays.Substring(6, 10);
                string flag = arrays.Substring(18, arrays.IndexOf('"', 18) - 18);
                string texture = arrays.Substring(18 + flag.Length + 3, arrays.IndexOf('"', 18 + flag.Length + 3) - (18 + flag.Length + 3));

                TexturePaths[counter] = texture;
                counter++;
            }
            //}
        }

        #endregion Constructors
    }
}