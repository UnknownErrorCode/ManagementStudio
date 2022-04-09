using System.Threading.Tasks;

namespace ManagementFramework.Network.Security
{
    public interface IPacketHandler
    {
        #region Methods

        Task<PacketHandlerResult> HandlePacketAction(ServerData data, Packet packet);

        #endregion Methods
    }
}