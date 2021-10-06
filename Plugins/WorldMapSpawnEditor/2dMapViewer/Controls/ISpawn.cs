using ClientDataStorage.Client.Files;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WorldMapSpawnEditor._2dMapViewer
{
    
    public abstract class ISpawn // : Panel
    {
        #region Properties


        /// <summary>
        /// Contains all Database Informations about the spawn.
        /// </summary>
        public SingleSpawn Spawn { get; private set; }

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

        /// <summary>
        /// Image of the spawn.
        /// </summary>
        public string ImgPath { get; set; }

        /// <summary>
        /// Translated Location on Control.
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// Texture for single Spawn   !obsolete!
        /// </summary>
       // public Bitmap Texture { get; set; }

        #endregion


        /// <summary>
        /// Raw logic of a single spawn. (Monster, UniqueMonster, Npc)
        /// </summary>
        public ISpawn(SingleSpawn spawn, int size, string mediaPath)
        {
            Spawn = spawn;
            //ImgPath = mediaPath;
            RegionID = spawn.Nest.nRegionDBID;
            InitializeProperties();
            //this.DoubleBuffered = true;
            //this.Size = new Size(12, 12);
            //this.BackgroundImageLayout = ImageLayout.Stretch;
            Location = new Point(X * (int)Math.Round(spawn.Nest.fLocalPosX / 7.5f, 0) - 4, Y *(int)Math.Round((spawn.Nest.fLocalPosZ / 7.5f - 256) * -1) - 4);
           // DrawBackgroundImage();
        }



        public void UpdateISpawn(int RegionSize)
        {
            //Spawn = newSpawn;
            this.Location = new Point(  ((int)Math.Round(Spawn.Nest.fLocalPosX / (1920f / RegionSize), 0) - 4), (int)Math.Round((Spawn.Nest.fLocalPosZ / (1920f / RegionSize)- RegionSize) * -1) - 4);
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
        /// Draws the Background Image from "ClientDataStorage.Client.Media.MediaPk2.GetByteArrayByDirectory(ImgPath, out byte[] file)".
        /// </summary>
        private void DrawBackgroundImage()
        {
            if (!ClientDataStorage.Client.Media.DDJFiles.ContainsKey(ImgPath))
            {
                if (ClientDataStorage.Client.Media.MediaPk2.GetByteArrayByDirectory(ImgPath, out byte[] file))
                {
                    DDJImage DDJFile = new DDJImage(file);
                    ClientDataStorage.Client.Media.DDJFiles.Add(ImgPath, DDJFile);
                }
            }
                //this.Texture = ClientDataStorage.Client.Media.DDJFiles[ImgPath].BitmapImage;
        }
    }
}
