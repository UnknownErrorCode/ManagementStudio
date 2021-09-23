using Structs.Pk2.Media;
using System.Collections.Concurrent;
using System.Linq;

namespace ClientDataStorage.Client.Textdata
{
    /// <summary>
    /// Contains all Text User Interface System elements from Media.pk2.
    /// </summary>
    public class TextUISystem : TextParser
    {
        /// <summary>
        /// Dictionary of Text User Interface System elements.
        /// </summary>
        public ConcurrentDictionary<string, TextUISystemStruct> UIIT_Strings = new ConcurrentDictionary<string, TextUISystemStruct>();

        public TextUISystem()
        {
            if (Media.MediaPk2.GetByteArrayByDirectory("Media\\server_dep\\silkroad\\textdata\\textuisystem.txt", out byte[] file))
            {
                base.ConvertByteArrayToStructedTextArray(file, 16, "\t".ToCharArray()).ToList().ForEach(arr => UIIT_Strings.TryAdd(arr[1], new TextUISystemStruct(arr)));
            }
        }

        public TextUISystem(byte[] file)
            => base.ConvertByteArrayToStructedTextArray(file, 16, "\t".ToCharArray()).ToList().ForEach(arr => UIIT_Strings.TryAdd(arr[1], new TextUISystemStruct(arr)));
    }
}
