using System;

namespace Structs.Tool
{
    [Flags]
    public enum SpawnType : byte
    {
        None = 0xFF,
        Monster = 0x00,
        Npc = 0x01,
        Unique = 0x02,
        Teleport = 0x03,
        Player = 0x04,
        Structure = 0x05,
        Nest = Monster | Npc | Unique,


    }
}