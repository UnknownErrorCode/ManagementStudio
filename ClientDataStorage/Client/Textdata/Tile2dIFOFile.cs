using ClientDataStorage.Client.Textdata;
using System.Linq;

namespace ClientDataStorage.Client
{
    public class Tile2dIFOFile
    {
        #region Fields

        public string[] TexturePaths;

        #endregion Fields

        #region Constructors

        public Tile2dIFOFile()
        {
            if (Map.MapPk2.GetByteArrayByDirectory("Map\\tile2d.ifo", out byte[] array))
            {
                string t45 = TextParser.StaticTextParser.ConvertByteArrayToAsciiText(array);
                string[] t5 = TextParser.StaticTextParser.ConvertTextToTextArray(t45).Where(text => text.Length > 24).ToArray();
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
            }
        }

        #endregion Constructors
    }
}