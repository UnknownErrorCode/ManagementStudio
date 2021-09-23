using Structs.Pk2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataStorage.Client.Files
{
    public class o2File
    {

        public List<MapObject> objects = new List<MapObject>();
        private List<MapObject> AllObjects = new List<MapObject>();
        public int OX;
        public int OY;

        public o2File(Pk2File binFile)
        {
            var buffer = Map.MapPk2.GetByteArrayByFile(binFile);
            using (MemoryStream stream = new MemoryStream(buffer))
            {
                using (BinaryReader binaryReader = new BinaryReader(stream))
                {
                    if (!int.TryParse(binFile.parentFolder.name, out int xval))
                        return;

                    if (!int.TryParse(binFile.name.Replace(".o2", ""), out int yval))
                        return;

                    this.OX = xval;
                    this.OY = yval;
                    List<int> intList = new List<int>();
                    binaryReader.BaseStream.Position = 12;
                    for (int index1 = 0; index1 < 144; ++index1)
                    {
                        short num1 = binaryReader.ReadInt16();
                        for (int index2 = 0; index2 < (int)num1; ++index2)
                        {
                            MapObject mapObject = new MapObject();
                            mapObject.groups.Add(index1);
                            mapObject.nameI = binaryReader.ReadInt32();
                            mapObject.X = binaryReader.ReadSingle();
                            mapObject.Y = binaryReader.ReadSingle();
                            mapObject.Z = binaryReader.ReadSingle();
                            string str1 = binaryReader.ReadByte().ToString("X2");
                            mapObject.Unknown1 = str1 + binaryReader.ReadByte().ToString("X2");
                            float num2 = binaryReader.ReadSingle();
                            while ((double)num2 < 0.0)
                                num2 += 6.283185f;
                            while ((double)num2 > 6.28318548202515)
                                num2 -= 6.283185f;
                            mapObject.Theta = num2;
                            mapObject.ID = binaryReader.ReadInt32();
                            string str2 = binaryReader.ReadByte().ToString("X2");
                            mapObject.Unknown2 = str2 + binaryReader.ReadByte().ToString("X2");
                            int num3 = (int)binaryReader.ReadByte();
                            int num4 = (int)binaryReader.ReadByte();
                            mapObject.X += (float)((num3 - this.OX) * 1920);
                            mapObject.Z += (float)((num4 - this.OY) * 1920);
                            this.AllObjects.Add(mapObject);
                            if (!intList.Contains(mapObject.ID))
                            {
                                this.objects.Add(mapObject);
                                intList.Add(mapObject.ID);

                            }
                            else
                                this.objects[intList.IndexOf(mapObject.ID)].groups.Add(index1);
                        }
                    }
                    this.objects.Reverse();
                }
            }
        }
    }
}
