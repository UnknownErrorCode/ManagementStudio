namespace Structs.Pk2.BinaryFiles.JMXRessource.Dungeon
{
    public struct DungeonRoomObject
    {
        #region Fields

        public ushort NameLength;

        public ushort PathLength;

        public uint pointCounter;

        public DungeonRoomObjectExtraInformation extraA;

        public DungeonRoomObjectExtraInformation extraB;

        /// <summary>
        ///  /// width = aabb[3] - aabb[0], height= aabb[4] - aabb[1], length = aabb[5] - aabb[2]
        /// </summary>
        private float[] aABB;

        /// <summary>
        /// Count of directly-connected objects. Example: 70, 146
        /// </summary>
        private uint connectedObjectCount;

        /// <summary>
        /// List of connected objects. Example: 70, 4, 146, 80
        /// </summary>
        private uint[] connectedObjectList;

        private uint entryCounter;
        private DungeonRoomObjectEntry[] entryList;

        //private DungeonRoomObjectExtraInformation extraA;
        //private DungeonRoomObjectExtraInformation extraB;
        private byte extraFlagA;

        private byte extraFlagB;

        /// <summary>
        ///  // Used for floorNames
        /// </summary>
        private uint floorIndex;

        /// <summary>
        /// Count of indirectly-connected objects.
        /// </summary>
        private uint indirectConnectedObjectCount;

        /// <summary>
        /// List of indirectly-connected objects. Example: 70, 4, 146, 80
        /// </summary>
        private uint[] indirectConnectedObjectList;

        private string name;
        private string path;
        private float pITCH;
        private DungeonRoomObjectPointStruct[] pointList;

        /// <summary>
        /// Used for roomNames
        /// </summary>
        private uint roomIndex;

        /// <summary>
        /// Has been 0 in every file...
        /// </summary>
        private float unk_float0;

        /// <summary>
        /// Seems fixed to -2,848866E+38
        /// </summary>
        private float unk_float12;

        /// <summary>
        /// Seems fixed to -2,288091E+38
        /// </summary>
        private float unk_float13;

        private float unk_float14;
        private float unk_float15;
        private float unk_float16;

        /// <summary>
        /// Has been 0 in every file...
        /// </summary>
        private uint unk_uint0;

        /// <summary>
        /// Either 0 or 1 ?..
        /// </summary>
        private uint unk_uint1;

        private float x;
        private float y;
        private float yAW;
        private float z;

        #endregion Fields

        #region Properties

        public float[] AABB { get => aABB; set => aABB = value; }
        public uint ConnectedObjectCount { get => connectedObjectCount; set => connectedObjectCount = value; }
        public uint[] ConnectedObjectList { get => connectedObjectList; set => connectedObjectList = value; }
        public uint EntryCounter { get => entryCounter; set => entryCounter = value; }
        public DungeonRoomObjectEntry[] EntryList { get => entryList; set => entryList = value; }
        public byte ExtraFlagA { get => extraFlagA; set => extraFlagA = value; }
        public byte ExtraFlagB { get => extraFlagB; set => extraFlagB = value; }
        public uint FloorIndex { get => floorIndex; set => floorIndex = value; }
        public uint IndirectConnectedObjectCount { get => indirectConnectedObjectCount; set => indirectConnectedObjectCount = value; }
        public uint[] IndirectConnectedObjectList { get => indirectConnectedObjectList; set => indirectConnectedObjectList = value; }
        public string Name { get => name; set => name = value; }
        public string Path { get => path; set => path = value; }
        public float PITCH { get => pITCH; set => pITCH = value; }
        public DungeonRoomObjectPointStruct[] PointList { get => pointList; set => pointList = value; }
        public uint RoomIndex { get => roomIndex; set => roomIndex = value; }
        public float Unk_float0 { get => unk_float0; set => unk_float0 = value; }
        public float Unk_float12 { get => unk_float12; set => unk_float12 = value; }
        public float Unk_float13 { get => unk_float13; set => unk_float13 = value; }
        public float Unk_float14 { get => unk_float14; set => unk_float14 = value; }
        public float Unk_float15 { get => unk_float15; set => unk_float15 = value; }
        public float Unk_float16 { get => unk_float16; set => unk_float16 = value; }
        public uint Unk_uint0 { get => unk_uint0; set => unk_uint0 = value; }
        public uint Unk_uint1 { get => unk_uint1; set => unk_uint1 = value; }
        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float YAW { get => yAW; set => yAW = value; }
        public float Z { get => z; set => z = value; }
        public DungeonRoomObjectExtraInformation ExtraA { get => extraA; set => extraA = value; }
        public DungeonRoomObjectExtraInformation ExtraB { get => extraB; set => extraB = value; }

        #endregion Properties
    }
}