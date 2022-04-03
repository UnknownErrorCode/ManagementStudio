using Structs.BinaryFiles.JMXRessource.Mesh;
using System.Collections.Generic;
using System.IO;

namespace BinaryFiles.PackFile.Map.o2
{
    public class JMXo2File : IJMXFile
    {
        /// <summary>
        /// List of all Objects inside the .o file.
        /// </summary>
        private List<CMapObject> Objects = new List<CMapObject>();

        /// <summary>
        /// Initialize .o or .o2 file from byte[]
        /// <br>Header:</br>
        /// <br>JMXVMAPO1001</br>
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="isO2"></param>
        /// <param name="_x"></param>
        /// <param name="_z"></param>
        public JMXo2File(byte[] buffer, bool isO2, byte _x = 0, byte _z = 0)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        Header = new JMXHeader(reader.ReadChars(12), JmxFileFormat._o2);

                        if (isO2)
                        {
                            ReadO2(reader);
                        }
                        else
                        {
                            ReadO(reader);
                        }
                    }
                }
                X = _x;
                Z = _z;
            }
            catch (System.Exception)
            {
                Initialized = false;
            }
        }

        /// <summary>
        /// X coordinate from .o file.
        /// </summary>
        public byte X { get; set; }

        /// <summary>
        /// Z coordinate from .o file.
        /// </summary>
        public byte Z { get; set; }

        public bool Initialized { get; }

        public JMXHeader Header { get; }

        /// <summary>
        /// Initialize .o file from raw byte[].
        /// </summary>
        /// <param name="file"></param>
        private void ReadO(BinaryReader reader)
        {
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

        /// <summary>
        /// Initialize .o2 file from raw byte[].
        /// </summary>
        /// <param name="buffer"></param>
        private void ReadO2(BinaryReader reader)
        {
            for (byte z = 0; z < 6; z++)
            {
                for (byte x = 0; x < 6; x++)
                {
                    ushort wTemp = reader.ReadUInt16(); // ASSERT(wTemp == 0)
                                                        //ToDo assert missing
                    for (int lodgroup = 0; lodgroup < 3; lodgroup++)
                    {
                        ushort mapObjInfoCount = reader.ReadUInt16();
                        var obj = new CMapObject();
                        obj.BlockX = x;
                        obj.BlockY = z;
                        obj.MapObjectInformationArray = new CMapObjectInformation[mapObjInfoCount];
                        for (ushort mapObjInfo = 0; mapObjInfo < mapObjInfoCount; mapObjInfo++)
                        {
                            obj.MapObjectInformationArray[mapObjInfo] = new CMapObjectInformation()
                            {
                                ObjectIndex = reader.ReadUInt32(),
                                LocalPosition = new Structs.SVector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle()),
                                IsStatic = reader.ReadInt16(),
                                Yaw = reader.ReadSingle(),
                                UID = reader.ReadUInt32(),
                                IsBig = reader.ReadByte(),
                                IsStruct = reader.ReadByte(),
                                RegionID = new Structs.WRegionID(reader.ReadInt16())
                            };
                        }
                    }
                }
            }
        }
    }
}