using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackFile.Utility
{
    internal static class TextParser
    {
        #region Methods

        /// <summary>
        /// Converts a byte array to one Ascii encrypted string.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        internal static string ConvertByteArrayToAsciiText(byte[] array)
        {
            return Encoding.ASCII.GetString(array);
        }

        /// <summary>
        /// Converts a byte array to formatted string arrays. The minSize indicates the required Count of one Element
        /// </summary>
        /// <param name="textArrayFromByte">Raw byte array from read file.</param>
        /// <param name="minSize">Minimum size of Elements.</param>
        /// <returns> IEnumerable of string[] </returns>
        internal static IEnumerable<string[]> ConvertByteArrayToStructedTextArray(byte[] byteArray, byte minSize, char[] splitCharakterArray)
        {
            return ConvertTextArrayToStructedText(ConvertTextToTextArray(ConvertByteArrayToUnicodeText(byteArray)), minSize, splitCharakterArray);
        }

        /// <summary>
        /// Converts a byte array to formatted string arrays.
        /// <br>The minSize indicates the required Count of one Element</br>
        /// <br>The  <paramref name="splitCharakterString"/> gets converted to an <see cref="char"/> array. </br>
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="minSize"></param>
        /// <param name="splitCharakterString"></param>
        /// <returns></returns>
        internal static IEnumerable<string[]> ConvertByteArrayToStructedTextArray(byte[] byteArray, byte minSize, string splitCharakterString)
        {
            return ConvertByteArrayToStructedTextArray(byteArray, minSize, splitCharakterString.ToCharArray());
        }

        /// <summary>
        /// Converts the raw byte[] from file to string[] consisting of each line from text file.
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <returns>string[] All lines from file.</returns>
        internal static string[] ConvertByteArrayToTextArray(byte[] sourceFile)
        {
            return ConvertTextToTextArray(ConvertByteArrayToUnicodeText(sourceFile));
        }

        /// <summary>
        /// Converts a byte array to one unicode encrypted string.
        /// </summary>
        /// <param name="array">The pure byte array.</param>
        /// <returns>string Text of file</returns>
        internal static string ConvertByteArrayToUnicodeText(byte[] array)
        {
            return Encoding.Unicode.GetString(array);
        }

        internal static IEnumerable<string[]> ConvertTextArrayToStructedText(string[] textArray, byte minSize, char[] splitCharakterArray)
        {
            return TextArrayFormatter.ConvertTextArrayToStructuredTextArray(textArray, minSize, splitCharakterArray);
        }

        /// <summary>
        /// Converts one string to an array including all lines.
        /// </summary>
        /// <param name="text">Text of byte array.</param>
        /// <returns>string[] All lines of text</returns>
        internal static string[] ConvertTextToTextArray(string text)
        {
            return text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Where(str => !str.StartsWith("//")).ToArray();
        }

        #endregion Methods
    }
}