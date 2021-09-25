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

            this.Resize += Region_Resize;


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

        private void Region_Resize(object sender, EventArgs e)
        {
            var test = this.Size;
        }
    }
}
