using System.Collections.Generic;
using System.IO;

namespace BinaryFiles.PackFile.Data.Dungeon
{
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
                FileSize = file.LongLength;
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

                    PointerDungeonBoundingBoxesEnd = reader.BaseStream.Position;
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
        public long FileSize { get; }
        public char[] Header { get => header; set => header = value; }
        public List<ObjLink> LinkConnectedObjectsArray { get => linkConnectedObjectsDic; set => linkConnectedObjectsDic = value; }
        public uint LinkCount { get => linkCounter; }
        public uint ObjectConnectionCount { get => objectConnectionCounter; }
        public List<ObjLink> ObjectConnections { get => objectConnections; set => objectConnections = value; }
        public uint ObjectGroupCount { get => objectGroupCount; }
        public uint PointerDungeonBoundingBoxes { get => pointerDungeonBoundingBoxes; set => pointerDungeonBoundingBoxes = value; }
        public long PointerDungeonBoundingBoxesEnd { get; }
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

        #endregion Properties
    }
}