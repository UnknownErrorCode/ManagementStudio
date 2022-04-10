using PluginFramework.Dashboard;
using ManagementFramework.BasicControls;
using ManagementFramework.Network.Security;
using Structs.Dashboard;
using Structs.Tool;
using System;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class DashboardControl : UserControl
    {
        #region Fields

        private const PluginData PLUGINDATA = PluginData.SkillEditor;
        private const string STRING_DLL = "Dashboard.dll";

        #endregion Fields

        #region Constructors

        public DashboardControl()
        {
            InitializeComponent();

            PluginFramework.ClientCore.AddEntry(PacketID.Server.TopicLoadResponse, TopicReceiveExisting);
            PluginFramework.ClientCore.AddEntry(PacketID.Server.TopicAddResponse, TopicReceiveNew);
            PluginFramework.ClientCore.AddEntry(PacketID.Server.TopicsEndLoading, TopicsFinishedLoading);
            PluginFramework.ClientCore.AddEntry(PacketID.Server.TopicDeleteResponse, TopicDeleteResponse);

            PluginFramework.ClientCore.AddEntry(PacketID.Server.UserLogOnOff, UserLogOnOff);

            PluginFramework.ClientCore.Send(DashboardPackets.RequestAllTopics);
            PluginFramework.ClientCore.Send(DashboardPackets.RequestOnlineUser);
        }

        #endregion Constructors

        #region Methods

        private void addNewTopicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (DashboardTopicEditor editor = new DashboardTopicEditor(PluginFramework.ClientMemory.AccountName))
            {
                editor.ShowDialog();
            }
        }

        private void deleteShownTopicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vSroButtonList1.LatestSelectedButton != null)
            {
                DashboardMessage messageToDelete = (DashboardMessage)vSroButtonList1.LatestSelectedButton.Tag;

                PluginFramework.ClientCore.Send(DashboardPackets.RequestDeleteTopicFromDashboard(messageToDelete));
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

        private void vSroButtonListDashboard_OnIndCh(object sender, EventArgs e)
        {
            DashboardMessage msg = (DashboardMessage)((vSroListButton)sender).Tag;
            Invoke(new Action(() =>
            {
                labelAuthor.Text = msg.Author;
                labelTopic.Text = msg.Title;
                labelText.Text = msg.Text;
            }));
        }

        #endregion Methods
    }
}