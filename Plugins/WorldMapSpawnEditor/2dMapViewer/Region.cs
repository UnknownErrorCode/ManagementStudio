using ClientDataStorage.Client.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldMapSpawnEditor._2dMapViewer
{
    class Region : PictureBox
    {
        #region Properties
         
        internal byte X { get; set; }
        internal byte Y { get; set; }
        int RegionID { get; set; }

        #endregion

        #region Constants

        private protected  string TexturePath { get => $"Media\\minimap\\{X}x{Y}.ddj"; }

        #endregion


        internal Region(int regionID)
        {
            RegionID = regionID;
            this.Size = new System.Drawing.Size(256, 256);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.DoubleBuffered = true;

            this.MouseClick += Region_MouseClick;


            if (regionID>0)
            {
                string convertedRegionID = RegionID.ToString("X");
                Y  = Convert.ToByte(Convert.ToInt32(convertedRegionID.Substring(0, 2), 16));
                X = Convert.ToByte(Convert.ToInt32(convertedRegionID.Substring(2, 2), 16));
                
                if (File.Exists(Path.Combine(ClientDataStorage.Config.StaticConfig.ClientExtracted, TexturePath.Replace(".ddj", ".jpg"))))
                {
                    this.BackgroundImage = System.Drawing.Image.FromFile(Path.Combine(ClientDataStorage.Config.StaticConfig.ClientExtracted, TexturePath.Replace(".ddj", ".jpg")));
                }
                else
                {
                    this.BackColor = System.Drawing.Color.Black;
                }
            }
        }

        private void Region_MouseClick(object sender, MouseEventArgs e)
        {
            var test = e.Location;
            var curSize = this.Size.Width;
            var factoring = 1920 / curSize;
            var realPosition = new System.Drawing.Point(e.X * factoring,(( e.Y * factoring) - 1920 ) * -1);
            // CreateGraphics().DrawEllipse(new System.Drawing.Pen(System.Drawing.Color.Red), new System.Drawing.RectangleF(e.X, e.Y, 10f, 10f));
            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            CreateGraphics().DrawString($"X:{realPosition.X} Y:{realPosition.Y} RegionID:{this.RegionID}",new System.Drawing.Font("Arial",12f), brush, e.X, e.Y);
        }

    }
}
