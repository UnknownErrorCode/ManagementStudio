using Structs.Pk2.Media;
using System.Collections.Concurrent;
using System.Linq;

namespace ClientDataStorage.Client.Textdata
{
    public class TextUISystem : TextParser
    {
        public  ConcurrentDictionary<string, TextUISystemStruct> UIIT_Strings = new ConcurrentDictionary<string, TextUISystemStruct>();
       
        public TextUISystem()
            => base.ConvertByteArrayToStructedTextArray(Media.MediaPk2.GetByteArrayByFile(Media.MediaPk2.GetFileByDirectory("Media\\server_dep\\silkroad\\textdata\\textuisystem.txt")), 16).ToList().ForEach(arr => UIIT_Strings.TryAdd(arr[1], new TextUISystemStruct(arr)));
    }
}
