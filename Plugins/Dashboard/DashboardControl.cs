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

        public DashboardControl(TabPage page)
        {
            InitializeComponent();

            ClientDataStorage.ClientCore.AddEntry(0xC001, TopicReceiveExisting);
            ClientDataStorage.ClientCore.AddEntry(0xC002, TopicReceiveNew);
            ClientDataStorage.ClientCore.AddEntry(0xC003, TopicsFinishedLoading);
            ClientDataStorage.ClientCore.AddEntry(0xC004, TopicDeleteResponse);

            ClientDataStorage.ClientCore.Send(RequestAllTopics);

            page.Controls.Add(this);
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

                ClientDataStorage.ClientCore.Send(RequestDeleteTopicFromDashboard(messageToDelete));
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
