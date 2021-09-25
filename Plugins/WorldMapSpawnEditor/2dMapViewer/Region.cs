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
        short RegionID { get; set; }

        RegionSpawn Spawns { get; set; }
        #endregion


        #region Constants
        private protected string TexturePath { get => $"Media\\minimap\\{X}x{Y}.ddj"; }
        #endregion


        internal Region(short regionID)
        {
            RegionID = regionID;
            InitializeProperties();
            InitializeComponents();

            

            Task.Run(() => InitializeSpawns());
        }
        void InitializeProperties()
        {
            if (RegionID > 0)
            {
                string convertedRegionID = RegionID.ToString("X");
                Y = Convert.ToByte(Convert.ToInt32(convertedRegionID.Substring(0, 2), 16));
                X = Convert.ToByte(Convert.ToInt32(convertedRegionID.Substring(2, 2), 16));
            }
        }


        void InitializeComponents()
        {
            this.Size = new System.Drawing.Size(256, 256);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.DoubleBuffered = true;

            this.MouseClick += Region_MouseClick;
            this.Resize += Region_Resize;

            if (File.Exists(Path.Combine(ClientDataStorage.Config.StaticConfig.ClientExtracted, TexturePath.Replace(".ddj", ".jpg"))))
                this.BackgroundImage = System.Drawing.Image.FromFile(Path.Combine(ClientDataStorage.Config.StaticConfig.ClientExtracted, TexturePath.Replace(".ddj", ".jpg")));
            else
                this.BackColor = System.Drawing.Color.Black;
        }


        private void InitializeSpawns()
        {
            Spawns = new RegionSpawn(RegionID);

            if (this.InvokeRequired)
            {
                if (Spawns.MonsterOnRegion.Count > 0)
                    Invoke(new Action(() => this.Controls.AddRange(Spawns.MonsterOnRegion.ToArray())));

                if (Spawns.UniqueMonsterOnRegion.Count > 0)
                    Invoke(new Action(() => this.Controls.AddRange(Spawns.UniqueMonsterOnRegion.ToArray())));

                if (Spawns.NpcOnRegion.Count > 0)
                    Invoke(new Action(() => this.Controls.AddRange(Spawns.NpcOnRegion.ToArray())));

                return;
            }

            if (Spawns.MonsterOnRegion.Count > 0)
                this.Controls.AddRange(Spawns.MonsterOnRegion.ToArray());

            if (Spawns.UniqueMonsterOnRegion.Count > 0)
                this.Controls.AddRange(Spawns.UniqueMonsterOnRegion.ToArray());

            if (Spawns.NpcOnRegion.Count > 0)
                this.Controls.AddRange(Spawns.NpcOnRegion.ToArray());
        }


        private void Region_Resize(object sender, EventArgs e)
        {
            foreach (Npc item in WorldMap2dPanel.GetControlsOfType<Npc>(this))
            {
                item.Location = new System.Drawing.Point((int)Math.Round(item.Spawn.Nest.fLocalPosX / (1920f / this.Width), 0) - 6, (int)Math.Round((item.Spawn.Nest.fLocalPosZ / (1920f / this.Width) - this.Width) * -1) - 6);
            }
            foreach (Monster item in WorldMap2dPanel.GetControlsOfType<Monster>(this))
            {
                item.Location = new System.Drawing.Point((int)Math.Round(item.Spawn.Nest.fLocalPosX / (1920f / this.Width), 0)-6, (int)Math.Round((item.Spawn.Nest.fLocalPosZ / (1920f / this.Width) - this.Width) * -1)-6);
            }
            foreach (UniqueMonster item in WorldMap2dPanel.GetControlsOfType<UniqueMonster>(this))
            {
                item.Location = new System.Drawing.Point((int)Math.Round(item.Spawn.Nest.fLocalPosX / (1920f / this.Width), 0)-6, (int)Math.Round((item.Spawn.Nest.fLocalPosZ / (1920f / this.Width) - this.Width) * -1)-6);
            }
        }


        private void Region_MouseClick(object sender, MouseEventArgs e)
        {
            var realPosition = new System.Drawing.Point(e.X * (1920 / this.Size.Width), ((e.Y * (1920 / this.Size.Width)) - 1920) * -1);
        }
    }
}
