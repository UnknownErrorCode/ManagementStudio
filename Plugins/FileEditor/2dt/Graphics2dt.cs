﻿using BinaryFiles.PackFile;
using BinaryFiles.PackFile.Media;
using PackFile.Media.Textdata;
using System.Collections.Generic;
using System.Drawing;

namespace FileEditor._2dt
{
    internal class Graphics2dt : IFile
    {
        internal int minX = 640, minY = 640, maxX = 0, maxY = 0;

        //private readonly JMX2dtFile display;
        private readonly Dictionary<string, Bitmap> ddjFiles = new Dictionary<string, Bitmap>();

        public Graphics2dt(JMX2dtFile file)
        {
            // display = file;
            JMXFile = file;
            foreach (var item in file.ElementList)
            {
                var path = $"Media\\{item.Image.Replace($"\0", "")}";
                if (!ddjFiles.ContainsKey(path) && PackFile.MediaPack.Reader.GetByteArrayByDirectory(path, out byte[] ddj))
                {
                    ddjFiles.Add(path, new JMXddjFile(ddj).BitmapImage);
                }

                path = $"Media\\{item.Background.Replace($"\0", "")}";
                if (!ddjFiles.ContainsKey(path) && PackFile.MediaPack.Reader.GetByteArrayByDirectory(path, out ddj))
                {
                    ddjFiles.Add(path, new JMXddjFile(ddj).BitmapImage);
                }

                if (item.ClientRectangle.X > 0 && minX > item.ClientRectangle.X)
                    minX = item.ClientRectangle.X;

                if (item.ClientRectangle.Y > 0 && minY > item.ClientRectangle.Y)
                    minY = item.ClientRectangle.Y;

                if (item.ClientRectangle.X + item.ClientRectangle.Width > maxX)
                    maxX = item.ClientRectangle.X + item.ClientRectangle.Width;

                if (item.ClientRectangle.Y + item.ClientRectangle.Higth > maxY)
                    maxY = item.ClientRectangle.Y + item.ClientRectangle.Higth;
            }
        }

        public IJMXFile JMXFile { get; set; }

        public void PaintGraphics(Graphics g)
        {
            foreach (var item in ((JMX2dtFile)JMXFile).ElementList)
            {
                if (item.Style.Equals(512))
                {
                    System.Windows.Forms.TextRenderer.DrawText(g, item.Text, SystemFonts.DefaultFont, new Point(item.ClientRectangle.X - minY, item.ClientRectangle.Y - minY), Color.FromArgb((int)item.Color));
                }
                else if (item.Style.Equals(65792))
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
                    if (item.Text.Length > 0)
                    {
                        if (File2dtEditor.TextUISystem.UIIT_Strings.TryGetValue(item.Text, out TextUISystemStruct sys))
                            System.Windows.Forms.TextRenderer.DrawText(g, sys.English, SystemFonts.DefaultFont, new Point(item.ClientRectangle.X - minY, item.ClientRectangle.Y - minY), Color.FromArgb((int)item.Color));
                        else
                            System.Windows.Forms.TextRenderer.DrawText(g, item.Text, SystemFonts.DefaultFont, new Point(item.ClientRectangle.X - minY, item.ClientRectangle.Y - minY), Color.FromArgb((int)item.Color));
                    }
                }
                else
                {
                    ManagementFramework.Log.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.warning, $"Unknown Style ={item.Style}");
                }
            }
        }
    }
}