﻿namespace PackFile.Utility
{
    internal interface IPk2Data
    {
        #region Methods

        bool FileExists(string dir);

        bool GetByteArrayByDirectory(string dir, out byte[] file);

        byte[] GetByteArrayByFile(Pk2File file);

        Pk2File GetFileByDirectory(string dir);

        void Read();

        bool Refresh();

        #endregion Methods
    }
}