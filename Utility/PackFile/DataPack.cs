﻿using PackFile.Data.Dungeon;
using PackFile.Utility;

namespace PackFile
{
    public static partial class DataPack
    {
        #region Fields

        /// <summary>
        /// The Main abstract Pk2 reader.
        /// </summary>
        private static Pk2Reader Reader;
        internal static bool Initialized => Reader.Initialized;

        #endregion Fields

        #region Methods

        /// <summary>
        /// Initialize the Data.pk2 syncronous.
        /// </summary>
        internal static bool Initialize(string clientPath)
        {
            Reader = new Pk2Reader($"{clientPath}\\Data.pk2");
            return Reader.Initialized;
        }

        public static bool GetDungeonInfo(out DungeonInfo outer)
        {
            outer = null;

            if (!Reader.GetByteArrayByDirectory("Data\\dungeon\\dungeoninfo.txt", out byte[] dungeoninfo_txt))
                return false;

            outer = new DungeonInfo(dungeoninfo_txt);

            return outer.Initialized;// && xxxx && xxxx
        }

        #endregion Methods
    }
}