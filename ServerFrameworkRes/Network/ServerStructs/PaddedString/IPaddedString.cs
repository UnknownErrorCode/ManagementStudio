using ServerFrameworkRes.Network.Security;

namespace ServerFrameworkRes.Network.ServerStructs.PaddedString
{
    public interface IPaddedString : Unmanaged.IMarshalled
    {
        #region Properties

        int Padding { get; }
        string Value { get; set; }

        #endregion Properties
    }
}