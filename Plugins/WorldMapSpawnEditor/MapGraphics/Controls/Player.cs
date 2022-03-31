namespace WorldMapSpawnEditor.MapGraphics
{
    internal class Player : Spawn
    {
        #region Fields

        private readonly int charID;
        private readonly string charName16;
        private readonly byte curLevel;
        private readonly int hP;
        private readonly int mP;

        #endregion Fields

        #region Constructors

        public Player(int _charID) : base(ClientDataStorage.Database.SRO_VT_SHARD._Char[_charID])
        {
            var charResult = ClientDataStorage.Database.SRO_VT_SHARD._Char[_charID];
            charID = charResult.CharID;
            charName16 = charResult.CharName16;
            curLevel = charResult.CurLevel;
            hP = charResult.HP;
            mP = charResult.MP;
        }

        #endregion Constructors

        #region Properties

        internal int CharID => charID;
        internal string CharName16 => charName16;
        internal virtual byte CurLevel => curLevel;
        internal int HP => hP;
        internal int MP => mP;

        #endregion Properties
    }
}