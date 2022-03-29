using System.Threading.Tasks;

namespace ServerFrameworkRes.Network.Security
{
    public interface IPacketHandler
    {
        #region Public Methods

        Task<PacketHandlerResult> HandlePacketAction(ServerData data, Packet packet);

        #endregion Public Methods
    }
}