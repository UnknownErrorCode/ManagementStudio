using Structs.Pk2;

namespace ClientDataStorage.Pk2
{
    public abstract class Pk2Data : IPk2Data
    {

        /// <summary>
        /// Pk2 File contains all information and files from pk2 data
        /// </summary>
        public Pk2Folder Pk2File { get; internal set; }

        /// <summary>
        /// Used to encrypt and decrypt the pk2 stream
        /// </summary>
        private protected Blowfish Blowfish = new Blowfish();

        /// <summary>
        /// This bKey is used to parse the security blowfish of the pk2 File
        /// </summary>
        private protected readonly byte[] bKey  = new byte[] { 0x32, 0xCE, 0xDD, 0x7C, 0xBC, 0xA8 };
       
        /// <summary>
        /// Pk2 data directory 
        /// </summary>
        private protected string Pk2DataPath { get; set; }

        /// <summary>
        /// Read pk2 data with BinaryReader
        /// </summary>
        public abstract void Read();

        /// <summary>
        /// Refreshs the Pk2File of changes
        /// </summary>
        public abstract bool Refresh();
    }
}