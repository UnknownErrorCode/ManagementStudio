using ServerFrameworkRes.BasicControls;
using ServerFrameworkRes.Network.Security;
using Structs.Dashboard;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClientFrameworkRes.Dashboard
{
    public partial class DashboardTopicEditor : Form
    {
        #region Fields

        private readonly bool IsEditMode;
        private readonly bool IsPreview = false;

        private DashboardMessage Message;
        private DashboardMessage NewMessage;

        #endregion Fields

        #region Constructors

        public DashboardTopicEditor(DashboardMessage msg)
        {
            Message = msg;
            InitializeComponent();
            Author = msg.Author;

            TopicText = EditTopicText = msg.Text;
            TopicTitle = EditTopicTitle = msg.Title;

            vSroSmallButtonAdd.Enabled = false;
            IsEditMode = true;
        }

        public DashboardTopicEditor(string author)
        {
            InitializeComponent();
            Author = author;
            vSroSmallButtonEdit.Enabled = false;
            IsEditMode = false;
        }

        #endregion Constructors

        #region Properties

        private string Author { get => labelAuthor.Text; set => labelAuthor.Text = value; }
        private string EditTopicText { get => richTextBox1.Text; set => richTextBox1.Text = value; }
        private string EditTopicTitle { get => textBox1.Text; set => textBox1.Text = value; }
        private string TopicText { get => labelText.Text; set => labelText.Text = value; }
        private string TopicTitle { get => labelTopic.Text; set => labelTopic.Text = value; }

        #endregion Properties

        #region Methods

        private void OnAddNew()
        {
            if (vSroMessageBox.YesOrNo("Do you want to add the new topic?", "Add new Topic"))
            {
                NewMessage = new DashboardMessage(EditTopicTitle, EditTopicText, Author);

                Packet pack = new Packet(PacketID.Client.TopicAddRequest);
                pack.WriteStruct(NewMessage);
                ClientCore.Send(pack);
            }
        }

        private void OnEdit()
        {
            if (vSroMessageBox.YesOrNo("Do you want to edit the topic?", "Edit Topic"))
            {
                NewMessage = new DashboardMessage(EditTopicTitle, EditTopicText, Author);

                Packet pack = new Packet(PacketID.Client.TopicEditRequest);
                pack.WriteStruct(Message);
                pack.WriteStruct(NewMessage);
                ClientCore.Send(pack);
            }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!EditTopicTitle.Equals(TopicTitle) && IsEditMode && textBox1.ForeColor != Color.Red)
            {
                textBox1.ForeColor = Color.Red;
            }
        }

        #endregion Methods
    }
}