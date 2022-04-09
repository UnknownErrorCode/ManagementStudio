using Structs.Database;

namespace PluginFramework.Database.SRProperties
{
    public struct PTabRefNest
    {
        private TabRefNest Nest;

        public PTabRefNest(TabRefNest nest)
        {
            Nest = nest;
        }

        public int dwNestID => Nest.dwNestID;

        public int dwHiveID { get => Nest.dwHiveID; set => Nest.dwHiveID = value; }
        public int dwTacticsID { get => Nest.dwTacticsID; set => Nest.dwTacticsID = value; }
        public short nRegionDBID { get => Nest.nRegionDBID; set => Nest.nRegionDBID = value; }
        public float fLocalPosX { get => Nest.fLocalPosX; set => Nest.fLocalPosX = value; }
        public float fLocalPosY { get => Nest.fLocalPosY; set => Nest.fLocalPosY = value; }
        public float fLocalPosZ { get => Nest.fLocalPosZ; set => Nest.fLocalPosZ = value; }
        public short wInitialDir { get => Nest.wInitialDir; set => Nest.wInitialDir = value; }
        public int nRadius { get => Nest.nRadius; set => Nest.nRadius = value; }
        public int nGenerateRadius { get => Nest.nGenerateRadius; set => Nest.nGenerateRadius = value; }
        public int nChampionGenPercentage { get => Nest.nChampionGenPercentage; set => Nest.nChampionGenPercentage = value; }
        public int dwDelayTimeMin { get => Nest.dwDelayTimeMin; set => Nest.dwDelayTimeMin = value; }
        public int dwDelayTimeMax { get => Nest.dwDelayTimeMax; set => Nest.dwDelayTimeMax = value; }
        public int dwMaxTotalCount { get => Nest.dwMaxTotalCount; set => Nest.dwMaxTotalCount = value; }
        public byte btFlag { get => Nest.btFlag; set => Nest.btFlag = value; }
        public byte btRespawn { get => Nest.btRespawn; set => Nest.btRespawn = value; }
        public byte btType { get => Nest.btType; set => Nest.btType = value; }

        //  public TabRefNest Nest1 => Nest;
    }

    public struct PTab_RefHive
    {
        private Tab_RefHive Hive;

        public PTab_RefHive(Tab_RefHive hive)
        {
            Hive = hive;
        }

        public int dwHiveID => Hive.dwHiveID;

        public byte BtKeepMonsterCountType { get => Hive.btKeepMonsterCountType; set => Hive.btKeepMonsterCountType = value; }
        public int DwOverwriteMaxTotalCount { get => Hive.dwOverwriteMaxTotalCount; set => Hive.dwOverwriteMaxTotalCount = value; }
        public float FMonsterCountPerPC { get => Hive.fMonsterCountPerPC; set => Hive.fMonsterCountPerPC = value; }
        public int DwSpawnSpeedIncreaseRate { get => Hive.dwSpawnSpeedIncreaseRate; set => Hive.dwSpawnSpeedIncreaseRate = value; }
        public int DwMaxIncreaseRate { get => Hive.dwMaxIncreaseRate; set => Hive.dwMaxIncreaseRate = value; }
        public byte BtFlag { get => Hive.btFlag; set => Hive.btFlag = value; }
        public short GameWorldID { get => Hive.GameWorldID; set => Hive.GameWorldID = value; }
        public short HatchObjType { get => Hive.HatchObjType; set => Hive.HatchObjType = value; }
        public string SzDescString128 { get => Hive.szDescString128; set => Hive.szDescString128 = value; }
    }

    public struct PTab_RefTactics
    {
        private Tab_RefTactics Tactics;

        public PTab_RefTactics(Tab_RefTactics tactics)
        {
            Tactics = tactics;
        }

        public int dwTacticsID => Tactics.dwTacticsID;

