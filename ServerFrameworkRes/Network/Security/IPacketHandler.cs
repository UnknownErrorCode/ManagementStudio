using System.Threading.Tasks;

namespace ServerFrameworkRes.Network.Security
{
    public interface IPacketHandler
    {
        #region Methods

        Task<PacketHandlerResult> HandlePacketAction(ServerData data, Packet packet);

        #endregion Methods
    }
}