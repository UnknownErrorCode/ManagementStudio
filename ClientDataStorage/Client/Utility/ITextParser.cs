using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataStorage.Client.Textdata
{
    internal interface ITextParser
    {   
        /// <summary>
        /// Converts a byte array to one string.
        /// </summary>
        /// <param name="array">The pure byte array.</param>
        /// <returns>string Text of file</returns>
        string ConvertByteArrayToUnicodeText(byte[] array);

        /// <summary>
        /// Converts the raw byte[] from file to string[] consisting of each line from text file.
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <returns>string[] All lines from file.</returns>
        string[] ConvertByteArrayToTextArray(byte[] sourceFile);

        /// <summary>
        /// Converts one string to an array including all lines.
        /// </summary>
        /// <param name="text">Text of byte array.</param>
        /// <returns>string[] All lines of text</returns>
        string[] ConvertTextToTextArray(string text);

        /// <summary>
        /// Converts a byte array to formatted string arrays. The minSize indicates the required Count of one Element
        /// </summary>
        /// <param name="textArrayFromByte">Raw byte array from read file.</param>
        /// <param name="minSize">Minimum size of Elements.</param>
        /// <returns> IEnumerable of string[] </returns>
        IEnumerable<string[]> ConvertByteArrayToStructedTextArray(byte[] textArrayFromByte, byte minSize, char[] splitCharArray);
    }
}
