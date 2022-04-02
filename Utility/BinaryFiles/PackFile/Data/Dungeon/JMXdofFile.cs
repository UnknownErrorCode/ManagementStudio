using Structs.Pk2.BinaryFiles.JMXRessource;
using Structs.Pk2.BinaryFiles.JMXRessource.Dungeon;
using System.Collections.Generic;
using System.IO;

namespace BinaryFiles.PackFile.Data.Dungeon
{
    public class JMXdofFile
    {
        #region Fields


        /// <summary>
        /// <br>Fixed Array size of 6 floats.</br>
        /// <br>6x4 = 24 bytes.</br>
        /// width = AABB[3] - AABB[0], height = AABB[4] - AABB[1], length = AABB[5] - AABB[2]
        /// </summary>
        private float[] dungeon_AABB;

        /// <summary>
        /// <br>Fixed Array size of 6 floats.</br>
        /// <br>6x4 = 24 bytes.</br>
        /// // width = OOBB[3] - OOBB[0], height = OOBB[4] - OOBB[1], length = OOBB[5] - OOBB[2]
        /// </summary>
        private float[] dungeon_OOBB;

        private char[] header;
        private uint pointerBlocks;
        private uint pointerBlockLinks;
        private uint pointerChunks;
        private uint pointerBlockNames;
        private uint pointerBlockGroup;
        private uint pointerUnk5;
        private uint pointerUnk6;
        private uint pointerBoundingBoxes;

        private uint blockLinkCount;
        private List<ObjLink> blockLinks;
        private uint linkCounter;
        private List<ObjLink> blockLinkList;
        private uint objectGroupCount;
        private List<DungeonRoomObjectGroop> objGroupArray;
        private ushort regionID;
        private uint roomCounter;
        private uint roomFloorCounter;
        private string[] roomFloorNames;
        private string[] roomNames;
        private List<DungeonBlockObject> roomObjArray;
        private uint roomObjectCount;
        private uint chunkX;
        private uint chunkY;
        private uint chunkZ;
        private CObjectInfo GeneralInformation;
        /// <summary>
        /// 256*256 = 65536
        /// </summary>
        private ushort unk_ushort0;

        private ushort unk_ushort1;

        #endregion Fields

        #region Constructors

