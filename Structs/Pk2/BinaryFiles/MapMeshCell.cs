
namespace Structs.Pk2.BinaryFiles
{
    public struct MapMeshCell
    {
        public readonly float Height;
        public readonly ushort texture;
        public readonly byte textureFlag;
        public readonly byte Brightness;

        public MapMeshCell(float f, ushort t, byte tf, byte b)
        {
            Height = f;
            texture = t;
            textureFlag = tf;
            Brightness = b;
        }
    }
}

// BitArray array = new BitArray(BitConverter.GetBytes(textu));
// if (array.Length > 9 && array.Length <= 16)
// {
//     var texturearray = new BitArray(new bool[10] { array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7], array[8], array[9] });
//     int[] iarray = new int[1];
//     texturearray.CopyTo(iarray, 0);
//     texture = (ushort)iarray[0];
// }