        public int dwObjID { get => Tactics.dwObjID; set => Tactics.dwObjID = value; }
        public byte btAIQoS { get => Tactics.btAIQoS; set => Tactics.btAIQoS = value; }
        public int nMaxStamina { get => Tactics.nMaxStamina; set => Tactics.nMaxStamina = value; }
        public byte btMaxStaminaVariance { get => Tactics.btMaxStaminaVariance; set => Tactics.btMaxStaminaVariance = value; }
        public int nSightRange { get => Tactics.nSightRange; set => Tactics.nSightRange = value; }
        public byte btAggressType { get => Tactics.btAggressType; set => Tactics.btAggressType = value; }
        public int AggressData { get => Tactics.AggressData; set => Tactics.AggressData = value; }
        public byte btChangeTarget { get => Tactics.btChangeTarget; set => Tactics.btChangeTarget = value; }
        public byte btHelpRequestTo { get => Tactics.btHelpRequestTo; set => Tactics.btHelpRequestTo = value; }
        public byte btHelpResponseTo { get => Tactics.btHelpResponseTo; set => Tactics.btHelpResponseTo = value; }
        public byte btBattleStyle { get => Tactics.btBattleStyle; set => Tactics.btBattleStyle = value; }
        public int BattleStyleData { get => Tactics.BattleStyleData; set => Tactics.BattleStyleData = value; }
        public byte BtDiversionBasis { get => Tactics.btDiversionBasis; set => Tactics.btDiversionBasis = value; }
        public int DiversionBasisData1 { get => Tactics.DiversionBasisData1; set => Tactics.DiversionBasisData1 = value; }
        public int DiversionBasisData2 { get => Tactics.DiversionBasisData2; set => Tactics.DiversionBasisData2 = value; }
        public int DiversionBasisData3 { get => Tactics.DiversionBasisData3; set => Tactics.DiversionBasisData3 = value; }
        public int DiversionBasisData4 { get => Tactics.DiversionBasisData4; set => Tactics.DiversionBasisData4 = value; }
        public int DiversionBasisData5 { get => Tactics.DiversionBasisData5; set => Tactics.DiversionBasisData5 = value; }
        public int DiversionBasisData6 { get => Tactics.DiversionBasisData6; set => Tactics.DiversionBasisData6 = value; }
        public int DiversionBasisData7 { get => Tactics.DiversionBasisData7; set => Tactics.DiversionBasisData7 = value; }
        public int DiversionBasisData8 { get => Tactics.DiversionBasisData8; set => Tactics.DiversionBasisData8 = value; }
        public byte BtDiversionKeepBasis { get => Tactics.btDiversionKeepBasis; set => Tactics.btDiversionKeepBasis = value; }
        public int DiversionKeepBasisData1 { get => Tactics.DiversionKeepBasisData1; set => Tactics.DiversionKeepBasisData1 = value; }
        public int DiversionKeepBasisData2 { get => Tactics.DiversionKeepBasisData2; set => Tactics.DiversionKeepBasisData2 = value; }
        public int DiversionKeepBasisData3 { get => Tactics.DiversionKeepBasisData3; set => Tactics.DiversionKeepBasisData3 = value; }
        public int DiversionKeepBasisData4 { get => Tactics.DiversionKeepBasisData4; set => Tactics.DiversionKeepBasisData4 = value; }
        public int DiversionKeepBasisData5 { get => Tactics.DiversionKeepBasisData5; set => Tactics.DiversionKeepBasisData5 = value; }
        public int DiversionKeepBasisData6 { get => Tactics.DiversionKeepBasisData6; set => Tactics.DiversionKeepBasisData6 = value; }
        public int DiversionKeepBasisData7 { get => Tactics.DiversionKeepBasisData7; set => Tactics.DiversionKeepBasisData7 = value; }
        public int DiversionKeepBasisData8 { get => Tactics.DiversionKeepBasisData8; set => Tactics.DiversionKeepBasisData8 = value; }
        public byte BtKeepDistance { get => Tactics.btKeepDistance; set => Tactics.btKeepDistance = value; }
        public int KeepDistanceData { get => Tactics.KeepDistanceData; set => Tactics.KeepDistanceData = value; }
        public byte BtTraceType { get => Tactics.btTraceType; set => Tactics.btTraceType = value; }
        public byte BtTraceBoundary { get => Tactics.btTraceBoundary; set => Tactics.btTraceBoundary = value; }
        public int TraceData { get => Tactics.TraceData; set => Tactics.TraceData = value; }
        public byte BtHomingType { get => Tactics.btHomingType; set => Tactics.btHomingType = value; }
        public int HomingData { get => Tactics.HomingData; set => Tactics.HomingData = value; }
        public byte BtAggressTypeOnHoming { get => Tactics.btAggressTypeOnHoming; set => Tactics.btAggressTypeOnHoming = value; }
        public byte BtFleeType { get => Tactics.btFleeType; set => Tactics.btFleeType = value; }
        public int DwChampionTacticsID { get => Tactics.dwChampionTacticsID; set => Tactics.dwChampionTacticsID = value; }
        public int AdditionOptionFlag { get => Tactics.AdditionOptionFlag; set => Tactics.AdditionOptionFlag = value; }
        public string SzDescString128 { get => Tactics.szDescString128; set => Tactics.szDescString128 = value; }
    }

