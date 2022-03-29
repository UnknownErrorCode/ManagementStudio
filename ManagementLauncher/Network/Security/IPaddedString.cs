namespace ManagementLauncher.Network.Security
{
    public interface IPaddedString : Unmanaged.IMarshalled
    {
        string Value { get; set; }
        int Padding { get; }
    }
}
