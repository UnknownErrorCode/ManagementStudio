namespace BinaryFiles.PackFile.Data.Dungeon
{
    public struct DungeonRoomObject
    {
        #region Fields
        /// width = aabb[3] - aabb[0], height= aabb[4] - aabb[1], length = aabb[5] - aabb[2]

        /// <summary>
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

    public struct DungeonRoomObjectEntry
    {
        #region Fields

        public string EPath;

        /// <summary>
        /// no byte??
        /// <br> 0x00 = Flames (Torch, Lamps, ect..) </br>
        /// <br> 0x02 = Stones (impassable)</br>
        /// <br> 0x04 =  Water </br>
        /// </summary>
        public uint extraFlag;

        public uint ID;
        public string Name;
        public ushort NameLength;
        public ushort PathLength;
        public float Pitch;
        public float Roll;
        public float ScaleHeight;
        public float ScaleLength;
        public float ScaleWidth;

        /// <summary>
        /// <br>1962.75232 for out_obj_stone</br>
        /// <br>902.9495 for out_obj_door</br>
        /// <br>-3.18711172E+38 and similar for water</br>
        /// </summary>
        public float unk_float0;

        public uint waterExta;
        public float X;
        public float Y;
        public float Yaw;
        public float Z;

        #endregion Fields
    }

    public struct DungeonRoomObjectExtraInformation
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

    public struct DungeonRoomObjectGroop
    {
        #region Fields

        /// <summary>
        /// service?
        /// </summary>
        public uint Flag;

        public string Name;
        public uint[] ObjIndexArray;
        public uint ObjArrayCount;

        #endregion Fields
    }

    public struct DungeonRoomObjectLink
    {
        #region Fields

        public uint connectionCount;
        public uint[] connectionList;
        public uint ID;

        #endregion Fields
    }

    public struct DungeonRoomObjectPointStruct
    {
        #region Fields

        /// <summary>
        /// also Roll ?
        /// </summary>
        public float float09;

        /// <summary>
        /// also Yaw ??
        /// </summary>
        public float float10;

        /// <summary>
        /// also Pitch ?
        /// </summary>
        public float float11;

        public float float12;
        public float float13;
        public float float14;
        public float Height;
        public float Length;
        public string Name;
        public ushort NameLength;
        public float Pitch;
        public float Roll;
        public float Width;
        public float X;
        public float Y;
        public float Yaw;
        public float Z;

        #endregion Fields
    }
}