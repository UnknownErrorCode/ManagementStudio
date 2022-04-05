using PackFile.Utility;
using System.Collections.Generic;

namespace PackFile.Media.Textdata
{
    public abstract class TextDataNameData
    {
        #region Fields

        public List<TextDataNameStruct> TextDataNameErrors;

        public Dictionary<string, TextDataNameStruct> TextDataNames;

        internal bool Initialized = true;

        internal TextGroupParser Group = new TextGroupParser();

        #endregion Fields

        #region Constructors

        protected TextDataNameData(byte[] file)
        {
            try
            {
                Group.Read(file);
            }
            catch (System.Exception)
            {
                Initialized = false;
            }
        }

        #endregion Constructors

        //TODO: WHY not static.. Textparser

        #region Methods

        internal void EndLoad()
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

        internal void Merge(string fileName, byte[] array, byte columnSize, char[] splitArray) => Group.Merge(fileName, array, columnSize, splitArray);

        #endregion Methods
    }
}