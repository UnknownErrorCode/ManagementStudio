namespace Structs.Database
{
    public struct TabRefNest
    {
        private readonly int dwNestID;
        private int dwHiveID;
        private int dwTacticsID;
        private short nRegionDBID;
        private float fLocalPosX;
        private float fLocalPosY;
        private float fLocalPosZ;
        private short wInitialDir;
        private int nRadius;
        private int nGenerateRadius;
        private int nChampionGenPercentage;
        private int dwDelayTimeMin;
        private int dwDelayTimeMax;
        private int dwMaxTotalCount;
        private byte btFlag;
        private byte btRespawn;
        private byte btType;

        public TabRefNest(object[] row)
        {
            dwNestID = int.Parse(row[0].ToString());
            dwHiveID = int.Parse(row[1].ToString());
            dwTacticsID = int.Parse(row[2].ToString());
            nRegionDBID = short.Parse(row[3].ToString());
            fLocalPosX = float.Parse(row[4].ToString());
            fLocalPosY = float.Parse(row[5].ToString());
            fLocalPosZ = float.Parse(row[6].ToString());
            wInitialDir = short.Parse(row[7].ToString());
            nRadius = int.Parse(row[8].ToString());
            nGenerateRadius = int.Parse(row[9].ToString());
            nChampionGenPercentage = int.Parse(row[10].ToString());
            dwDelayTimeMin = int.Parse(row[11].ToString());
            dwDelayTimeMax = int.Parse(row[12].ToString());
            dwMaxTotalCount = int.Parse(row[13].ToString());
            btFlag = byte.Parse(row[14].ToString());
            btRespawn = byte.Parse(row[15].ToString());
            btType = byte.Parse(row[16].ToString());
        }

        public int DwNestID => dwNestID;

        public int DwHiveID { get => dwHiveID; set => dwHiveID = value; }
        public int DwTacticsID { get => dwTacticsID; set => dwTacticsID = value; }
        public short NRegionDBID { get => nRegionDBID; set => nRegionDBID = value; }
        public float FLocalPosX { get => fLocalPosX; set => fLocalPosX = value; }
        public float FLocalPosY { get => fLocalPosY; set => fLocalPosY = value; }
        public float FLocalPosZ { get => fLocalPosZ; set => fLocalPosZ = value; }
        public short WInitialDir { get => wInitialDir; set => wInitialDir = value; }
        public int NRadius { get => nRadius; set => nRadius = value; }
        public int NGenerateRadius { get => nGenerateRadius; set => nGenerateRadius = value; }
        public int NChampionGenPercentage { get => nChampionGenPercentage; set => nChampionGenPercentage = value; }
        public int DwDelayTimeMin { get => dwDelayTimeMin; set => dwDelayTimeMin = value; }
        public int DwDelayTimeMax { get => dwDelayTimeMax; set => dwDelayTimeMax = value; }
        public int DwMaxTotalCount { get => dwMaxTotalCount; set => dwMaxTotalCount = value; }
        public byte BtFlag { get => btFlag; set => btFlag = value; }
        public byte BtRespawn { get => btRespawn; set => btRespawn = value; }
        public byte BtType { get => btType; set => btType = value; }
    }
}