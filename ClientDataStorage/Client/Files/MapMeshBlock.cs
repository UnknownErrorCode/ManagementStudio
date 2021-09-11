using System.Collections.Generic;
using System.Drawing;

namespace ClientDataStorage.Client.Files
{
    public class MapMeshBlock
    {
        //Every MapMesh consists of 6 * 6 = 36 MapMeshBlocks
        public char[] BlockName { get; set; }
        public Dictionary<Point, MapMeshCell> MapCells { get; set; }


        public byte Density { get; set; }     //0x00 = Water, 0x01 = Ice, FF = Solid
        public byte UnkByte0 { get; set; }//related to Block.Density (see screens)
        public float SeaLevel { get; set; }
        public List<KeyValuePair<byte, byte>> ExtraMin { get; set; }
        public float HeightMax { get; set; }
        public float HeightMin { get; set; }
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

        public MapMeshCell GetCellFromBlock(int x, int y)
        {
            System.Drawing.Point p = new System.Drawing.Point(x, y);
            return (MapCells.ContainsKey(p) ? MapCells[p] : null);
        }
    }
}