using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BinaryFiles.PackFile.Data.Dungeon
{
    public struct ObjLink
    {
        #region Constructors

        public ObjLink(uint id, uint[] links)
        {
            LinkID = id;
            Links = links.ToList();
        }

        #endregion Constructors

        #region Properties

        public int LinkCount { get => Links.Count; }
        public uint LinkID { get; set; }
        public List<uint> Links { get; set; }

        #endregion Properties
    }

    public class DungeonFile
    {
        #region Fields

        private readonly ushort dungeonNameLength;
        private float[] dungeon_AABB;

        // width = AABB[3] - AABB[0], height = AABB[4] - AABB[1], length = AABB[5] - AABB[2]
        private float[] dungeon_OOBB;

        private string dungeonName;
        private char[] header;
        private List<ObjLink> linkConnectedObjectsDic;
        private uint linkCounter;
        private uint objectConnectionCounter;
        private List<ObjLink> objectConnections;
        private uint objectGroupCount;
        private List<DungeonRoomObjectGroop> objGroupArray;
        private uint pointerDungeonBoundingBoxes;
        private uint pointerIndexNames;
        private uint pointerLinks;
        private uint pointerObjectConnections;
        private uint pointerObjectGroups;
        private uint pointerRoomObjects;
        private uint pointerUnk5;
        private uint pointerUnk6;
        private ushort regionID;
        private uint roomCounter;
        private uint roomFloorCounter;
        private string[] roomFloorNames;
        private string[] roomNames;
        private List<DungeonRoomObject> roomObjArray;
        private uint roomObjectCount;
        private uint unk_uint0;
        private uint unk_uint1;
        private uint unk_uint2;
        private uint unk_uint3;
        private uint unk_uint4;
        // width = OOBB[3] - OOBB[0], height = OOBB[4] - OOBB[1], length = OOBB[5] - OOBB[2]

        /// <summary>
        /// 256*256 = 65536
        /// </summary>
        private ushort unk_ushort0;

        private ushort unk_ushort1;

        #endregion Fields

        #region Constructors

        public DungeonFile(byte[] file)
        {
            try
            {
                using (var reader = new BinaryReader(new MemoryStream(file)))
                {
                    header = reader.ReadChars(12);
                    pointerRoomObjects = reader.ReadUInt32();
                    pointerObjectConnections = reader.ReadUInt32();
                    pointerLinks = reader.ReadUInt32();
                    pointerObjectGroups = reader.ReadUInt32();
                    pointerIndexNames = reader.ReadUInt32();
                    pointerUnk5 = reader.ReadUInt32();
                    pointerUnk6 = reader.ReadUInt32();
                    pointerDungeonBoundingBoxes = reader.ReadUInt32();
                    unk_ushort0 = reader.ReadUInt16();
                    unk_ushort1 = reader.ReadUInt16();
                    var NameLength = reader.ReadUInt32();
                    dungeonNameLength = (ushort)NameLength;
                    dungeonName = new string(reader.ReadChars(dungeonNameLength));
                    unk_uint0 = reader.ReadUInt32();
                    unk_uint1 = reader.ReadUInt32();
                    regionID = reader.ReadUInt16();

                    reader.BaseStream.Position = pointerDungeonBoundingBoxes;
                    dungeon_AABB = new float[6] { reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle() };
                    dungeon_OOBB = new float[6] { reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle() };

                    reader.BaseStream.Position = pointerLinks;

                    unk_uint2 = reader.ReadUInt32();
                    unk_uint3 = reader.ReadUInt32();
                    unk_uint4 = reader.ReadUInt32();
                    linkCounter = reader.ReadUInt32();
                    linkConnectedObjectsDic = new List<ObjLink>((int)linkCounter);
                    for (int i = 0; i < linkCounter; i++)
                    {
                        var link = reader.ReadUInt32();
                        var linkConCount = reader.ReadUInt32();
                        var arr = new uint[linkConCount];

                        for (int i2 = 0; i2 < linkConCount; i2++)
                        {
                            arr[i2] = reader.ReadUInt32();
                        }
                        linkConnectedObjectsDic.Add(new ObjLink(link, arr));
                    }
                    PointerLinksEnd = reader.BaseStream.Position;
                    PointerLinksLength = reader.BaseStream.Position - pointerLinks;
                    reader.BaseStream.Position = pointerIndexNames;

                    roomCounter = reader.ReadUInt32();
                    roomNames = new string[roomCounter];
                    for (int roomIndex = 0; roomIndex < roomCounter; roomIndex++)
                    {
                        roomNames[roomIndex] = new string(reader.ReadChars(reader.ReadInt32()));
                    }

                    roomFloorCounter = reader.ReadUInt32();
                    roomFloorNames = new string[roomCounter];
                    for (int floorIndex = 0; floorIndex < roomFloorCounter; floorIndex++)
                    {
                        roomFloorNames[floorIndex] = new string(reader.ReadChars(reader.ReadInt32()));
                    }
                    PointerIndexNamesEnd = reader.BaseStream.Position;
                    PointerIndexNamesLength = reader.BaseStream.Position - pointerIndexNames;

                    reader.BaseStream.Position = pointerObjectConnections;
                    objectConnectionCounter = reader.ReadUInt32();
                    objectConnections = new List<ObjLink>((int)objectConnectionCounter);

                    for (int i = 0; i < objectConnectionCounter; i++)
                    {
                        var objConCount = reader.ReadUInt32();
                        var arr = new uint[objConCount];

                        for (int i2 = 0; i2 < objConCount; i2++)
                        {
                            arr[i2] = reader.ReadUInt32();
                        }
                        objectConnections.Add(new ObjLink((uint)i, arr));
                    }
                    PointerObjectConnectionsEnd = reader.BaseStream.Position;
                    PointerObjectConnectionsLength = reader.BaseStream.Position - pointerObjectConnections;

                    reader.BaseStream.Position = pointerRoomObjects;
                    roomObjectCount = reader.ReadUInt32();
                    roomObjArray = new List<DungeonRoomObject>((int)roomObjectCount);
                    for (int i = 0; i < roomObjectCount; i++)
                    {
                        DungeonRoomObject obj = new DungeonRoomObject()
                        {
                            ExtraA = new DungeonRoomObjectExtraInformation() { },
                            ExtraB = new DungeonRoomObjectExtraInformation() { },
                            path = new string(reader.ReadChars(reader.ReadInt32())),
                            Name = new string(reader.ReadChars(reader.ReadInt32())),
                            unk_float0 = reader.ReadSingle(),
                            X = reader.ReadSingle(),
                            Z = reader.ReadSingle(),
                            Y = reader.ReadSingle(),
                            YAW = reader.ReadSingle(),
                            PITCH = reader.ReadSingle(),
                            AABB = new float[6] { reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle() },
                            unk_float12 = reader.ReadSingle(),
                            unk_float13 = reader.ReadSingle(),
                            unk_float14 = reader.ReadSingle(),
                            unk_float15 = reader.ReadSingle(),
                            unk_float16 = reader.ReadSingle(),
                            extraFlagA = reader.ReadByte()
                        };
                        if (obj.extraFlagA == 0x01)
                        {
                            obj.ExtraA.unk_float0 = reader.ReadSingle();
                            obj.ExtraA.unk_float1 = reader.ReadSingle();
                            obj.ExtraA.unk_float2 = reader.ReadSingle();
                            obj.ExtraA.unk_float3 = reader.ReadSingle();
                        }
                        obj.extraFlagB = reader.ReadByte();
                        if (obj.extraFlagB == 0x02)
                        {
                            obj.ExtraB.unk_float0 = reader.ReadSingle();
                            obj.ExtraB.unk_float1 = reader.ReadSingle();
                            obj.ExtraB.unk_float2 = reader.ReadSingle();
                            obj.ExtraB.unk_float3 = reader.ReadSingle();
                            obj.ExtraB.unk_float4 = reader.ReadSingle();
                            obj.ExtraB.unk_float5 = reader.ReadSingle();
                            obj.ExtraB.unk_float6 = reader.ReadSingle();
                        }
                        obj.unk_uint0 = reader.ReadUInt32();
                        obj.roomIndex = reader.ReadUInt32();
                        obj.floorIndex = reader.ReadUInt32();
                        obj.connectedObjectCount = reader.ReadUInt32();
                        obj.ConnectedObjectList = new uint[obj.connectedObjectCount];
                        for (int objconindex = 0; objconindex < obj.connectedObjectCount; objconindex++)
                        {
                            obj.ConnectedObjectList[objconindex] = reader.ReadUInt32();
                        }

                        obj.indirectConnectedObjectCount = reader.ReadUInt32();
                        obj.IndirectConnectedObjectList = new uint[obj.indirectConnectedObjectCount];
                        for (int objconindex = 0; objconindex < obj.indirectConnectedObjectCount; objconindex++)
                        {
                            obj.IndirectConnectedObjectList[objconindex] = reader.ReadUInt32();
                        }

                        obj.entryCounter = reader.ReadUInt32();
                        obj.unk_uint1 = reader.ReadUInt32();

                        obj.entryList = new DungeonRoomObjectEntry[obj.entryCounter];
                        for (int ei = 0; ei < obj.entryCounter; ei++)
                        {
                            var robj = new DungeonRoomObjectEntry()
                            {
                                Name = new string(reader.ReadChars(reader.ReadInt32())),
                                EPath = new string(reader.ReadChars(reader.ReadInt32())),
                                X = reader.ReadSingle(),
                                Z = reader.ReadSingle(),
                                Y = reader.ReadSingle(),
                                Roll = reader.ReadSingle(),
                                Yaw = reader.ReadSingle(),
                                Pitch = reader.ReadSingle(),
                                ScaleWidth = reader.ReadSingle(),
                                ScaleHeight = reader.ReadSingle(),
                                ScaleLength = reader.ReadSingle(),
                                extraFlag = reader.ReadUInt32(),
                            };
                            if (robj.extraFlag == 0x04)
                            {
                                robj.waterExta = reader.ReadUInt32();
                            }
                            robj.ID = reader.ReadUInt32();
                            robj.unk_float0 = reader.ReadSingle();

                            obj.entryList[ei] = robj;
                        }

                        obj.pointCounter = reader.ReadUInt32();
                        obj.pointList = new DungeonRoomObjectPointStruct[obj.pointCounter];
                        for (int pi = 0; pi < obj.pointCounter; pi++)
                        {
                            var dpoint = new DungeonRoomObjectPointStruct()
                            {
                                Name = new string(reader.ReadChars(reader.ReadInt32())),
                                X = reader.ReadSingle(),
                                Z = reader.ReadSingle(),
                                Y = reader.ReadSingle(),
                                Roll = reader.ReadSingle(),
                                Yaw = reader.ReadSingle(),
                                Pitch = reader.ReadSingle(),
                                Width = reader.ReadSingle(),
                                Height = reader.ReadSingle(),
                                Length = reader.ReadSingle(),
                                float09 = reader.ReadSingle(),
                                float10 = reader.ReadSingle(),
                                float11 = reader.ReadSingle(),
                                float12 = reader.ReadSingle(),
                                float13 = reader.ReadSingle(),
                                float14 = reader.ReadSingle(),
                            };
                            obj.pointList[pi] = dpoint;
                        }

                        roomObjArray.Add(obj);
                    }

                    PointerRoomObjectsLength = reader.BaseStream.Position - pointerRoomObjects;
                    PointerRoomObjectsEnd = reader.BaseStream.Position;

                    reader.BaseStream.Position = pointerObjectGroups;
                    objectGroupCount = reader.ReadUInt32();
                    objGroupArray = new List<DungeonRoomObjectGroop>((int)objectGroupCount);
                    for (int gobjIndex = 0; gobjIndex < objectGroupCount; gobjIndex++)
                    {
                        var gobj = new DungeonRoomObjectGroop()
                        {
                            Name = new string(reader.ReadChars(reader.ReadInt32())),
                            Flag = reader.ReadUInt32(),
                            ObjArrayCount = reader.ReadUInt32()
                        };
                        gobj.ObjIndexArray = new uint[gobj.ObjArrayCount];
                        for (int objInGroup = 0; objInGroup < gobj.ObjArrayCount; objInGroup++)
                        {
                            gobj.ObjIndexArray[objInGroup] = reader.ReadUInt32();
                        }
                    }
                    PointerObjectGroupsLength = reader.BaseStream.Position - pointerObjectGroups;
                    PointerObjectGroupsEnd = reader.BaseStream.Position;
                }
            }
            catch (System.Exception e)
            {
            }
        }

        #endregion Constructors

        #region Properties

        public float[] Dungeon_AABB { get => dungeon_AABB; set => dungeon_AABB = value; }
        public float[] Dungeon_OOBB { get => dungeon_OOBB; set => dungeon_OOBB = value; }
        public string DungeonName { get => dungeonName; set => dungeonName = value; }

        public ushort DungeonNameLength => dungeonNameLength;

        public char[] Header { get => header; set => header = value; }
        public List<ObjLink> LinkConnectedObjectsArray { get => linkConnectedObjectsDic; set => linkConnectedObjectsDic = value; }
        public uint LinkCount { get => linkCounter; }
        public uint ObjectConnectionCount { get => objectConnectionCounter; }
        public List<ObjLink> ObjectConnections { get => objectConnections; set => objectConnections = value; }
        public uint ObjectGroupCount { get => objectGroupCount; }

        // public List<DungeonRoomObjectGroop> ObjGroupArray { get => objGroupArray.ToList(); set => objGroupArray = value.ToArray(); }
        public uint PointerDungeonBoundingBoxes { get => pointerDungeonBoundingBoxes; set => pointerDungeonBoundingBoxes = value; }

        public uint PointerIndexNames { get => pointerIndexNames; set => pointerIndexNames = value; }
        public long PointerIndexNamesEnd { get; }
        public long PointerIndexNamesLength { get; }
        public uint PointerLinks { get => pointerLinks; set => pointerLinks = value; }
        public long PointerLinksEnd { get; }
        public long PointerLinksLength { get; }
        public uint PointerObjectConnections { get => pointerObjectConnections; set => pointerObjectConnections = value; }
        public long PointerObjectConnectionsEnd { get; }
        public long PointerObjectConnectionsLength { get; }
        public uint PointerObjectGroups { get => pointerObjectGroups; set => pointerObjectGroups = value; }
        public long PointerObjectGroupsEnd { get; }
        public long PointerObjectGroupsLength { get; }
        public uint PointerRoomObjects { get => pointerRoomObjects; set => pointerRoomObjects = value; }
        public long PointerRoomObjectsEnd { get; }
        public long PointerRoomObjectsLength { get; }
        public uint PointerUnk5 { get => pointerUnk5; set => pointerUnk5 = value; }
        public uint PointerUnk6 { get => pointerUnk6; set => pointerUnk6 = value; }
        public ushort RegionID { get => regionID; set => regionID = value; }
        public uint RoomCount { get => roomCounter; }
        public uint RoomFloorCount { get => roomFloorCounter; }
        public string[] RoomFloorNames { get => roomFloorNames; set => roomFloorNames = value; }
        public string[] RoomNames { get => roomNames; set => roomNames = value; }
        public List<DungeonRoomObject> RoomObjArray { get => roomObjArray; set => roomObjArray = value; }
        public uint RoomObjectCount { get => roomObjectCount; set => roomObjectCount = value; }
        public uint Unk_uint0 { get => unk_uint0; set => unk_uint0 = value; }
        public uint Unk_uint1 { get => unk_uint1; set => unk_uint1 = value; }
        public uint Unk_uint2 { get => unk_uint2; set => unk_uint2 = value; }
        public uint Unk_uint3 { get => unk_uint3; set => unk_uint3 = value; }
        public uint Unk_uint4 { get => unk_uint4; set => unk_uint4 = value; }
        public ushort Unk_ushort0 { get => unk_ushort0; set => unk_ushort0 = value; }
        public ushort Unk_ushort1 { get => unk_ushort1; set => unk_ushort1 = value; }
        public long PointerDungeonBoundingBoxesEnd { get; }

        #endregion Properties
    }
}

