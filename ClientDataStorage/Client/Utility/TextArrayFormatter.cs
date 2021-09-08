using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataStorage.Client.Textdata
{
    public abstract class TextArrayFormatter
    {
        internal IEnumerator<string[]> ConvertTextArrayToStructuredTextArray(string[] array, byte minSize)
        {
            var FormattedStringArray = new List<string[]>();
            for (int i = 0; i < array.Length; i++)
                if (array[i].Split('\t').Length >= minSize)
                    FormattedStringArray.Add(array[i].Split('\t'));

            return FormattedStringArray.GetEnumerator();
        }
    }
}
