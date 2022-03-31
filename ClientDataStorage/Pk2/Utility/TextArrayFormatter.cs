using System.Collections.Generic;
using System.Linq;

namespace ClientDataStorage.Client.Textdata
{
    public abstract class TextArrayFormatter
    {
        #region Methods

        /// <summary>
        /// Converts a string[] including each row of the binary file and returns all elements with minimum column size.
        /// </summary>
        /// <param name="array">The string after NewLine split</param>
        /// <param name="minSize">Minimum Array Length</param>
        /// <returns>IEnumerator<string[]> Formatted Strings</returns>
        internal IEnumerable<string[]> ConvertTextArrayToStructuredTextArray(string[] array, byte minSize, char[] splitCharakterArray)
        {
            List<string[]> FormattedStringArray = new List<string[]>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Split(splitCharakterArray).Length >= minSize)
                {
                    FormattedStringArray.Add(array[i].Split(splitCharakterArray));
                }
            }

            return FormattedStringArray.AsEnumerable();
        }

        #endregion Methods
    }
}