/*

12  byte[]  Header                                         //JMXVDOF 0101 supported only
4   uint    pointerRoomObjects
4   uint    pointerObjectConnections
4   uint    pointerLinks
4   uint    pointerObjectGroups
4   uint    pointerIndexNames
4   uint    pointerUnk5                                    // Has been 0 in every file...
4   uint    pointerUnk6                                    // Has been 0 in every file...
4   uint    pointerDungeonBoundingBoxes
2   ushort  unk_ushort0                                    // Has been 0xFFFF in every file...
2   ushort  unk_ushort1                                    // Has been 0x0400 in every file...
2   ushort  dungeonNameLength
*   string  dungeonName                                    // Has been "Noname" in every file... -> used as projectName in MapEditor.
4   uint    unk_uint0                                      // Has been 0xFFFFFFFF in every file...
4   uint    unk_uint1                                      // Has been 0xFFFFFFFF in every file...
2   ushort  regionID                                       // Used in packets and database for whole Dungeon. Used in minimap_d as center- or origin-region (stores _default_).

//pointerDungeonBoundingBoxes will get you here
24  float[]  dungeon_AABB                                  // width = AABB[3] - AABB[0], height = AABB[4] - AABB[1], length = AABB[5] - AABB[2]
24  float[]  dungeon_OOBB                                  // width = OOBB[3] - OOBB[0], height = OOBB[4] - OOBB[1], length = OOBB[5] - OOBB[2]

//pointerRoomObjects will get you here
4   uint    roomObjectCounter
for (int roomObjectIndex = 0; roomObjectIndex < roomObjectCounter; roomObjectIndex++)
{
    2   ushort  roomObject.PathLength
    *   string  roomObject.Path

    2   ushort  roomObject.NameLength
    *   string  roomObject.Name

    4   float   roomObject.unk_floot0                      // Has been 0 in every file...
    4   float   roomObject.X
    4   float   roomObject.Z
    4   float   roomObject.Y
    4   float   roomObject.YAW                             // Google it... and use this: 57.2957795 for calculation
    4   float   roomObject.PITCH                           // Google it... and don't ask for missing roll, this is no flight simulator...
    24  float[] roomObject.AABB                            // width = aabb[3] - aabb[0], height= aabb[4] - aabb[1], length = aabb[5] - aabb[2]
    4   float   roomObject.unk_float12                     // Seems fixed to -2,848866E+38
    4   float   roomObject.unk_float13                     // Seems fixed to -2,288091E+38
    4   float   roomObject.unk_float14                     // Example: -150
    4   float   roomObject.unk_float15                     // Example: 1456
    4   float   roomObject.unk_float16                     // Example: 0,001

    1   byte    roomObject.extraFlagA
    if(roomObject.extraFlagA == 0x01)
    {
        4   float   roomObject.ExtraA.unk_float0           // Example: 750
        4   float   roomObject.ExtraA.unk_float1           // Example: 680
        4   float   roomObject.ExtraA.unk_float2           // Example: 50
        4   float   roomObject.ExtraA.unk_float3           // Example: 0,08
    }

    1   byte roomObject.extraFlagB
    if(roomObject.extraFlagB == 0x02)
    {
        4   float   roomObject.ExtraB.unk_float0           // Example: 0,1871207
        4   float   roomObject.ExtraB.unk_float1           // Example: 0
        4   float   roomObject.ExtraB.unk_float2           // Example: -0,8803339
        4   float   roomObject.ExtraB.unk_float3           // Example: 0
        4   float   roomObject.ExtraB.unk_float4           // Example: 2,932153
        4   float   roomObject.ExtraB.unk_float5           // Example: 0
        4   float   roomObject.ExtraB.unk_float6           // Example: 3,503246E-42
    }

    4   uint    roomObject.unk_uint0                       // Has been 0 in every file...
    4   uint    roomObject.roomIndex                       // Used for roomNames
    4   uint    roomObject.floorIndex                      // Used for floorNames

    4   uint    roomObject.connectedObjectCount            //List of directly-connected objects. Example: 70, 146
    for (int i = 0; i < roomObject.connectedObjectCount; i++)
    {
        4   uint    objectIndex
    }

    4   uint    roomObject.indirectConnectedObjectCount    //List of indirectly-connected objects. Example: 70, 4, 146, 80
        for (int i = 0; i < roomObject.indirectConnectedObjectCount; i++)
    {
        4   uint    objectIndex
    }

    4   uint    roomObject.entryCounter
    4   uint    roomObject.unk_uint1                        //Either 0 or 1
    for (int entryIndex = 0; entryIndex < roomObject.entryCounter; entryIndex++)
    {
        //Contains Flames, Stones, Jewelry, Water, and other stuff...
        2   ushort  entry.NameLength
        *   string  entry.Name

        2   ushort  entry.PathLength
        *   string  entry.Path

        4   float   entry.X
        4   float   entry.Z
        4   float   entry.Y

        4   float   entry.Roll
        4   float   entry.Yaw
        4   float   entry.Pitch

        4   float   entry.ScaleWidth
        4   float   entry.ScaleHeight
        4   float   entry.ScaleLength

        4   uint    entry.extraFlag                        // I've seen this as 0x00 for Flames (Torch & Lamps), 0x02 for Stones (impassable), 0x04 for Water
        if(entry.extraFlag == 0x04) //Water...
        {
            4   uint    waterExta
        }

        4   uint    entry.ID
        4   float   entry.unk_float0
        //1962.75232 for out_obj_stone
        //902.9495 for out_obj_door
        //-3.18711172E+38 and similar for water
    }

    4   uint    roomObject.pointCounter
    for (int pointIndex = 0; pointIndex < roomObject.pointCounter; pointIndex++)
    {
        2   ushort  point.NameLength
        *   string  point.Name

        4   float   point.X
        4   float   point.Z
        4   float   point.Y

        4   float   point.Roll
        4   float   point.Yaw
        4   float   point.Pitch

        4   float   point.Width
        4   float   point.Height
        4   float   point.Length

        4   float   point.float09                          // also Roll
        4   float   point.float10                          // also Yaw
        4   float   point.float11                          // also Pitch
        4   float   point.float12                          // Example: 0,8
        4   float   point.float13                          // Example: 0,007
        4   float   point.float14                          // Example: 3E-05
    }
}

//pointerLinks will get you here
4   uint    unk_uint2
4   uint    unk_uint3
4   uint    unk_uint4
4   uint    linkCounter
for (int linkIndex = 0; linkIndex < linkCounter; linkIndex++)
{
    4   uint    link.ID
    4   uint    link.connectionCount
    for (int i = 0; i < link.connectionCount; i++)
    {
        4   uint    objectIndex
    }
}

//pointerObjectConnections will get you here
4   uint    objectConnectionCounter                        //Always equal to roomObjectCounter?
for (int objectIndex = 0; objectIndex < objectConnectionCounter; objectIndex++)
{
    4   uint    connectedObjectCount
    for (int i = 0; i < connectedObjectCount; i++)
    {
        4   uint    connectedObjectIndex
    }
}

//pointerIndexNames will get you here
4   uint    roomCounter
for (int roomIndex = 0; roomIndex < roomCounter; roomIndex++)
{
    //Some of them might be empty but thats no problem...
    2   ushort  roomNameLength
    *   string  roomName
}
4   uint    floorCounter
for (int floorIndex = 0; floorIndex < roomCounter; floorIndex++)
{
    //Some of them might be empty but thats no problem...
    2   ushort  floorNameLength
    *   string  floorName
}

//pointerObjectGroups
4   uint    objectGroupCounter
for (int i = 0; i < objectGroupCounter; i++)
{
    2   ushort  group.NameLength
    *   string  group.Name
    4   uint    group.Flag                                 //0 or 1 -> Service?
    4   uint    group.objectCount
    for (int ii = 0; ii < group.objectCount; ii++)
    {
        4   uint    objectIndex
    }
}
//EOF

 */