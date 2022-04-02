namespace PackFile.Data.Dungeon
{
    /// <summary>
    /// Consists of all .dof file paths the GameServer/ShardManager requires to load.
    /// </summary>
    public class DungeonInfo : DungeonInfoData
    {
        #region Constructors

        /// <summary>
        /// Consists of all .dof file paths the GameServer/ShardManager requires to load.
        /// <br>Initialize it with the raw byte[]</br>
        /// </summary>
        /// <param name="file"></param>
        public DungeonInfo(byte[] file) : base(file)
        { }

        #endregion Constructors
    }
}