        public JMXdofFile(byte[] file)
        {
            try
            {
                FileSize = file.LongLength;
                using (var reader = new BinaryReader(new MemoryStream(file)))
                {
                    header = reader.ReadChars(12);
                    pointerBlocks = reader.ReadUInt32();
                    pointerBlockLinks = reader.ReadUInt32();
                    pointerChunks = reader.ReadUInt32();
                    pointerBlockGroup = reader.ReadUInt32();
                    pointerBlockNames = reader.ReadUInt32();
                    pointerUnk5 = reader.ReadUInt32();
                    pointerUnk6 = reader.ReadUInt32();
                    pointerBoundingBoxes = reader.ReadUInt32();

                    GeneralInformation = new CObjectInfo()
                    {
                        Type = (ResourceType)reader.ReadUInt32(),
                        Name = new string(reader.ReadChars((int)reader.ReadUInt32())),
                        UnkUInt0 = reader.ReadUInt32(),
                        UnkUInt1 = reader.ReadUInt32()
                    };


                    regionID = reader.ReadUInt16();

                    #region pointerBoundingBoxes
                    reader.BaseStream.Position = pointerBoundingBoxes;
                    dungeon_AABB = new float[6] { reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle() };
                    dungeon_OOBB = new float[6] { reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle() };

                    PointerBoundingBoxesEnd = reader.BaseStream.Position;

                    #endregion pointerBoundingBoxes

                    #region pointerChunks
                    reader.BaseStream.Position = pointerChunks;

                    chunkX = reader.ReadUInt32();
                    chunkY = reader.ReadUInt32();
                    chunkZ = reader.ReadUInt32();
                    linkCounter = reader.ReadUInt32();
                    blockLinks = new List<ObjLink>((int)linkCounter);
                    for (int i = 0; i < linkCounter; i++)
                    {
                        var link = reader.ReadUInt32();
                        var linkConCount = reader.ReadUInt32();
                        var arr = new uint[linkConCount];

                        for (int i2 = 0; i2 < linkConCount; i2++)
                        {
                            arr[i2] = reader.ReadUInt32();
                        }
                        blockLinks.Add(new ObjLink(link, arr));
                    }
                    PointerChunksEnd = reader.BaseStream.Position;
                    PointerChunksLength = reader.BaseStream.Position - pointerChunks;

                    #endregion pointerChunks


                    reader.BaseStream.Position = pointerBlockNames;

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
                    PointerBlockNamesEnd = reader.BaseStream.Position;
                    PointerBlockNamesLength = reader.BaseStream.Position - pointerBlockNames;

                    reader.BaseStream.Position = pointerBlockLinks;
                    var blockLinkCount = reader.ReadUInt32();
                    blockLinkList = new List<ObjLink>((int)blockLinkCount);

                    for (int i = 0; i < blockLinkCount; i++)
                    {
                        var objConCount = reader.ReadUInt32();
                        var arr = new uint[objConCount];

                        for (int i2 = 0; i2 < objConCount; i2++)
                        {
                            arr[i2] = reader.ReadUInt32();
                        }
                        blockLinkList.Add(new ObjLink((uint)i, arr));
                    }
                    PointerBlockLinksEnd = reader.BaseStream.Position;
                    PointerBlockLinksLength = reader.BaseStream.Position - pointerBlockLinks;

                    reader.BaseStream.Position = pointerBlocks;
                    roomObjectCount = reader.ReadUInt32();
                    roomObjArray = new List<DungeonBlockObject>((int)roomObjectCount);
                    for (int i = 0; i < roomObjectCount; i++)
                    {
                        DungeonBlockObject obj = new DungeonBlockObject()
                        {
                            extraA = new DungeonRoomObjectExtraInformation() { },
                            extraB = new DungeonRoomObjectExtraInformation() { },
                            Path = new string(reader.ReadChars(reader.ReadInt32())),
                            Name = new string(reader.ReadChars(reader.ReadInt32())),
                            Unk_float0 = reader.ReadSingle(),
                            X = reader.ReadSingle(),
                            Z = reader.ReadSingle(),
                            Y = reader.ReadSingle(),
                            YAW = reader.ReadSingle(),
                            PITCH = reader.ReadSingle(),
                            AABB = new float[6] { reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle() },
                            Unk_float12 = reader.ReadSingle(),
                            FogColor = reader.ReadUInt32(),
                            FogNearPlane = reader.ReadSingle(),
                            FogFarPlane = reader.ReadSingle(),
                            FogIndensity = reader.ReadSingle(),
                            HasHeightFog = reader.ReadByte()
                        };
                        if (obj.HasHeightFog == 0x01)
                        {
                            obj.extraA.Unk_float0 = reader.ReadSingle();
                            obj.extraA.Unk_float1 = reader.ReadSingle();
                            obj.extraA.Unk_float2 = reader.ReadSingle();
                            obj.extraA.Unk_float3 = reader.ReadSingle();
                        }
                        obj.ExtraFlagB = reader.ReadByte();
                        if (obj.ExtraFlagB == 0x02)
                        {
                            obj.extraB.Vector0 = new Structs.SVector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                            obj.extraB.Vector1 = new Structs.SVector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                            //obj.extraB.Unk_float0 = reader.ReadSingle();
                            //obj.extraB.Unk_float1 = reader.ReadSingle();
                            //obj.extraB.Unk_float2 = reader.ReadSingle();
                            //obj.extraB.Unk_float3 = reader.ReadSingle();
                            //obj.extraB.Unk_float4 = reader.ReadSingle();
                            //obj.extraB.Unk_float5 = reader.ReadSingle();
                            obj.extraB.Unk_float6 = reader.ReadSingle();
                        }
                        obj.Unk_uint0 = reader.ReadUInt32();
                        obj.RoomIndex = reader.ReadUInt32();
                        obj.FloorIndex = reader.ReadUInt32();
                        obj.ConnectedObjectCount = reader.ReadUInt32();
                        obj.ConnectedObjectList = new uint[obj.ConnectedObjectCount];
                        for (int objconindex = 0; objconindex < obj.ConnectedObjectCount; objconindex++)
                        {
                            obj.ConnectedObjectList[objconindex] = reader.ReadUInt32();
                        }

                        obj.IndirectConnectedObjectCount = reader.ReadUInt32();
                        obj.IndirectConnectedObjectList = new uint[obj.IndirectConnectedObjectCount];
                        for (int objconindex = 0; objconindex < obj.IndirectConnectedObjectCount; objconindex++)
                        {
                            obj.IndirectConnectedObjectList[objconindex] = reader.ReadUInt32();
                        }

                        obj.EntryCounter = reader.ReadUInt32();
                        obj.Unk_uint1 = reader.ReadUInt32();

                        obj.EntryList = new DungeonBlockObjectEntry[obj.EntryCounter];
                        for (int ei = 0; ei < obj.EntryCounter; ei++)
                        {
                            var robj = new DungeonBlockObjectEntry()
                            {
                                Name = new string(reader.ReadChars(reader.ReadInt32())),
                                EntryPath = new string(reader.ReadChars(reader.ReadInt32())),
                                X = reader.ReadSingle(),
                                Z = reader.ReadSingle(),
                                Y = reader.ReadSingle(),
                                Roll = reader.ReadSingle(),
                                Yaw = reader.ReadSingle(),
                                Pitch = reader.ReadSingle(),
                                ScaleWidth = reader.ReadSingle(),
                                ScaleHeight = reader.ReadSingle(),
                                ScaleLength = reader.ReadSingle(),
                                ExtraFlag = reader.ReadUInt32(),
                            };
                            if (robj.ExtraFlag == 0x04)
                            {
                                robj.WaterExta = reader.ReadUInt32();
                            }
                            robj.ID = reader.ReadUInt32();
                            robj.Unk_float0 = reader.ReadSingle();

                            obj.EntryList[ei] = robj;
                        }

                        obj.pointCounter = reader.ReadUInt32();
                        obj.PointList = new DungeonRoomObjectPointStruct[obj.pointCounter];
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
                                Float09 = reader.ReadSingle(),
                                Float10 = reader.ReadSingle(),
                                Float11 = reader.ReadSingle(),
                                Float12 = reader.ReadSingle(),
                                Float13 = reader.ReadSingle(),
                                Float14 = reader.ReadSingle(),
                            };
                            obj.PointList[pi] = dpoint;
                        }

                        roomObjArray.Add(obj);
                    }

                    PointerRoomObjectsLength = reader.BaseStream.Position - pointerBlocks;
                    PointerRoomObjectsEnd = reader.BaseStream.Position;

                    reader.BaseStream.Position = pointerBlockGroup;
                    objectGroupCount = reader.ReadUInt32();
                    ObjGroupArray = new List<DungeonRoomObjectGroop>((int)objectGroupCount);
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
                        ObjGroupArray.Add(gobj);
                    }
                    PointerObjectGroupsLength = reader.BaseStream.Position - pointerBlockGroup;
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
        public string Name { get => GeneralInformation.Name; set => GeneralInformation.Name = value; }

