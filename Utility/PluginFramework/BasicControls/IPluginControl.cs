using ManagementFramework.Network.Security;
using Structs.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginFramework.BasicControls
{
    public interface IPluginControl
    {
        PluginData PLUGINDATA { get; set; }
        Packet RequestDataPacket { get; }
        string STRING_DLL { get; set; }

        void InitializePlugin();

        PacketHandlerResult OnDataReceive(ServerData arg1, Packet arg2);
    }
}