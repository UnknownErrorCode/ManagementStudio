using Structs.Pk2;

namespace ClientDataStorage.Pk2
{
    public abstract class Pk2Data : IPk2Data
    {
        #region Fields

        /// <summary>
        /// Used to encrypt and decrypt the pk2 stream
        /// </summary>
        internal Blowfish Blowfish = new Blowfish();

        /// <summary>
        /// This bKey is used to parse the security blowfish of the pk2 File
        /// </summary>
        protected readonly byte[] bKey = new byte[] { 0x32, 0xCE, 0xDD, 0x7C, 0xBC, 0xA8 };

        #endregion Fields

        #region Properties

        /// <summary>
        /// Pk2 File contains all information and files from pk2 data
        /// </summary>
        public Pk2Folder Pk2File { get; internal set; }

        /// <summary>
        /// Pk2 data directory
        /// </summary>
        protected string Pk2DataPath { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Check if file exists in certain pk2 data.
        /// </summary>
        /// <param name="dir">Directory of file inside the pk2 data.</param>
        /// <returns>bool exists</returns>
        public abstract bool FileExists(string dir);

        /// <summary>
        /// Seek the file by directory and returns it as raw byte array
        /// </summary>
        /// <param name="directory">Directory of the file inside the pk2 data.</param>
        /// <param name="fileArray">out byte[] array</param>
        /// <returns>byte[] raw array</returns>
        public abstract bool GetByteArrayByDirectory(string dir, out byte[] file);

        /// <summary>
        /// Returns file as byte array with parameter Pk2File.
        /// </summary>
        /// <param name="file">Pk2File from Pk2Data.</param>
        /// <returns>byte[] : Raw bytes from Pk2File. </returns>
        public abstract byte[] GetByteArrayByFile(Pk2File file);

        /// <summary>
        /// Returns file by directory of pk2 file.
        /// </summary>
        /// <param name="dir"></param>
        /// <returns>Pk2File from FolderDirectory</returns>
        public abstract Pk2File GetFileByDirectory(string dir);

        /// <summary>
        /// Read pk2 data with BinaryReader
        /// </summary>
        public abstract void Read();

        /// <summary>
        /// Refreshs the Pk2File of changes
        /// </summary>
        public abstract bool Refresh();

        #endregion Methods
    }
}