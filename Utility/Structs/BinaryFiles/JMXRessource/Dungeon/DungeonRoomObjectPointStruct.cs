namespace Structs.Pk2.BinaryFiles.JMXRessource.Dungeon
{
    public struct DungeonRoomObjectPointStruct
    {
        #region Fields

        public ushort NameLength;

        /// <summary>
        /// also Roll ?
        /// </summary>
        private float float09;

        /// <summary>
        /// also Yaw ??
        /// </summary>
        private float float10;

        /// <summary>
        /// also Pitch ?
        /// </summary>
        private float float11;

        private float float12;
        private float float13;
        private float float14;
        private float height;
        private float length;
        private string name;
        private float pitch;
        private float roll;
        private float width;
        private float x;
        private float y;
        private float yaw;
        private float z;

        #endregion Fields

        #region Properties

        public float Float09 { get => float09; set => float09 = value; }
        public float Float10 { get => float10; set => float10 = value; }
        public float Float11 { get => float11; set => float11 = value; }
        public float Float12 { get => float12; set => float12 = value; }
        public float Float13 { get => float13; set => float13 = value; }
        public float Float14 { get => float14; set => float14 = value; }
        public float Height { get => height; set => height = value; }
        public float Length { get => length; set => length = value; }
        public string Name { get => name; set => name = value; }
        public float Pitch { get => pitch; set => pitch = value; }
        public float Roll { get => roll; set => roll = value; }
        public float Width { get => width; set => width = value; }
        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Yaw { get => yaw; set => yaw = value; }
        public float Z { get => z; set => z = value; }

        #endregion Properties
    }
}