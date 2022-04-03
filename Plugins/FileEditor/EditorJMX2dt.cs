using BinaryFiles.PackFile.Media;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FileEditor
{
    public partial class EditorJMX2dt : Form
    {
        private readonly JMX2dtFile display;
        private Dictionary<string, Bitmap> ddjFiles = new Dictionary<string, Bitmap>();

        public EditorJMX2dt(JMX2dtFile dis, string name)
        {
            display = dis;
            InitializeComponent();
            Text = name;
            foreach (var item in dis.ElementList)
            {
                var path = $"Media\\{item.Image.Replace($"\0", "")}";
                if (!ddjFiles.ContainsKey(path) && PackFile.MediaPack.Reader.GetByteArrayByDirectory(path, out byte[] ddj))
                {
                    ddjFiles.Add(path, new BinaryFiles.PackFile.JMXddjFile(ddj).BitmapImage);
                }

                path = $"Media\\{item.Background.Replace($"\0", "")}";
                if (!ddjFiles.ContainsKey(path) && PackFile.MediaPack.Reader.GetByteArrayByDirectory(path, out ddj))
                {
                    ddjFiles.Add(path, new BinaryFiles.PackFile.JMXddjFile(ddj).BitmapImage);
                }


                if (item.ClientRectangle.X + item.ClientRectangle.Width > Width)
                {
                    Width = item.ClientRectangle.X + item.ClientRectangle.Width;
                }
                if (item.ClientRectangle.Y + item.ClientRectangle.Higth > Height)
                {
                    Height = item.ClientRectangle.Y + item.ClientRectangle.Higth;
                }
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EditorJMX2dt_Paint(object sender, PaintEventArgs e)
        {
            foreach (var item in display.ElementList)
            {
                var path = $"Media\\{item.Image.Replace($"\0", "")}";
                if (ddjFiles.ContainsKey(path))
                {
                    e.Graphics.DrawImage(ddjFiles[path], item.ClientRectangle.X, item.ClientRectangle.Y, item.ClientRectangle.Width, item.ClientRectangle.Higth);
                }

                path = $"Media\\{item.Background.Replace($"\0", "")}";
                if (ddjFiles.ContainsKey(path))
                {
                    e.Graphics.DrawImage(ddjFiles[path], item.ClientRectangle.X, item.ClientRectangle.Y, item.ClientRectangle.Width, item.ClientRectangle.Higth);
                }
            }
        }

        internal static void Show(JMX2dtFile file, string item)
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                using (EditorJMX2dt e = new EditorJMX2dt(file, item))
                {
                    e.ShowDialog();
                }
            });
        }
    }
}