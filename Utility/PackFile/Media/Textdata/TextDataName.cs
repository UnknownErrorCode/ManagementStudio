namespace PackFile.Media.Textdata
{
    public class TextDataName : TextDataNameData
    {

        #region Constructors

        public TextDataName(byte[] array) : base(array)
        {
            try
            {
                foreach (var item in Group.GroupFiles.Keys)
                {
                    if (MediaPack.Reader.GetByteArrayByDirectory($"Media\\server_dep\\silkroad\\textdata\\{item}", out byte[] member))
                        Merge(item, member, 9, "\t".ToCharArray());
                }
                EndLoad();
            }
            catch (System.Exception)
            {
                Initialized = false;
            }
        }

        #endregion Constructors
    }
}