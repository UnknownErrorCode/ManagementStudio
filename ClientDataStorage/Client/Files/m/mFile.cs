using Structs.Pk2;
using Structs.Pk2.BinaryFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ClientDataStorage.Client.Files
{
    public class mFile
    {
        /// <summary>
        /// X coordinate of .m file.
        /// </summary>
        public byte X { get; private set; }

        /// <summary>
        /// Y coordinate of .m file.
        /// </summary>
        public byte Y { get; private set; }

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

            if (!byte.TryParse(pk2file.parentFolder.name, out byte yCoordinate))
                return;

            if (!byte.TryParse(pk2file.name.Replace(".m", ""), out byte xCoordinate))
                return;

            byte[] buffer = Map.MapPk2.GetByteArrayByFile(pk2file);

            Initialize(buffer, xCoordinate, yCoordinate);

        }

        /// <summary>
        /// .m file inside Map.Pk2 includes all informations about the terrain mesh.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        public mFile(byte[] buffer, byte xCoordinate, byte yCoordinate)
            => Initialize(buffer, xCoordinate, yCoordinate);

        /// <summary>
        /// initialize the mFile by byte array, x and y coordinate.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        private void Initialize(byte[] buffer, byte xCoordinate, byte yCoordinate)
        {
            X = xCoordinate;
            Y = yCoordinate;

            using (MemoryStream strea = new MemoryStream(buffer))
            {
                using (BinaryReader readBin = new BinaryReader(strea))
                {
                    Header = readBin.ReadChars(12);

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
                                    var bri = readBin.ReadByte();
                                    var skip = readBin.ReadByte();

                                    try
                                    {
                                        Cells.Add(new System.Drawing.Point(Cellx, Celly), new Structs.Pk2.BinaryFiles.MapMeshCell(hei, (ushort)tex, 0,bri));
                                    }
                                    catch (Exception ex)
                                    {
                                    }
                                }
                            }

                            var waterType = readBin.ReadByte();
                            var waterWaveType = readBin.ReadByte();
                            var WaterHeight = readBin.ReadSingle();
                            var ExtraMinMax = new List<KeyValuePair<byte, byte>>();

                            for (int mapMeshTile = 0; mapMeshTile < 256; mapMeshTile++)
                            {
                                var extraMin = readBin.ReadByte();
                                var extraMax = readBin.ReadByte();
                                ExtraMinMax.Add(new KeyValuePair<byte, byte>(extraMin, extraMax));
                            }

                            var HeightMax = readBin.ReadSingle();
                            var HeightMin = readBin.ReadSingle();
                            var reserved = readBin.ReadBytes(20);
                            Blocks.Add(new System.Drawing.Point(xBlock, yBlock), new MapMeshBlock(blockName, Cells, waterType, waterWaveType, WaterHeight, ExtraMinMax, HeightMax, HeightMin, reserved));
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
        public bool GetMapMeshCell(int x, int y, int Cx, int Cy, out MapMeshCell cell)
        {
            System.Drawing.Point p = new System.Drawing.Point(x, y);
            System.Drawing.Point cp = new System.Drawing.Point(Cx, Cy);

            cell = new MapMeshCell();

            if (Blocks[p].MapCells.ContainsKey(p))
                 cell = Blocks[p].MapCells[p];
            else
                return false;

            return true;
        }

        public bool GetHightByfPoint(float regX, float regY, out float Z)
        {
            Z = 0.0f;
            BlockEntry(regX, out byte BlockX);
            BlockEntry(regY, out byte BlockY);

            CellEntry(regX, false, out byte CellX);
            CellEntry(regY, true, out byte CellY);

            var Point1 = new System.Drawing.Point(BlockX, BlockY);
            var Point2 = new System.Drawing.Point(CellX, CellY);

            Z = this.Blocks[Point1].MapCells[Point2].Height;

            return true;
        }


        private static bool BlockEntry(float regX, out byte blockX)
        {
            blockX = 0;

            if (Enumerable.Range(0, 320).Contains((int)regX))
                blockX = 0;
            else if (Enumerable.Range(320, 320).Contains((int)regX))
                blockX = 1;
            else if (Enumerable.Range(640, 320).Contains((int)regX))
                blockX = 2;
            else if (Enumerable.Range(960, 320).Contains((int)regX))
                blockX = 3;
            else if (Enumerable.Range(1280, 320).Contains((int)regX))
                blockX = 4;
            else if (Enumerable.Range(1600, 320).Contains((int)regX))
                blockX = 5;
            else
                return false;

            return true;
        }

        private static bool CellEntry(float reg, bool reverse, out byte Cell)
        {
            Cell = 0;

            if (Enumerable.Range(0, 120).Contains((int)reg))
                Cell = reverse ? (byte)15 : (byte)0;
            else if (Enumerable.Range(120, 120).Contains((int)reg))
                Cell = reverse ? (byte)14 : (byte)1;
            else if (Enumerable.Range(240, 120).Contains((int)reg))
                Cell = reverse ? (byte)13 : (byte)2;
            else if (Enumerable.Range(360, 120).Contains((int)reg))
                Cell = reverse ? (byte)12 : (byte)3;
            else if (Enumerable.Range(480, 120).Contains((int)reg))
                Cell = reverse ? (byte)11 : (byte)4;
            else if (Enumerable.Range(600, 120).Contains((int)reg))
                Cell = reverse ? (byte)10 : (byte)5;
            else if (Enumerable.Range(720, 120).Contains((int)reg))
                Cell = reverse ? (byte)9 : (byte)6;
            else if (Enumerable.Range(840, 120).Contains((int)reg))
                Cell = reverse ? (byte)8 : (byte)7;
            else if (Enumerable.Range(960, 120).Contains((int)reg))
                Cell = reverse ? (byte)7 : (byte)8;
            else if (Enumerable.Range(1080, 120).Contains((int)reg))
                Cell = reverse ? (byte)6 : (byte)9;
            else if (Enumerable.Range(1200, 120).Contains((int)reg))
                Cell = reverse ? (byte)5 : (byte)10;
            else if (Enumerable.Range(1320, 120).Contains((int)reg))
                Cell = reverse ? (byte)4 : (byte)11;
            else if (Enumerable.Range(1440, 120).Contains((int)reg))
                Cell = reverse ? (byte)3 : (byte)12;
            else if (Enumerable.Range(1560, 120).Contains((int)reg))
                Cell = reverse ? (byte)2 : (byte)13;
            else if (Enumerable.Range(1680, 120).Contains((int)reg))
                Cell = reverse ? (byte)1 : (byte)14;
            else if (Enumerable.Range(1800, 120).Contains((int)reg))
                Cell = reverse ? (byte)0 : (byte)15;
            else
                return false;

            return true;
        }
    }
}
