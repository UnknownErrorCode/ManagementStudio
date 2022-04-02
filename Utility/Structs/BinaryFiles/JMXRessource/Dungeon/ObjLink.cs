namespace Structs.Pk2.BinaryFiles.JMXRessource.Dungeon
{
    public struct ObjLink
    {
        #region Fields

        private uint linkID;

        private uint[] links;

        #endregion Fields

        #region Constructors

        public ObjLink(uint id, uint[] _links)
        {
            linkID = id;
            links = _links;
        }

        #endregion Constructors

        #region Properties

        public int LinkCount { get => Links.Length; }
        public uint[] Links { get => links; set => links = value; }
        public uint LinkID { get => linkID; set => linkID = value; }

        #endregion Properties
    }
}