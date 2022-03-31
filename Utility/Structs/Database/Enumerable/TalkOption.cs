namespace Structs.Database
{
    public enum TalkOption : byte
    {
        Store = 1,
        Quest = 2,
        Storage = 3,
        Repair = 4,

        Monster = 5, // 圭쨍 (Click)

        Unknown6 = 6, // 캐 (Casserole)

        /// <summary>
        /// UIIT_CTL_RECALL_POSITION
        /// <para>Designate as return/recall point</para>
        /// </summary>
        SetReturnPoint = 7,

        /// <summary>
        /// UIIT_CTL_TELEPORT_TARGET
        /// <para>Select teleport area</para>
        /// </summary>
        TeleportTarget = 8,

        /// <summary>
        /// UIIT_CTL_TELEPORT_TO_RESURRECT_POS
        /// <param>Teleport to return point.</param>
        /// </summary>
        TeleportReturnPoint = 9,

        /// <summary>
        /// UIIT_MSG_CIRCULATION_WITHDRAW_SKILL
        /// <para>Withdrawing Skill</para>
        /// </summary>
        WithdrawSkill = 10,

        /// <summary>
        /// Nothing visual
        /// </summary>
        Stable = 11,

        /// <summary>
        /// Goods & Export Details
        /// </summary>
        Trade = 12,

        Guild = 15,

        /// <summary>
        /// SN_TALK_CH_GACHA_MACHINE_2
        /// <para>Participate in the game.</para>
        /// </summary>
        MagicPopPlay = 17,

        /// <summary>
        /// SN_TALK_CH_GACHA_OPERATOR_2
        /// <para>Exchange Item Exchange Coupon to Item</para>
        /// </summary>
        MagicPopExchange = 18,

        /// <summary>
        /// UIIT_MSG_XMAS_EVENT_CHANGE
        /// <para>Give the socks and receive a gift.</para>
        /// </summary>
        EventChristmasExchange = 19,

        Trader = 20,
        Tief = 21,
        Hunter = 22,

        FortressAdministration = 23,
        FortressApplication = 24,
        FortressStructManagement = 25,
        FortressItemProduction = 26,
        FortressTraining = 27,

        TeleportLastLocation = 28,

        TeleportGuide = 30,

        FortressPully = 31,

        GrantMagicOption = 32,

        ArenaManager = 33,
        ArenaItemManager = 34,

        Consigment = 35,

        SummonPartyMember = 39,

        TeleportExitFortressDungeon = 40,
        TeleportExitDungeon = 41,
    }
}