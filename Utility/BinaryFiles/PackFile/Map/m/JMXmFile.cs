﻿using Structs;
using Structs.BinaryFiles.JMXRessource.Mesh;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BinaryFiles.PackFile.Map.m
{
    public class JMXmFile : IJMXFile
    {
        /// <summary>
        /// JMX Header file of version
        /// </summary>
        private readonly JMXHeader header;

        /// <summary>
        /// Each region consists of 36 Blocks. 6 x 6 Blocks equals 1 WorldRegion.
        /// <br>__________________ </br>
        /// <br>|1 |2 |3 |4 |5 |6 |</br>
        /// <br>|7 |8 |9 |10|11|12|</br>
        /// <br>|13|14|15|16|17|18|</br>
        /// <br>|19|20|21|22|23|24|</br>
        /// <br>|25|26|27|28|29|30|</br>
        /// <br>|31|32|33|34|35|36|</br>
        /// </summary>
        private readonly Dictionary<Structs.Point8, CMapMeshBlock> blocks = new Dictionary<Structs.Point8, CMapMeshBlock>(36);

        /// <summary>
        /// X coordinate of .m file.
        /// </summary>
        private byte x;

        /// <summary>
        /// Y coordinate of .m file.
        /// </summary>
        private byte y;

        /// <summary>
        /// .m file inside Map.Pk2 includes all informations about the terrain mesh.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        public JMXmFile(byte[] buffer, byte xCoordinate = 0, byte yCoordinate = 0)
        {
            try
            {
                X = xCoordinate;
                Z = yCoordinate;

                using (MemoryStream strea = new MemoryStream(buffer))
                {
                    using (BinaryReader reader = new BinaryReader(strea))
                    {
                        header = new JMXHeader(reader.ReadChars(12), JmxFileFormat._m);

                        for (byte zBlock = 0; zBlock < 6; zBlock++)
                        {
                            for (byte xBlock = 0; xBlock < 6; xBlock++)
                            {
                                Blocks.Add(Point8.FromXY(xBlock, zBlock), ReadBlock(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Initialized = false;
            }
        }

        public bool Initialized { get; } = true;

        public Dictionary<Point8, CMapMeshBlock> Blocks => blocks;

        public byte X { get => x; set => x = value; }
        public byte Z { get => y; set => y = value; }

        public JMXHeader Header => header;

        /// <summary>
        /// Get the EntryBlock by x & y coordinate
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>[MapMeshBlock] block</returns>
        [Obsolete]
        public bool GetEntryBlock(Structs.Point8 point, out CMapMeshBlock meshBlock)
        {
            var contains = Blocks.ContainsKey(point);
            meshBlock = contains ? Blocks[point] : default(CMapMeshBlock);
            return contains;
        }

        public float GetHightByfPoint(float regX, float regY)
        {
            var bx = (int)regX / (1920 / 6);
            var by = (int)regY / (1920 / 6);
            if (bx == 6)
                bx -= 1;
            if (by == 6)
                by -= 1;

            var cx = regX / (1920 / 16);
            var cy = (regY / (1920 / 16) - 16) * -1;

            Structs.Point8 Point1 = Structs.Point8.FromXY((byte)bx, (byte)by);
            Structs.Point8 Point2 = Structs.Point8.FromXY((byte)cx, (byte)cy);

            return Blocks[Point1].MapCells[Point2].Height;
        }

        /// <summary>
        /// Returns the MeshCell of the MeshBlock.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="Cx"></param>
        /// <param name="Cy"></param>
        /// <returns>MapMeshCell cell</returns>
        [Obsolete]
        public bool GetMapMeshCell(byte x, byte y, int Cx, int Cy, out CMapMeshCell cell)
        {
            Structs.Point8 p = new Structs.Point8(x, y);
            Structs.Point32 cp = new Structs.Point32(Cx, Cy);

            cell = new CMapMeshCell();

            if (Blocks[p].MapCells.ContainsKey(p))
            {
                cell = Blocks[p].MapCells[p];
            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns the height of the MeshCell inside the MeshBlock.
        /// </summary>
        /// <param name="BlockX"></param>
        /// <param name="BlockY"></param>
        /// <param name="CellX"></param>
        /// <param name="CellY"></param>
        /// <returns>float Height of MapMeshCell</returns>
        [Obsolete]
        public float GetMapMeshHeight(byte BlockX, byte BlockY, byte CellX, byte CellY)
        {
            Structs.Point8 p = new Structs.Point8(BlockX, BlockY);
            Structs.Point8 cp = new Structs.Point8(CellX, CellY);

            if (Blocks[p].MapCells.ContainsKey(p))
            {
                return Blocks[p].MapCells[p].Height;
            }
            else
            {
                return 0f;
            }
        }

        /// <summary>
        /// ABSOLUTELY OBSOLET!!
        /// </summary>
        /// <param name="regX"></param>
        /// <param name="blockX"></param>
        /// <returns></returns>
        [Obsolete]
        private static bool BlockEntry(float regX, out byte blockX)
        {
            blockX = 0;

            if (Enumerable.Range(0, 320).Contains((int)regX))
            {
                blockX = 0;
            }
            else if (Enumerable.Range(320, 320).Contains((int)regX))
            {
                blockX = 1;
            }
            else if (Enumerable.Range(640, 320).Contains((int)regX))
            {
                blockX = 2;
            }
            else if (Enumerable.Range(960, 320).Contains((int)regX))
            {
                blockX = 3;
            }
            else if (Enumerable.Range(1280, 320).Contains((int)regX))
            {
                blockX = 4;
            }
            else if (Enumerable.Range(1600, 320).Contains((int)regX))
            {
                blockX = 5;
            }
            else
            {
                return false;
            }

            return true;
        }

        [Obsolete]
        private static bool CellEntry(float reg, bool reverse, out byte Cell)
        {
            Cell = 0;

            if (Enumerable.Range(0, 120).Contains((int)reg))
            {
                Cell = reverse ? (byte)15 : (byte)0;
            }
            else if (Enumerable.Range(120, 120).Contains((int)reg))
            {
                Cell = reverse ? (byte)14 : (byte)1;
            }
            else if (Enumerable.Range(240, 120).Contains((int)reg))
            {
                Cell = reverse ? (byte)13 : (byte)2;
            }
            else if (Enumerable.Range(360, 120).Contains((int)reg))
            {
                Cell = reverse ? (byte)12 : (byte)3;
            }
            else if (Enumerable.Range(480, 120).Contains((int)reg))
            {
                Cell = reverse ? (byte)11 : (byte)4;
            }
            else if (Enumerable.Range(600, 120).Contains((int)reg))
            {
                Cell = reverse ? (byte)10 : (byte)5;
            }
            else if (Enumerable.Range(720, 120).Contains((int)reg))
            {
                Cell = reverse ? (byte)9 : (byte)6;
            }
            else if (Enumerable.Range(840, 120).Contains((int)reg))
            {
                Cell = reverse ? (byte)8 : (byte)7;
            }
            else if (Enumerable.Range(960, 120).Contains((int)reg))
            {
                Cell = reverse ? (byte)7 : (byte)8;
            }
            else if (Enumerable.Range(1080, 120).Contains((int)reg))
            {
                Cell = reverse ? (byte)6 : (byte)9;
            }
            else if (Enumerable.Range(1200, 120).Contains((int)reg))
            {
                Cell = reverse ? (byte)5 : (byte)10;
            }
            else if (Enumerable.Range(1320, 120).Contains((int)reg))
            {
                Cell = reverse ? (byte)4 : (byte)11;
            }
            else if (Enumerable.Range(1440, 120).Contains((int)reg))
            {
                Cell = reverse ? (byte)3 : (byte)12;
            }
            else if (Enumerable.Range(1560, 120).Contains((int)reg))
            {
                Cell = reverse ? (byte)2 : (byte)13;
            }
            else if (Enumerable.Range(1680, 120).Contains((int)reg))
            {
                Cell = reverse ? (byte)1 : (byte)14;
            }
            else if (Enumerable.Range(1800, 120).Contains((int)reg))
            {
                Cell = reverse ? (byte)0 : (byte)15;
            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Reads a single <see cref="CMapMeshBlock"/> from the <see cref="BinaryReader"/> <paramref name="reader"/>.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private CMapMeshBlock ReadBlock(BinaryReader reader)
        {
            CMapMeshBlock block = new CMapMeshBlock()
            {
                BlockName = new string(System.Text.Encoding.UTF8.GetChars(reader.ReadBytes(6)))
            };

            #region Mesh Cells

            block.MapCells = new Dictionary<Point8, CMapMeshCell>(289);

            //every block has 17 * 17 MapMeshVerticies
            for (byte CellZ = 0; CellZ < 17; CellZ++)
            {
                for (byte CellX = 0; CellX < 17; CellX++)
                {
                    var meshCell = new CMapMeshCell()
                    {
                        Height = reader.ReadSingle(),
                        Texture = reader.ReadUInt16(),
                        Brightness = reader.ReadByte(),
                    };
                    block.MapCells.Add(new Point8(CellZ, CellX), meshCell);
                }
            }

            #endregion Mesh Cells

            #region Water

            block.WaterType = reader.ReadByte();
            block.WaterWaveType = reader.ReadByte();
            block.SeaLevel = reader.ReadSingle();

            #endregion Water

            #region Mesh Tiles

            block.MapMeshTiles = new CMapMeshTile[256];
            //TODO: Maybe also using dictionary later as property? idk...
            for (int mapMeshTile = 0; mapMeshTile < 256; mapMeshTile++)
            {
                block.MapMeshTiles[mapMeshTile] = new CMapMeshTile() { ExtraMin = reader.ReadByte(), ExtraMax = reader.ReadByte() };
            }

            #endregion Mesh Tiles

            #region Min Max Heigth

            block.HeightMax = reader.ReadSingle();
            block.HeightMin = reader.ReadSingle();
            block.Reserved = reader.ReadBytes(20);

            #endregion Min Max Heigth

            return block;
        }
    }
}