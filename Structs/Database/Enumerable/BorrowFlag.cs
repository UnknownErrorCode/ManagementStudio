using System;

namespace Structs.Database
{
    [Flags]
    public enum BorrowFlag : byte
    {
        No = 0,
        Storage = 128,
        GuildStorage = 64,
        PetInventory = 32,
        Exchange = (Bit4 & Bit3 & Bit2 & Bit1 & Bit0),
        Bit4 = 16,
        Bit3 = 8,
        Bit2 = 4,
        Bit1 = 2,
        Bit0 = 1
    }
}