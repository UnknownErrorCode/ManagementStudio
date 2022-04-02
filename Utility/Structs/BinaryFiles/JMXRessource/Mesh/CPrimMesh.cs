namespace Structs.Pk2.BinaryFiles.JMXRessource
{
    public struct CPrimMesh
    {
        #region Properties

        public string MeshPath;
        public uint MeshPathLength;

        /// <summary>
        /// If (header.Int0 & 1)    =>   this->dword310 = 1
        /// </summary>
        public uint meshUnkUInt0;

        #endregion Properties
    }
}