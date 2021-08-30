using ServerFrameworkRes.BasicControls;
using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementClient.CHandler
{
    class LoginHandler
    {
        internal static PacketHandlerResult LoginStatus(ServerData arg1, Packet arg2)
        {
            var ok = arg2.ReadBool();
            var msg = arg2.ReadAscii();
            var securityGroup = int.Parse(arg2.ReadAscii());
            var accountName = arg2.ReadAscii();
            if (ok)
            {
                ClientMemory.LoggedIn = true;
                arg1.AccountName = accountName;
                Program.StaticLoginForm.Invoke(new Action(() => Program.StaticLoginForm.OnHide()));
            }
            else
                vSroMessageBox.Show($"Login failed! \n{msg}");


            return PacketHandlerResult.Block;
        }
    }
}
