namespace BinaryFiles.PackFile.Data.Dungeon
{
    public struct DungeonRoomObject
    {
        #region Fields

        /// <summary>
        ///  /// width = aabb[3] - aabb[0], height= aabb[4] - aabb[1], length = aabb[5] - aabb[2]
        /// </summary>
        public float[] AABB;

        /// <summary>
        /// Count of directly-connected objects. Example: 70, 146
        /// </summary>
        public uint connectedObjectCount;

        /// <summary>
        /// List of connected objects. Example: 70, 4, 146, 80
        /// </summary>
        public uint[] ConnectedObjectList;

        public uint entryCounter;
        public DungeonRoomObjectEntry[] entryList;
        public DungeonRoomObjectExtraInformation ExtraA;
        public DungeonRoomObjectExtraInformation ExtraB;
        public byte extraFlagA;
        public byte extraFlagB;

        /// <summary>
        ///  // Used for floorNames
        /// </summary>
        public uint floorIndex;

        /// <summary>
        /// Count of indirectly-connected objects.
        /// </summary>
        public uint indirectConnectedObjectCount;

        /// <summary>
        /// List of indirectly-connected objects. Example: 70, 4, 146, 80
        /// </summary>
        public uint[] IndirectConnectedObjectList;

        public string Name;
        public ushort NameLength;
        public string path;
        public ushort PathLength;
        public float PITCH;
        public uint pointCounter;
        public DungeonRoomObjectPointStruct[] pointList;

        /// <summary>
        /// Used for roomNames
        /// </summary>
        public uint roomIndex;

        /// <summary>
        /// Has been 0 in every file...
        /// </summary>
        public float unk_float0;

        /// <summary>
        /// Seems fixed to -2,848866E+38
        /// </summary>
        public float unk_float12;

        /// <summary>
        /// Seems fixed to -2,288091E+38
        /// </summary>
        public float unk_float13;

        public float unk_float14;
        public float unk_float15;
        public float unk_float16;

        /// <summary>
        /// Has been 0 in every file...
        /// </summary>
        public uint unk_uint0;

        /// <summary>
        /// Either 0 or 1 ?..
        /// </summary>
        public uint unk_uint1;

        public float X;
        public float Y;
        public float YAW;
        public float Z;

        #endregion Fields
    }
}