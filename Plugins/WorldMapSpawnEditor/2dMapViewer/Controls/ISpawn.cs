using ClientDataStorage.Client.Files;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WorldMapSpawnEditor._2dMapViewer
{
    
    public abstract class ISpawn : Panel
    {
        /// <summary>
        /// Contains all Database Informations about the spawn.
        /// </summary>
        public SingleSpawn Spawn { get; private set; }

        /// <summary>
        /// Image of the spawn.
        /// </summary>
        public string ImgPath { get; set; }

        /// <summary>
        /// Raw logic of a single spawn. (Monster, UniqueMonster, Npc)
        /// </summary>
        public ISpawn(SingleSpawn spawn, int size, string mediaPath)
        {
            Spawn = spawn;
            ImgPath = mediaPath;
            this.DoubleBuffered = true;
            this.Size = new Size(12, 12);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Location = new Point((int)Math.Round(spawn.Nest.fLocalPosX / 7.5f, 0) - 6, (int)Math.Round((spawn.Nest.fLocalPosZ / 7.5f - 256) * -1) - 6);
            DrawBackgroundImage();
        }



        public void UpdateISpawn(SingleSpawn newSpawn)
        {
            Spawn = newSpawn;
            this.Location = new Point((int)Math.Round(Spawn.Nest.fLocalPosX / 7.5f, 0) - 6, (int)Math.Round((Spawn.Nest.fLocalPosZ / 7.5f - 256) * -1) - 6);
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
                    this.BackgroundImage = DDJFile.BitmapImage;
                    return;
                }
                this.BackColor = Color.Orange;
            }
            else
                this.BackgroundImage = ClientDataStorage.Client.Media.DDJFiles[ImgPath].BitmapImage;
        }
    }
}
