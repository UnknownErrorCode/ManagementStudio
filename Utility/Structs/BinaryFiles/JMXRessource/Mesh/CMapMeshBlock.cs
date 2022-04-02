using System.Collections.Generic;

namespace Structs.BinaryFiles.JMXRessource.Mesh
{
    public struct CMapMeshBlock
    {
        #region Constructors

        public CMapMeshBlock(string blockName, Dictionary<Point8, CMapMeshCell> mapCells, byte density, byte unkByte0, float seaLevel, CMapMeshTile[] tiles, float heightMax, float heightMin, byte[] unkBuffer0)
        {
            BlockName = blockName;
            MapCells = mapCells;
            MapMeshTiles = tiles;
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
        public string BlockName { get; set; }

        /// <summary>
        /// unknown
        /// </summary>
        public CMapMeshTile[] MapMeshTiles { get; set; }

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
        public Dictionary<Point8, CMapMeshCell> MapCells { get; set; }

        /// <summary>
        /// unknown reserved fixed 20 byte
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
        public CMapMeshCell GetCellFromBlock(byte x, byte y)
        {
            return GetCellFromBlock(Point8.FromXY(x, y));
        }

        /// <summary>
        /// Returns the Cell of this block by System.Drawing.Point.
        /// </summary>
        /// <param name="point"></param>
        /// <returns>MapMeshCell cell</returns>
        public CMapMeshCell GetCellFromBlock(Point8 point)
        {
            return MapCells.ContainsKey(point) ? MapCells[point] : new CMapMeshCell();
        }

        #endregion Methods
    }
}