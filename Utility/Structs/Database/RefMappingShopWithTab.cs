namespace Structs.Database
{
    public struct RefMappingShopWithTab
    {
        public byte Service;
        public int Country;
        public string RefShopCodeName;
        public string RefTabGroupCodeName;

        public RefMappingShopWithTab(object[] row)
        {
            Service = byte.Parse(row[0].ToString());
            Country = int.Parse(row[1].ToString());
            RefShopCodeName = row[2].ToString();
            RefTabGroupCodeName = row[3].ToString();
        }
    }
}
