﻿using ClientDataStorage.Client.Files;
using System;
using Editors.Spawn;
using System.Drawing;

namespace WorldMapSpawnEditor.MapGraphics
{

    public abstract class ISpawn
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
        private short RegionID { get => Spawn.Nest.nRegionDBID; }

        /// <summary>
        /// Image of the spawn.
        /// </summary>
        public string ImgPath { get; set; }

        /// <summary>
        /// Translated Location on Control.
        /// </summary>
        public Point Location { get; set; }

        #endregion

        /// <summary>
        /// Raw logic of a single spawn. (Monster, UniqueMonster, Npc)
        /// </summary>
        public ISpawn(SingleSpawn spawn)
        {
            Spawn = spawn;
            if (RegionID > 0)
            {
                InitializeProperties();
                Location = new Point(X * (int)Math.Round(spawn.Nest.fLocalPosX / 7.5f, 0), Y * (int)Math.Round((spawn.Nest.fLocalPosZ / 7.5f - 256) * -1));
            }
        }

        /// <summary>
        /// Updates the position of the spawn
        /// </summary>
        /// <param name="RegionSize"></param>
        public void UpdateISpawn(int RegionSize)
            => this.Location = new Point(((int)Math.Round(Spawn.Nest.fLocalPosX / (1920f / RegionSize), 0)), (int)Math.Round((Spawn.Nest.fLocalPosZ / (1920f / RegionSize) - RegionSize) * -1));


        /// <summary>
        /// Initialize required Properties to load Components with no error.
        /// </summary>
        void InitializeProperties()
        {
            string convertedRegionID = RegionID.ToString("X");
            Y = Convert.ToByte(Convert.ToInt32(convertedRegionID.Substring(0, 2), 16));
            X = Convert.ToByte(Convert.ToInt32(convertedRegionID.Substring(2, 2), 16));
        }
    }
}