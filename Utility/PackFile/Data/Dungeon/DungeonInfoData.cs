using System.Collections.Generic;
using System.Linq;

namespace PackFile.Data.Dungeon
{
    public abstract class DungeonInfoData
    {
        #region Fields

        private List<DungeonInfoStruct> list;
        public bool Initialized;

        #endregion Fields

        #region Constructors

        public DungeonInfoData(byte[] file)
        {
            try
            {
                string t45 = Utility.TextParser.ConvertByteArrayToAsciiText(file);
                string[] t5 = Utility.TextParser.ConvertTextToTextArray(t45);
                var dungeonInfoRows = Utility.TextParser.ConvertTextArrayToStructedText(t5, 3, "\t".ToCharArray());
                list = new List<DungeonInfoStruct>(dungeonInfoRows.Count());

                foreach (var item in dungeonInfoRows)
                {
                    list.Add(new DungeonInfoStruct(item));
                }
                Initialized = true;
            }
            catch (System.Exception)
            {
                Initialized = false;
            }

        }

        #endregion Constructors

        #region Properties

        public int Count => list.Count;

        #endregion Properties
    }
}