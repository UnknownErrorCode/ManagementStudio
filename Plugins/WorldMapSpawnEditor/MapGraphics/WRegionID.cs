using System;
using System.Runtime.InteropServices;

namespace WorldMapSpawnEditor.MapGraphics
{
    /// <summary>
    /// Consists of <see cref="IsDungeon"/> and the coordinates X and Z.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    internal struct WRegionID : IEquatable<WRegionID>
    {
        /// <summary>
        /// Specifies weather the region is a dungeon or not. ( <see cref="RegionID"/> AND <see cref="DUNGEON_MASK"/> ) != 0 
        /// </summary>
        public bool IsDungeon  => (RegionID & DUNGEON_MASK) != 0; 

        /// <summary>
        /// X abscissa.
        /// </summary>
        public byte X => x;

        /// <summary>
        /// z ordinate.
        /// </summary>
        public byte Z => y;

        /// <summary>
        /// World Region Identifier.
        /// </summary>
        [FieldOffset(0)]
        public readonly short RegionID;



        [FieldOffset(0)]
        private readonly byte x;

        [FieldOffset(1)]
        private readonly byte y;

        
        private const int DUNGEON_MASK = 0b10000000_00000000;


        internal WRegionID(short wRegionID)
        {
            RegionID = wRegionID;
            x = (byte)( wRegionID % 256);
            y = (byte)( wRegionID / 256);
        }

        public bool Equals(WRegionID other)
            => this.Equals(other);

    }
}