using System.Data;

namespace Structs.Database
{
    public struct RefPackageItem
    {
        public byte Service;
        public int Country;
        public int ID;
        public string CodeName128;
        public short SaleTag;
        public string ExpandTerm;
        public string NameStrID;
        public string DescStrID;
        public string AssocFileIcon;
        public int Param1;
        public string Param1_Desc128;
        public int Param2;
        public string Param2_Desc128;
        public int Param3;
        public string Param3_Desc128;
        public int Param4;
        public string Param4_Desc128;

        public RefPackageItem(DataRow row)
        {
            Service       = row.Field<byte>("Service");      //= byte.Parse(row[0].ToString());
            Country       = row.Field<int>("Country");//   = int.Parse(row[1].ToString());
            ID            = row.Field<int>("ID");//   = int.Parse(row[2].ToString());
            CodeName128   = row.Field<string>("CodeName128");//  = row[3].ToString();
            SaleTag       = row.Field<short>("SaleTag");//  = short.Parse(row[4].ToString());
            ExpandTerm    = row.Field<string>("ExpandTerm");//  = row[5].ToString();
            NameStrID     = row.Field<string>("NameStrID");//   = row[6].ToString();
            DescStrID     = row.Field<string>("DescStrID");//   = row[7].ToString();
            AssocFileIcon = row.Field<string>("AssocFileIcon");//  = row[8].ToString();
            Param1        = row.Field<int>("Param1");// = int.Parse(row[9].ToString());
            Param1_Desc128= row.Field<string>("Param1_Desc128");//= row[10].ToString();
            Param2        = row.Field<int>("Param2");// = int.Parse(row[11].ToString());
            Param2_Desc128= row.Field<string>("Param2_Desc128");//= row[12].ToString();
            Param3        = row.Field<int>("Param3");// = int.Parse(row[13].ToString());
            Param3_Desc128= row.Field<string>("Param3_Desc128");//= row[14].ToString();
            Param4        = row.Field<int>("Param4");//  = int.Parse(row[15].ToString());
            Param4_Desc128= row.Field<string>("Param4_Desc128");//= row[16].ToString();

            // Service = byte.Parse(row[0].ToString());
            // Country = int.Parse(row[1].ToString());
            // ID = int.Parse(row[2].ToString());
            // CodeName128 = row[3].ToString();
            // SaleTag = short.Parse(row[4].ToString());
            // ExpandTerm = row[5].ToString();
            // NameStrID = row[6].ToString();
            // DescStrID = row[7].ToString();
            // AssocFileIcon = row[8].ToString();
            // Param1 = int.Parse(row[9].ToString());
            // Param1_Desc128 = row[10].ToString();
            // Param2 = int.Parse(row[11].ToString());
            // Param2_Desc128 = row[12].ToString();
            // Param3 = int.Parse(row[13].ToString());
            // Param3_Desc128 = row[14].ToString();
            // Param4 = int.Parse(row[15].ToString());
            // Param4_Desc128 = row[16].ToString();

        }
    }
}
