using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataStorage.Client.Textdata
{
    public abstract class TextParser : TextArrayFormatter, ITextParser
    {
        public string ConvertByteArrayToText(byte[] array)
            => Encoding.ASCII.GetString(array);

        public string[] ConvertTextToTextArray(string text)
            => text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Where(str => !str.StartsWith("//")).ToArray();

        public IEnumerable<string[]> ConvertTextArrayToStructedText(string[] textArray, byte minSize, char[] splitCharakterArray) 
            => (IEnumerable<string[]>)base.ConvertTextArrayToStructuredTextArray(textArray, minSize, splitCharakterArray);

        public IEnumerable<string[]> ConvertByteArrayToStructedTextArray(byte[] byteArray, byte minSize, char[] splitCharakterArray)
            => ConvertTextArrayToStructedText(ConvertTextToTextArray(ConvertByteArrayToText(byteArray)), minSize, splitCharakterArray);
    }
}
