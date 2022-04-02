namespace Structs.Pk2.BinaryFiles.JMXRessource.Dungeon
{
    public struct DungeonRoomObjectLink
    {
        #region Fields

        private uint connectionCount;
        private uint[] connectionList;
        private uint iD;

        public uint ConnectionCount { get => connectionCount; set => connectionCount = value; }
        public uint[] ConnectionList { get => connectionList; set => connectionList = value; }
        public uint ID { get => iD; set => iD = value; }

        #endregion Fields
    }
}