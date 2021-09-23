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
        /// <summary>
        /// X coordinate of .m file.
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Y coordinate of .m file.
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// JMX Header file of version
        /// </summary>
        public char[] Header { get; private set; }

        /// <summary>
        /// Each region consists of 36 Blocks. 6 x 6 Blocks equals 1 WorldRegion.
        /// </summary>
        public Dictionary<System.Drawing.Point, MapMeshBlock> Blocks = new Dictionary<System.Drawing.Point, MapMeshBlock>();

        /// <summary>
        /// .m file inside Map.Pk2 includes all informations about the terrain mesh.
        /// </summary>
        /// <param name="pk2file"></param>
        public mFile(Pk2File pk2file)
        {
            if (pk2file.name == null)
                return;

            if (!int.TryParse(pk2file.parentFolder.name, out int yCoordinate))
                return;

            if (!int.TryParse(pk2file.name.Replace(".m", ""), out int xCoordinate))
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

        /// <summary>
        /// Check if Block exists inside one of 6*6 MeshBlocks.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>bool exists</returns>
        public bool ContainsEntryBlock(System.Drawing.Point point)
            => Blocks.ContainsKey(point);

        /// <summary>
        /// Get the EntryBlock by x & y coordinate
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>[MapMeshBlock] block</returns>
        public MapMeshBlock GetEntryBlock(System.Drawing.Point point)
            => (Blocks.ContainsKey(point) ? Blocks[point] : null);


        /// <summary>
        /// Returns the height of the MeshCell inside the MeshBlock.
        /// </summary>
        /// <param name="BlockX"></param>
        /// <param name="BlockY"></param>
        /// <param name="CellX"></param>
        /// <param name="CellY"></param>
        /// <returns>float Height of MapMeshCell</returns>
        public float GetMapMeshHeight(int BlockX, int BlockY, int CellX, int CellY)
        {
            System.Drawing.Point p = new System.Drawing.Point(BlockX, BlockY);
            System.Drawing.Point cp = new System.Drawing.Point(CellX, CellY);

            if (Blocks[p].MapCells.ContainsKey(p))
                return Blocks[p].MapCells[p].Height;
            else
                return 0f;
        }

        /// <summary>
        /// Returns the MeshCell of the MeshBlock.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="Cx"></param>
        /// <param name="Cy"></param>
        /// <returns>MapMeshCell cell</returns>
        public MapMeshCell GetMapMeshCell(int x, int y, int Cx, int Cy)
        {
            System.Drawing.Point p = new System.Drawing.Point(x, y);
            System.Drawing.Point cp = new System.Drawing.Point(Cx, Cy);

            if (Blocks[p].MapCells.ContainsKey(p))
                return Blocks[p].MapCells[p];
            else
                return null;
        }
    }
}