    public struct P_RefObjCommon
    {
        private RefObjCommon Common;

        public P_RefObjCommon(RefObjCommon common)
        {
            Common = common;
        }

        public int Service { get => Common.Service; set => Common.Service = value; }
        public int ID => Common.ID;
        public string CodeName128 { get => Common.CodeName128; set => Common.CodeName128 = value; }
        public string ObjName128 { get => Common.ObjName128; set => Common.ObjName128 = value; }
        public string OrgObjCodeName128 { get => Common.OrgObjCodeName128; set => Common.OrgObjCodeName128 = value; }
        public string NameStrID128 { get => Common.NameStrID128; set => Common.NameStrID128 = value; }
        public string DescStrID128 { get => Common.DescStrID128; set => Common.DescStrID128 = value; }
        public byte CashItem { get => Common.CashItem; set => Common.CashItem = value; }
        public byte Bionic { get => Common.Bionic; set => Common.Bionic = value; }
        public byte TypeID1 { get => Common.TypeID1; set => Common.TypeID1 = value; }
        public byte TypeID2 { get => Common.TypeID2; set => Common.TypeID2 = value; }
        public byte TypeID3 { get => Common.TypeID3; set => Common.TypeID3 = value; }
        public byte TypeID4 { get => Common.TypeID4; set => Common.TypeID4 = value; }
        public int DecayTime { get => Common.DecayTime; set => Common.DecayTime = value; }
        public byte Country { get => Common.Country; set => Common.Country = value; }
        public Rarity Rarity { get => Common.Rarity; set => Common.Rarity = value; }
        public byte CanTrade { get => Common.CanTrade; set => Common.CanTrade = value; }
        public byte CanSell { get => Common.CanSell; set => Common.CanSell = value; }
        public byte CanBuy { get => Common.CanBuy; set => Common.CanBuy = value; }
        public BorrowFlag CanBorrow { get => Common.CanBorrow; set => Common.CanBorrow = value; }
        public DropFlag CanDrop { get => Common.CanDrop; set => Common.CanDrop = value; }
        public byte CanPick { get => Common.CanPick; set => Common.CanPick = value; }
        public byte CanRepair { get => Common.CanRepair; set => Common.CanRepair = value; }
        public byte CanRevive { get => Common.CanRevive; set => Common.CanRevive = value; }
        public byte CanUse { get => Common.CanUse; set => Common.CanUse = value; }
        public byte CanThrow { get => Common.CanThrow; set => Common.CanThrow = value; }
        public int Price { get => Common.Price; set => Common.Price = value; }
        public int CostRepair { get => Common.CostRepair; set => Common.CostRepair = value; }
        public int CostRevive { get => Common.CostRevive; set => Common.CostRevive = value; }
        public int CostBorrow { get => Common.CostBorrow; set => Common.CostBorrow = value; }
        public int KeepingFee { get => Common.KeepingFee; set => Common.KeepingFee = value; }
        public int SellPrice { get => Common.SellPrice; set => Common.SellPrice = value; }
        public int ReqLevelType1 { get => Common.ReqLevelType1; set => Common.ReqLevelType1 = value; }
        public byte ReqLevel1 { get => Common.ReqLevel1; set => Common.ReqLevel1 = value; }
        public int ReqLevelType2 { get => Common.ReqLevelType2; set => Common.ReqLevelType2 = value; }
        public byte ReqLevel2 { get => Common.ReqLevel2; set => Common.ReqLevel2 = value; }
        public int ReqLevelType3 { get => Common.ReqLevelType3; set => Common.ReqLevelType3 = value; }
        public byte ReqLevel3 { get => Common.ReqLevel3; set => Common.ReqLevel3 = value; }
        public int ReqLevelType4 { get => Common.ReqLevelType4; set => Common.ReqLevelType4 = value; }
        public byte ReqLevel4 { get => Common.ReqLevel4; set => Common.ReqLevel4 = value; }
        public int MaxContain { get => Common.MaxContain; set => Common.MaxContain = value; }
        public short RegionID { get => Common.RegionID; set => Common.RegionID = value; }
        public short Dir { get => Common.Dir; set => Common.Dir = value; }
        public short OffsetX { get => Common.OffsetX; set => Common.OffsetX = value; }
        public short OffsetY { get => Common.OffsetY; set => Common.OffsetY = value; }
        public short OffsetZ { get => Common.OffsetZ; set => Common.OffsetZ = value; }
        public short Speed1 { get => Common.Speed1; set => Common.Speed1 = value; }
        public short Speed2 { get => Common.Speed2; set => Common.Speed2 = value; }
        public int Scale { get => Common.Scale; set => Common.Scale = value; }
        public short BCHeight { get => Common.BCHeight; set => Common.BCHeight = value; }
        public short BCRadius { get => Common.BCRadius; set => Common.BCRadius = value; }
        public int EventID { get => Common.EventID; set => Common.EventID = value; }
        public string AssocFileObj128 { get => Common.AssocFileObj128; set => Common.AssocFileObj128 = value; }
        public string AssocFileDrop128 { get => Common.AssocFileDrop128; set => Common.AssocFileDrop128 = value; }
        public string AssocFileIcon128 { get => Common.AssocFileIcon128; set => Common.AssocFileIcon128 = value; }
        public string AssocFile1_128 { get => Common.AssocFile1_128; set => Common.AssocFile1_128 = value; }
        public string AssocFile2_128 { get => Common.AssocFile2_128; set => Common.AssocFile2_128 = value; }
        public int Link { get => Common.Link; set => Common.Link = value; }
    }

