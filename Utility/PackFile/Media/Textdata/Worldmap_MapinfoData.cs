using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PackFile.Media.Textdata
{
    public abstract class Worldmap_MapinfoData
    {
        #region Fields

        private List<Worldmap_Mapinfo_WorldStruct> WorldInfo;
        private List<Worldmap_Mapinfo_DungeonStruct> DungeonInfo;

        #endregion Fields

        #region Constructors

        protected Worldmap_MapinfoData(byte[] file)
        {
            try
            {
                var lines = Utility.TextParser.ConvertByteArrayToTextArray(file);
                bool isDungeon;
                foreach (var line in lines)
                {
                    var section = Regex.Match(line, "(?<sectionID>section)\\t(?<section>.*)");
                    if (section.Success)
                    {
                        isDungeon = section.Groups["section"].Value == "wlocalmap" ? false : true;
                    }
                    var match = Regex.Match(line, "(?<service>0|1)\\t(?<id>\\d*)\\t(?<path>.*)");
                }
            }
            catch (System.Exception)
            {
                Initialized = false;
            }
        }

        #endregion Constructors

        #region Properties

        internal readonly bool Initialized = true;

        #endregion Properties
    }
}