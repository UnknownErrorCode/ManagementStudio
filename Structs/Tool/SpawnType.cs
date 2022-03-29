namespace Structs.Tool
{
    public enum SpawnType : byte
    {
        None = 0xFF,
        Monster = 0x00,
        Npc = 0x01,
        Unique = 0x02,
        Teleport = 0x03,
        Player = 0x04
    }
}