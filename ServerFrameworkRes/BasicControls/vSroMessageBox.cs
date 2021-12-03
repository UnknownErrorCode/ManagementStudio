using System;
using System.Drawing;
using System.Windows.Forms;

namespace ServerFrameworkRes.BasicControls
{
    public partial class vSroMessageBox : Form
    {
        private bool onMove;
        private Point LastPoint;
        public bool OK = false;

        public string ReturnValue1 { get => vSroInputBox1.ValueText; }
        public string ReturnValue2 { get => vSroInputBox2.ValueText; }
        public string ReturnValue3 { get => vSroInputBox3.ValueText; }
        public vSroMessageBox(string text)
        {
            InitializeComponent();
            richTextBoxMessage.Text = text;
            vSroButtonYes.RealButton.Text = "Yes";
            vSroButtonYes.RealButton.Click += ButtonYes_Click;
            vSroButtonNo.RealButton.Text = "No";
            vSroButtonNo.RealButton.Click += ButtonNo_Click;

        }

        public vSroMessageBox(string text, string Title)
        {
            InitializeComponent();
            vSroButtonYes.RealButton.Text = "Yes";
            vSroButtonYes.RealButton.Click += ButtonYes_Click;
            vSroButtonNo.RealButton.Text = "No";
            vSroButtonNo.RealButton.Click += ButtonNo_Click;
            richTextBoxMessage.Text = text;
            labelTitle.Text = Title;
        }

        private void ButtonNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ButtonYes_Click(object sender, EventArgs e)
        {
            OK = true;
            this.Close();
        }
        private void RealButton_Click(object sender, EventArgs e)
        {
            OK = true;
            this.Close();
        }


        public static void Show(string message)
        {
            vSroMessageBox showTempMsg = new vSroMessageBox(message);
            showTempMsg.ShowDialog();
            showTempMsg.Dispose();
        }
        public static void Show(string message, string title)
        {
            vSroMessageBox showTempMsg = new vSroMessageBox(message, title);
            showTempMsg.ShowDialog();
            showTempMsg.Dispose();
        }

        public static bool YesOrNo(string message, string title)
        {
            vSroMessageBox showTempMsg = new vSroMessageBox(message, title);
            showTempMsg.ShowDialog();
            var booler = showTempMsg.OK;
            showTempMsg.Dispose();
            return booler;
        }
        public static string GetInput(string message, string title, string valueTitle)
        {
            string ret = "";
            using (vSroMessageBox showTempMsg = new vSroMessageBox(message, title))
            {
                showTempMsg.ShowDialog();
                if (showTempMsg.ReturnValue1.Length>0)
                    ret = showTempMsg.ReturnValue1;
            }
            return ret;
        }


        private void vSroMessageBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X <= 355 && e.Y <= 25)
            {
                if (e.Button == MouseButtons.Left)
                {
                    onMove = true;
                    LastPoint = new Point(-e.X, -e.Y);
                }
            }
        }
        private void vSroMessageBox_MouseUp(object sender, MouseEventArgs e)
        {
            onMove = false;
        }
        private void vSroMessageBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (onMove)
            {

                Point mousePos = Control.MousePosition;
                mousePos.Offset(LastPoint.X, LastPoint.Y);

                if (Location != mousePos)
                {
                    Location = mousePos;
                }
            }
        }
    }
}
