using ManagementFramework.Network.Security;

namespace ManagementFramework.Network.ServerStructs.PaddedString
{
    public interface IPaddedString : Unmanaged.IMarshalled
    {
        #region Properties

        int Padding { get; }
        string Value { get; set; }

        #endregion Properties
    }
}