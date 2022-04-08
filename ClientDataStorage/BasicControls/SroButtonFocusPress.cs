using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PluginFramework.BasicControls
{
    public class SroButtonFocusPress : Button
    {
        public Bitmap button;
        public Bitmap button_focus;
        public Bitmap button_press;

        public Action OnClick;

        public SroButtonFocusPress(Bitmap _button, Bitmap _button_focus, Bitmap _button_press, string name = "")
        {
            Text = name;

            button = _button;
            button_focus = _button_focus;
            button_press = _button_press;

            this.BackgroundImageLayout = ImageLayout.Stretch;
            BackgroundImage = button;

            MouseEnter += OnMouseEnter;
            MouseLeave += OnMouseLeave;
            MouseDown += OnMouseDown;
            MouseUp += OnMouseUp;

            Click += SroButtonFocusPress_Click;
        }

        private void SroButtonFocusPress_Click(object sender, EventArgs e)
        {
            if (OnClick != null)
                OnClick();
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            BackgroundImage = button_focus;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            BackgroundImage = button_press;
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            BackgroundImage = button;
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            BackgroundImage = button_focus;
        }
    }
}