    public struct P_RefObjChar
    {
        private RefObjChar Char;

        public P_RefObjChar(RefObjChar @char)
        {
            Char = @char;
        }

        public int ID { get => Char.ID; }
        public byte Lvl { get => Char.Lvl; set => Char.Lvl = value; }
        public byte CharGender { get => Char.CharGender; set => Char.CharGender = value; }
        public int MaxHP { get => Char.MaxHP; set => Char.MaxHP = value; }
        public int MaxMP { get => Char.MaxMP; set => Char.MaxMP = value; }
        public int ResistFrozen { get => Char.ResistFrozen; set => Char.ResistFrozen = value; }
        public int ResistFrostbite { get => Char.ResistFrostbite; set => Char.ResistFrostbite = value; }
        public int ResistBurn { get => Char.ResistBurn; set => Char.ResistBurn = value; }
        public int ResistEShock { get => Char.ResistEShock; set => Char.ResistEShock = value; }
        public int ResistPoison { get => Char.ResistPoison; set => Char.ResistPoison = value; }
        public int ResistZombie { get => Char.ResistZombie; set => Char.ResistZombie = value; }
        public int ResistSleep { get => Char.ResistSleep; set => Char.ResistSleep = value; }
        public int ResistRoot { get => Char.ResistRoot; set => Char.ResistRoot = value; }
        public int ResistSlow { get => Char.ResistSlow; set => Char.ResistSlow = value; }
        public int ResistFear { get => Char.ResistFear; set => Char.ResistFear = value; }
        public int ResistMyopia { get => Char.ResistMyopia; set => Char.ResistMyopia = value; }
        public int ResistBlood { get => Char.ResistBlood; set => Char.ResistBlood = value; }
        public int ResistStone { get => Char.ResistStone; set => Char.ResistStone = value; }
        public int ResistDark { get => Char.ResistDark; set => Char.ResistDark = value; }
        public int ResistStun { get => Char.ResistStun; set => Char.ResistStun = value; }
        public int ResistDisea { get => Char.ResistDisea; set => Char.ResistDisea = value; }
        public int ResistChaos { get => Char.ResistChaos; set => Char.ResistChaos = value; }
        public int ResistCsePD { get => Char.ResistCsePD; set => Char.ResistCsePD = value; }
        public int ResistCseMD { get => Char.ResistCseMD; set => Char.ResistCseMD = value; }
        public int ResistCseSTR { get => Char.ResistCseSTR; set => Char.ResistCseSTR = value; }
        public int ResistCseINT { get => Char.ResistCseINT; set => Char.ResistCseINT = value; }
        public int ResistCseHP { get => Char.ResistCseHP; set => Char.ResistCseHP = value; }
        public int ResistCseMP { get => Char.ResistCseMP; set => Char.ResistCseMP = value; }
        public int Resist24 { get => Char.Resist24; set => Char.Resist24 = value; }
        public int ResistBomb { get => Char.ResistBomb; set => Char.ResistBomb = value; }
        public int Resist26 { get => Char.Resist26; set => Char.Resist26 = value; }
        public int Resist27 { get => Char.Resist27; set => Char.Resist27 = value; }
        public int Resist28 { get => Char.Resist28; set => Char.Resist28 = value; }
        public int Resist29 { get => Char.Resist29; set => Char.Resist29 = value; }
        public int Resist30 { get => Char.Resist30; set => Char.Resist30 = value; }
        public int Resist31 { get => Char.Resist31; set => Char.Resist31 = value; }
        public int Resist32 { get => Char.Resist32; set => Char.Resist32 = value; }
        public byte InventorySize { get => Char.InventorySize; set => Char.InventorySize = value; }
        public byte CanStore_TID1 { get => Char.CanStore_TID1; set => Char.CanStore_TID1 = value; }
        public byte CanStore_TID2 { get => Char.CanStore_TID2; set => Char.CanStore_TID2 = value; }
        public byte CanStore_TID3 { get => Char.CanStore_TID3; set => Char.CanStore_TID3 = value; }
        public byte CanStore_TID4 { get => Char.CanStore_TID4; set => Char.CanStore_TID4 = value; }
        public byte CanBeVehicle { get => Char.CanBeVehicle; set => Char.CanBeVehicle = value; }
        public byte CanControl { get => Char.CanControl; set => Char.CanControl = value; }
        public byte DamagePortion { get => Char.DamagePortion; set => Char.DamagePortion = value; }
        public short MaxPassenger { get => Char.MaxPassenger; set => Char.MaxPassenger = value; }
        public int AssocTactics { get => Char.AssocTactics; set => Char.AssocTactics = value; }
        public int PD { get => Char.PD; set => Char.PD = value; }
        public int MD { get => Char.MD; set => Char.MD = value; }
        public int PAR { get => Char.PAR; set => Char.PAR = value; }
        public int MAR { get => Char.MAR; set => Char.MAR = value; }
        public int ER { get => Char.ER; set => Char.ER = value; }
        public int BR { get => Char.BR; set => Char.BR = value; }
        public int HR { get => Char.HR; set => Char.HR = value; }
        public int CHR { get => Char.CHR; set => Char.CHR = value; }
        public int ExpToGive { get => Char.ExpToGive; set => Char.ExpToGive = value; }
        public int CreepType { get => Char.CreepType; set => Char.CreepType = value; }
        public byte Knockdown { get => Char.Knockdown; set => Char.Knockdown = value; }
        public int KO_RecoverTime { get => Char.KO_RecoverTime; set => Char.KO_RecoverTime = value; }
        public int DefaultSkill_1 { get => Char.DefaultSkill_1; set => Char.DefaultSkill_1 = value; }
        public int DefaultSkill_2 { get => Char.DefaultSkill_2; set => Char.DefaultSkill_2 = value; }
        public int DefaultSkill_3 { get => Char.DefaultSkill_3; set => Char.DefaultSkill_3 = value; }
        public int DefaultSkill_4 { get => Char.DefaultSkill_4; set => Char.DefaultSkill_4 = value; }
        public int DefaultSkill_5 { get => Char.DefaultSkill_5; set => Char.DefaultSkill_5 = value; }
        public int DefaultSkill_6 { get => Char.DefaultSkill_6; set => Char.DefaultSkill_6 = value; }
        public int DefaultSkill_7 { get => Char.DefaultSkill_7; set => Char.DefaultSkill_7 = value; }
        public int DefaultSkill_8 { get => Char.DefaultSkill_8; set => Char.DefaultSkill_8 = value; }
        public int DefaultSkill_9 { get => Char.DefaultSkill_9; set => Char.DefaultSkill_9 = value; }
        public int DefaultSkill_10 { get => Char.DefaultSkill_10; set => Char.DefaultSkill_10 = value; }
        public byte TextureType { get => Char.TextureType; set => Char.TextureType = value; }
        public int Except_1 { get => Char.Except_1; set => Char.Except_1 = value; }
        public int Except_2 { get => Char.Except_2; set => Char.Except_2 = value; }
        public int Except_3 { get => Char.Except_3; set => Char.Except_3 = value; }
        public int Except_4 { get => Char.Except_4; set => Char.Except_4 = value; }
        public int Except_5 { get => Char.Except_5; set => Char.Except_5 = value; }
        public int Except_6 { get => Char.Except_6; set => Char.Except_6 = value; }
        public int Except_7 { get => Char.Except_7; set => Char.Except_7 = value; }
        public int Except_8 { get => Char.Except_8; set => Char.Except_8 = value; }
        public int Except_9 { get => Char.Except_9; set => Char.Except_9 = value; }
        public int Except_10 { get => Char.Except_10; set => Char.Except_10 = value; }
        public int Link { get => Char.Link; set => Char.Link = value; }
    }

