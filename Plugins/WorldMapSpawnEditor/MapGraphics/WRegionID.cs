using System;
using System.Runtime.InteropServices;

namespace WorldMapSpawnEditor.MapGraphics
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct WRegionID : IEquatable<WRegionID>
    {
        /// <summary>
        /// Specifies weather the region is a dungeon or not. ( <see cref="Value"/> AND <see cref="DUNGEON_MASK"/> ) != 0 
        /// </summary>
        public bool IsDungeon { get => (Value & DUNGEON_MASK) != 0; }

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
        public short Value;

        [FieldOffset(0)]
        private byte x;

        [FieldOffset(1)]
        private byte y;

        /// <summary>
        /// Constant integer 0b10000000_00000000;
        /// </summary>
        private const int DUNGEON_MASK = 0b10000000_00000000;


        internal WRegionID(short wRegionID)
        {
            Value = wRegionID;
            x = (byte)( wRegionID % 255);
            y = (byte)( wRegionID / 255);
        }

        public bool Equals(WRegionID other)
            => this.Equals(other);

    }
}