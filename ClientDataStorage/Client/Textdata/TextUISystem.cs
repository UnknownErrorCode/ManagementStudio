using Structs.Pk2.Media;
using System.Collections.Concurrent;
using System.Linq;

namespace ClientDataStorage.Client.Textdata
{
    public class TextUISystem : TextParser
    {
        public ConcurrentDictionary<string, TextUISystemStruct> UIIT_Strings = new ConcurrentDictionary<string, TextUISystemStruct>();

        public TextUISystem()
        {
            var t1 = Media.MediaPk2.GetFileByDirectory("Media\\server_dep\\silkroad\\textdata\\textuisystem.txt");
            var t2 = Media.MediaPk2.GetByteArrayByFile(t1);


            var t3 = base.ConvertByteArrayToStructedTextArray(t2, 16, "\t".ToCharArray()).ToList();
            t3.ForEach(arr => UIIT_Strings.TryAdd(arr[1], new TextUISystemStruct(arr)));

        }
    }
}
