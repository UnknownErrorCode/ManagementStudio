using ServerFrameworkRes.BasicControls;
using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementClient.Network
{
    class ClientPacketHandler : PacketHandler
    {

        public ClientPacketHandler()
        {
            base.AddEntry(0xC000, Reply0xC000);
            base.AddEntry(0xC001, Reply0xC001LoginStatus);
        }


        /// <summary>
        /// SERVER_HANDSHAKE 
        /// -- Server sends request to the Client and forces to send login information to the server
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        private PacketHandlerResult Reply0xC000(ServerData arg1, Packet arg2)
        {
            var prove = arg2.ReadAscii();
            if (prove == "RequestAuthentification")
            {
               // Packet requestLogin = new Packet(0x1000);
               // requestLogin.WriteAscii(ClientMemory.LatestAccountName);
               // requestLogin.WriteAscii(ClientMemory.LatestPassword);
               // arg1.m_security.Send(requestLogin);
               // return PacketHandlerResult.Response;
            }
            return PacketHandlerResult.Block;
        }

       private PacketHandlerResult Reply0xC001LoginStatus(ServerData arg1, Packet arg2)
        {
            var ok = arg2.ReadBool();
            var msg = arg2.ReadAscii();
            var securityGroup = int.Parse(arg2.ReadAscii());
            var accountName = arg2.ReadAscii();
            if (ok)
            {
                ClientMemory.LoggedIn = true;
                arg1.AccountName = accountName;
                Program.StaticLoginForm.Invoke( new Action( () => Program.StaticLoginForm.OnHide()));
             //   Program.StaticClientForm.Invoke( new Action( () => Program.StaticClientForm.Show()));
            }
            else
            {
                vSroMessageBox.Show($"Login failed! \n{msg}");
                return PacketHandlerResult.Block;
            }

            return PacketHandlerResult.Block;
        }
    }
}
