using ClientDataStorage.Client.Textdata;
using System.Linq;

namespace ClientDataStorage.Client
{
    public class Tile2dIFOFile
    {
        public string[] TexturePaths;

        public Tile2dIFOFile()
        {
            if (Map.MapPk2.GetByteArrayByDirectory("Map\\tile2d.ifo", out byte[] array))
            {
                var t45 = TextParser.StaticTextParser.ConvertByteArrayToAsciiText(array);
                var t5 = TextParser.StaticTextParser.ConvertTextToTextArray(t45).Where(text => text.Length > 24).ToArray();
                int counter = 0;
                TexturePaths = new string[t5.Length];
                foreach (var arrays in t5)
                {
                    var ID = arrays.Substring(0, 5);
                    var unk = arrays.Substring(6, 10);
                    var flag = arrays.Substring(18, arrays.IndexOf('"', 18) - 18);
                    var texture = arrays.Substring(18 + flag.Length + 3, arrays.IndexOf('"', 18 + flag.Length + 3) - (18 + flag.Length + 3));

                    TexturePaths[counter] = texture;
                    counter++;
                }
            }
        }
    }
}