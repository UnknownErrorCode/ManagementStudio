using BinaryFiles.PackFile.Media;
using System.Collections.Generic;
using System.Drawing;

namespace FileEditor._2dt
{
    class Graphics2dt
    {
        private readonly JMX2dtFile display;
        private Dictionary<string, Bitmap> ddjFiles = new Dictionary<string, Bitmap>();
        internal int minX = 640, minY = 640, maxX = 0, maxY = 0;

        public Graphics2dt(JMX2dtFile file)
        {
            display = file;
            foreach (var item in file.ElementList)
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
        }

        public void EditorJMX2dt_Paint(Graphics g)
        {
            foreach (var item in display.ElementList)
            {
                var path = $"Media\\{item.Image.Replace($"\0", "")}";
                if (ddjFiles.ContainsKey(path))
                {
                    g.DrawImage(ddjFiles[path], item.ClientRectangle.X - minX, item.ClientRectangle.Y - minY, item.ClientRectangle.Width, item.ClientRectangle.Higth);
                }

                path = $"Media\\{item.Background.Replace($"\0", "")}";
                if (ddjFiles.ContainsKey(path))
                {
                    g.DrawImage(ddjFiles[path], item.ClientRectangle.X - minX, item.ClientRectangle.Y - minY, item.ClientRectangle.Width, item.ClientRectangle.Higth);
                }
            }
        }
    }
}
