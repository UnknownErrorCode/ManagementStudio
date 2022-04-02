using PackFile.Utility;
using System.Collections.Concurrent;
using System.Linq;

namespace PackFile.Media.Textdata
{
    /// <summary>
    /// Contains all Text User Interface System elements from Media.pk2.
    /// </summary>
    public abstract class TextUISystemData
    {
        #region Fields

        /// <summary>
        /// Dictionary of Text User Interface System elements.
        /// </summary>
        public ConcurrentDictionary<string, TextUISystemStruct> UIIT_Strings = new ConcurrentDictionary<string, TextUISystemStruct>();

        internal readonly bool Initialized = true;

        #endregion Fields

        #region Constructors

        public TextUISystemData(byte[] file)
        {
            try
            {
                TextParser.ConvertByteArrayToStructedTextArray(file, 10, "\t".ToCharArray()).ToList().ForEach(arr => UIIT_Strings.TryAdd(arr[1], new TextUISystemStruct(arr)));
            }
            catch (System.Exception)
            {
                Initialized = false;
            }
        }

        #endregion Constructors
    }
}