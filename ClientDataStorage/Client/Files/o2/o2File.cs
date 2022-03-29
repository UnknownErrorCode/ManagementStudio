using Structs.Pk2;
using System.Collections.Generic;
using System.IO;

namespace ClientDataStorage.Client.Files
{
    public class o2File
    {
        /// <summary>
        /// List of all Objects inside the .o file.
        /// </summary>
        private List<MapObject> AllObjects { get; set; } = new List<MapObject>();

        /// <summary>
        /// X coordinate from .o file.
        /// </summary>
        public byte OX { get; set; }

        /// <summary>
        /// Z coordinate from .o file.
        /// </summary>
        public byte OZ { get; set; }

        /// <summary>
        /// Initialize .o file from Pk2File
        /// </summary>
        /// <param name="binFile"></param>
        public o2File(Pk2File binFile)
        {
            byte[] buffer = Map.MapPk2.GetByteArrayByFile(binFile);

            if (!byte.TryParse(binFile.parentFolder.name, out byte xval))
            {
                return;
            }

            if (!byte.TryParse(binFile.name.Replace(".o2", ""), out byte zval))
            {
                return;
            }

            OX = xval;
            OZ = zval;
            Initialize(buffer, xval, zval);
        }

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
                                    AllObjects.Add(new MapObject()
                                    {
                                        ObjectID = binaryReader.ReadInt32(),
                                        X = binaryReader.ReadSingle(),
                                        Y = binaryReader.ReadSingle(),
                                        Z = binaryReader.ReadSingle(),
                                        IsStatic = binaryReader.ReadUInt16(),
                                        Yaw = binaryReader.ReadSingle(),
                                        UID = binaryReader.ReadInt32(),
                                        IsBig = binaryReader.ReadByte(),
                                        IsStruct = binaryReader.ReadByte(),
                                        RegionID = binaryReader.ReadUInt16()
                                    });
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}