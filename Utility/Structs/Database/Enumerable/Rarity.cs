using System;

namespace Structs.Database
{

    /// <summary>
    /// Defines the rarity of each monster / item ingame.
    /// </summary>
    [Flags]
    public enum Rarity : byte
    {
        MonsterGeneral = 0x00,
        MonsterChampion = 0x01,
        MonsterUnique = 0x03,
        MonsterGiant = 0x04,
        MonsterTitan = 0x05,
        MonsterElite = 0x06,
        MonsterStrongElite = 0x07,
        MonsterUniqueNoMsg = 0x08,

        /// <summary>
        /// ITEM_%
        /// </summary>
        ItemCommon = 0x00,

        /// <summary>
        /// ITEM_ETC_ARCHEMY_UPPER_REINFORCE_RECIPE_%
        /// </summary>
        ItemReinforce = 0x01,

        /// <summary>
        /// ITEM_%_RARE_%
        /// </summary>
        ItemSoX = 0x02,

        /// <summary>
        /// ITEM_%_SET_%
        /// </summary>
        ItemSet = 0x03,

        /// <summary>
        /// ITEM_%_SET_RARE_%
        /// </summary>
        ItemSetSoX = 0x06,

        /// <summary>
        /// ??? idk if this evenexists or works..
        /// </summary>
        ItemLegend = 0x07,

        /// <summary>
        /// ITEM_PRE_MALL_RETURN_SCROLL_HIGH_SPEED, 
        /// ITEM_PRE_MALL_HP_INC_1000_POTION
        /// </summary>
        ItemHighReturnScroll = 0x08,


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