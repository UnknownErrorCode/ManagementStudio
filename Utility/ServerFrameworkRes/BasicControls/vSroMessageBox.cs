using System;
using System.Drawing;
using System.Windows.Forms;

namespace ServerFrameworkRes.BasicControls
{
    public partial class vSroMessageBox : Form
    {
        #region Fields

        public bool OK = false;

        private Point LastPoint;
        private bool onMove;

        #endregion Fields

        #region Constructors

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

        #endregion Constructors

        #region Properties

        public string ReturnValue1 => vSroInputBox1.ValueText;
        public string ReturnValue2 => vSroInputBox2.ValueText;
        public string ReturnValue3 => vSroInputBox3.ValueText;

        #endregion Properties

        #region Methods

        public static string GetInput(string message, string title, string valueTitle)
        {
            string ret = "";
            using (vSroMessageBox showTempMsg = new vSroMessageBox(message, title))
            {
                showTempMsg.vSroInputBox1.Visible = true;
                showTempMsg.vSroInputBox1.TitleText = valueTitle;
                showTempMsg.ShowDialog();
                ret = showTempMsg.ReturnValue1.Length > 0 ? showTempMsg.ReturnValue1 : "error";
            }
            return ret;
        }

        public static string[] GetInput(string message, string title, string valueTitle, string valueTitle2)
        {
            string[] ret = new string[2];
            using (vSroMessageBox showTempMsg = new vSroMessageBox(message, title))
            {
                showTempMsg.vSroInputBox1.Visible = true;
                showTempMsg.vSroInputBox2.Visible = true;
                showTempMsg.vSroInputBox1.TitleText = valueTitle;
                showTempMsg.vSroInputBox2.TitleText = valueTitle2;
                showTempMsg.ShowDialog();
                ret[0] = showTempMsg.ReturnValue1.Length > 0 ? showTempMsg.ReturnValue1 : "error";
                ret[1] = showTempMsg.ReturnValue2.Length > 0 ? showTempMsg.ReturnValue2 : "error";
            }
            return ret;
        }

        public static string[] GetInput(string message, string title, string valueTitle, string valueTitle2, string valueTitle3)
        {
            string[] ret = new string[3];
            using (vSroMessageBox showTempMsg = new vSroMessageBox(message, title))
            {
                showTempMsg.vSroInputBox1.Visible = true;
                showTempMsg.vSroInputBox2.Visible = true;
                showTempMsg.vSroInputBox3.Visible = true;
                showTempMsg.vSroInputBox1.TitleText = valueTitle;
                showTempMsg.vSroInputBox2.TitleText = valueTitle2;
                showTempMsg.vSroInputBox3.TitleText = valueTitle3;
                showTempMsg.ShowDialog();
                ret[0] = showTempMsg.ReturnValue1.Length > 0 ? showTempMsg.ReturnValue1 : "error";
                ret[1] = showTempMsg.ReturnValue2.Length > 0 ? showTempMsg.ReturnValue2 : "error";
                ret[2] = showTempMsg.ReturnValue3.Length > 0 ? showTempMsg.ReturnValue3 : "error";
            }
            return ret;
        }

        public static void Show(string message)
        {
            using (vSroMessageBox showTempMsg = new vSroMessageBox(message))
            {
                showTempMsg.ShowDialog();
            }
        }

        public static void Show(string message, string title)
        {
            using (vSroMessageBox showTempMsg = new vSroMessageBox(message, title))
            {
                showTempMsg.ShowDialog();
            }
        }

        public static bool YesOrNo(string message, string title)
        {
            using (vSroMessageBox showTempMsg = new vSroMessageBox(message, title))
            {
                showTempMsg.ShowDialog();
                return showTempMsg.OK;
            }
        }

        private void ButtonNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonYes_Click(object sender, EventArgs e)
        {
            OK = true;
            Close();
        }

        private void RealButton_Click(object sender, EventArgs e)
        {
            OK = true;
            Close();
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

        private void vSroMessageBox_MouseUp(object sender, MouseEventArgs e)
        {
            onMove = false;
        }

        #endregion Methods
    }
}