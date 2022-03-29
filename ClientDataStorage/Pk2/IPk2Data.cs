using Structs.Pk2;

namespace ClientDataStorage.Pk2
{
    internal interface IPk2Data
    {
        bool FileExists(string dir);

        bool GetByteArrayByDirectory(string dir, out byte[] file);

        byte[] GetByteArrayByFile(Pk2File file);

        Pk2File GetFileByDirectory(string dir);

        void Read();

        bool Refresh();
    }
}