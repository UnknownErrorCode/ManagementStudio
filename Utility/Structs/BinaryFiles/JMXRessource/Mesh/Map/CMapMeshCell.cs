namespace Structs.BinaryFiles.JMXRessource.Mesh
{
    /// <summary>
    /// Has a <see cref="Height"/>,
    /// <br><see cref="Texture"/> 10 bit texture n 6 bit splash flag</br>
    /// <br><see cref="Brightness"/></br>
    /// </summary>
    public struct CMapMeshCell
    {
        /// <summary>
        /// Height of <see cref="CMapMeshCell"/>.
        /// </summary>
        public float Height;

        /// <summary>
        /// 10 bit texture n 6 bit splash
        /// </summary>
        public ushort Texture;

        /// <summary>
        /// Brightness of <see cref="CMapMeshCell"/>.
        /// </summary>
        public byte Brightness;
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