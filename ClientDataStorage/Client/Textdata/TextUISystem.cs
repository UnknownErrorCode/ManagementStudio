using Structs.Pk2.Media;
using System.Collections.Concurrent;
using System.Linq;

namespace ClientDataStorage.Client.Textdata
{
    /// <summary>
    /// Contains all Text User Interface System elements from Media.pk2.
    /// </summary>
    public class TextUISystem
    {
        /// <summary>
        /// Dictionary of Text User Interface System elements.
        /// </summary>
        public ConcurrentDictionary<string, TextUISystemStruct> UIIT_Strings = new ConcurrentDictionary<string, TextUISystemStruct>();


        public TextUISystem(byte[] file)
            => TextParser.StaticTextParser.ConvertByteArrayToStructedTextArray(file, 10, "\t".ToCharArray()).ToList().ForEach(arr => UIIT_Strings.TryAdd(arr[1], new TextUISystemStruct(arr)));
    }
}
