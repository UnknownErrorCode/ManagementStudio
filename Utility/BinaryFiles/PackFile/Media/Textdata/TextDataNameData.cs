using BinaryFiles.Utility;
using Structs.Pk2.Media;
using System.Collections.Generic;

namespace BinaryFiles.PackFile.Media.Textdata
{
    public abstract class TextDataNameData
    {
        #region Fields

        // TODO: Thy no static?
        public TextGroupParser Group = new TextGroupParser();

        public List<TextDataNameStruct> TextDataNameErrors;
        public Dictionary<string, TextDataNameStruct> TextDataNames;

        #endregion Fields

        #region Constructors

        protected TextDataNameData(byte[] file) => Group.Read(file);

        #endregion Constructors

        //TODO: WHY not static.. Textparser

        #region Methods

        public void EndLoad()
        {
            TextDataNames = new Dictionary<string, TextDataNameStruct>();
            foreach (var item in Group.GroupFiles.Values)
            {
                foreach (var udata in item)
                {
                    var data = new TextDataNameStruct(udata);

                    if (TextDataNames.ContainsKey(data.Code))
                    {
                        TextDataNameErrors.Add(data);
                    }
                    else
                    {
                        TextDataNames.Add(data.Code, data);
                    }
                }
            }
        }

        public void Merge(string fileName, byte[] array, byte columnSize, char[] splitArray) => Group.Merge(fileName, array, columnSize, splitArray);

        #endregion Methods
    }
}