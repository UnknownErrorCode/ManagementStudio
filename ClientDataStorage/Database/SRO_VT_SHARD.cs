using Structs.Database;
using Structs.Database.Enumerable;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ClientFrameworkRes.Database
{
    public static class SRO_VT_SHARD //<T> where T : struct
    {
        #region Fields

        public static ConcurrentDictionary<int, IChar> _Char;
        public static ConcurrentDictionary<int, RefGame_World> _RefGame_World;
        public static ConcurrentDictionary<int, RefGameWorldBindTriggerCategory> _RefGameWorldBindTriggerCategory;
        public static ConcurrentBag<RefMappingShopGroup> _RefMappingShopGroup;
        public static ConcurrentDictionary<string, RefMappingShopWithTab[]> _RefMappingShopWithTab;
        public static ConcurrentDictionary<int, RefObjChar> _RefObjChar;
        public static ConcurrentDictionary<int, RefObjCommon> _RefObjCommon;
        public static ConcurrentDictionary<int, RefObjItem> _RefObjItem;
        public static ConcurrentDictionary<string, RefPackageItem> _RefPackageItem;
        public static ConcurrentDictionary<string, RefPricePolicyOfItem[]> _RefPricePolicyOfItem;
        public static ConcurrentDictionary<short, RefRegion> _RefRegion;
        public static ConcurrentStack<RefRegionBindAssocServer> _RefRegionBindAssocServer;
        public static ConcurrentDictionary<string, RefScrapOfPackageItem> _RefScrapOfPackageItem;
        public static ConcurrentDictionary<int, RefShop> _RefShop;
        public static ConcurrentStack<RefShopGood> _RefShopGoods;
        public static ConcurrentStack<RefShopGroup> _RefShopGroup;
        public static ConcurrentDictionary<string, RefShopTab> _RefShopTab;
        public static ConcurrentDictionary<string, RefShopTabGroup> _RefShopTabGroup;
        public static ConcurrentDictionary<int, RefSkill> _RefSkill;
        public static ConcurrentDictionary<int, RefSkillGroup> _RefSkillGroup;
        public static ConcurrentDictionary<int, RefSkillMastery> _RefSkillMastery;
        public static List<RefTeleLink> _RefTeleLink;
        public static ConcurrentDictionary<int, RefTeleport> _RefTeleport;
        public static ConcurrentDictionary<int, RefTrigger> _RefTrigger;
        public static ConcurrentDictionary<int, RefTriggerCategory> _RefTriggerCategory;
        public static ConcurrentDictionary<int, RefTriggerCategoryBindTrigger> _RefTriggerCategoryBindTrigger;
        public static DataSet dbo = new DataSet("SRO_VT_SHARD");
        public static ConcurrentDictionary<int, Tab_RefHive> Tab_RefHive;
        public static ConcurrentDictionary<int, TabRefNest> Tab_RefNest;
        public static ConcurrentDictionary<int, Tab_RefTactics> Tab_RefTactics;

        #endregion Fields

        #region Methods

        /// <summary>
        /// Save or update the Table in memory.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="arg2"></param>
        internal static async void PoolDataTable(string tableName, DataTable arg2)
        {
            arg2.TableName = tableName;
            if (Enum.TryParse<TableName>(tableName, out TableName value))
            {
                switch (value)
                {
                    case TableName._AccountJID:
                        break;

                    case TableName._AlliedClans:
                        break;

                    case TableName._AssociationReputation:
                        break;

                    case TableName._BindingOptionWithItem:
                        break;

                    case TableName._BlockedPartyInviter:
                        break;

                    case TableName._BlockedWhisperers:
                        break;

                    case TableName._Char:
                        InitializeRefTableToStruct<IChar>(arg2, ref _Char, "CharID");
                        break;

                    case TableName._CharAlchemy_MK_Recipe:
                        break;

                    case TableName._CharCollectionBook:
                        break;

                    case TableName._CharCOS:
                        break;

                    case TableName._CharInstanceWorldData:
                        break;

                    case TableName._CharNameList:
                        break;

                    case TableName._CharNewTrade:
                        break;

                    case TableName._CharNickNameList:
                        break;

                    case TableName._CharQuest:
                        break;

                    case TableName._CharSkill:
                        break;

                    case TableName._CharSkillMastery:
                        break;

                    case TableName._CharTradeConflictJob:
                        break;

                    case TableName._CharTradeConflictJob_Kill:
                        break;

                    case TableName._CharTrijob:
                        break;

                    case TableName._CharTriJobContribution:
                        break;

                    case TableName._CharTriJobRanking:
                        break;

                    case TableName._CharTrijobSafeTrade:
                        break;

                    case TableName._Chest:
                        break;

                    case TableName._ChestInfo:
                        break;

                    case TableName._ClientConfig:
                        break;

                    case TableName._ConsignmentTrade_Invest:
                        break;

                    case TableName._ConsignmentTrade_Progress:
                        break;

                    case TableName._DeletedChar:
                        break;

                    case TableName._EventRamadanVoucher:
                        break;

                    case TableName._FlagWorld_EventParticipants:
                        break;

                    case TableName._FleaMarketNetwork:
                        break;

                    case TableName._Friend:
                        break;

                    case TableName._FriendGroup:
                        break;

                    case TableName._GPHistory:
                        break;

                    case TableName._Guild:
                        break;

                    case TableName._GuildChest:
                        break;

                    case TableName._GuildMember:
                        break;

                    case TableName._GuildWar:
                        break;

                    case TableName._InvCOS:
                        break;

                    case TableName._Inventory:
                        break;

                    case TableName._InventoryForAvatar:
                        break;

                    case TableName._InventoryForLinkedStorage:
                        break;

                    case TableName._ItemPool:
                        break;

                    case TableName._ItemQuotation:
                        break;

                    case TableName._Items:
                        break;

                    case TableName._KeepDelCharName:
                        break;

                    case TableName._LatestItemSerial:
                        break;

                    case TableName._Memo:
                        break;

                    case TableName._OffsetItemUpgradeNReinforceRatio:
                        break;

                    case TableName._OffsetItemUpgradeNReinforceRatio_Backup:
                        break;

                    case TableName._OpenMarket:
                        break;

                    case TableName._PathPositionRememberPathPatrol:
                        break;

                    case TableName._PreoccupancyName:
                        break;

                    case TableName._RefAbilityByItemOptLevel:
                        break;

                    case TableName._RefAccessPermissionOfShop:
                        break;

                    case TableName._RefAlchemy_MK_MaterialGroup:
                        break;

                    case TableName._RefAlchemy_MK_Recipe:
                        break;

                    case TableName._RefAlchemy_MK_ResultGroup:
                        break;

                    case TableName._RefAlchemy_MK_Shop:
                        break;

                    case TableName._RefAlchemy_MK_UI:
                        break;

                    case TableName._RefAlchemyMerit:
                        break;

                    case TableName._RefCartCosInfo:
                        break;

                    case TableName._RefCharDefault_Quest:
                        break;

                    case TableName._RefCharDefault_Skill:
                        break;

                    case TableName._RefCharDefault_SkillMastery:
                        break;

                    case TableName._RefCharGen:
                        break;

                    case TableName._RefClimate:
                        break;

                    case TableName._RefCollectionBook_Item:
                        break;

                    case TableName._RefCollectionBook_Theme:
                        break;

                    case TableName._RefConditionToBuyScrapItem:
                        break;

                    case TableName._RefConditionToSellPackageItem:
                        break;

                    case TableName._RefConditionToSellScrapItem:
                        break;

                    case TableName._RefCustomizingReservedItemDropForMonster:
                        break;

                    case TableName._RefDropClassSel_Alchemy_ATTRStone:
                        break;

                    case TableName._RefDropClassSel_Alchemy_Enhancer:
                        break;

                    case TableName._RefDropClassSel_Alchemy_MagicStone:
                        break;

                    case TableName._RefDropClassSel_Alchemy_Tablet:
                        break;

                    case TableName._RefDropClassSel_Alchemy_UpgradeStone:
                        break;

                    case TableName._RefDropClassSel_Ammo:
                        break;

                    case TableName._RefDropClassSel_Cure:
                        break;

                    case TableName._RefDropClassSel_Equip:
                        break;

                    case TableName._RefDropClassSel_RareEquip:
                        break;

                    case TableName._RefDropClassSel_Recover:
                        break;

                    case TableName._RefDropClassSel_Reinforce:
                        break;

                    case TableName._RefDropClassSel_Scroll:
                        break;

                    case TableName._RefDropClassSel_Specialty:
                        break;

                    case TableName._RefDropGold:
                        break;

                    case TableName._RefDropItemAssign:
                        break;

                    case TableName._RefDropItemGroup:
                        break;

                    case TableName._RefDropOptLvlSel:
                        break;

                    case TableName._RefDummySlot:
                        break;

                    case TableName._RefEquipItemPenalty:
                        break;

                    case TableName._RefEquipItemPenaltyBalance:
                        break;

                    case TableName._RefEvent:
                        break;

                    case TableName._RefEventReward:
                        break;

                    case TableName._RefEventRewardItems:
                        break;

                    case TableName._RefEventZone:
                        break;

                    case TableName._RefExtraAbilityByEquipItemOptLevel:
                        break;

                    case TableName._RefFmnCategoryTree:
                        break;

                    case TableName._RefFmnTidGroup:
                        break;

                    case TableName._RefFmnTidGroupMap:
                        break;

                    case TableName._RefGachaCode:
                        break;

                    case TableName._RefGachaItemSet:
                        break;

                    case TableName._RefGachaNpcMap:
                        break;

                    case TableName._RefGachaTreeForClientUI:
                        break;

                    case TableName._RefGame_World:
                        InitializeRefTableToStruct<RefGame_World>(arg2, ref _RefGame_World);
                        break;

                    case TableName._RefGame_World_Config:
                        break;

                    case TableName._RefGameWorldBindGameWorldGroup:
                        break;

                    case TableName._RefGameWorldBindTriggerCategory:
                        InitializeRefTableToStruct<RefGameWorldBindTriggerCategory>(arg2, ref _RefGameWorldBindTriggerCategory);
                        break;

                    case TableName._RefGameWorldGroup:
                        break;

                    case TableName._RefGameWorldGroup_Config:
                        break;

                    case TableName._RefGameWorldNPC:
                        break;

                    case TableName._RefHWANLevel:
                        break;

                    case TableName._RefInstance_World_Region:
                        break;

                    case TableName._RefInstance_World_Start_Pos:
                        break;

                    case TableName._RefItemUpgradeNReinforceRatio:
                        break;

                    case TableName._RefLearnRecipeByReqType:
                        break;

                    case TableName._RefLevel:
                        break;

                    case TableName._RefMagicOpt:
                        break;

                    case TableName._RefMagicOptAssign:
                        break;

                    case TableName._RefMagicOptAssignForTradeEquip:
                        break;

                    case TableName._RefMagicOptByItemOptLevel:
                        break;

                    case TableName._RefMagicOptGroup:
                        break;

                    case TableName._RefMappingAlchemy_MK_Shop_With_NPC:
                        break;

                    case TableName._RefMappingShopGroup:
                        InitializeRefTableToStruct<RefMappingShopGroup>(arg2, ref _RefMappingShopGroup);
                        break;

                    case TableName._RefMappingShopWithTab:
                        InitializeRefTableToStruct<RefMappingShopWithTab>(arg2, ref _RefMappingShopWithTab, "RefShopCodeName");
                        break;

                    case TableName._RefMonster_AssignedItemDrop:
                        break;

                    case TableName._RefMonster_AssignedItemRndDrop:
                        break;

                    case TableName._RefNewTrade_RewardRatio:
                        break;

                    case TableName._RefObjChar:
                        InitializeRefTableToStruct<RefObjChar>(arg2, ref _RefObjChar);
                        break;

                    case TableName._RefObjCharExtraSkill:
                        break;

                    case TableName._RefObjCommon:
                        InitializeRefTableToStruct<RefObjCommon>(arg2, ref _RefObjCommon);
                        break;

                    case TableName._RefObjItem:
                        InitializeRefTableToStruct<RefObjItem>(arg2, ref _RefObjItem);
                        break;

                    case TableName._RefObjStruct:
                        break;

                    case TableName._RefOptionalTeleport:
                        break;

                    case TableName._RefPackageItem:
                        InitializeRefTableToStruct<RefPackageItem>(arg2, ref _RefPackageItem, "CodeName128");
                        break;

                    case TableName._RefPath:
                        break;

                    case TableName._RefPath_Config_Type:
                        break;

                    case TableName._RefPath_Const:
                        break;

                    case TableName._RefPath_Flock:
                        break;

                    case TableName._RefPath_FlockMember:
                        break;

                    case TableName._RefPath_Position:
                        break;

                    case TableName._RefPath_Position_Config:
                        break;

                    case TableName._RefPath_Position_Config_Group:
                        break;

                    case TableName._RefPricePolicyOfItem:
                        InitializeRefTableToStruct<RefPricePolicyOfItem>(arg2, ref _RefPricePolicyOfItem, "RefPackageItemCodeName");
                        break;

                    case TableName._RefQuest:
                        break;

                    case TableName._RefQuestReward:
                        break;

                    case TableName._RefQuestRewardItems:
                        break;

                    case TableName._RefRegion:
                        InitializeRefTableToStruct<RefRegion>(arg2, ref _RefRegion, "wRegionID");
                        break;

                    case TableName._RefRegionBindAssocServer:
                        InitializeRefTableToStruct<RefRegionBindAssocServer>(arg2, ref _RefRegionBindAssocServer);
                        break;

                    case TableName._RefRentItem:
                        break;

                    case TableName._RefRewardPolicyToBuyScrapItem:
                        break;

                    case TableName._RefRewardPolicyToSellPackageItem:
                        break;

                    case TableName._RefRewardPolicyToSellScrapItem:
                        break;

                    case TableName._RefScheduleDefine:
                        break;

                    case TableName._RefScrapOfPackageItem:
                        InitializeRefTableToStruct<RefScrapOfPackageItem>(arg2, ref _RefScrapOfPackageItem, "RefPackageItemCodeName");
                        break;

                    case TableName._RefServerEvent:
                        break;

                    case TableName._RefServerEventReward:
                        break;

                    case TableName._RefServerEventReward_ExpUPForPlayers:
                        break;

                    case TableName._RefServerEventReward_SpawnMonster:
                        break;

                    case TableName._RefSetItemGroup:
                        break;

                    case TableName._RefShardContentConfig:
                        break;

                    case TableName._RefShop:
                        InitializeRefTableToStruct<RefShop>(arg2, ref _RefShop);
                        break;

                    case TableName._RefShopGoods:
                        InitializeRefTableToStruct<RefShopGood>(arg2, ref _RefShopGoods);
                        break;

                    case TableName._RefShopGroup:
                        InitializeRefTableToStruct<RefShopGroup>(arg2, ref _RefShopGroup);
                        break;

                    case TableName._RefShopItemGroup:
                        break;

                    case TableName._RefShopItemStockPeriod:
                        break;

                    case TableName._RefShopObject:
                        break;

                    case TableName._RefShopTab:
                        InitializeRefTableToStruct<RefShopTab>(arg2, ref _RefShopTab, "CodeName128");
                        break;

                    case TableName._RefShopTabGroup:
                        InitializeRefTableToStruct<RefShopTabGroup>(arg2, ref _RefShopTabGroup, "CodeName128");
                        break;

                    case TableName._RefSiegeBlessBuff:
                        break;

                    case TableName._RefSiegeDungeon:
                        break;

                    case TableName._RefSiegeFortress:
                        break;

                    case TableName._RefSiegeFortressBattleRank:
                        break;

                    case TableName._RefSiegeFortressGuard:
                        break;

                    case TableName._RefSiegeFortressItemForge:
                        break;

                    case TableName._RefSiegeFortressRewards:
                        break;

                    case TableName._RefSiegeLvlSummonMonster:
                        break;

                    case TableName._RefSiegeQuest:
                        break;

                    case TableName._RefSiegeQuestReward:
                        break;

                    case TableName._RefSiegeStructUpgrade:
                        break;

                    case TableName._RefSkill:
                        break;

                    case TableName._RefSkillByItemOptLevel:
                        break;

                    case TableName._RefSkillGroup:
                        break;

                    case TableName._RefSkillMastery:
                        break;

                    case TableName._RefTeleLink:
                        InitializeRefTableToStruct<RefTeleLink>(arg2, ref _RefTeleLink);
                        break;

                    case TableName._RefTeleport:
                        InitializeRefTableToStruct<RefTeleport>(arg2, ref _RefTeleport);
                        break;

                    case TableName._RefTradeConflict_Class:
                        break;

                    case TableName._RefTradeConflict_JobLevel:
                        break;

                    case TableName._RefTradeConflict_PromotionReq:
                        break;

                    case TableName._RefTradeConflict_ReputationPoint:
                        break;

                    case TableName._RefTreatItemOfShop:
                        break;

                    case TableName._RefTrigger:
                        break;

                    case TableName._RefTriggerAction:
                        break;

                    case TableName._RefTriggerActionParam:
                        break;

                    case TableName._RefTriggerBindAction:
                        break;

                    case TableName._RefTriggerBindCondition:
                        break;

                    case TableName._RefTriggerBindEvent:
                        break;

                    case TableName._RefTriggerCategory:
                        break;

                    case TableName._RefTriggerCategoryBindTrigger:
                        break;

                    case TableName._RefTriggerCommon:
                        break;

                    case TableName._RefTriggerCondition:
                        break;

                    case TableName._RefTriggerConditionParam:
                        break;

                    case TableName._RefTriggerEvent:
                        break;

                    case TableName._RefTriggerVariable:
                        break;

                    case TableName._RefUIString_Mt:
                        break;

                    case TableName._RefUpgradeEquipItem:
                        break;

                    case TableName._RenameLog_Char:
                        break;

                    case TableName._RenameLog_Guild:
                        break;

                    case TableName._RentItemInfo:
                        break;

                    case TableName._ResultOfPackageItemToMappingWithServerSide:
                        break;

                    case TableName._Schedule:
                        break;

                    case TableName._ServerEvent:
                        break;

                    case TableName._ServerEventReward:
                        break;

                    case TableName._ShopItemStockQuantity:
                        break;

                    case TableName._SiegeFortress:
                        break;

                    case TableName._SiegeFortressBattleRecord:
                        break;

                    case TableName._SiegeFortressItemForge:
                        break;

                    case TableName._SiegeFortressObject:
                        break;

                    case TableName._SiegeFortressRequest:
                        break;

                    case TableName._SiegeFortressStoneState:
                        break;

                    case TableName._SiegeFortressStruct:
                        break;

                    case TableName._StaticAvatar:
                        break;

                    case TableName._TEMP_ADDITEMEXTERN_CHEST_LOG:
                        break;

                    case TableName._TimedJob:
                        break;

                    case TableName._TimedJobForPet:
                        break;

                    case TableName._TMP_CHARID_CONVERSION:
                        break;

                    case TableName._TMP_GUILDID_CONVERSION:
                        break;

                    case TableName._TradeBagInventory:
                        break;

                    case TableName._TradeEquipInventory:
                        break;

                    case TableName._TrainingCamp:
                        break;

                    case TableName._TrainingCampBuffStatus:
                        break;

                    case TableName._TrainingCampHonorRank:
                        break;

                    case TableName._TrainingCampHonorRankUpdateDate:
                        break;

                    case TableName._TrainingCampMember:
                        break;

                    case TableName._TrainingCampSubMentorHonorPoint:
                        break;

                    case TableName._TrijobRewards:
                        break;

                    case TableName._User:
                        break;

                    case TableName._UserTradeConflictJob:
                        break;

                    case TableName.Tab_RefAISkill:
                        break;

                    case TableName.Tab_RefHive:
                        InitializeRefTableToStruct<Tab_RefHive>(arg2, ref Tab_RefHive, "dwHiveID");
                        break;

                    case TableName.Tab_RefNest:
                        InitializeRefTableToStruct<TabRefNest>(arg2, ref Tab_RefNest, "dwNestID");
                        break;

                    case TableName.Tab_RefRanking_HunterActivity:
                        break;

                    case TableName.Tab_RefRanking_HunterContribution:
                        break;

                    case TableName.Tab_RefRanking_RobberActivity:
                        break;

                    case TableName.Tab_RefRanking_RobberContribution:
                        break;

                    case TableName.Tab_RefRanking_TraderActivity:
                        break;

                    case TableName.Tab_RefRanking_TraderContribution:
                        break;

                    case TableName.Tab_RefTactics:
                        InitializeRefTableToStruct<Tab_RefTactics>(arg2, ref Tab_RefTactics, "dwTacticsID");
                        break;

                    default:
                        break;
                }
                //GC.Collect();
            }

            //   if (SRO_VT_SHARD.dbo.Tables.Contains(tableName))
            //       SRO_VT_SHARD.dbo.Tables.Remove(tableName);
            //
            //   SRO_VT_SHARD.dbo.Tables.Add(arg2);

            await Task.Delay(1);
        }

        private static void InitializeRefTableToStruct<T>(DataTable table, ref List<T> stack) where T : struct
        {
            stack = new List<T>(table.Rows.Count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                stack.Add((T)Activator.CreateInstance(typeof(T), new object[1] { table.Rows[i].ItemArray }));
            }
        }

        private static void InitializeRefTableToStruct<T>(DataTable table, ref ConcurrentStack<T> stack) where T : struct
        {
            stack = new ConcurrentStack<T>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                stack.Push((T)Activator.CreateInstance(typeof(T), new object[1] { table.Rows[i].ItemArray }));
            }
        }

        private static void InitializeRefTableToStruct<T>(DataTable table, ref ConcurrentBag<T> stack) where T : struct
        {
            stack = new ConcurrentBag<T>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                stack.Add((T)Activator.CreateInstance(typeof(T), new object[1] { table.Rows[i].ItemArray }));
            }
        }

        private static void InitializeRefTableToStruct<T>(DataTable table, ref ConcurrentDictionary<int, T> dic, string keyName = "ID") where T : struct
        {
            dic = new ConcurrentDictionary<int, T>(2, table.Rows.Count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                dic.TryAdd(table.Rows[i].Field<int>(keyName), (T)Activator.CreateInstance(typeof(T), new object[1] { table.Rows[i].ItemArray }));
            }
        }

        private static void InitializeRefTableToStruct<T>(DataTable table, ref ConcurrentDictionary<short, T> dic, string keyName = "ID") where T : struct
        {
            dic = new ConcurrentDictionary<short, T>(2, table.Rows.Count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                dic.TryAdd(table.Rows[i].Field<short>(keyName), (T)Activator.CreateInstance(typeof(T), new object[1] { table.Rows[i].ItemArray }));
            }
        }

        private static void InitializeRefTableToStruct<T>(DataTable table, ref ConcurrentDictionary<string, T> dic, string keyName = "ID") where T : struct
        {
            dic = new ConcurrentDictionary<string, T>(2, table.Rows.Count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                dic.TryAdd(table.Rows[i].Field<string>(keyName), (T)Activator.CreateInstance(typeof(T), new object[1] { table.Rows[i] }));
            }
        }

        private static void InitializeRefTableToStruct<T>(DataTable table, ref ConcurrentDictionary<string, T[]> dic, string keyName = "ID") where T : struct
        {
            ConcurrentDictionary<string, List<T>> dict = new ConcurrentDictionary<string, List<T>>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string keyValue = table.Rows[i].Field<string>(keyName);
                if (!dict.ContainsKey(keyValue))
                {
                    if (dict.TryAdd(keyValue, new List<T>()))
                    {
                        dict[keyValue].Add((T)Activator.CreateInstance(typeof(T), new object[1] { table.Rows[i].ItemArray }));
                    }
                }
                else
                {
                    dict[keyValue].Add((T)Activator.CreateInstance(typeof(T), new object[1] { table.Rows[i].ItemArray }));
                }
            }
            dic = new ConcurrentDictionary<string, T[]>(1, dict.Count);
            foreach (KeyValuePair<string, List<T>> pair in dict)
            {
                dic.TryAdd(pair.Key, pair.Value.ToArray());
            }
        }

        #endregion Methods
    }
}