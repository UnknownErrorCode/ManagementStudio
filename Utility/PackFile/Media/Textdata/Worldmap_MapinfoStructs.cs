namespace PackFile.Media.Textdata
{
    /// <summary>
    /// Type 0:Wmap, 1:Local
    /// </summary>
    public enum WorldMapType : byte
    {
        WorldMap = 0x00,
        LocalMap = 0x01
    }

    public struct Worldmap_Mapinfo_DungeonStruct
    {
        #region Fields

        //Map ID	Name	layer	layers	total layers	code	texture num x	texture num y	draw x	draw y	start region				    Scale	    map path	                              Region ID	     the number of layers	            All_Map_Button_type	                 Left	Top	    Right	    Bottom
        //					TextZoneName.txt에 있는 지역 코드와 이름	x 텍스쳐 개수	y 텍스쳐 개수	그려질 크기 x	그려질 크기 y	left(X)	top(Y)	right(X)	bottom(Y)	1.0 = 256	Texture path (path under media folder)			                       (1:Visible, 0:invisible)
        //2001	돈황석굴    	F	    1	        4	        32769	    3	            3	          768	 768	    127	    128	129	126	        1.0 	interface\worldmap\dungeon\map_world_donf01_	1 	             DH_A01_FLOOR01	                    1	                               0	0	0	0
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

        #endregion Fields

        // MapSize by x && y (bottom) (Not sure if MapSize)

        #region Constructors

        public Worldmap_Mapinfo_DungeonStruct(string[] data)
        {
            MapID = int.Parse(data[0]);
            Name = data[1];
            Layer = System.Convert.ToChar(data[2]);
            Layers = int.Parse(data[3]);
            Total_layers = int.Parse(data[4]);
            Code = int.Parse(data[5]);
            Texture_num_x = int.Parse(data[6]);
            Texture_num_y = int.Parse(data[7]);
            Draw_x = int.Parse(data[8]);
            Draw_y = int.Parse(data[9]);
            StartRegion_left = int.Parse(data[10]);
            StartRegion_top = int.Parse(data[11]);
            StartRegion_right = int.Parse(data[12]);
            StartRegion_bottom = int.Parse(data[13]);
            Scale = data[14];
            Map_path = data[15];
            RegionID = int.Parse(data[16]);
            number_of_layers_String = data[17];
            All_Map_Button_Visibilty = data[18].Equals("1");
            MapSize_left = int.Parse(data[19]);
            MapSize_top = int.Parse(data[20]);
            MapSize_right = int.Parse(data[21]);
            MapSize_bottom = int.Parse(data[22]);
        }
    }

    #endregion Constructors

    #region Structs

    public struct Worldmap_Mapinfo_WorldStruct
    {
        #region Fields

        ///Map ID	Type 0:Wmap, 1:Local	//Name(Skip)
        ///Addr	Texture Size_x	Texture Size_y	Pic Area_x	Pic Area_y	Draw x	Draw y	리젼 left	top	right	bottom	좌표 LT _ x	좌표 LT _y	좌표 RB_x	좌표 RB_y	요새월드ID	로컬 이름 스트링 코드	전체맵버튼타입(1:보임,0:안보임)	한 리젼 크기
        public int MapID;

        public WorldMapType Type;
        public string Name;
        public string Path;
        public int Size_x;
        public int Size_y;
        public int Area_x;
        public int Area_y;
        public int TotalSize_x;
        public int TotalSize_y;
        public int left;
        public int top;
        public int right;
        public int bottom;
        public int LT_x;
        public int LT_y;
        public int RB_x;
        public int RB_y;
        public string FortressWorldID;
        public string LOCALNAME;
        public bool buttontype;
        public string regionsize;

        #endregion Fields

        #region Constructors

        public Worldmap_Mapinfo_WorldStruct(string[] data)
        {
            MapID = int.Parse(data[0]);
            Type = data[1].Equals("0") ? WorldMapType.WorldMap : WorldMapType.LocalMap;
            Name = data[2];
            Path = data[3];
            Size_x = int.Parse(data[4]);
            Size_y = int.Parse(data[5]);
            Area_x = int.Parse(data[6]);
            Area_y = int.Parse(data[7]);
            TotalSize_x = int.Parse(data[8]);
            TotalSize_y = int.Parse(data[9]);
            left = int.Parse(data[10]);
            top = int.Parse(data[11]);
            right = int.Parse(data[12]);
            bottom = int.Parse(data[13]);
            LT_x = int.Parse(data[14]);
            LT_y = int.Parse(data[15]);
            RB_x = int.Parse(data[16]);
            RB_y = int.Parse(data[17]);
            FortressWorldID = data[18];
            LOCALNAME = data[19];
            buttontype = data[20].Equals("1");
            regionsize = data[21];
        }

        #endregion Constructors
    }

    #endregion Structs
}