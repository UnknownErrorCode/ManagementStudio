using System.Data;
using System.Runtime.InteropServices;

namespace Structs.Database
{
	[StructLayout(LayoutKind.Sequential, Size = 677)]
	public struct RefPricePolicyOfItem
	{
		public byte Service{ get; set; } 
		public int Country{ get; set; }
		public string RefPackageItemCodeName{ get; set; }
		public PaymentDevice PaymentDevice{ get; set; }
		public int PreviousCost{ get; set; }
		public int Cost{ get; set; }
		public int Param1{ get; set; }
		public string Param1_Desc128{ get; set; }
		public int Param2{ get; set; }
		public string Param2_Desc128{ get; set; }
		public int Param3{ get; set; }
		public string Param3_Desc128{ get; set; }
		public int Param4{ get; set; }
		public string Param4_Desc128{ get; set; }
		public int index{ get; set; }

		public RefPricePolicyOfItem(object[] row)
		{
			Service = byte.Parse(row[0].ToString());
			Country = int.Parse(row[1].ToString());
			RefPackageItemCodeName = row[2].ToString();
			PaymentDevice = (PaymentDevice)int.Parse(row[3].ToString());
			PreviousCost = int.Parse(row[4].ToString());
			Cost = int.Parse(row[5].ToString());
			Param1 = int.Parse(row[6].ToString());
			Param1_Desc128 = row[7].ToString();
			Param2 = int.Parse(row[8].ToString());
			Param2_Desc128 = row[9].ToString();
			Param3 = int.Parse(row[10].ToString());
			Param3_Desc128 = row[11].ToString();
			Param4 = int.Parse(row[12].ToString());
			Param4_Desc128 = row[13].ToString();
			index = int.Parse(row[14].ToString());
		}
	}
}

namespace Structs
{
    public enum PaymentDevice : int
    {
		Gold = 1,
		Silk = 2,
		SilkGift = 4,
		GuildPoint = 8, 
		SilkPoints = 16,
		HonorPoint = 32,
		CopperCoin = 64,
		IronCoin = 128,
		SilverCoin = 256,
		GoldCoin = 512,
		ArenaCoin = 1024
    }
}