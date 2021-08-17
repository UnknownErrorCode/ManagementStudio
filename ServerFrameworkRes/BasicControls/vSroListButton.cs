using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerFrameworkRes.BasicControls
{
    public partial class vSroListButton : UserControl
    {

       

        public string ButtonName { get; set; }


        public vSroListButton(string buttonText)
        {
            InitializeComponent();
            ButtonName = buttonText.Length > 0 ? buttonText : "EmptyName";
            labelButtonName.Text = ButtonName;
        }

        public vSroListButton()
        {
            InitializeComponent();
        }
        public void RenameButton(string buttonText)
        {
            ButtonName = buttonText.Length > 0 ? buttonText : "EmptyName";
            labelButtonName.Text = ButtonName;
        }

        private void vSroListButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = imageListSingleButton.Images[1];
        }

        private void vSroListButton_MouseUp(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = imageListSingleButton.Images[0];
            labelButtonName.ForeColor = Color.Red;
        }

        private void labelEnter(object sender, EventArgs e)
        {
            if (((Label)sender).ForeColor != Color.Red)
            {
                ((Label)sender).ForeColor = Color.Orange;
            }
        }

        private void labelleave(object sender, EventArgs e)
        {
            if (((Label)sender).ForeColor!= Color.Red)
            {
                ((Label)sender).ForeColor = Color.White;
            }
        }


        public static void OnButtonClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            MessageBox.Show("Clicked !");
        }

    }
}