        /// <summary>
        /// Size of file
        /// </summary>
        public long FileSize { get; }

        public char[] Header { get => header; set => header = value; }
        public uint PointerDungeonBoundingBoxes { get => pointerBoundingBoxes; set => pointerBoundingBoxes = value; }
        public long PointerBoundingBoxesEnd { get; }
        public uint PointerIndexNames { get => pointerBlockNames; set => pointerBlockNames = value; }
        public long PointerBlockNamesEnd { get; }
        public long PointerBlockNamesLength { get; }
        public uint PointerLinks { get => pointerChunks; set => pointerChunks = value; }
        public long PointerChunksEnd { get; }
        public long PointerChunksLength { get; }
        public uint PointerObjectConnections { get => pointerBlockLinks; set => pointerBlockLinks = value; }
        public long PointerBlockLinksEnd { get; }
        public long PointerBlockLinksLength { get; }
        public uint PointerObjectGroups { get => pointerBlockGroup; set => pointerBlockGroup = value; }
        public long PointerObjectGroupsEnd { get; }
        public long PointerObjectGroupsLength { get; }
        public uint PointerRoomObjects { get => pointerBlocks; set => pointerBlocks = value; }
        public long PointerRoomObjectsEnd { get; }
        public long PointerRoomObjectsLength { get; }
        public uint PointerUnk5 { get => pointerUnk5; set => pointerUnk5 = value; }
        public uint PointerUnk6 { get => pointerUnk6; set => pointerUnk6 = value; }


        public ushort RegionID { get => regionID; set => regionID = value; }
        //public uint RoomCount { get => roomCounter; }
        //public uint BlockLinkCount { get => linkCounter; }
        public List<ObjLink> BlockLinks { get => blockLinks; set => blockLinks = value; }
        //public uint ObjectConnectionCount { get => objectConnectionCounter; }
        public List<ObjLink> ObjectConnections { get => blockLinkList; set => blockLinkList = value; }
        //public uint ObjectGroupCount { get => objectGroupCount; }
        //public uint RoomFloorCount { get => roomFloorCounter; }
        public string[] RoomFloorNames { get => roomFloorNames; set => roomFloorNames = value; }
        public string[] RoomNames { get => roomNames; set => roomNames = value; }
        public List<DungeonBlockObject> RoomObjArray { get => roomObjArray; set => roomObjArray = value; }
        //public uint RoomObjectCount { get => roomObjectCount; set => roomObjectCount = value; }
        public uint GeneralInfoUnkUInt0 { get => GeneralInformation.UnkUInt0; set => GeneralInformation.UnkUInt0 = value; }
        public uint GeneralInfoUnkUInt1 { get => GeneralInformation.UnkUInt1; set => GeneralInformation.UnkUInt1 = value; }
        public uint ChunkX { get => chunkX; set => chunkX = value; }
        public uint ChunkY { get => chunkY; set => chunkY = value; }
        public uint ChunkZ { get => chunkZ; set => chunkZ = value; }
        public List<DungeonRoomObjectGroop> ObjGroupArray { get => objGroupArray; set => objGroupArray = value; }

        #endregion Properties
    }
}