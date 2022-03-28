namespace Structs.Database
{
    public struct RefShop
    {
        public byte Service;
        public int Country;
        public int ID;
        public string CodeName128;
        public int Param1;
        public string Param1_Desc128;
        public int Param2;
        public string Param2_Desc128;
        public int Param3;
        public string Param3_Desc128;
        public int Param4;
        public string Param4_Desc128;


        public RefShop(object[] row)
        {
            Service = byte.Parse(row[0].ToString());
            Country = int.Parse(row[1].ToString());
            ID = int.Parse(row[2].ToString());
            CodeName128 = row[3].ToString();
            Param1 = int.Parse(row[4].ToString());
            Param1_Desc128 = row[5].ToString();
            Param2 = int.Parse(row[6].ToString());
            Param2_Desc128 = row[7].ToString();
            Param3 = int.Parse(row[8].ToString());
            Param3_Desc128 = row[9].ToString();
            Param4 = int.Parse(row[10].ToString());
            Param4_Desc128 = row[11].ToString();
        }
    }
}
