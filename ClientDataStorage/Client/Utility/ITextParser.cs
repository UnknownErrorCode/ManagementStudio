﻿using System;
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
        string ConvertByteArrayToText(byte[] array);

        /// <summary>
        /// Converts one string to an array including all lines.
        /// </summary>
        /// <param name="text">Text of byte array.</param>
        /// <returns>string[] All lines of text</returns>
        string[] ConvertTextToTextArray(string text);

        /// <summary>
        /// Converts an string array including all lines from text file to splitted rows. The minSize indicates the required Count of one Element.
        /// </summary>
        /// <param name="textArrayFromTextArray">String array including all rows.</param>
        /// <param name="minSize">Minimum size of Elements.</param>
        /// <returns> IEnumerable of string[] </returns>
  //      IEnumerable<string[]> ConvertTextArrayToStructedTextArray(string[] textArrayFromTextArray, byte minSize);

        /// <summary>
        /// Converts a byte array to formatted string arrays. The minSize indicates the required Count of one Element
        /// </summary>
        /// <param name="textArrayFromByte">Raw byte array from read file.</param>
        /// <param name="minSize">Minimum size of Elements.</param>
        /// <returns> IEnumerable of string[] </returns>
        IEnumerable<string[]> ConvertByteArrayToStructedTextArray(byte[] textArrayFromByte, byte minSize);
    }
}