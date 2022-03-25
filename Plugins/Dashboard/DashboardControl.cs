using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ClientDataStorage.Dashboard;
using ServerFrameworkRes.BasicControls;
using ServerFrameworkRes.Network.Security;
using Structs.Dashboard;

namespace Dashboard
{
    public partial class DashboardControl : UserControl
    {

        public DashboardControl()
        {
            InitializeComponent();

            ClientDataStorage.Network.ClientCore.AddEntry(0xC001, TopicReceiveExisting);
            ClientDataStorage.Network.ClientCore.AddEntry(0xC002, TopicReceiveNew);
            ClientDataStorage.Network.ClientCore.AddEntry(0xC003, TopicsFinishedLoading);
            ClientDataStorage.Network.ClientCore.AddEntry(0xC004, TopicDeleteResponse);

            ClientDataStorage.Network.ClientCore.Send(RequestAllTopics);
            //timerCheckDashboard.Enabled = true;
        }

        private void SaveTopic()
        {
            if (textBoxTopic.TextLength == 0)
                return;
            if (richTextBoxEditTopicText.TextLength == 0)
                return;
            if (ClientDataStorage.ClientMemory.AccountName == null)
                return;
            if (!listView1.Items.ContainsKey(textBoxTopic.Text))
            {
                ClientDataStorage.Network.ClientCore.Send(RequestAddTopicToDashboard(new DashboardMessage(textBoxTopic.Text, richTextBoxEditTopicText.Text, ClientDataStorage.ClientMemory.AccountName)));
            }
        }

        private void OnCheckTopics(object sender, EventArgs e)
        {

        }

        private void addNewTopicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (DashboardTopicEditor editor = new DashboardTopicEditor(ClientDataStorage.ClientMemory.AccountName))
                editor.ShowDialog();
            //splitContainerDashboardText.Panel2Collapsed = false;
            //vSroSmallButtonSave.vSroSmallButtonName = "Add Topic";
        }

        private void editShownTopicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vSroButtonList1.LatestSelectedButton != null)
            {
                using (DashboardTopicEditor editor = new DashboardTopicEditor((DashboardMessage)vSroButtonList1.LatestSelectedButton.Tag))
                    editor.ShowDialog();


                //        vSroSmallButtonSave.vSroSmallButtonName = "Save topic";
                //    splitContainerDashboardText.Panel2Collapsed = false;
                //
                //    richTextBoxEditTopicText.Text = ((DashboardMessage)vSroButtonList1.LatestSelectedButton.Tag).Text;
                //    textBoxTopic.Text = ((DashboardMessage)vSroButtonList1.LatestSelectedButton.Tag).Title;
            }
        }

        private void deleteShownTopicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vSroButtonList1.LatestSelectedButton != null)
            {
                DashboardMessage messageToDelete = (DashboardMessage)vSroButtonList1.LatestSelectedButton.Tag;

                ClientDataStorage.Network.ClientCore.Send(RequestDeleteTopicFromDashboard(messageToDelete));
            }
        }

        private void OnIdexChange(object sender, EventArgs e)
        {


        }

        private void richTextBoxShowTopicText_TextChanged(object sender, EventArgs e)
        {

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
    }
}
