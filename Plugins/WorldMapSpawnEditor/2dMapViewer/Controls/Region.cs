﻿using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldMapSpawnEditor._2dMapViewer
{
    class Region : RegionSpawn
    {
        #region Properties
        /// <summary>
        /// Ordinate of Region Coorainate.
        /// </summary>
        internal byte X { get; set; }

        /// <summary>
        /// Abszisse of Region Coordinate.
        /// </summary>
        internal byte Y { get; set; }

        /// <summary>
        /// Region Identifier build as Int16 from a string that consists of HexString(Y) + HexString(X) .
        /// </summary>
        short RegionID { get; set; }

        #endregion


        #region Constants
        /// <summary>
        /// TexturePath is combined by  {X}x{Y}.ddj.
        /// </summary>
        private protected string TexturePath { get => $"Media\\minimap\\{X}x{Y}.ddj"; }
        #endregion

        /// <summary>
        /// Region contains all information about spawns.
        /// </summary>
        /// <param name="regionID"></param>
        internal Region(short regionID) : base(regionID)
        {
            RegionID = regionID;
            InitializeProperties();
            InitializeComponents();

        }

        /// <summary>
        /// Initialize required Properties to load Components with no error.
        /// </summary>
        void InitializeProperties()
        {
            if (RegionID > 0)
            {
                string convertedRegionID = RegionID.ToString("X");
                Y = Convert.ToByte(Convert.ToInt32(convertedRegionID.Substring(0, 2), 16));
                X = Convert.ToByte(Convert.ToInt32(convertedRegionID.Substring(2, 2), 16));
            }
        }

        /// <summary>
        /// Initialize Components for the Region. Loads the Image from  "ClientDataStorage.Config.StaticConfig.ClientExtracted" + "TexturePath.Replace(".ddj", ".jpg")"
        /// </summary>
        void InitializeComponents()
        {
            this.Size = new System.Drawing.Size(256, 256);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.DoubleBuffered = true;
            this.Resize += Region_Resize;

            if (File.Exists(Path.Combine(ClientDataStorage.Config.StaticConfig.ClientExtracted, TexturePath.Replace(".ddj", ".jpg"))))
                this.BackgroundImage = System.Drawing.Image.FromFile(Path.Combine(ClientDataStorage.Config.StaticConfig.ClientExtracted, TexturePath.Replace(".ddj", ".jpg")));
            else
                this.BackColor = System.Drawing.Color.Black;
        }

        /// <summary>
        /// Resize the Region and all Spawn Controls on it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Region_Resize(object sender, EventArgs e)
        {

            foreach (Control item in Controls)
            {
              //  item.Location = new System.Drawing.Point((int)Math.Round(((ISpawn)item).Spawn.Nest.fLocalPosX / (1920f / this.Width), 0) - 6, (int)Math.Round((((ISpawn)item).Spawn.Nest.fLocalPosZ / (1920f / this.Width) - this.Width) * -1) - 6);
            }
        }
    }
}