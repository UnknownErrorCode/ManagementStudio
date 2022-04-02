namespace Structs.Pk2.BinaryFiles.JMXRessource.Dungeon
{
    public struct DungeonBlockObjectEntry
    {
        #region Fields

        private string entryPath;
        private uint extraFlag;
        private uint iD;
        private string name;
        public ushort NameLength;
        public ushort EntryPathLength;
        private float pitch;
        private float roll;
        private float scaleHeight;
        private float scaleLength;
        private float scaleWidth;
        private float unk_float0;
        private uint waterExta;
        private float x;
        private float y;
        private float yaw;
        private float z;

        public string EntryPath { get => entryPath; set => entryPath = value; }
        /// <summary>
        /// no byte??
        /// <br> 0x00 = Flames (Torch, Lamps, ect..) </br>
        /// <br> 0x02 = Stones (impassable)</br>
        /// <br> 0x04 =  Water </br>
        /// </summary>
        public uint ExtraFlag { get => extraFlag; set => extraFlag = value; }
        public uint ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public float Pitch { get => pitch; set => pitch = value; }
        public float Roll { get => roll; set => roll = value; }
        public float ScaleHeight { get => scaleHeight; set => scaleHeight = value; }
        public float ScaleLength { get => scaleLength; set => scaleLength = value; }
        public float ScaleWidth { get => scaleWidth; set => scaleWidth = value; }

        /// <summary>
        /// <br>1962.75232 for out_obj_stone</br>
        /// <br>902.9495 for out_obj_door</br>
        /// <br>-3.18711172E+38 and similar for water</br>
        /// </summary>
        public float Unk_float0 { get => unk_float0; set => unk_float0 = value; }
        public uint WaterExta { get => waterExta; set => waterExta = value; }
        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Yaw { get => yaw; set => yaw = value; }
        public float Z { get => z; set => z = value; }

        #endregion Fields
    }
}