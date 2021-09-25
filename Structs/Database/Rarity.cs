using System;

namespace Structs.Database
{
    [Flags]
    public enum Rarity : byte
    {
        General = 0x00,
        Champion = 0x01,
        Unique = 0x03,
        Giant = 0x04, 
        Titan = 0x05, 
        Elite = 0x06,
        StrongElite = 0x07,
        UniqueNoMsg = 0x08
    }
}


/*         case "General":
                    return 0;
                case "Champion":
                    return 1;
                case "Unique":
                    return 3;
                case "Giant":
                    return 4;
                case "Titan":
                    return 5;
                case "Elite":
                    return 6;
                case "Strong Elite":
                    return 7;
                case "No Msg Unique":
                    return 8;*/