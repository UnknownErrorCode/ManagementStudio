namespace BinaryFiles.PackFile.Map.o2
{
    [System.Obsolete]
    public class MapObject
    {
        #region Properties

        /// <summary>
        /// Exceeds Region Size.
        /// </summary>
        public byte IsBig { get; set; }

        /// <summary>
        /// Weather the MapObject is static or not. 0 = No, 0xFFFF = Yes.
        /// </summary>
        public ushort IsStatic { get; set; }

        /// <summary>
        /// Defines if MapObject has "objectstring.ifo".
        /// </summary>
        public byte IsStruct { get; set; }

        /// <summary>
        /// ObjectID from "objectinfo.ifo".
        /// </summary>
        public int ObjectID { get; set; }

        /// <summary>
        /// RegionID from MapObject Position.
        /// </summary>
        public ushort RegionID { get; set; }

        /// <summary>
        /// Unique Identify.
        /// </summary>
        public int UID { get; set; }

        /// <summary>
        /// Y Position of MapObject.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Y Position of MapObject.
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Yaw of MapObject.
        /// </summary>
        public float Yaw { get; set; }

        /// <summary>
        /// Z Position of MapObject.
        /// </summary>
        public float Z { get; set; }

        #endregion Properties
    }
}