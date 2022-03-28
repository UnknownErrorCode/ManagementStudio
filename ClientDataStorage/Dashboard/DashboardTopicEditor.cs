using ServerFrameworkRes.BasicControls;
using ServerFrameworkRes.Network.Security;
using Structs.Dashboard;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClientDataStorage.Dashboard
{
    public partial class DashboardTopicEditor : Form
    {

        bool IsEditMode;
        bool IsPreview = false;

        DashboardMessage Message { get; set; }
        DashboardMessage NewMessage;

        string Author { get => labelAuthor.Text; set => labelAuthor.Text = value; }
        string TopicText { get => labelText.Text; set => labelText.Text = value; }
        string TopicTitle { get => labelTopic.Text; set => labelTopic.Text = value; }

        string EditTopicText { get => richTextBox1.Text; set => richTextBox1.Text = value; }
        string EditTopicTitle { get => textBox1.Text; set => textBox1.Text = value; }
        public DashboardTopicEditor(DashboardMessage msg)
        {
            Message = msg;
            // NewMessage = new DashboardMessage(msg);
            InitializeComponent();
            Author = msg.Author;

            TopicText = EditTopicText = msg.Text;
            TopicTitle = EditTopicTitle = msg.Title;

            vSroSmallButtonAdd.Enabled = false;
            IsEditMode = true;
        }

        public DashboardTopicEditor(string author)
        {
            // Message = msg;
            // NewMessage = new DashboardMessage();
            InitializeComponent();
            Author = author;
            vSroSmallButtonEdit.Enabled = false;
            IsEditMode = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!EditTopicTitle.Equals(TopicTitle) && IsEditMode && textBox1.ForeColor != Color.Red)
                textBox1.ForeColor = Color.Red;
        }

        private void OnPreviewClick()
        {
            if (!IsPreview)
            {
                TopicTitle = EditTopicTitle;
                TopicText = EditTopicText;
            }
            else
            {
                TopicTitle = Message.Title;
                TopicText = Message.Text;
            }
        }

        private void OnEdit()
        {
            if (vSroMessageBox.YesOrNo("Do you want to edit the topic?", "Edit Topic"))
            {
                NewMessage = new DashboardMessage(EditTopicTitle, EditTopicText, Author);

                var pack = new Packet(PacketID.Client.TopicEditRequest);
                pack.WriteStruct(Message);
                pack.WriteStruct(NewMessage);
                ClientCore.Send(pack);
            }
        }

        private void OnAddNew()
        {
            if (vSroMessageBox.YesOrNo("Do you want to add the new topic?", "Add new Topic"))
            {
                NewMessage = new DashboardMessage(EditTopicTitle, EditTopicText, Author);

                var pack = new Packet(PacketID.Client.TopicAddRequest);
                pack.WriteStruct(NewMessage);
                ClientCore.Send(pack);
            }
        }
    }
}
