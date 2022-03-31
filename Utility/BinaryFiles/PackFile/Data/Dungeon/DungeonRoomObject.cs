namespace BinaryFiles.PackFile.Data.Dungeon
{
    internal struct DungeonRoomObject
    {
        #region Fields

        /// <summary>
        /// width = aabb[3] - aabb[0], height= aabb[4] - aabb[1], length = aabb[5] - aabb[2]
        /// </summary>
        private float[] AABB;

        /// <summary>
        /// Count of directly-connected objects. Example: 70, 146
        /// </summary>
        private uint connectedObjectCount;

        /// <summary>
        /// List of connected objects. Example: 70, 4, 146, 80
        /// </summary>
        private uint[] ConnectedObjectList;

        private uint entryCounter;
        private DungeonRoomObjectEntry[] entryList;
        private DungeonRoomObjectExtraInformation ExtraA;
        private DungeonRoomObjectExtraInformation ExtraB;
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
        private uint[] IndirectConnectedObjectList;

        private string Name;
        private ushort NameLength;
        private string Path;
        private ushort PathLength;
        private float PITCH;
        private uint pointCounter;
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

        private float X;
        private float Y;
        private float YAW;
        private float Z;

        #endregion Fields
    }

    internal struct DungeonRoomObjectEntry
    {
        #region Fields

        /// <summary>
        /// I've seen this as
        /// <br> 0x00 = Flames (Torch, Lamps, ect..) </br>
        /// <br> 0x02 = Stones (impassable)</br>
        /// <br> 0x04 =  Water </br>
        /// </summary>
        private uint extraFlag;

        private uint ID;
        private string Name;
        private ushort NameLength;
        private string Path;
        private ushort PathLength;
        private float Pitch;
        private float Roll;
        private float ScaleHeight;
        private float ScaleLength;
        private float ScaleWidth;

        /// <summary>
        /// <br>1962.75232 for out_obj_stone</br>
        /// <br>902.9495 for out_obj_door</br>
        /// <br>-3.18711172E+38 and similar for water</br>
        /// </summary>
        private float unk_float0;

        private uint waterExta;
        private float X;
        private float Y;
        private float Yaw;
        private float Z;

        #endregion Fields
    }

    internal struct DungeonRoomObjectExtraInformation
    {
        #region Fields

        public float unk_float0;
        public float unk_float1;
        public float unk_float2;
        public float unk_float3;
        public float unk_float4;
        public float unk_float5;
        public float unk_float6;

        #endregion Fields
    }

    internal struct DungeonRoomObjectGroop
    {
        #region Fields

        /// <summary>
        /// service?
        /// </summary>
        private uint Flag;

        private string Name;
        private uint[] ObjIndexArray;

        #endregion Fields
    }

    internal struct DungeonRoomObjectLink
    {
        #region Fields

        private uint connectionCount;
        private uint[] connectionList;
        private uint ID;

        #endregion Fields
    }

    internal struct DungeonRoomObjectPointStruct
    {
        #region Fields

        /// <summary>
        /// also Roll ?
        /// </summary>
        private float float09;

        /// <summary>
        /// also Yaw ??
        /// </summary>
        private float float10;

        /// <summary>
        /// also Pitch ?
        /// </summary>
        private float float11;

        private float float12;
        private float float13;
        private float float14;
        private float Height;
        private float Length;
        private string Name;
        private ushort NameLength;
        private float Pitch;
        private float Roll;
        private float Width;
        private float X;
        private float Y;
        private float Yaw;
        private float Z;

        #endregion Fields
    }
}