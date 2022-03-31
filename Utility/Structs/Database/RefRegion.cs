namespace Structs.Database
{
    public struct RefRegion
    {
        public short wRegionID;
        public byte X;
        public byte Z;
        public string ContinentName;
        public string AreaName;
        public byte IsBattleField;
        public int Climate;
        public int MaxCapacity;
        public int AssocObjID;
        public int AssocServer;
        public string AssocFile256;
        public int LinkedRegion_1;
        public int LinkedRegion_2;
        public int LinkedRegion_3;
        public int LinkedRegion_4;
        public int LinkedRegion_5;
        public int LinkedRegion_6;
        public int LinkedRegion_7;
        public int LinkedRegion_8;
        public int LinkedRegion_9;
        public int LinkedRegion_10;

        public RefRegion(object[] row)
        {
            wRegionID = short.Parse(row[0].ToString());
            X = byte.Parse(row[1].ToString());
            Z = byte.Parse(row[2].ToString());
            ContinentName = row[3].ToString();
            AreaName = row[4].ToString();
            IsBattleField = byte.Parse(row[5].ToString());
            Climate = int.Parse(row[6].ToString());
            MaxCapacity = int.Parse(row[7].ToString());
            AssocObjID = int.Parse(row[8].ToString());
            AssocServer = int.Parse(row[9].ToString());
            AssocFile256 = row[10].ToString();
            int.TryParse(row[11].ToString(), out LinkedRegion_1);
            int.TryParse(row[12].ToString(), out LinkedRegion_2);
            int.TryParse(row[13].ToString(), out LinkedRegion_3);
            int.TryParse(row[14].ToString(), out LinkedRegion_4);
            int.TryParse(row[15].ToString(), out LinkedRegion_5);
            int.TryParse(row[16].ToString(), out LinkedRegion_6);
            int.TryParse(row[17].ToString(), out LinkedRegion_7);
            int.TryParse(row[18].ToString(), out LinkedRegion_8);
            int.TryParse(row[19].ToString(), out LinkedRegion_9);
            int.TryParse(row[20].ToString(), out LinkedRegion_10);
        }
    }
}