    public struct P_RefTeleport
    {
        private RefTeleport teleport;

        public P_RefTeleport(RefTeleport teleport)
        {
            this.teleport = teleport;
        }

        public int Service { get => teleport.Service; set => teleport.Service = value; }
        public int ID { get => teleport.ID; }
        public string CodeName128 { get => teleport.CodeName128; set => teleport.CodeName128 = value; }
        public string AssocRefObjCodeName128 { get => teleport.AssocRefObjCodeName128; set => teleport.AssocRefObjCodeName128 = value; }
        public int AssocRefObjID { get => teleport.AssocRefObjID; set => teleport.AssocRefObjID = value; }
        public string ZoneName128 { get => teleport.ZoneName128; set => teleport.ZoneName128 = value; }
        public short GenRegionID { get => teleport.GenRegionID; set => teleport.GenRegionID = value; }
        public short GenPos_X { get => teleport.GenPos_X; set => teleport.GenPos_X = value; }
        public short GenPos_Y { get => teleport.GenPos_Y; set => teleport.GenPos_Y = value; }
        public short GenPos_Z { get => teleport.GenPos_Z; set => teleport.GenPos_Z = value; }
        public short GenAreaRadius { get => teleport.GenAreaRadius; set => teleport.GenAreaRadius = value; }
        public byte CanBeResurrectPos { get => teleport.CanBeResurrectPos; set => teleport.CanBeResurrectPos = value; }
        public byte CanGotoResurrectPos { get => teleport.CanGotoResurrectPos; set => teleport.CanGotoResurrectPos = value; }
        public short GenWorldID { get => teleport.GenWorldID; set => teleport.GenWorldID = value; }
        public byte BindInteractionMask { get => teleport.BindInteractionMask; set => teleport.BindInteractionMask = value; }
        public byte FixedService { get => teleport.FixedService; set => teleport.FixedService = value; }
    }

