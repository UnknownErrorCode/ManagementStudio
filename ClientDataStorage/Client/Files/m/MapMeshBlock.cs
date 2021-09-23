using System.Collections.Generic;
using System.Drawing;

namespace ClientDataStorage.Client.Files
{
    public class MapMeshBlock
    {
        /// <summary>
        /// Name of the Block
        /// </summary>
        public char[] BlockName { get; set; }

        /// <summary>
        /// Dictionary of all MapMeshCells. each Block consists of 16x16 MapmeshCells
        /// </summary>
        public Dictionary<Point, MapMeshCell> MapCells { get; set; }

        /// <summary>
        /// 0x00 = Water, 0x01 = Ice, FF = Solid
        /// </summary>
        public byte Density { get; set; }

        /// <summary>
        /// related to Block.Density (see screens)
        /// </summary>
        public byte UnkByte0 { get; set; }

        /// <summary>
        /// Sea level height
        /// </summary>
        public float SeaLevel { get; set; }

        /// <summary>
        /// unknown
        /// </summary>
        public List<KeyValuePair<byte, byte>> ExtraMin { get; set; }

        /// <summary>
        /// Max height of block.
        /// </summary>
        public float HeightMax { get; set; }

        /// <summary>
        /// Min height of block.
        /// </summary>
        public float HeightMin { get; set; }

        /// <summary>
        /// unknown.
        /// </summary>
        public byte[] UnkBuffer0 { get; set; }


        public MapMeshBlock(char[] blockName, Dictionary<Point, MapMeshCell> mapCells, byte density, byte unkByte0, float seaLevel, List<KeyValuePair<byte, byte>> extraMin, float heightMax, float heightMin, byte[] unkBuffer0)
        {
            BlockName = blockName;
            MapCells = mapCells;
            ExtraMin = extraMin;
            HeightMax = heightMax;
            HeightMin = heightMin;
            UnkBuffer0 = unkBuffer0;
            Density = density;
            UnkByte0 = unkByte0;
            SeaLevel = seaLevel;
        }

        /// <summary>
        /// Returns the Cell of this block by x and y coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>MapMeshCell cell</returns>
        public MapMeshCell GetCellFromBlock(int x, int y)
            => GetCellFromBlock(new System.Drawing.Point(x, y));

        /// <summary>
        /// Returns the Cell of this block by System.Drawing.Point.
        /// </summary>
        /// <param name="point"></param>
        /// <returns>MapMeshCell cell</returns>
        public MapMeshCell GetCellFromBlock(System.Drawing.Point point)
            => MapCells.ContainsKey(point) ? MapCells[point] : null;
    }
}