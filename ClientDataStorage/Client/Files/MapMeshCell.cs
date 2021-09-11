using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataStorage.Client.Files
{
    public class MapMeshCell
    {
        public float Height { get; }
        public ushort texture { get; }
        public byte textureFlag { get; }
        public byte Brightness { get; }


        public MapMeshCell(float f, ushort textu, byte Bright)
        {
            Height = f;
            //texture = textu;
            Brightness = Bright;
            BitArray array = new BitArray(BitConverter.GetBytes(textu));
            if (array.Length>9 && array.Length<=16)
            {
                BitArray texturearray = new BitArray(new bool[10] { array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7], array[8], array[9] });

                int[] iarray = new int[1];
                texturearray.CopyTo(iarray, 0);
                texture = (ushort) iarray[0];
                if (texture>255)
                {

                }
            }
     
        }
    }
}
