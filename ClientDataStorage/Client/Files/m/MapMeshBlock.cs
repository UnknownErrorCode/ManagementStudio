using Structs.Pk2.BinaryFiles;
using System.Collections.Generic;
using System.Drawing;

namespace ClientDataStorage.Client.Files
{
    public class MapMeshBlock
    {
        #region Constructors

        public MapMeshBlock(char[] blockName, Dictionary<Point, MapMeshCell> mapCells, byte density, byte unkByte0, float seaLevel, List<KeyValuePair<byte, byte>> extraMin, float heightMax, float heightMin, byte[] unkBuffer0)
        {
            BlockName = blockName;
            MapCells = mapCells;
            ExtraMin = extraMin;
            HeightMax = heightMax;
            HeightMin = heightMin;
            Reserved = unkBuffer0;
            WaterType = density;
            WaterWaveType = unkByte0;
            SeaLevel = seaLevel;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Name of the Block
        /// </summary>
        public char[] BlockName { get; set; }

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
        /// Dictionary of all MapMeshCells. each Block consists of 16x16 MapmeshCells
        /// </summary>
        public Dictionary<Point, MapMeshCell> MapCells { get; set; }

        /// <summary>
        /// unknown.
        /// </summary>
        public byte[] Reserved { get; set; }

        /// <summary>
        /// Sea level height
        /// </summary>
        public float SeaLevel { get; set; }

        /// <summary>
        /// 0x00 = Water, 0x01 = Ice, FF = Solid
        /// </summary>
        public byte WaterType { get; set; }

        /// <summary>
        /// related to Block.Density (see screens)
        /// </summary>
        public byte WaterWaveType { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Returns the Cell of this block by x and y coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>MapMeshCell cell</returns>
        public MapMeshCell GetCellFromBlock(int x, int y)
        {
            return GetCellFromBlock(new Point(x, y));
        }

        /// <summary>
        /// Returns the Cell of this block by System.Drawing.Point.
        /// </summary>
        /// <param name="point"></param>
        /// <returns>MapMeshCell cell</returns>
        public MapMeshCell GetCellFromBlock(Point point)
        {
            return MapCells.ContainsKey(point) ? MapCells[point] : new MapMeshCell();
        }

        #endregion Methods
    }
}