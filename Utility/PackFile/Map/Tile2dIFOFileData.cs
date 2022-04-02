using PackFile.Utility;
using System.Linq;

namespace PackFile.Map
{
    public abstract class Tile2dIFOFileData
    {
        #region Fields

        public string[] texturePaths;

        internal readonly bool Initialized;

        #endregion Fields

        #region Constructors

        public Tile2dIFOFileData(byte[] array)
        {
            try
            {
                string t45 = TextParser.ConvertByteArrayToAsciiText(array);
                string[] t5 = TextParser.ConvertTextToTextArray(t45).Where(text => text.Length > 24).ToArray();
                int counter = 0;
                texturePaths = new string[t5.Length];
                foreach (string arrays in t5)
                {
                    string ID = arrays.Substring(0, 5);
                    string unk = arrays.Substring(6, 10);
                    string flag = arrays.Substring(18, arrays.IndexOf('"', 18) - 18);
                    string texture = arrays.Substring(18 + flag.Length + 3, arrays.IndexOf('"', 18 + flag.Length + 3) - (18 + flag.Length + 3));

                    texturePaths[counter] = texture;
                    counter++;
                }
            }
            catch (System.Exception)
            {
                Initialized = false;
            }
            Initialized = true;
        }

        #endregion Constructors
    }
}