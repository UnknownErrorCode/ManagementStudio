using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientDataStorage.Client.Textdata
{
    public class TextParser : TextArrayFormatter, ITextParser
    {
        public static TextParser StaticTextParser = new TextParser();
        public string ConvertByteArrayToUnicodeText(byte[] array)
            => Encoding.Unicode.GetString(array);
        public string ConvertByteArrayToAsciiText(byte[] array)
            => Encoding.ASCII.GetString(array);

        public string[] ConvertTextToTextArray(string text)
            => text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Where(str => !str.StartsWith("//")).ToArray();

        public string[] ConvertByteArrayToTextArray(byte[] sourceFile)
            => ConvertTextToTextArray(ConvertByteArrayToUnicodeText(sourceFile));

        public IEnumerable<string[]> ConvertTextArrayToStructedText(string[] textArray, byte minSize, char[] splitCharakterArray)
            => (IEnumerable<string[]>)base.ConvertTextArrayToStructuredTextArray(textArray, minSize, splitCharakterArray);

        public IEnumerable<string[]> ConvertByteArrayToStructedTextArray(byte[] byteArray, byte minSize, char[] splitCharakterArray)
            => ConvertTextArrayToStructedText(ConvertTextToTextArray(ConvertByteArrayToUnicodeText(byteArray)), minSize, splitCharakterArray);
    }
}
