namespace Structs.Pk2.BinaryFiles.JMXRessource.Dungeon
{
    public struct DungeonRoomObjectGroop
    {
        #region Fields

        /// <summary>
        /// service?
        /// </summary>
        private uint flag;

        private string name;
        private uint objArrayCount;
        private uint[] objIndexArray;


        /// <summary>
        /// Service probably?
        /// </summary>
        public uint Flag { get => flag; set => flag = value; }
        public string Name { get => name; set => name = value; }
        public uint ObjArrayCount { get => objArrayCount; set => objArrayCount = value; }
        public uint[] ObjIndexArray { get => objIndexArray; set => objIndexArray = value; }

        #endregion Fields
    }
}