    public struct P_RefTeleLink
    {
        private RefTeleLink telelink;

        public P_RefTeleLink(RefTeleLink telelink)
        {
            this.telelink = telelink;
        }

        public int Service { get => telelink.Service; set => telelink.Service = value; }
        public int OwnerTeleport { get => telelink.OwnerTeleport; set => telelink.OwnerTeleport = value; }
        public int TargetTeleport { get => telelink.TargetTeleport; set => telelink.TargetTeleport = value; }
        public int Fee { get => telelink.Fee; set => telelink.Fee = value; }
        public byte RestrictBindMethod { get => telelink.RestrictBindMethod; set => telelink.RestrictBindMethod = value; }
        public byte RunTimeTeleportMethod { get => telelink.RunTimeTeleportMethod; set => telelink.RunTimeTeleportMethod = value; }
        public byte CheckResult { get => telelink.CheckResult; set => telelink.CheckResult = value; }
        public int Restrict1 { get => telelink.Restrict1; set => telelink.Restrict1 = value; }
        public int Data1_1 { get => telelink.Data1_1; set => telelink.Data1_1 = value; }
        public int Data1_2 { get => telelink.Data1_2; set => telelink.Data1_2 = value; }
        public int Restrict2 { get => telelink.Restrict2; set => telelink.Restrict2 = value; }
        public int Data2_1 { get => telelink.Data2_1; set => telelink.Data2_1 = value; }
        public int Data2_2 { get => telelink.Data2_2; set => telelink.Data2_2 = value; }
        public int Restrict3 { get => telelink.Restrict3; set => telelink.Restrict3 = value; }
        public int Data3_1 { get => telelink.Data3_1; set => telelink.Data3_1 = value; }
        public int Data3_2 { get => telelink.Data3_2; set => telelink.Data3_2 = value; }
        public int Restrict4 { get => telelink.Restrict4; set => telelink.Restrict4 = value; }
        public int Data4_1 { get => telelink.Data4_1; set => telelink.Data4_1 = value; }
        public int Data4_2 { get => telelink.Data4_2; set => telelink.Data4_2 = value; }
        public int Restrict5 { get => telelink.Restrict5; set => telelink.Restrict5 = value; }
        public int Data5_1 { get => telelink.Data5_1; set => telelink.Data5_1 = value; }
        public int Data5_2 { get => telelink.Data5_2; set => telelink.Data5_2 = value; }
    }
}