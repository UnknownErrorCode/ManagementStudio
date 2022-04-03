namespace BinaryFiles.PackFile
{
    public interface IJMXFile
    {
        JMXHeader Header { get; }
        bool Initialized { get; }

    }
}
