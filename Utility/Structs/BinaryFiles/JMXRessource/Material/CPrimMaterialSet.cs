namespace Structs.Pk2.BinaryFiles.JMXRessource
{
    public struct CPrimMaterialSet
    {
        #region Fields

        private uint materialID;
        private string materialPath;

        #endregion Fields

        #region Properties

        public uint MaterialID { get => materialID; set => materialID = value; }
        public string MaterialPath { get => materialPath; set => materialPath = value; }

        #endregion Properties
    }
}