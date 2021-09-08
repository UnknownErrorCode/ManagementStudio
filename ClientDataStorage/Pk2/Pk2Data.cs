using Structs.Pk2;

namespace ClientDataStorage.Pk2
{
    public abstract class Pk2Data : IPk2Data
    {


        private protected Pk2Folder Pk2File { get; set; }

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


        public abstract Pk2Folder GetFolder();


        /// <summary>
        /// Read pk2 data with BinaryReader
        /// </summary>
        public abstract void Read();
    }
}