using BinaryFiles.PackFile.Media;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FileEditor
{
    public partial class ViewerJMX2dt : Form
    {
        private readonly JMX2dtFile display;
        private Dictionary<string, Bitmap> ddjFiles = new Dictionary<string, Bitmap>();
        private int minX = 640, minY = 640, maxX = 0, maxY = 0;
        public ViewerJMX2dt(JMX2dtFile dis, string name)
        {
            display = dis;
            StartPosition = FormStartPosition.CenterScreen;
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

                if (item.ClientRectangle.X > 0)
                {
                    if (minX > item.ClientRectangle.X)
                        minX = item.ClientRectangle.X;
                }
                if (item.ClientRectangle.Y > 0)
                {
                    if (minY > item.ClientRectangle.Y)
                        minY = item.ClientRectangle.Y;

                }

                if (item.ClientRectangle.X + item.ClientRectangle.Width > maxX)
                {
                    maxX = item.ClientRectangle.X + item.ClientRectangle.Width;
                }
                if (item.ClientRectangle.Y + item.ClientRectangle.Higth > maxY)
                {
                    maxY = item.ClientRectangle.Y + item.ClientRectangle.Higth;
                }
            }
            Width = maxX;
            Height = maxY;
        }

        private void EditorJMX2dt_Paint(object sender, PaintEventArgs e)
        {
            foreach (var item in display.ElementList)
            {
                var path = $"Media\\{item.Image.Replace($"\0", "")}";
                if (ddjFiles.ContainsKey(path))
                {
                    e.Graphics.DrawImage(ddjFiles[path], item.ClientRectangle.X - minX, item.ClientRectangle.Y - minY, item.ClientRectangle.Width, item.ClientRectangle.Higth);
                }

                path = $"Media\\{item.Background.Replace($"\0", "")}";
                if (ddjFiles.ContainsKey(path))
                {
                    e.Graphics.DrawImage(ddjFiles[path], item.ClientRectangle.X - minX, item.ClientRectangle.Y - minY, item.ClientRectangle.Width, item.ClientRectangle.Higth);
                }
            }
        }

        internal static void Show(JMX2dtFile file, string item)
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                using (ViewerJMX2dt e = new ViewerJMX2dt(file, item))
                {
                    e.ShowDialog();
                }
            });
        }
    }
}