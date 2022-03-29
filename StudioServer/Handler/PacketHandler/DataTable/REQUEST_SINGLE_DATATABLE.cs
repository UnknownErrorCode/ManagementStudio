using ServerFrameworkRes.Network.Security;

namespace StudioServer.Handler.PacketHandler
{
    class REQUEST_SINGLE_DATATABLE
    {
        public static Packet Request(Packet packet)
        {

            string tab = packet.ReadAscii();


            if (tab == "_AccountJID")
            {
                packet = new Packet(0x4000, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [AccountID],[JID],[Gold] from _AccountJID;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_AlliedClans")
            {
                packet = new Packet(0x4001, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[Ally1],[Ally2],[Ally3],[Ally4],[Ally5],[Ally6],[Ally7],[Ally8],[FoundationDate],[LastCrestRev],[CurCrestRev] from _AlliedClans;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_AssociationReputation")
            {
                packet = new Packet(0x4002, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [AssociationCodeName],[AssociationTypeName],[Reputation],[PriorOccupation] from _AssociationReputation;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_BindingOptionWithItem")
            {
                packet = new Packet(0x4003, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [nItemDBID],[bOptType],[nSlot],[nOptID],[nOptLvl],[nOptValue],[nParam1],[nParam2] from _BindingOptionWithItem;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_BlackNameList")
            {
                packet = new Packet(0x4004, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [BlacklistName] from _BlackNameList;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_BlockedWhisperers")
            {
                packet = new Packet(0x4005, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [OwnerID],[TargetName] from _BlockedWhisperers;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_Char")
            {
                packet = new Packet(0x4006, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharID],[Deleted],[RefObjID],[CharName16],[NickName16],[Scale],[CurLevel],[MaxLevel],[ExpOffset],[SExpOffset],[Strength],[Intellect],[RemainGold],[RemainSkillPoint],[RemainStatPoint],[RemainHwanCount],[GatheredExpPoint],[HP],[MP],[LatestRegion],[PosX],[PosY],[PosZ],[AppointedTeleport],[AutoInvestExp],[InventorySize],[DailyPK],[TotalPK],[PKPenaltyPoint],[TPP],[PenaltyForfeit],[JobPenaltyTime],[JobLvl_Trader],[Trader_Exp],[JobLvl_Hunter],[Hunter_Exp],[JobLvl_Robber],[Robber_Exp],[GuildID],[LastLogout],[TelRegion],[TelPosX],[TelPosY],[TelPosZ],[DiedRegion],[DiedPosX],[DiedPosY],[DiedPosZ],[WorldID],[TelWorldID],[DiedWorldID],[HwanLevel] from _Char;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_CharCollectionBook")
            {
                packet = new Packet(0x4007, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharID],[ThemeID],[SlotIndex],[RegDate] from _CharCollectionBook;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_CharCOS")
            {
                packet = new Packet(0x4008, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[OwnerCharID],[RefCharID],[HP],[MP],[KeeperNPC],[State],[CharName],[Lvl],[ExpOffset],[HGP],[PetOption],[RentEndTime] from _CharCOS;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_CharInstanceWorldData")
            {
                packet = new Packet(0x4009, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharID],[DungeonKeyID],[WorldID],[LayerID],[OpenedTime],[RegionID],[PosX],[PosY],[PosZ],[IsActivated],[EnterCount],[LastEnterTime] from _CharInstanceWorldData;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_CharNameList")
            {
                packet = new Packet(0x4010, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharName16],[CharID] from _CharNameList;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_CharNickNameList")
            {
                packet = new Packet(0x4011, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [NickName16],[CharID] from _CharNickNameList;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_CharQuest")
            {
                packet = new Packet(0x4012, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharID],[QuestID],[Status],[AchievementCount],[StartTime],[EndTime],[QuestData1],[QuestData2] from _CharQuest;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_CharSkill")
            {
                packet = new Packet(0x4013, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharID],[SkillID],[Enable] from _CharSkill;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_CharSkillMastery")
            {
                packet = new Packet(0x4014, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharID],[MasteryID],[Level] from _CharSkillMastery;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_CharTrijob")
            {
                packet = new Packet(0x4015, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharID],[JobType],[Level],[Exp],[Contribution],[Reward] from _CharTrijob;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_CharTrijobSafeTrade")
            {
                packet = new Packet(0x4016, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharID],[AbleCount],[Status],[LastSafeTrade] from _CharTrijobSafeTrade;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_Chest")
            {
                packet = new Packet(0x4017, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [UserJID],[Slot],[ItemID] from _Chest;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_ChestInfo")
            {
                packet = new Packet(0x4018, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [JID],[ChestSize] from _ChestInfo;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_ClientConfig")
            {
                packet = new Packet(0x4019, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharID],[ConfigType],[SlotSeq],[SlotType],[Data] from _ClientConfig;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_DeletedChar")
            {
                packet = new Packet(0x4020, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharID],[UserJID],[DeletedDate] from _DeletedChar;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_ExploitLog")
            {
                packet = new Packet(0x4021, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[CharID],[DetectedApp],[Description],[LogTime] from _ExploitLog;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_FlagWorld_EventParticipants")
            {
                packet = new Packet(0x4022, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [JID],[LatestAttempt],[Count] from _FlagWorld_EventParticipants;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_FleaMarketNetwork")
            {
                packet = new Packet(0x4023, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [AbleOpen],[CharID],[Slot],[TidGroupID],[ItemClass],[ItemCount],[MakeZone],[Cash] from _FleaMarketNetwork;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_FreeAccessBanLvl")
            {
                packet = new Packet(0x4024, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [JID],[BanLvl],[EndTime] from _FreeAccessBanLvl;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_Friend")
            {
                packet = new Packet(0x4025, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharID],[FriendCharID],[FriendCharName],[RefObjID] from _Friend;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_GPHistory")
            {
                packet = new Packet(0x4026, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[GuildID],[UsedTime],[CharName],[UsedGP],[Reason] from _GPHistory;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_Guild")
            {
                packet = new Packet(0x4027, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[Name],[Lvl],[GatheredSP],[FoundationDate],[Alliance],[MasterCommentTitle],[MasterComment],[Booty],[Gold],[LastCrestRev],[CurCrestRev],[MercenaryAttr],[MasterName] from _Guild;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_GuildChest")
            {
                packet = new Packet(0x4028, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [GuildID],[Slot],[ItemID] from _GuildChest;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_GuildMember")
            {
                packet = new Packet(0x4029, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [GuildID],[CharID],[CharName],[MemberClass],[CharLevel],[GP_Donation],[JoinDate],[Permission],[Contribution],[GuildWarKill],[GuildWarKilled],[Nickname],[RefObjID],[SiegeAuthority] from _GuildMember;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_GuildWar")
            {
                packet = new Packet(0x4030, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[WarType],[VictoryPointIndex],[LodgedGold],[WarEndTime],[Guild1],[Guild2],[PointGain1],[PointGain2],[Data1],[Data2] from _GuildWar;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_InvCOS")
            {
                packet = new Packet(0x4031, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [COSID],[Slot],[ItemID] from _InvCOS;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_Inventory")
            {
                packet = new Packet(0x4032, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharID],[Slot],[ItemID] from _Inventory;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_InventoryForAvatar")
            {
                packet = new Packet(0x4033, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharID],[Slot],[ItemID] from _InventoryForAvatar;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_InventoryForLinkedStorage")
            {
                packet = new Packet(0x4034, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [LinkedItemID],[Slot],[ItemID] from _InventoryForLinkedStorage;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_ItemPool")
            {
                packet = new Packet(0x4035, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ItemID],[InUse] from _ItemPool;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_ItemQuotation")
            {
                packet = new Packet(0x4036, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[Service],[AssocNPC],[RefItemID],[BaseQuot],[Quot_LB],[Quot_UB],[BaseStockAmount],[FluctuateAmount],[CurStockAmount] from _ItemQuotation;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_Items")
            {
                packet = new Packet(0x4037, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID64],[RefItemID],[OptLevel],[Variance],[Data],[CreaterName],[MagParamNum],[MagParam1],[MagParam2],[MagParam3],[MagParam4],[MagParam5],[MagParam6],[MagParam7],[MagParam8],[MagParam9],[MagParam10],[MagParam11],[MagParam12],[Serial64] from _Items;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_LatestItemSerial")
            {
                packet = new Packet(0x4038, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [LatestItemSerial] from _LatestItemSerial;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_Log_SEEK_N_DESTROY_ITEM_FAST")
            {
                packet = new Packet(0x4039, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [DeletedTime],[OwnerType],[OwnerID],[ID64],[CodeName],[OptLevel],[Variance],[Data] from _Log_SEEK_N_DESTROY_ITEM_FAST;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_Memo")
            {
                packet = new Packet(0x4040, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID64],[CharID],[FromCharName],[Message],[Date],[Status],[RefObjID] from _Memo;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_OldTrijob")
            {
                packet = new Packet(0x4041, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharID],[JobLvl_Trader],[Trader_Exp],[JobLvl_Robber],[Robber_Exp],[JobLvl_Hunter],[Hunter_Exp] from _OldTrijob;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_OpenMarket")
            {
                packet = new Packet(0x4042, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [JID],[PersnalID],[CharName16],[Status],[RefItemID],[TidGroupID],[ItemClass],[ItemID],[SellCnt],[RegDate],[EndDate],[Price],[Deposit],[SellFee],[UseCash],[Serial64] from _OpenMarket;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefAbilityByItemOptLevel")
            {
                packet = new Packet(0x4043, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[RefItemID],[ItemOptLevel] from _RefAbilityByItemOptLevel;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefAccessPermissionOfShop")
            {
                packet = new Packet(0x4044, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[RefShopCodeName],[AcceptOrReject],[FourCC],[Param1],[Param1_Desc128],[Param2],[Param2_Desc128],[Param3],[Param3_Desc128],[Param4],[Param4_Desc128] from _RefAccessPermissionOfShop;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefAlchemyMerit")
            {
                packet = new Packet(0x4045, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Group],[OptName128],[Level],[Weapon],[Armor],[Accessory],[Shield],[FreeParam1],[FreeParamDesc1],[FreeParam2],[FreeParamDesc2],[FreeParam3],[FreeParamDesc3] from _RefAlchemyMerit;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefCharDefault_Quest")
            {
                packet = new Packet(0x4046, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[Race],[CodeName],[RequiredLevel] from _RefCharDefault_Quest;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefCharDefault_Skill")
            {
                packet = new Packet(0x4047, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Race],[SkillID] from _RefCharDefault_Skill;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefCharDefault_SkillMastery")
            {
                packet = new Packet(0x4048, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Race],[MasteryID] from _RefCharDefault_SkillMastery;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefCharGen")
            {
                packet = new Packet(0x4049, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[RefObjID] from _RefCharGen;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefClimate")
            {
                packet = new Packet(0x4050, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[InitialWeather],[InitialAmount],[ChangeWeather],[Division],[Duration],[DurationVariance],[Snowfall],[SnowfallVariance],[ProbSnow],[Rainfall],[RainfallVariance],[ProbRain] from _RefClimate;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefCollectionBook_Item")
            {
                packet = new Packet(0x4051, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[CodeName128],[ObjName128],[ThemeCodeName128],[SlotIndex],[Story128],[DDJFile128] from _RefCollectionBook_Item;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefCollectionBook_Theme")
            {
                packet = new Packet(0x4052, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[CodeName128],[ObjName128],[Name128],[Desc128],[CompleteNum] from _RefCollectionBook_Theme;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefConditionToBuyScrapItem")
            {
                packet = new Packet(0x4053, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[Cash],[TypeID1],[TypeID2],[TypeID3],[TypeID4],[RefItemCodeName],[AcceptOrReject],[FourCC],[Param1],[Param1_Desc128],[Param2],[Param2_Desc128],[Param3],[Param3_Desc128],[Param4],[Param4_Desc128] from _RefConditionToBuyScrapItem;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefConditionToSellPackageItem")
            {
                packet = new Packet(0x4054, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[RefPackageItemCodeName],[AcceptOrReject],[FourCC],[Param1],[Param1_Desc128],[Param2],[Param2_Desc128],[Param3],[Param3_Desc128],[Param4],[Param4_Desc128] from _RefConditionToSellPackageItem;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefConditionToSellScrapItem")
            {
                packet = new Packet(0x4055, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[Cash],[TypeID1],[TypeID2],[TypeID3],[TypeID4],[RefItemCodeName],[AcceptOrReject],[FourCC],[Param1],[Param1_Desc128],[Param2],[Param2_Desc128],[Param3],[Param3_Desc128],[Param4],[Param4_Desc128] from _RefConditionToSellScrapItem;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefCustomizingReservedItemDropForMonster")
            {
                packet = new Packet(0x4056, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [RefMonsterID],[Rarity],[Command],[DropGroupType],[Param1],[Param2],[Param3],[Param4],[Param5] from _RefCustomizingReservedItemDropForMonster;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefDropClassSel_Alchemy_ATTRStone")
            {
                packet = new Packet(0x4057, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [MonLevel],[ProbGroup1],[ProbGroup2],[ProbGroup3],[ProbGroup4],[ProbGroup5],[ProbGroup6],[ProbGroup7],[ProbGroup8],[ProbGroup9],[ProbGroup10],[ProbGroup11],[ProbGroup12] from _RefDropClassSel_Alchemy_ATTRStone;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefDropClassSel_Alchemy_MagicStone")
            {
                packet = new Packet(0x4058, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [MonLevel],[ProbGroup1],[ProbGroup2],[ProbGroup3],[ProbGroup4],[ProbGroup5],[ProbGroup6],[ProbGroup7],[ProbGroup8],[ProbGroup9],[ProbGroup10],[ProbGroup11],[ProbGroup12] from _RefDropClassSel_Alchemy_MagicStone;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefDropClassSel_Alchemy_Tablet")
            {
                packet = new Packet(0x4059, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [MonLevel],[ProbGroup1],[ProbGroup2],[ProbGroup3],[ProbGroup4],[ProbGroup5],[ProbGroup6],[ProbGroup7],[ProbGroup8],[ProbGroup9],[ProbGroup10],[ProbGroup11],[ProbGroup12] from _RefDropClassSel_Alchemy_Tablet;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefDropClassSel_Ammo")
            {
                packet = new Packet(0x4060, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [MonLevel],[ProbGroup1],[ProbGroup2],[ProbGroup3],[ProbGroup4],[ProbGroup5],[ProbGroup6] from _RefDropClassSel_Ammo;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefDropClassSel_Cure")
            {
                packet = new Packet(0x4061, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [MonLevel],[ProbGroup1],[ProbGroup2],[ProbGroup3],[ProbGroup4],[ProbGroup5],[ProbGroup6],[ProbGroup7],[ProbGroup8],[ProbGroup9],[ProbGroup10],[ProbGroup11],[ProbGroup12],[ProbGroup13],[ProbGroup14] from _RefDropClassSel_Cure;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefDropClassSel_Equip")
            {
                packet = new Packet(0x4062, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [MonLevel],[ProbGroup1],[ProbGroup2],[ProbGroup3],[ProbGroup4],[ProbGroup5],[ProbGroup6],[ProbGroup7],[ProbGroup8],[ProbGroup9],[ProbGroup10],[ProbGroup11],[ProbGroup12],[ProbGroup13],[ProbGroup14],[ProbGroup15],[ProbGroup16],[ProbGroup17],[ProbGroup18],[ProbGroup19],[ProbGroup20],[ProbGroup21],[ProbGroup22],[ProbGroup23],[ProbGroup24],[ProbGroup25],[ProbGroup26],[ProbGroup27],[ProbGroup28],[ProbGroup29],[ProbGroup30],[ProbGroup31],[ProbGroup32],[ProbGroup33],[ProbGroup34],[ProbGroup35],[ProbGroup36] from _RefDropClassSel_Equip;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefDropClassSel_RareEquip")
            {
                packet = new Packet(0x4063, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [MonLevel],[ProbGroup1],[ProbGroup2],[ProbGroup3],[ProbGroup4],[ProbGroup5],[ProbGroup6],[ProbGroup7],[ProbGroup8],[ProbGroup9],[ProbGroup10],[ProbGroup11],[ProbGroup12],[ProbGroup13],[ProbGroup14],[ProbGroup15],[ProbGroup16],[ProbGroup17],[ProbGroup18],[ProbGroup19],[ProbGroup20],[ProbGroup21],[ProbGroup22],[ProbGroup23],[ProbGroup24],[ProbGroup25],[ProbGroup26],[ProbGroup27],[ProbGroup28],[ProbGroup29],[ProbGroup30],[ProbGroup31],[ProbGroup32],[ProbGroup33],[ProbGroup34],[ProbGroup35],[ProbGroup36] from _RefDropClassSel_RareEquip;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefDropClassSel_Recover")
            {
                packet = new Packet(0x4064, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [MonLevel],[ProbGroup1],[ProbGroup2],[ProbGroup3],[ProbGroup4],[ProbGroup5],[ProbGroup6],[ProbGroup7] from _RefDropClassSel_Recover;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefDropClassSel_Reinforce")
            {
                packet = new Packet(0x4065, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [MonLevel],[ProbGroup1],[ProbGroup2] from _RefDropClassSel_Reinforce;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefDropClassSel_Scroll")
            {
                packet = new Packet(0x4066, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [MonLevel],[ProbGroup1],[ProbGroup2],[ProbGroup3] from _RefDropClassSel_Scroll;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefDropGold")
            {
                packet = new Packet(0x4067, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [MonLevel],[DropProb],[GoldMin],[GoldMax] from _RefDropGold;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefDropItemAssign")
            {
                packet = new Packet(0x4068, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[RefItemID],[Prob_Relative],[Prob_Absolute],[AssignedGroup],[DropCount] from _RefDropItemAssign;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefDropItemGroup")
            {
                packet = new Packet(0x4069, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[RefItemGroupID],[CodeName128],[RefItemID],[SelectRatio],[RefMagicGroupID] from _RefDropItemGroup;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefDropOptLvlSel")
            {
                packet = new Packet(0x4070, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [OptLevel],[Prob],[ReqOnlineTime] from _RefDropOptLvlSel;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefDummySlot")
            {
                packet = new Packet(0x4071, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [cnt] from _RefDummySlot;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefEvent")
            {
                packet = new Packet(0x4072, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[CodeName],[DescName],[ScheduleName],[ScheduleCount] from _RefEvent;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefEventReward")
            {
                packet = new Packet(0x4073, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[EventID],[EventCodeName],[IsView],[IsBasicReward],[IsItemReward],[IsCheckCondition],[IsCheckCountry],[IsCheckClass],[IsCheckGender],[Gold],[Exp],[SPExp],[SP],[Hwan],[Inventory],[ItemRewardType],[SelectionCnt],[Param1],[Param1_Desc],[Param2],[Param2_Desc],[Param3],[Param3_Desc] from _RefEventReward;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefEventRewardItems")
            {
                packet = new Packet(0x4074, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[EventID],[EventCodeName],[ItemCodeName],[PayCount],[AchieveRatio],[RentItemCodeName],[Param1],[Param1_Desc],[Param2],[Param2_Desc] from _RefEventRewardItems;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefEventZone")
            {
                packet = new Packet(0x4075, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[ZoneName],[EventName],[Param1],[Param2],[Param3],[Param4],[Param5],[strParam1],[strParam2],[strParam3],[strParam4],[strParam5] from _RefEventZone;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefFmnCategoryTree")
            {
                packet = new Packet(0x4076, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[CategoryName],[StringID],[ParentCategoryName],[TidGroupID],[Degree] from _RefFmnCategoryTree;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefFmnTidGroup")
            {
                packet = new Packet(0x4077, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [TidGroupID],[TidGroupName] from _RefFmnTidGroup;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefFmnTidGroupMap")
            {
                packet = new Packet(0x4078, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[TidGroupID],[TypeID1],[TypeID2],[TypeID3],[TypeID4] from _RefFmnTidGroupMap;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefGachaCode")
            {
                packet = new Packet(0x4079, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CodeName128],[GachaSetID] from _RefGachaCode;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefGachaItemSet")
            {
                packet = new Packet(0x4080, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Set_ID],[RefItemID],[Ratio],[Count],[GachaID],[Visible],[param1],[param1_Desc128],[param2],[param2_Desc128],[param3],[param3_Desc128],[param4],[param4_Desc128] from _RefGachaItemSet;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefGachaNpcMap")
            {
                packet = new Packet(0x4081, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[NPC_ID],[SelectionGachaID],[WasteGachaID] from _RefGachaNpcMap;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefGame_World")
            {
                packet = new Packet(0x4082, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[WorldCodeName128],[Type],[WorldMaxCount],[WorldMaxUserCount],[WorldEntryType],[WorldEntranceType],[WorldLeaveType],[WorldDurationTime],[WorldEmptyRemainTime],[ConfigGroupCodeName128] from _RefGame_World;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefGame_World_Config")
            {
                packet = new Packet(0x4083, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[GroupCodeName128],[ValueCodeName128],[Value],[Type] from _RefGame_World_Config;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefGameWorldBindGameWorldGroup")
            {
                packet = new Packet(0x4084, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[GameWorldID],[GameWorldGroupID] from _RefGameWorldBindGameWorldGroup;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefGameWorldBindTriggerCategory")
            {
                packet = new Packet(0x4085, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[GameWorldID],[TriggerCategoryID] from _RefGameWorldBindTriggerCategory;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefGameWorldGroup")
            {
                packet = new Packet(0x4086, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[CodeName128],[ObjName128],[ConfigGroupCodeName128] from _RefGameWorldGroup;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefGameWorldGroup_Config")
            {
                packet = new Packet(0x4087, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[GroupCodeName128],[ValueCodeName128],[Value],[Type] from _RefGameWorldGroup_Config;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefGameWorldNPC")
            {
                packet = new Packet(0x4088, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[WorldCodeName128],[NPCCodeName128],[RegionID],[PosX],[PosY],[PosZ],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10] from _RefGameWorldNPC;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefHWANLevel")
            {
                packet = new Packet(0x4089, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [HwanLevel],[ParamFourcc1],[ParamValue1],[ParamFourcc2],[ParamValue2],[ParamFourcc3],[ParamValue3],[ParamFourcc4],[ParamValue4],[ParamFourcc5],[ParamValue5],[AssocFileObj128],[Title_CH70],[Title_EU70] from _RefHWANLevel;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefInstance_World_Region")
            {
                packet = new Packet(0x4090, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [WorldID],[RegionID] from _RefInstance_World_Region;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefInstance_World_Start_Pos")
            {
                packet = new Packet(0x4091, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [WorldID],[RegionID],[PosX],[PosY],[PosZ],[Param] from _RefInstance_World_Start_Pos;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefLatestItemSerial")
            {
                packet = new Packet(0x4092, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [LatestItemSerial] from _RefLatestItemSerial;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefLevel")
            {
                packet = new Packet(0x4093, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Lvl],[Exp_C],[Exp_M],[Cost_M],[Cost_ST],[GUST_Mob_Exp],[JobExp_Trader],[JobExp_Robber],[JobExp_Hunter] from _RefLevel;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefMagicOpt")
            {
                packet = new Packet(0x4094, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[MOptName128],[AttrType],[MLevel],[Prob],[Weight],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16],[ExcFunc1],[ExcFunc2],[ExcFunc3],[ExcFunc4],[ExcFunc5],[ExcFunc6],[AvailItemGroup1],[ReqClass1],[AvailItemGroup2],[ReqClass2],[AvailItemGroup3],[ReqClass3],[AvailItemGroup4],[ReqClass4],[AvailItemGroup5],[ReqClass5],[AvailItemGroup6],[ReqClass6],[AvailItemGroup7],[ReqClass7],[AvailItemGroup8],[ReqClass8],[AvailItemGroup9],[ReqClass9],[AvailItemGroup10],[ReqClass10] from _RefMagicOpt;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefMagicOptAssign")
            {
                packet = new Packet(0x4095, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Race],[TID3],[TID4],[AvailMOpt1],[AvailMOpt2],[AvailMOpt3],[AvailMOpt4],[AvailMOpt5],[AvailMOpt6],[AvailMOpt7],[AvailMOpt8],[AvailMOpt9],[AvailMOpt10],[AvailMOpt11],[AvailMOpt12],[AvailMOpt13],[AvailMOpt14],[AvailMOpt15],[AvailMOpt16],[AvailMOpt17],[AvailMOpt18],[AvailMOpt19],[AvailMOpt20],[AvailMOpt21],[AvailMOpt22],[AvailMOpt23],[AvailMOpt24],[AvailMOpt25] from _RefMagicOptAssign;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefMagicOptByItemOptLevel")
            {
                packet = new Packet(0x4096, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Link],[RefMagicOptID],[MagicOptValue],[TooltipType],[TooltipCodename] from _RefMagicOptByItemOptLevel;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefMagicOptGroup")
            {
                packet = new Packet(0x4097, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[LinkID],[MagicType],[CodeName128],[MOptID],[MOptLevel],[Value],[Param1],[Param1_Desc],[Param2],[Param2_Desc] from _RefMagicOptGroup;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefMappingShopGroup")
            {
                packet = new Packet(0x4098, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[RefShopGroupCodeName],[RefShopCodeName] from _RefMappingShopGroup;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefMappingShopWithTab")
            {
                packet = new Packet(0x4099, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[RefShopCodeName],[RefTabGroupCodeName] from _RefMappingShopWithTab;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefMonster_AssignedItemDrop")
            {
                packet = new Packet(0x4100, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [RefMonsterID],[RefItemID],[DropGroupType],[OptLevel],[DropAmountMin],[DropAmountMax],[DropRatio],[RefMagicOptionID1],[CustomValue1],[RefMagicOptionID2],[CustomValue2],[RefMagicOptionID3],[CustomValue3],[RefMagicOptionID4],[CustomValue4],[RefMagicOptionID5],[CustomValue5],[RefMagicOptionID6],[CustomValue6],[RefMagicOptionID7],[CustomValue7],[RefMagicOptionID8],[CustomValue8],[RefMagicOptionID9],[CustomValue9],[RentCodeName] from _RefMonster_AssignedItemDrop;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefMonster_AssignedItemRndDrop")
            {
                packet = new Packet(0x4101, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[RefMonsterID],[RefItemGroupID],[ItemGroupCodeName128],[Overlap],[DropAmountMin],[DropAmountMax],[DropRatio],[param1],[param2] from _RefMonster_AssignedItemRndDrop;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefObjChar")
            {
                packet = new Packet(0x4102, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[Lvl],[CharGender],[MaxHP],[MaxMP],[ResistFrozen],[ResistFrostbite],[ResistBurn],[ResistEShock],[ResistPoison],[ResistZombie],[ResistSleep],[ResistRoot],[ResistSlow],[ResistFear],[ResistMyopia],[ResistBlood],[ResistStone],[ResistDark],[ResistStun],[ResistDisea],[ResistChaos],[ResistCsePD],[ResistCseMD],[ResistCseSTR],[ResistCseINT],[ResistCseHP],[ResistCseMP],[Resist24],[ResistBomb],[Resist26],[Resist27],[Resist28],[Resist29],[Resist30],[Resist31],[Resist32],[InventorySize],[CanStore_TID1],[CanStore_TID2],[CanStore_TID3],[CanStore_TID4],[CanBeVehicle],[CanControl],[DamagePortion],[MaxPassenger],[AssocTactics],[PD],[MD],[PAR],[MAR],[ER],[BR],[HR],[CHR],[ExpToGive],[CreepType],[Knockdown],[KO_RecoverTime],[DefaultSkill_1],[DefaultSkill_2],[DefaultSkill_3],[DefaultSkill_4],[DefaultSkill_5],[DefaultSkill_6],[DefaultSkill_7],[DefaultSkill_8],[DefaultSkill_9],[DefaultSkill_10],[TextureType],[Except_1],[Except_2],[Except_3],[Except_4],[Except_5],[Except_6],[Except_7],[Except_8],[Except_9],[Except_10],[Link] from _RefObjChar;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefObjCharExtraSkill")
            {
                packet = new Packet(0x4103, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[CharID],[ExtraSkill_1],[ExtraSkill_2],[ExtraSkill_3],[ExtraSkill_4],[ExtraSkill_5],[ExtraSkill_6],[ExtraSkill_7],[ExtraSkill_8],[ExtraSkill_9],[ExtraSkill_10],[ExtraSkill_11],[ExtraSkill_12],[ExtraSkill_13],[ExtraSkill_14],[ExtraSkill_15],[ExtraSkill_16],[ExtraSkill_17],[ExtraSkill_18],[ExtraSkill_19],[ExtraSkill_20] from _RefObjCharExtraSkill;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefObjCommon")
            {
                packet = new Packet(0x4104, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[CodeName128],[ObjName128],[OrgObjCodeName128],[NameStrID128],[DescStrID128],[CashItem],[Bionic],[TypeID1],[TypeID2],[TypeID3],[TypeID4],[DecayTime],[Country],[Rarity],[CanTrade],[CanSell],[CanBuy],[CanBorrow],[CanDrop],[CanPick],[CanRepair],[CanRevive],[CanUse],[CanThrow],[Price],[CostRepair],[CostRevive],[CostBorrow],[KeepingFee],[SellPrice],[ReqLevelType1],[ReqLevel1],[ReqLevelType2],[ReqLevel2],[ReqLevelType3],[ReqLevel3],[ReqLevelType4],[ReqLevel4],[MaxContain],[RegionID],[Dir],[OffsetX],[OffsetY],[OffsetZ],[Speed1],[Speed2],[Scale],[BCHeight],[BCRadius],[EventID],[AssocFileObj128],[AssocFileDrop128],[AssocFileIcon128],[AssocFile1_128],[AssocFile2_128],[Link] from _RefObjCommon;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefObjItem")
            {
                packet = new Packet(0x4105, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[MaxStack],[ReqGender],[ReqStr],[ReqInt],[ItemClass],[SetID],[Dur_L],[Dur_U],[PD_L],[PD_U],[PDInc],[ER_L],[ER_U],[ERInc],[PAR_L],[PAR_U],[PARInc],[BR_L],[BR_U],[MD_L],[MD_U],[MDInc],[MAR_L],[MAR_U],[MARInc],[PDStr_L],[PDStr_U],[MDInt_L],[MDInt_U],[Quivered],[Ammo1_TID4],[Ammo2_TID4],[Ammo3_TID4],[Ammo4_TID4],[Ammo5_TID4],[SpeedClass],[TwoHanded],[Range],[PAttackMin_L],[PAttackMin_U],[PAttackMax_L],[PAttackMax_U],[PAttackInc],[MAttackMin_L],[MAttackMin_U],[MAttackMax_L],[MAttackMax_U],[MAttackInc],[PAStrMin_L],[PAStrMin_U],[PAStrMax_L],[PAStrMax_U],[MAInt_Min_L],[MAInt_Min_U],[MAInt_Max_L],[MAInt_Max_U],[HR_L],[HR_U],[HRInc],[CHR_L],[CHR_U],[Param1],[Desc1_128],[Param2],[Desc2_128],[Param3],[Desc3_128],[Param4],[Desc4_128],[Param5],[Desc5_128],[Param6],[Desc6_128],[Param7],[Desc7_128],[Param8],[Desc8_128],[Param9],[Desc9_128],[Param10],[Desc10_128],[Param11],[Desc11_128],[Param12],[Desc12_128],[Param13],[Desc13_128],[Param14],[Desc14_128],[Param15],[Desc15_128],[Param16],[Desc16_128],[Param17],[Desc17_128],[Param18],[Desc18_128],[Param19],[Desc19_128],[Param20],[Desc20_128],[MaxMagicOptCount],[ChildItemCount],[Link] from _RefObjItem;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefObjStruct")
            {
                packet = new Packet(0x4106, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[Dummy_Data] from _RefObjStruct;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefOptionalTeleport")
            {
                packet = new Packet(0x4107, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[ObjName128],[ZoneName128],[RegionID],[Pos_X],[Pos_Y],[Pos_Z],[WorldID],[RegionIDGroup],[MapPoint],[LevelMin],[LevelMax],[Param1],[Param1_Desc_128],[Param2],[Param2_Desc_128],[Param3],[Param3_Desc_128] from _RefOptionalTeleport;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefPackageItem")
            {
                packet = new Packet(0x4108, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[ID],[CodeName128],[SaleTag],[ExpandTerm],[NameStrID],[DescStrID],[AssocFileIcon],[Param1],[Param1_Desc128],[Param2],[Param2_Desc128],[Param3],[Param3_Desc128],[Param4],[Param4_Desc128] from _RefPackageItem;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefPricePolicyOfItem")
            {
                packet = new Packet(0x4109, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[RefPackageItemCodeName],[PaymentDevice],[PreviousCost],[Cost],[Param1],[Param1_Desc128],[Param2],[Param2_Desc128],[Param3],[Param3_Desc128],[Param4],[Param4_Desc128],[index] from _RefPricePolicyOfItem;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefQuest")
            {
                packet = new Packet(0x4110, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[CodeName],[Level],[DescName],[NameString],[PayString],[ContentsString],[PayContents],[NoticeNPC],[NoticeCondition] from _RefQuest;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefQuestReward")
            {
                packet = new Packet(0x4111, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[QuestID],[QuestCodeName],[IsView],[IsBasicReward],[IsItemReward],[IsCheckCondition],[IsCheckCountry],[IsCheckClass],[IsCheckGender],[Gold],[Exp],[SPExp],[SP],[AP],[APType],[Hwan],[Inventory],[ItemRewardType],[SelectionCnt],[Param1],[Param1_Desc],[Param2],[Param2_Desc],[Param3],[Param3_Desc] from _RefQuestReward;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefQuestRewardItems")
            {
                packet = new Packet(0x4112, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[QuestID],[QuestCodeName],[RewardType],[ItemCodeName],[OptionalItemCode],[OptionalItemCnt],[AchieveQuantity],[RentItemCodeName],[Param1],[Param1_Desc],[Param2],[Param2_Desc] from _RefQuestRewardItems;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefRegion")
            {
                packet = new Packet(0x4113, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [wRegionID],[X],[Z],[ContinentName],[AreaName],[IsBattleField],[Climate],[MaxCapacity],[AssocObjID],[AssocServer],[AssocFile256],[LinkedRegion_1],[LinkedRegion_2],[LinkedRegion_3],[LinkedRegion_4],[LinkedRegion_5],[LinkedRegion_6],[LinkedRegion_7],[LinkedRegion_8],[LinkedRegion_9],[LinkedRegion_10] from _RefRegion;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefRegion_bak")
            {
                packet = new Packet(0x4114, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [wRegionID],[X],[Z],[ContinentName],[AreaName],[IsBattleField],[Climate],[MaxCapacity],[AssocObjID],[AssocServer],[AssocFile256],[LinkedRegion_1],[LinkedRegion_2],[LinkedRegion_3],[LinkedRegion_4],[LinkedRegion_5],[LinkedRegion_6],[LinkedRegion_7],[LinkedRegion_8],[LinkedRegion_9],[LinkedRegion_10] from _RefRegion_bak;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefRegionBindAssocServer")
            {
                packet = new Packet(0x4115, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [AreaName],[AssocServer] from _RefRegionBindAssocServer;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefRegionBindAssocServer_bak")
            {
                packet = new Packet(0x4116, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [AreaName],[AssocServer] from _RefRegionBindAssocServer_bak;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefRentItem")
            {
                packet = new Packet(0x4117, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [service],[RentCodeName],[RefItemID],[CanDelete],[CnaRecharge],[RentType],[StartTime],[EndTime],[TimeCnt],[Time1],[Time2],[Time3],[Time4],[Time5] from _RefRentItem;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefRewardPolicyToBuyScrapItem")
            {
                packet = new Packet(0x4118, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[Cash],[TypeID1],[TypeID2],[TypeID3],[TypeID4],[RefItemCodeName],[AcceptOrReject],[FourCC],[Param1],[Param1_Desc128],[Param2],[Param2_Desc128],[Param3],[Param3_Desc128],[Param4],[Param4_Desc128] from _RefRewardPolicyToBuyScrapItem;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefRewardPolicyToSellPackageItem")
            {
                packet = new Packet(0x4119, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[RefPackageItemCodeName],[AcceptOrReject],[FourCC],[Param1],[Param1_Desc128],[Param2],[Param2_Desc128],[Param3],[Param3_Desc128],[Param4],[Param4_Desc128] from _RefRewardPolicyToSellPackageItem;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefRewardPolicyToSellScrapItem")
            {
                packet = new Packet(0x4120, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[Cash],[TypeID1],[TypeID2],[TypeID3],[TypeID4],[RefItemCodeName],[AcceptOrReject],[FourCC],[Param1],[Param1_Desc128],[Param2],[Param2_Desc128],[Param3],[Param3_Desc128],[Param4],[Param4_Desc128] from _RefRewardPolicyToSellScrapItem;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefScheduleDefine")
            {
                packet = new Packet(0x4121, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ScheduleDefineIdx],[ScheduleName],[Description] from _RefScheduleDefine;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefScrapOfPackageItem")
            {
                packet = new Packet(0x4122, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[RefPackageItemCodeName],[RefItemCodeName],[OptLevel],[Variance],[Data],[MagParamNum],[MagParam1],[MagParam2],[MagParam3],[MagParam4],[MagParam5],[MagParam6],[MagParam7],[MagParam8],[MagParam9],[MagParam10],[MagParam11],[MagParam12],[Param1],[Param1_Desc128],[Param2],[Param2_Desc128],[Param3],[Param3_Desc128],[Param4],[Param4_Desc128],[Index] from _RefScrapOfPackageItem;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefServerEvent")
            {
                packet = new Packet(0x4123, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[DetectingTargetType],[DetectingTargetID],[Name],[BeginDate],[EndDate],[NotificationTypeDetectingTarget],[AchievementConditionType],[AchievementConditionLevel],[AchievementCondition],[RewardTarget],[GiveRewardDelayTime],[ActivateClientUI] from _RefServerEvent;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefServerEventReward")
            {
                packet = new Packet(0x4124, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[RewardID],[OwnerServerEventID],[RefRewardID],[Quantity],[RewardClass],[MasterReward] from _RefServerEventReward;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefServerEventReward_ExpUPForPlayers")
            {
                packet = new Packet(0x4125, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [OwnerRewardID],[ApplyTime],[ApplyExpRatio],[ApplySExpRatio] from _RefServerEventReward_ExpUPForPlayers;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefServerEventReward_SpawnMonster")
            {
                packet = new Packet(0x4126, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [OwnerRewardID],[RegionID],[PosX],[PosY],[PosZ] from _RefServerEventReward_SpawnMonster;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefSetItemGroup")
            {
                packet = new Packet(0x4127, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[CodeName128],[ObjName128],[NameStrID128],[DescStrID128],[SetEffectMask],[SetMagicMask],[2SetMOptGroupID],[3SetMOptGroupID],[4SetMOptGroupID],[5SetMOptGroupID],[6SetMOptGroupID],[7SetMOptGroupID],[8SetMOptGroupID],[9SetMOptGroupID],[10SetMOptGroupID],[11SetMOptGroupID] from _RefSetItemGroup;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefShardContentConfig")
            {
                packet = new Packet(0x4128, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[CodeName128],[CodeDesc128],[Value],[Type] from _RefShardContentConfig;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefShop")
            {
                packet = new Packet(0x4129, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[ID],[CodeName128],[Param1],[Param1_Desc128],[Param2],[Param2_Desc128],[Param3],[Param3_Desc128],[Param4],[Param4_Desc128] from _RefShop;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefShopGoods")
            {
                packet = new Packet(0x4130, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[RefTabCodeName],[RefPackageItemCodeName],[SlotIndex],[Param1],[Param1_Desc128],[Param2],[Param2_Desc128],[Param3],[Param3_Desc128],[Param4],[Param4_Desc128],[index] from _RefShopGoods;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefShopGroup")
            {
                packet = new Packet(0x4131, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[ID],[CodeName128],[RefNPCCodeName],[Param1],[Param1_Desc128],[Param2],[Param2_Desc128],[Param3],[Param3_Desc128],[Param4],[Param4_Desc128] from _RefShopGroup;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefShopItemGroup")
            {
                packet = new Packet(0x4132, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[GroupID],[CodeName128],[StrID128_Group] from _RefShopItemGroup;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefShopItemStockPeriod")
            {
                packet = new Packet(0x4133, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[ID],[RefShopGroupCodeName],[RefPackageItemCodeName],[StockOpeningDate],[StockExpireDate],[PeriodDevice] from _RefShopItemStockPeriod;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefShopObject")
            {
                packet = new Packet(0x4134, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[CodeName128] from _RefShopObject;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefShopTab")
            {
                packet = new Packet(0x4135, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[ID],[CodeName128],[RefTabGroupCodeName],[StrID128_Tab] from _RefShopTab;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefShopTabGroup")
            {
                packet = new Packet(0x4136, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[ID],[CodeName128],[StrID128_Group] from _RefShopTabGroup;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefSiegeBlessBuff")
            {
                packet = new Packet(0x4137, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[BlessID],[FortressID],[RefBlessBuffID],[NeedGold],[NeedGP] from _RefSiegeBlessBuff;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefSiegeDungeon")
            {
                packet = new Packet(0x4138, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[FortressID],[WorldID],[MaxCreateCount],[EntryGold],[EntryGP] from _RefSiegeDungeon;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefSiegeFortress")
            {
                packet = new Packet(0x4139, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[FortressID],[CodeName128],[Name],[NameID128],[LinkedTeleportCodeName],[Scale],[MaxAdmission],[MaxGuard],[MaxBarricade],[TaxTargets],[RequestFee],[CrestPath128],[RequestNPCName128] from _RefSiegeFortress;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefSiegeFortressBattleRank")
            {
                packet = new Packet(0x4140, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[RankLvl],[RankName],[ReqPKCount],[BindedSkillID],[CrestPath128] from _RefSiegeFortressBattleRank;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefSiegeFortressGuard")
            {
                packet = new Packet(0x4141, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[FortressID],[GuardRefObjID] from _RefSiegeFortressGuard;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefSiegeFortressItemForge")
            {
                packet = new Packet(0x4142, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[FortressID],[RefItemID],[ReqGold],[ReqGP],[ForgeTimeMin] from _RefSiegeFortressItemForge;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefSiegeFortressRewards")
            {
                packet = new Packet(0x4143, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[FortressID],[RewardTypeID],[RewardValue],[RewardCount] from _RefSiegeFortressRewards;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefSiegeLvlSummonMonster")
            {
                packet = new Packet(0x4144, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[RefObjID],[RefOrgObjID] from _RefSiegeLvlSummonMonster;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefSiegeQuest")
            {
                packet = new Packet(0x4145, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[QuestID],[QuestName],[QuestType],[RewardConditionTargetCount],[IsAccumulation] from _RefSiegeQuest;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefSiegeQuestReward")
            {
                packet = new Packet(0x4146, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[QuestID],[RewardType],[RewardRefID],[RewardValue] from _RefSiegeQuestReward;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefSiegeStructUpgrade")
            {
                packet = new Packet(0x4147, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Structname],[BaseStructcodename],[UpgradeStructname1],[UpgradeStructname2],[UpgradeStructname3],[UpgradeStructname4] from _RefSiegeStructUpgrade;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefSkill")
            {
                packet = new Packet(0x4148, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[GroupID],[Basic_Code],[Basic_Name],[Basic_Group],[Basic_Original],[Basic_Level],[Basic_Activity],[Basic_ChainCode],[Basic_RecycleCost],[Action_PreparingTime],[Action_CastingTime],[Action_ActionDuration],[Action_ReuseDelay],[Action_CoolTime],[Action_FlyingSpeed],[Action_Interruptable],[Action_Overlap],[Action_AutoAttackType],[Action_InTown],[Action_Range],[Target_Required],[TargetType_Animal],[TargetType_Land],[TargetType_Building],[TargetGroup_Self],[TargetGroup_Ally],[TargetGroup_Party],[TargetGroup_Enemy_M],[TargetGroup_Enemy_P],[TargetGroup_Neutral],[TargetGroup_DontCare],[TargetEtc_SelectDeadBody],[ReqCommon_Mastery1],[ReqCommon_Mastery2],[ReqCommon_MasteryLevel1],[ReqCommon_MasteryLevel2],[ReqCommon_Str],[ReqCommon_Int],[ReqLearn_Skill1],[ReqLearn_Skill2],[ReqLearn_Skill3],[ReqLearn_SkillLevel1],[ReqLearn_SkillLevel2],[ReqLearn_SkillLevel3],[ReqLearn_SP],[ReqLearn_Race],[Req_Restriction1],[Req_Restriction2],[ReqCast_Weapon1],[ReqCast_Weapon2],[Consume_HP],[Consume_MP],[Consume_HPRatio],[Consume_MPRatio],[Consume_WHAN],[UI_SkillTab],[UI_SkillPage],[UI_SkillColumn],[UI_SkillRow],[UI_IconFile],[UI_SkillName],[UI_SkillToolTip],[UI_SkillToolTip_Desc],[UI_SkillStudy_Desc],[AI_AttackChance],[AI_SkillType],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16],[Param17],[Param18],[Param19],[Param20],[Param21],[Param22],[Param23],[Param24],[Param25],[Param26],[Param27],[Param28],[Param29],[Param30],[Param31],[Param32],[Param33],[Param34],[Param35],[Param36],[Param37],[Param38],[Param39],[Param40],[Param41],[Param42],[Param43],[Param44],[Param45],[Param46],[Param47],[Param48],[Param49],[Param50] from _RefSkill;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefSkillByItemOptLevel")
            {
                packet = new Packet(0x4149, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Link],[RefSkillID] from _RefSkillByItemOptLevel;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefSkillGroup")
            {
                packet = new Packet(0x4150, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[Code] from _RefSkillGroup;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefSkillMastery")
            {
                packet = new Packet(0x4151, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[Code],[Weapon] from _RefSkillMastery;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefTeleLink")
            {
                packet = new Packet(0x4152, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[OwnerTeleport],[TargetTeleport],[Fee],[RestrictBindMethod],[RunTimeTeleportMethod],[CheckResult],[Restrict1],[Data1_1],[Data1_2],[Restrict2],[Data2_1],[Data2_2],[Restrict3],[Data3_1],[Data3_2],[Restrict4],[Data4_1],[Data4_2],[Restrict5],[Data5_1],[Data5_2] from _RefTeleLink;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefTeleport")
            {
                packet = new Packet(0x4153, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[CodeName128],[AssocRefObjCodeName128],[AssocRefObjID],[ZoneName128],[GenRegionID],[GenPos_X],[GenPos_Y],[GenPos_Z],[GenAreaRadius],[CanBeResurrectPos],[CanGotoResurrectPos],[GenWorldID],[BindInteractionMask],[FixedService] from _RefTeleport;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefTreatItemOfShop")
            {
                packet = new Packet(0x4154, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[RefShopCodeName],[Cash],[TypeID1],[TypeID2],[TypeID3],[TypeID4],[RefItemCodeName],[AcceptOrReject],[FourCC],[Param1],[Param1_Desc128],[Param2],[Param2_Desc128],[Param3],[Param3_Desc128],[Param4],[Param4_Desc128] from _RefTreatItemOfShop;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefTrigger")
            {
                packet = new Packet(0x4155, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[CodeName128],[IsActive],[IsRepeat],[Comment512],[IndexNumber] from _RefTrigger;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefTriggerAction")
            {
                packet = new Packet(0x4156, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[RefTriggerCommonID],[Delay],[ParamGroupCodeName128] from _RefTriggerAction;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefTriggerActionParam")
            {
                packet = new Packet(0x4157, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[GroupCodeName128],[ValueCodeName128],[Value],[Type] from _RefTriggerActionParam;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefTriggerBindAction")
            {
                packet = new Packet(0x4158, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[TriggerID],[TriggerActionID] from _RefTriggerBindAction;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefTriggerBindCondition")
            {
                packet = new Packet(0x4159, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[TriggerID],[TriggerConditionID] from _RefTriggerBindCondition;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefTriggerBindEvent")
            {
                packet = new Packet(0x4160, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[TriggerID],[TriggerEventID] from _RefTriggerBindEvent;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefTriggerCategory")
            {
                packet = new Packet(0x4161, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[CodeName128],[ObjName128],[IndexNumber] from _RefTriggerCategory;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefTriggerCategoryBindTrigger")
            {
                packet = new Packet(0x4162, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[TriggerCategoryID],[TriggerID] from _RefTriggerCategoryBindTrigger;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefTriggerCommon")
            {
                packet = new Packet(0x4163, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[CodeName128],[ObjName128],[TID1],[TID2],[TID3],[TID4] from _RefTriggerCommon;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefTriggerCondition")
            {
                packet = new Packet(0x4164, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[RefTriggerCommonID],[OnTrue],[OnFalse],[Sequence],[ParamGroupCodeName128] from _RefTriggerCondition;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefTriggerConditionParam")
            {
                packet = new Packet(0x4165, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[GroupCodeName128],[ValueCodeName128],[Value],[Type] from _RefTriggerConditionParam;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefTriggerEvent")
            {
                packet = new Packet(0x4166, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[RefTriggerCommonID] from _RefTriggerEvent;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefTriggerVariable")
            {
                packet = new Packet(0x4167, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[ID],[BindTriggerID],[CodeName128],[Type],[Value],[Comment128] from _RefTriggerVariable;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RefUIString_Mt")
            {
                packet = new Packet(0x4168, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[GroupCodeName128],[ValueCodeName128],[Value],[Type] from _RefUIString_Mt;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_RentItemInfo")
            {
                packet = new Packet(0x4169, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [nItemDBID],[nRentType],[nCanDelete],[nCanRecharge],[PeriodBeginTime],[PeriodEndTime],[MeterRateTime],[nPackingState],[nPackingTime] from _RentItemInfo;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_ResultOfPackageItemToMappingWithServerSide")
            {
                packet = new Packet(0x4170, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Operation],[CharID],[Slot],[RefItemSerial64],[RefItemDBID],[RefItemID],[Type],[SubType] from _ResultOfPackageItemToMappingWithServerSide;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_Schedule")
            {
                packet = new Packet(0x4171, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ScheduleIdx],[ScheduleDefineIdx],[DateStart],[DateEnd],[MainInterval_Type],[MainInterval_TypeDate],[SubInterval_DayOfWeek],[SubInterval_Days],[SubInterval_Weeks],[SubInterval_Months],[SubInterval_StartTimeHour],[SubInterval_StartTimeMinute],[SubInterval_StartTimeSecond],[SubInterval_DurationSecond],[SubInterval_RepititionTerm],[SubInterval_MaintainTime],[Param],[Description] from _Schedule;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_ServerEvent")
            {
                packet = new Packet(0x4172, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[CompletionValue],[AchievementCondition],[ProgressCount] from _ServerEvent;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_ServerEventReward")
            {
                packet = new Packet(0x4173, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ServerEventID],[RewardID],[RemainRewardTime] from _ServerEventReward;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_ShopItemStockQuantity")
            {
                packet = new Packet(0x4174, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Service],[Country],[RefShopGroupCodeName],[RefPackageItemCodeName],[ConstStockQuantity],[StockQuantity] from _ShopItemStockQuantity;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_SiegeFortress")
            {
                packet = new Packet(0x4175, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [FortressID],[GuildID],[TaxRatio],[Tax],[NPCHired],[TempGuildID],[Introduction],[CreatedDungeonTime],[CreatedDungeonCount],[IntroductionModificationPermission] from _SiegeFortress;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_SiegeFortressBattleRecord")
            {
                packet = new Packet(0x4176, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [FortressID],[CharID],[KillCount],[KilledCount],[RankUpDate],[CurRank] from _SiegeFortressBattleRecord;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_SiegeFortressItemForge")
            {
                packet = new Packet(0x4177, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [FortressID],[ItemRefID],[Amount],[Finished],[StartDate],[FinishDate] from _SiegeFortressItemForge;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_SiegeFortressObject")
            {
                packet = new Packet(0x4178, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[FortressID],[OwnerGuildID],[RefObjID],[HP],[Region],[PosX],[PosY],[PosZ],[Direction],[OwnerLevel] from _SiegeFortressObject;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_SiegeFortressRequest")
            {
                packet = new Packet(0x4179, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [FortressID],[GuildID],[RequestType] from _SiegeFortressRequest;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_SiegeFortressStoneState")
            {
                packet = new Packet(0x4180, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [FortressID],[GuildID],[AccumulateDamage] from _SiegeFortressStoneState;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_SiegeFortressStruct")
            {
                packet = new Packet(0x4181, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [FortressID],[OwnerGuildID],[RefEventStructID],[RefObjID],[HP],[MakeDate],[State] from _SiegeFortressStruct;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_Skill_BaoHiem_TNET")
            {
                packet = new Packet(0x4182, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharID],[CharName],[SkillBaoHiem],[Regdate],[LastModified] from _Skill_BaoHiem_TNET;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_StaticAvatar")
            {
                packet = new Packet(0x4183, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharID],[Param1],[Param2],[Param3],[Param4],[Param5],[Param6],[Param7],[Param8],[Param9],[Param10],[Param11],[Param12],[Param13],[Param14],[Param15],[Param16] from _StaticAvatar;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_TEMP_ADDITEMEXTERN_CHEST_LOG")
            {
                packet = new Packet(0x4184, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[LogString],[LogDate] from _TEMP_ADDITEMEXTERN_CHEST_LOG;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_testTable")
            {
                packet = new Packet(0x4185, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Name] from _testTable;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_TimedJob")
            {
                packet = new Packet(0x4186, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[CharID],[Category],[JobID],[TimeToKeep],[Data1],[Data2],[Data3],[Data4],[Data5],[Data6],[Data7],[Data8],[Serial64],[JID] from _TimedJob;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_TimedJobForPet")
            {
                packet = new Packet(0x4187, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[CharID],[Category],[JobID],[TimeToKeep],[Data1],[Data2],[Data3],[Data4],[Data5],[Data6],[Data7],[Data8],[Serial64],[JID] from _TimedJobForPet;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_TrainingCamp")
            {
                packet = new Packet(0x4188, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[CreationDate],[Rank],[GraduateCount],[EvaluationPoint],[LatestEvaluationDate],[CommentTitle],[Comment] from _TrainingCamp;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_TrainingCampBuffStatus")
            {
                packet = new Packet(0x4189, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CampID],[RecipientCharID],[BuffSlotIdx],[DonorCharID],[StartingTime],[RemainBuffPoint],[BuffType] from _TrainingCampBuffStatus;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_TrainingCampHonorRank")
            {
                packet = new Packet(0x4190, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Ranking],[CampID],[Rank] from _TrainingCampHonorRank;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_TrainingCampHonorRankUpdateDate")
            {
                packet = new Packet(0x4191, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [LastUpdateDate] from _TrainingCampHonorRankUpdateDate;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_TrainingCampMember")
            {
                packet = new Packet(0x4192, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CampID],[CharID],[RefObjID],[CharName],[JoinDate],[MemberClass],[CharJoinedLevel],[CharCurLevel],[CharMaxLevel],[HonorPoint] from _TrainingCampMember;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_TrainingCampSubMentorHonorPoint")
            {
                packet = new Packet(0x4193, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharID],[HonorPoint] from _TrainingCampSubMentorHonorPoint;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_TrijobRanking4WEB")
            {
                packet = new Packet(0x4194, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [TrijobType],[RankType],[Rank],[NickName],[JobLevel],[JobData],[IsNewEntry],[RankDelta],[Country] from _TrijobRanking4WEB;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_TrijobRewards")
            {
                packet = new Packet(0x4195, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [JobType],[Reward] from _TrijobRewards;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_UniqueInfo")
            {
                packet = new Packet(0x4196, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CodeName128],[Name],[Points],[ID] from _UniqueInfo;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_UniqueKillList")
            {
                packet = new Packet(0x4197, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[CharID],[CodeName128],[time] from _UniqueKillList;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_UniqueRanking")
            {
                packet = new Packet(0x4198, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharID],[CodeName128],[points] from _UniqueRanking;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_User")
            {
                packet = new Packet(0x4199, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [UserJID],[CharID] from _User;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_UserBalance_Nhat")
            {
                packet = new Packet(0x4200, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [JID],[Balance] from _UserBalance_Nhat;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_UserOld")
            {
                packet = new Packet(0x4201, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [UserJID],[CharID1],[CharID2],[CharID3],[Gold] from _UserOld;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "_WebShop_SRO_Log")
            {
                packet = new Packet(0x4202, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [ID],[JID],[IP],[CodeName128],[Balance_Before_Buy],[Balance_After_Buy] from _WebShop_SRO_Log;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "C_EquipStrings")
            {
                packet = new Packet(0x4203, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [NameStrID128],[TextString] from C_EquipStrings;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "dtproperties")
            {
                packet = new Packet(0x4204, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [id],[objectid],[property],[value],[uvalue],[lvalue],[version] from dtproperties;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "Item_Quay_TNET")
            {
                packet = new Packet(0x4205, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CodeName] from Item_Quay_TNET;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "Tab_DBSafe_CheckState")
            {
                packet = new Packet(0x4206, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [btCheckIn] from Tab_DBSafe_CheckState;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "Tab_RefAISkill")
            {
                packet = new Packet(0x4207, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [TacticsID],[SkillCodeName],[ExcuteConditionType],[ExcuteConditionData],[Option] from Tab_RefAISkill;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "Tab_RefHive")
            {
                packet = new Packet(0x4208, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [dwHiveID],[btKeepMonsterCountType],[dwOverwriteMaxTotalCount],[fMonsterCountPerPC],[dwSpawnSpeedIncreaseRate],[dwMaxIncreaseRate],[btFlag],[GameWorldID],[HatchObjType],[szDescString128] from Tab_RefHive;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "Tab_RefNest")
            {
                packet = new Packet(0x4209, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [dwNestID],[dwHiveID],[dwTacticsID],[nRegionDBID],[fLocalPosX],[fLocalPosY],[fLocalPosZ],[wInitialDir],[nRadius],[nGenerateRadius],[nChampionGenPercentage],[dwDelayTimeMin],[dwDelayTimeMax],[dwMaxTotalCount],[btFlag],[btRespawn],[btType] from Tab_RefNest;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "Tab_RefRanking_HunterActivity")
            {
                packet = new Packet(0x4210, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Rank],[NickName],[JobLevel],[JobExp],[Country] from Tab_RefRanking_HunterActivity;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "Tab_RefRanking_HunterContribution")
            {
                packet = new Packet(0x4211, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Rank],[NickName],[JobLevel],[Contribution] from Tab_RefRanking_HunterContribution;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "Tab_RefRanking_RobberActivity")
            {
                packet = new Packet(0x4212, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Rank],[NickName],[JobLevel],[JobExp],[Country] from Tab_RefRanking_RobberActivity;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "Tab_RefRanking_RobberContribution")
            {
                packet = new Packet(0x4213, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Rank],[NickName],[JobLevel],[Contribution] from Tab_RefRanking_RobberContribution;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "Tab_RefRanking_TraderActivity")
            {
                packet = new Packet(0x4214, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Rank],[NickName],[JobLevel],[JobExp],[Country] from Tab_RefRanking_TraderActivity;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "Tab_RefRanking_TraderContribution")
            {
                packet = new Packet(0x4215, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [Rank],[NickName],[JobLevel],[Contribution] from Tab_RefRanking_TraderContribution;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "Tab_RefSpawnToolVersion")
            {
                packet = new Packet(0x4216, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [dwRefDataVersion],[szVersionDescString] from Tab_RefSpawnToolVersion;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "Tab_RefTactics")
            {
                packet = new Packet(0x4217, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [dwTacticsID],[dwObjID],[btAIQoS],[nMaxStamina],[btMaxStaminaVariance],[nSightRange],[btAggressType],[AggressData],[btChangeTarget],[btHelpRequestTo],[btHelpResponseTo],[btBattleStyle],[BattleStyleData],[btDiversionBasis],[DiversionBasisData1],[DiversionBasisData2],[DiversionBasisData3],[DiversionBasisData4],[DiversionBasisData5],[DiversionBasisData6],[DiversionBasisData7],[DiversionBasisData8],[btDiversionKeepBasis],[DiversionKeepBasisData1],[DiversionKeepBasisData2],[DiversionKeepBasisData3],[DiversionKeepBasisData4],[DiversionKeepBasisData5],[DiversionKeepBasisData6],[DiversionKeepBasisData7],[DiversionKeepBasisData8],[btKeepDistance],[KeepDistanceData],[btTraceType],[btTraceBoundary],[TraceData],[btHomingType],[HomingData],[btAggressTypeOnHoming],[btFleeType],[dwChampionTacticsID],[AdditionOptionFlag],[szDescString128] from Tab_RefTactics;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "test_item_TNET")
            {
                packet = new Packet(0x4218, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [id],[CodeName] from test_item_TNET;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }
            else if (tab == "TimItemOnChar")
            {
                packet = new Packet(0x4219, false, true);
                System.Data.DataTable dt = SQL.ReturnDataTable($"Select [CharID],[CharName16],[OptLevel],[Variance],[Data],[MagParamNum],[CreaterName],[MagParam1],[MagParam2],[MagParam3],[MagParam4],[MagParam5],[MagParam6],[MagParam7],[MagParam8],[MagParam9],[MagParam10],[MagParam11],[MagParam12],[Serial64] from TimItemOnChar;", StudioServer.settings.DBSha);
                packet.WriteDataTable(dt);
                return packet;
            }


            else
            {
                return null;
            }

        }


    }
}
