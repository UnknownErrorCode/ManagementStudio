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

        private void SaveTopic()
        {
            if (textBoxTopic.TextLength == 0)
                return;
            if (richTextBoxEditTopicText.TextLength == 0)
                return;

            ClientData.m_security.Send(DashboardPackets.AddTopicToDashboard(DashboardMessage.CreateDashboardMessage(textBoxTopic.Text, richTextBoxEditTopicText.Text, ClientData.AccountName)));
        }
    }
}
