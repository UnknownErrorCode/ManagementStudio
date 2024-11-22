﻿using System;
using System.Runtime.InteropServices;

namespace Structs
{
    /// <summary>
    /// Consists of <see cref="IsDungeon"/> and the coordinates X and Z.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct WRegionID : IEquatable<WRegionID>
    {
        private const int DUNGEON_MASK = 0b10000000_00000000;

        /// <summary>
        /// World Region Identifier.
        /// </summary>
        [FieldOffset(0)]
        public readonly short RegionID;

        [FieldOffset(0)]
        private readonly byte x;

        [FieldOffset(1)]
        private readonly byte y;

        public WRegionID(short wRegionID)
        {
            RegionID = wRegionID;
            x = (byte)(wRegionID % 256);
            y = (byte)(wRegionID / 256);
        }

        /// <summary>
        /// Specifies weather the region is a dungeon or not. ( <see cref="RegionID"/> AND <see cref="DUNGEON_MASK"/> ) != 0
        /// </summary>
        public bool IsDungeon => (RegionID & DUNGEON_MASK) != 0;

        /// <summary>
        /// X abscissa.
        /// </summary>
        public byte X => x;

        /// <summary>
        /// z ordinate.
        /// </summary>
        public byte Z => y;

        public bool Equals(WRegionID other) => this.RegionID.Equals(other.RegionID) && this.X.Equals(other.X) && this.Z.Equals(other.Z);

        public static short GetRegionID(int i, int i2) => GetRegionID((byte)i, (byte)i2);

        public static short GetRegionID(byte i, byte i2) => (short)Convert.ToInt32($"{i2.ToString("X")}{i.ToString("X")}", 16);

        public static WRegionID GetWRegionID(int i, int i2) => GetWRegionID((byte)i, (byte)i2);

        public static WRegionID GetWRegionID(byte i, byte i2) => new WRegionID((short)Convert.ToInt32($"{i2.ToString("X")}{i.ToString("X")}", 16));
    }
}