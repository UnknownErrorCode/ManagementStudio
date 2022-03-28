namespace Structs.Database
{
    public struct RefMappingShopGroup
	{
		public byte Service;
		public int Country;
		public string RefShopGroupCodeName;
		public string RefShopCodeName;

		public RefMappingShopGroup(object[] row)
		{
			Service = byte.Parse(row[0].ToString());
			Country = int.Parse(row[1].ToString());
			RefShopGroupCodeName = row[2].ToString();
			RefShopCodeName = row[3].ToString();
		}
	}
}
