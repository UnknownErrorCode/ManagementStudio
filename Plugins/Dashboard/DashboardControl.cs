using ClientDataStorage.Dashboard;
using ServerFrameworkRes.BasicControls;
using ServerFrameworkRes.Network.Security;
using Structs.Dashboard;
using Structs.Tool;
using System;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class DashboardControl : UserControl
    {

        private const string STRING_DLL = "Dashboard.dll";
        private const PluginData PLUGINDATA = PluginData.SkillEditor;

        #region Public Constructors

        public DashboardControl()
        {
            InitializeComponent();

            ClientDataStorage.ClientCore.AddEntry(PacketID.Server.TopicLoadResponse, TopicReceiveExisting);
            ClientDataStorage.ClientCore.AddEntry(PacketID.Server.TopicAddResponse, TopicReceiveNew);
            ClientDataStorage.ClientCore.AddEntry(PacketID.Server.TopicsEndLoading, TopicsFinishedLoading);
            ClientDataStorage.ClientCore.AddEntry(PacketID.Server.TopicDeleteResponse, TopicDeleteResponse);

            ClientDataStorage.ClientCore.AddEntry(PacketID.Server.UserLogOnOff, UserLogOnOff);

            ClientDataStorage.ClientCore.Send(DashboardPackets.RequestAllTopics);
            ClientDataStorage.ClientCore.Send(DashboardPackets.RequestOnlineUser);
        }

        private PacketHandlerResult UserLogOnOff(ServerData arg1, Packet arg2)
        {
            var count = arg2.ReadInt();
            for (int i = 0; i < count; i++)
            {
                var login = arg2.ReadBool();
                var user = arg2.ReadAscii();
                if (login)
                    vSroButtonListOnlineUser.Invoke(new Action(() => vSroButtonListOnlineUser.AddSingleButtonToList(user)));
                else
                    vSroButtonListOnlineUser.Invoke(new Action(() => vSroButtonListOnlineUser.RemoveSingleButtonFromList(user)));

            }
            return PacketHandlerResult.Block;
        }

        #endregion Public Constructors

        #region Private Methods

        private void addNewTopicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (DashboardTopicEditor editor = new DashboardTopicEditor(ClientDataStorage.ClientMemory.AccountName))
            {
                editor.ShowDialog();
            }
        }

        private void deleteShownTopicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vSroButtonList1.LatestSelectedButton != null)
            {
                DashboardMessage messageToDelete = (DashboardMessage)vSroButtonList1.LatestSelectedButton.Tag;

                ClientDataStorage.ClientCore.Send(DashboardPackets.RequestDeleteTopicFromDashboard(messageToDelete));
            }
        }

        private void editShownTopicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vSroButtonList1.LatestSelectedButton != null)
            {
                using (DashboardTopicEditor editor = new DashboardTopicEditor((DashboardMessage)vSroButtonList1.LatestSelectedButton.Tag))
                {
                    editor.ShowDialog();
                }
            }
        }

        private void vSroButtonList1_OnIndCh(object sender, EventArgs e)
        {
            DashboardMessage msg = (DashboardMessage)((vSroListButton)sender).Tag;
            Invoke(new Action(() =>
            {
                labelAuthor.Text = msg.Author;
                labelTopic.Text = msg.Title;
                labelText.Text = msg.Text;
            }));
        }

        #endregion Private Methods
    }
}