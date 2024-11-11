using Structs.Pk2.BinaryFiles.JMXRessource;
using System;

namespace Structs.BinaryFiles
{
    public struct ObjectStringIFOStruct
    {
        public int ID1 { get; private set; }
        public int ID2 { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public float PosX { get; private set; }
        public float PosY { get; private set; }
        public float PosZ { get; private set; }
        public float Rotation { get; private set; }
        public string Name { get; private set; }

        public ObjectStringIFOStruct(string[] array)
        {
            if (array.Length < 9)
                throw new ArgumentException("Array length must be 9.");

            byte[] rawX = new byte[array[4].Replace("0x", "").Length / 2];
            byte[] rawY = new byte[array[6].Replace("0x", "").Length / 2];

            ID1 = Convert.ToInt32(array[0], 16);
            ID2 = Convert.ToInt32(array[1], 16);
            X = int.Parse(array[2]);
            Y = int.Parse(array[3]);
            PosX = BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToUInt32(array[4], 16)), 0);
            PosY = BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToUInt32(array[5], 16)), 0);
            PosZ = BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToUInt32(array[6], 16)), 0);
            Rotation = BitConverter.ToSingle(BitConverter.GetBytes(Convert.ToUInt32(array[7], 16)), 0);
            Name = array[8];
        }
    }
}
