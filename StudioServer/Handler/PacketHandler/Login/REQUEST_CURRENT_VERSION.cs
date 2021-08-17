using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Handler.PacketHandler.Login
{
    class REQUEST_CURRENT_VERSION
    {
        public static Packet VersionSame(Packet packet, SecurityManager incomeSocketData)
        {
            var version = packet.ReadInt();
            if (version != StudioServer.settings.Version)//not CurrentVersion
            {
                packet = new Packet(0xD011);
                packet.WriteInt(StudioServer.settings.Version);
                packet.WriteAscii($"Your version '{version}' is incompatible,please launch vSroStudioLauncher to get the newest version: {StudioServer.settings.Version}");
                return packet;
               
            }
            else
            {
                packet = new Packet(0xD011);
                packet.WriteInt(version);
                packet.WriteAscii($"Successfully load vSroStudio v.{version}");
                return packet;
            }
          
        }

       
    }
}
