namespace Structs.Pk2.Data.Dungeon
{
    public struct DungeonInfoStruct
    {
        #region Fields

        /// <summary>
        /// Assigns the .dof file
        /// //TODO: Add .dof file format..
        /// </summary>
        public readonly string DungeonFilePath;

        /// <summary>
        /// int or byte??
        /// </summary>
        public readonly int Index;

        /// <summary>
        /// Weather the dungeon gets load or not.
        /// </summary>
        public readonly bool Service;

        #endregion Fields

        #region Constructors

        public DungeonInfoStruct(string[] array)
        {
            Service = byte.TryParse(array[0], out byte service) ? service == 1 ? true : false : false;
            Index = int.Parse(array[1]);
            DungeonFilePath = array[2].Replace(@"""", "");
        }

        #endregion Constructors
    }
}