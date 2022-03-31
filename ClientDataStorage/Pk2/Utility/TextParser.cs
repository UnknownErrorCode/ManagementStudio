using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientDataStorage.Client.Textdata
{
    public class TextParser : TextArrayFormatter, ITextParser
    {
        #region Fields

        public static TextParser StaticTextParser = new TextParser();

        #endregion Fields

        #region Methods

        public string ConvertByteArrayToAsciiText(byte[] array)
        {
            return Encoding.ASCII.GetString(array);
        }

        public IEnumerable<string[]> ConvertByteArrayToStructedTextArray(byte[] byteArray, byte minSize, char[] splitCharakterArray)
        {
            return ConvertTextArrayToStructedText(ConvertTextToTextArray(ConvertByteArrayToUnicodeText(byteArray)), minSize, splitCharakterArray);
        }

        public string[] ConvertByteArrayToTextArray(byte[] sourceFile)
        {
            return ConvertTextToTextArray(ConvertByteArrayToUnicodeText(sourceFile));
        }

        public string ConvertByteArrayToUnicodeText(byte[] array)
        {
            return Encoding.Unicode.GetString(array);
        }

        public IEnumerable<string[]> ConvertTextArrayToStructedText(string[] textArray, byte minSize, char[] splitCharakterArray)
        {
            return base.ConvertTextArrayToStructuredTextArray(textArray, minSize, splitCharakterArray);
        }

        public string[] ConvertTextToTextArray(string text)
        {
            return text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Where(str => !str.StartsWith("//")).ToArray();
        }

        #endregion Methods
    }
}