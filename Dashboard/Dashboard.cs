using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerFrameworkRes.Network.Security;

namespace Dashboard
{
    public partial class Dashboard: UserControl
    {
        internal static ServerData ClientData;
        public Dashboard(ServerData data )
        {
            InitializeComponent();
            ClientData = data;
        }

        private void toolStripStatusLabelAdTopic_Click(object sender, EventArgs e)
        {
            splitContainerDashboardText.Panel2Collapsed = false;
        }
    }
}
