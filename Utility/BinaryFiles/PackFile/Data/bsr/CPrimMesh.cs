namespace BinaryFiles.PackFile.Data.bsr
{
    public class CPrimMesh
    {
        #region Properties

        public string MeshPath { get; set; }
        public uint MeshPathLength { get; set; }

        /// <summary>
        /// If (header.Int0 & 1)    =>   this->dword310 = 1
        /// </summary>
        public uint meshUnkUInt0 { get; set; }

        #endregion Properties
    }
}