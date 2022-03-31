using BinaryFiles.PackFile.Media.Textdata;

namespace ClientDataStorage.Client.Textdata
{
    public class TextDataName : TextDataNameData
    {
        #region Constructors

        public TextDataName(byte[] array) : base(array)
        {
            foreach (var item in Group.GroupFiles.Keys)
            {
                if (Media.MediaPk2.GetByteArrayByDirectory($"Media\\server_dep\\silkroad\\textdata\\{item}", out byte[] member))
                    Merge(item, member, 9, "\t".ToCharArray());
            }
            EndLoad();
        }

        #endregion Constructors
    }
}