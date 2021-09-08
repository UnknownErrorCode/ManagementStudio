using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataStorage.Client.Textdata
{
    internal interface ITextParser
    {
        string ConvertByteArrayToText(byte[] array);
        string[] ConvertTextToTextArray(string text);
        IEnumerable<string[]> ConvertTextArrayToStructedTextArray(string[] textArrayFromTextArray, byte minSize);
        IEnumerable<string[]> ConvertByteArrayToStructedTextArray(byte[] textArrayFromByte, byte minSize);
    }
}
