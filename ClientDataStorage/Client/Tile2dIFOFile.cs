using ClientDataStorage.Client.Textdata;
using System.Linq;

namespace ClientDataStorage.Client
{
    public class Tile2dIFOFile : TextParser
    {
        public string[] TexturePaths;

        public Tile2dIFOFile()
        {
            var t1 = Map.MapPk2.GetFileByDirectory("Map\\tile2d.ifo");
            var t2 = Map.MapPk2.GetByteArrayByFile(t1);
            var t3 = base.ConvertByteArrayToStructedTextArray(t2, 4," ".ToCharArray()).ToList();
            var t45 = base.ConvertByteArrayToText(t2);
            var t5 = base.ConvertTextToTextArray(t45).Where(text => text.Length > 24).ToArray();

            int counter = 0;
            TexturePaths = new string[t5.Length];
            foreach (var arrays in t5)
            {
                if (counter == 717)
                {

                }
                var ID = arrays.Substring(0, 5);
                var unk = arrays.Substring(6, 10);
                var flag = arrays.Substring(18, arrays.IndexOf('"', 18)-18);
                var texture = arrays.Substring(18 + flag.Length + 3, arrays.IndexOf('"', 18 + flag.Length + 3) -(18 + flag.Length + 3));


                TexturePaths[counter] = texture;
                counter++;
            }
        }
    }
}