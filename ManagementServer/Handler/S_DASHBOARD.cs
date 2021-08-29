using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServer.Handler
{
    class S_DASHBOARD
    {
        internal static PacketHandlerResult TryAddNewTopic(ServerData arg1, Packet arg2)
        {
            var Author =  arg2.ReadAscii();
            var Title = arg2.ReadAscii();
            var Text = arg2.ReadAscii();
            var created = arg2.ReadDateTime();
            var edited = arg2.ReadDateTime();

            if (!Directory.Exists(ServerManager.settings.GuidePath))
                Directory.CreateDirectory(ServerManager.settings.GuidePath).Create();

            if (!File.Exists(Path.Combine(ServerManager.settings.GuidePath,$"{Author}_{Title}.log")))
                File.AppendAllText(Path.Combine(ServerManager.settings.GuidePath, $"{Author}_{Title}.log"), $"{Title}\n\n{Text}\n\nCreated:{created.ToString()}");


            return PacketHandlerResult.Response;
        }
    }
}
