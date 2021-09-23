using Structs.Pk2;

namespace ClientDataStorage.Pk2
{
    internal interface IPk2Data
    {
        void Read();
        bool Refresh();
        bool FileExists(string dir);
        Pk2File GetFileByDirectory(string dir);
        byte[] GetByteArrayByFile(Pk2File file);
        bool GetByteArrayByDirectory(string dir, out byte[] file);
    }
}