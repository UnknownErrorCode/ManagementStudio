using Structs.BinaryFiles.JMXRessource.Mesh;
using System.Collections.Generic;
using System.IO;

namespace BinaryFiles.PackFile.Map.o2
{
    public class JMXo2File
    {
        /// <summary>
        /// JMXVMAPO1001
        /// </summary>
        public string Header;

        /// <summary>
        /// List of all Objects inside the .o file.
        /// </summary>
        private List<CMapObject> Objects = new List<CMapObject>();

        #region Constructors

        /// <summary>
        /// Initialize .o file from Pk2File
        /// </summary>
        /// <param name="binFile"></param>
        [System.Obsolete]
        public JMXo2File(byte[] buffer)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        Header = new string(reader.ReadChars(12));
                        for (byte x = 0; x < 6; x++)
                        {
                            for (byte z = 0; z < 6; z++)
                            {
                                var obj = new CMapObject();
                                obj.BlockX = x;
                                obj.BlockY = z;
                                var infoCount = reader.ReadInt32();
                                obj.MapObjectInformationArray = new CMapObjectInformation[infoCount];
                                for (int infoIndex = 0; infoIndex < infoCount; infoIndex++)
                                {
                                    obj.MapObjectInformationArray[infoIndex] = new CMapObjectInformation()
                                    {
                                        ObjectIndex = reader.ReadUInt32(),
                                        LocalPosition = new Structs.SVector3(reader.ReadSingle(),
                                        reader.ReadSingle(),
                                        reader.ReadSingle()),
                                        IsStatic = reader.ReadInt16(),
                                        Yaw = reader.ReadSingle(),
                                        UID = reader.ReadUInt32(),
                                        IsBig = reader.ReadByte(),
                                        IsStruct = reader.ReadByte(),
                                        RegionID = new Structs.WRegionID(reader.ReadInt16())
                                    };
                                }
                                Objects.Add(obj);
                            }
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                Initialized = false;
            }

            //OX = xval;
            //OZ = zval;
            //Initialize(buffer, xval, zval);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// X coordinate from .o file.
        /// </summary>
        public byte X { get; set; }

        /// <summary>
        /// Z coordinate from .o file.
        /// </summary>
        public byte Z { get; set; }

        public bool Initialized { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Initialize .o file from raw byte[].
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="xCoordinate"></param>
        /// <param name="zCoordinate"></param>
        private void Initialize(byte[] buffer, byte xCoordinate, byte zCoordinate)
        {
            using (MemoryStream stream = new MemoryStream(buffer))
            {
                using (BinaryReader binaryReader = new BinaryReader(stream))
                {
                    binaryReader.BaseStream.Position = 12;

                    for (int z = 0; z < 6; z++)
                    {
                        for (int x = 0; x < 6; x++)
                        {
                            ushort wTemp = binaryReader.ReadUInt16(); // ASSERT(wTemp == 0)

                            for (int lodgroup = 0; lodgroup < 3; lodgroup++)
                            {
                                ushort mapObjInfoCount = binaryReader.ReadUInt16();

                                for (ushort mapObjInfo = 0; mapObjInfo < mapObjInfoCount; mapObjInfo++)
                                {
                                    //AllObjects.Add(new MapObject()
                                    //{
                                    //    ObjectID = binaryReader.ReadInt32(),
                                    //    X = binaryReader.ReadSingle(),
                                    //    Y = binaryReader.ReadSingle(),
                                    //    Z = binaryReader.ReadSingle(),
                                    //    IsStatic = binaryReader.ReadUInt16(),
                                    //    Yaw = binaryReader.ReadSingle(),
                                    //    UID = binaryReader.ReadInt32(),
                                    //    IsBig = binaryReader.ReadByte(),
                                    //    IsStruct = binaryReader.ReadByte(),
                                    //    RegionID = binaryReader.ReadUInt16()
                                    //});
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion Methods
    }
}