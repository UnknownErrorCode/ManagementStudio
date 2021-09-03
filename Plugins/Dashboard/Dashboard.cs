using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ClientDataStorage.Dashboard;
using ServerFrameworkRes.Network.Security;
using Structs.Dashboard;

namespace Dashboard
{
    public partial class Dashboard : UserControl
    {
        internal static ServerData ClientData;

        public Dashboard(ServerData data)
        {
            InitializeComponent();
            ClientData = data;
            ClientData.m_security.Send(DashboardPackets.RequestAllTopics);
            timerCheckDashboard.Enabled = true;
        }

        private void SaveTopic()
        {
            if (textBoxTopic.TextLength == 0)
                return;
            if (richTextBoxEditTopicText.TextLength == 0)
                return;
            if (ClientData.AccountName == null)
                return;

            ClientData.m_security.Send(DashboardPackets.AddTopicToDashboard(new DashboardMessage(textBoxTopic.Text, richTextBoxEditTopicText.Text, ClientData.AccountName)));
        }

        private void OnCheckTopics(object sender, EventArgs e)
        {
            if (DashboardMemory.ChangesAviable)
            {
                foreach (var topic in DashboardMemory.TopicDictionary)
                    if (!listView1.Items.ContainsKey(topic.Key))
                        listView1.Items.Add(new ListViewItem(topic.Key) { Tag = topic.Value, Name = topic.Key });
                foreach (ListViewItem items in listView1.Items)
                    if (!DashboardMemory.TopicDictionary.ContainsKey(items.Name))
                        listView1.Items.RemoveByKey(items.Name);
                DashboardMemory.ChangesAviable = false;
            }
            
        }

        private void addNewTopicToolStripMenuItem_Click(object sender, EventArgs e)
            => splitContainerDashboardText.Panel2Collapsed = false;

        private void editShownTopicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0] != null)
            {
                if (splitContainerDashboardText.Panel2Collapsed)
                    splitContainerDashboardText.Panel2Collapsed = false;
                richTextBoxEditTopicText.Text = ((DashboardMessage)listView1.SelectedItems[0].Tag).Text;
                textBoxTopic.Text = ((DashboardMessage)listView1.SelectedItems[0].Tag).Title;
            }


        }

        private void deleteShownTopicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0]!=null)
            {
                DashboardMessage messageToDelete = (DashboardMessage)listView1.SelectedItems[0].Tag;
               
                ClientData.m_security.Send(DashboardPackets.DeleteTopicFromDashboard(messageToDelete));
            }
        }

        private void OnIdexChange(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count>0)
                richTextBoxShowTopicText.Text = ((DashboardMessage)listView1.SelectedItems[0].Tag).Text;
        }
    }
}
