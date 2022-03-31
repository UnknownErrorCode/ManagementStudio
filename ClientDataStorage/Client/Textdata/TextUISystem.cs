using BinaryFiles.PackFile.Media.Textdata;

namespace ClientDataStorage.Client.Textdata
{
    /// <summary>
    /// Contains all Text User Interface System elements from Media.pk2.
    /// </summary>
    public class TextUISystem : TextUISystemData
    {
        #region Constructors

        /// <summary>
        /// TextUISystem from Media.pk2
        /// </summary>
        public TextUISystem(byte[] file) : base(file)
        {
        }

        #endregion Constructors
    }
}