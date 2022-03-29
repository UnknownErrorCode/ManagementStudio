namespace StudioServer.Handler.PacketHandler.Spawns.SpawnInterfaces
{
    public struct ITabRefNestUpdater
    {
        public string dwHiveID { get; set; }
        public string dwTacticsID { get; set; }
        public string CharName16 { get; set; }
        public int nRegionDBID { get; set; }
        public string fLocalPosX { get; set; }
        public string fLocalPosY { get; set; }
        public string fLocalPosZ { get; set; }
        public string wInitialDir { get; set; }
        public string nRadius { get; set; }
        public string nGenerateRadius { get; set; }
        public string nChampionGenPercentage { get; set; }
        public string dwDelayTimeMin { get; set; }
        public string dwDelayTimeMax { get; set; }
        public string dwMaxTotalCount { get; set; }
        public string btFlag { get; set; }
        public string btRespawn { get; set; }
        public string btType { get; set; }
    }
}

