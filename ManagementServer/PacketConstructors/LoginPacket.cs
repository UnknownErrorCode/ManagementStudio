using ServerFrameworkRes.Network.Security;
using Structs.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementServer.PacketConstructors
{
    class LoginPacket
    {

        internal static Packet Status(LoginStatus status)
        {
            var LoginStatus = new Packet(PacketID.Server.LoginStatus, false, true);
            LoginStatus.WriteStruct(status);
         // LoginStatus.WriteBool(success);
         // LoginStatus.WriteAscii(notify);
         // LoginStatus.WriteAscii(securityGroup);
         // LoginStatus.WriteAscii(accName);
            return LoginStatus;
        }
    }
}
