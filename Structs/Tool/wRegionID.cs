using System;
using System.Runtime.InteropServices;

namespace Structs
{
    /// <summary>
    /// Consists of <see cref="IsDungeon"/> and the coordinates X and Z.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct WRegionID : IEquatable<WRegionID>
    {
        /// <summary>
        /// World Region Identifier.
        /// </summary>
        [FieldOffset(0)]
        public readonly short RegionID;

        private const int DUNGEON_MASK = 0b10000000_00000000;

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

        public bool Equals(WRegionID other)
        {
            return Equals(other);
        }
    }
}