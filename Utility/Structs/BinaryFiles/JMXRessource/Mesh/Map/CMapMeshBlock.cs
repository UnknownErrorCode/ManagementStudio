using System.Collections.Generic;

namespace Structs.BinaryFiles.JMXRessource.Mesh
{
    /// <summary>
    /// Consists of various water and higth information.
    /// <br>17 * 17 <see cref="CMapMeshCell"/></br>
    /// <br>16 * 16 <see cref="CMapMeshTile"/></br>
    /// </summary>
    public struct CMapMeshBlock
    {
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
    }
}