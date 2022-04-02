using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PackFile.Media.Textdata
{

    public abstract class Worldmap_MapinfoData
    {
        #region Fields
        private readonly WorldMapInfoSection flag;
        private const string WORLDMAP_PATTERN = "(?<MapID>\\d*)\\t(?<Name>\\w+)\\t(?<Layer>\\w)\\t(?<LayerID>\\d*)\\t(?<LayerTotalCount>\\d*)\\t(?<wRegionID>\\d*)\\t(?<Texture_num_x>\\d*)\\t(?<Texture_num_y>\\d*)\\t(?<Draw_x>\\d*)\\t(?<Draw_y>\\d*)\\t";
        private List<Worldmap_Mapinfo_WorldStruct> WorldInfo;
        private List<Worldmap_Mapinfo_DungeonStruct> DungeonInfo;

        public bool TryGetMainWorldInfo(out Worldmap_Mapinfo_WorldStruct world)
        {

            world = new Worldmap_Mapinfo_WorldStruct();
            if (WorldInfo.Exists(w => w.Type.Equals(WorldMapInfoType.WorldMap)))
            {
                world = WorldInfo.Find(w => w.Type.Equals(WorldMapInfoType.WorldMap));
                return true;
            }
            return false;
        }
        /*
          public int MapID;            //2001
        public string Name;        //돈황석굴
        public char Layer;         //F or B
        public int Layers;         // 1
        public int Total_layers;   // 4
        public int Code;           //32769
        public int Texture_num_x;  //3
        public int Texture_num_y;  //3
        public int Draw_x;         //768
        public int Draw_y;         //768
        public int StartRegion_left;       //(start_region  (left: 127   )
        public int StartRegion_top;        //(start_region  ( top: 128    )
        public int StartRegion_right;      //(start_region  (  right: 129)
        public int StartRegion_bottom;     //(start_region  (bottom : 126)
        public string Scale;        //1.0
        public string Map_path;    //interface\worldmap\dungeon\map_world_donf01_  스트링	전체맵버튼타입
        public int RegionID;       // Region ID : 1
        public string number_of_layers_String; //  DH_A01_FLOOR01
        public bool All_Map_Button_Visibilty;         // 0:false, 1:true
        public int MapSize_left;       // MapSize by x && y (left) (Not sure if MapSize)
        public int MapSize_top;       // MapSize by x && y (top) (Not sure if MapSize)
        public int MapSize_right;       // MapSize by x && y (right) (Not sure if MapSize)
        public int MapSize_bottom;
         */
        #endregion Fields

        #region Constructors

        protected Worldmap_MapinfoData(byte[] file)
        {
            try
            {
                var lines = Utility.TextParser.ConvertByteArrayToTextArray(file);
                WorldInfo = new List<Worldmap_Mapinfo_WorldStruct>();
                DungeonInfo = new List<Worldmap_Mapinfo_DungeonStruct>();
                flag = WorldMapInfoSection.None;
                foreach (var line in lines)
                {
                    var section = Regex.Match(line, "(?<sectionID>section)\\t(?<section>\\w+)");
                    if (line.StartsWith("\\") || line.StartsWith("\t") || line.StartsWith("/*") || line.StartsWith("*/"))
                        continue;

                    if (section.Success)
                    {
                        flag = section.Groups["section"].Value.ToLower().Equals("dungeonmap") ? WorldMapInfoSection.Dungeonmap : WorldMapInfoSection.wLocalMap;
                        continue;
                    }
                    var arr = Regex.Split(line, "\t");
                    if (arr.Length < 22)
                        continue;

                    Match match;
                    switch (flag)
                    {
                        case WorldMapInfoSection.None:
                            continue;
                        case WorldMapInfoSection.wLocalMap:
                            match = Regex.Match(line, WORLDMAP_PATTERN);
                            WorldInfo.Add(new Worldmap_Mapinfo_WorldStruct(arr));
                            continue;
                        case WorldMapInfoSection.Dungeonmap:
                            match = Regex.Match(line, "(?<service>0|1)\\t(?<id>\\d*)\\t(?<path>\\w+)\\t(?<path>\\w+)");
                            DungeonInfo.Add(new Worldmap_Mapinfo_DungeonStruct(arr));
                            continue;
                        default:
                            continue;
                    }

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