
namespace BinaryFiles.PackFile.Data.Dungeon
{
    public struct DungeonRoomObjectEntry
    {
        #region Fields

        public string EPath;

        /// <summary>
        /// no byte??
        /// <br> 0x00 = Flames (Torch, Lamps, ect..) </br>
        /// <br> 0x02 = Stones (impassable)</br>
        /// <br> 0x04 =  Water </br>
        /// </summary>
        public uint extraFlag;

        public uint ID;
        public string Name;
        public ushort NameLength;
        public ushort PathLength;
        public float Pitch;
        public float Roll;
        public float ScaleHeight;
        public float ScaleLength;
        public float ScaleWidth;

        /// <summary>
        /// <br>1962.75232 for out_obj_stone</br>
        /// <br>902.9495 for out_obj_door</br>
        /// <br>-3.18711172E+38 and similar for water</br>
        /// </summary>
        public float unk_float0;

        public uint waterExta;
        public float X;
        public float Y;
        public float Yaw;
        public float Z;

        #endregion Fields
    }
}