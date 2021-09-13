using Structs.Pk2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataStorage.Client.Files
{
    public class mFile
    {
        public int X;
        public int Y;
        public char[] Header { get; }
        public Dictionary<System.Drawing.Point, MapMeshBlock> Blocks = new Dictionary<System.Drawing.Point, MapMeshBlock>();

        #region obsolate
        public string[] TexPaths;


        #endregion
        public mFile(Pk2File pk2file)
        {
            if (pk2file.name == null)
                return;

            if (!int.TryParse(pk2file.parentFolder.name, out int xCoordinate))
                return;
            if (!int.TryParse(pk2file.name.Replace(".m", ""), out int yCoordinate))
                return;


            X = xCoordinate;
            Y = yCoordinate;

            byte[] buffer = Client.Map.MapPk2.GetByteArrayByFile(pk2file);

            using (MemoryStream strea = new MemoryStream(buffer))
            {
                using (BinaryReader readBin = new BinaryReader(strea))
                {
                    Header = readBin.ReadChars(12);

                    var counter = 0;
                    for (int xBlock = 0; xBlock < 6; xBlock++)
                    {
                        for (int yBlock = 0; yBlock < 6; yBlock++)
                        {

                            var Cells = new Dictionary<System.Drawing.Point, MapMeshCell>();
                            var blockName = UnicodeEncoding.UTF8.GetChars(readBin.ReadBytes(6));
                            for (int Cellx = 0; Cellx < 17; Cellx++)
                            {

                                for (int Celly = 0; Celly < 17; Celly++)
                                {
                                    var hei = readBin.ReadSingle();
                                    var tex = readBin.ReadByte();
                                    var bri = (byte)readBin.ReadByte();
                                    var skip = readBin.ReadByte();

                                    try
                                    {
                                        Cells.Add(new System.Drawing.Point(Cellx, Celly), new MapMeshCell(hei, (ushort)tex, bri));
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }
                            }
                            counter++;

                            var Density = readBin.ReadByte();
                            var UnkByte0 = readBin.ReadByte();
                            var SeaLevel = readBin.ReadSingle();
                            var ExtraMinMax = new List<KeyValuePair<byte, byte>>();

                            for (int i = 0; i < 256; i++)
                            {
                                var extraMin = readBin.ReadByte();
                                var extraMax = readBin.ReadByte();
                                ExtraMinMax.Add(new KeyValuePair<byte, byte>(extraMin, extraMax));
                            }


                            var HeightMax = readBin.ReadSingle();
                            var HeightMin = readBin.ReadSingle();
                            var unkBuffer0 = readBin.ReadBytes(20);
                            Blocks.Add(new System.Drawing.Point(xBlock, yBlock), new MapMeshBlock(blockName, Cells, Density, UnkByte0, SeaLevel, ExtraMinMax, HeightMax, HeightMin, unkBuffer0));
                        }
                    }
                }
            }
        }


        public bool ContainsEntryBlock(int x, int y)
        {
            System.Drawing.Point p = new System.Drawing.Point(x, y);

            return Blocks.ContainsKey(p);
        }
        public MapMeshBlock GetEntryBlock(int x, int y)
        {
            System.Drawing.Point p = new System.Drawing.Point(x, y);


            return (Blocks.ContainsKey(p) ? Blocks[p] : null);
        }


        public float GetMapMeshHeight(int x, int y, int Cx, int Cy)
        {
            System.Drawing.Point p = new System.Drawing.Point(x, y);
            System.Drawing.Point cp = new System.Drawing.Point(Cx, Cy);

            if (Blocks[p].MapCells.ContainsKey(p))
            {
                return Blocks[p].MapCells[p].Height;
            }
            else
            {
                return 0f;
            }
        }
        public MapMeshCell GetMapMeshCell(int x, int y, int Cx, int Cy)
        {
            System.Drawing.Point p = new System.Drawing.Point(x, y);
            System.Drawing.Point cp = new System.Drawing.Point(Cx, Cy);

            if (Blocks[p].MapCells.ContainsKey(p))
            {
                return Blocks[p].MapCells[p];
            }
            else
            {
                return null;
            }
        }
    }
}
