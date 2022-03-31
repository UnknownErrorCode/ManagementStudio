using BinaryFiles.PackFile.Media.Textdata;

namespace ClientDataStorage.Client
{
    public class Tile2dIFOFile : Tile2dIFOFileData
    {
        #region Fields

        public string[] TexturePaths;

        #endregion Fields

        #region Constructors

        public Tile2dIFOFile(byte[] file) : base(file)
        {
        }

        #endregion Constructors
    }
}