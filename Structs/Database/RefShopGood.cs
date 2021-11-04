using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structs.Database
{
    public struct RefShopGood
    {
		public byte Service{ get; set; }
		public int Country{ get; set; }
		public string RefTabCodeName{ get; set; }
		public string RefPackageItemCodeName{ get; set; }
		public byte SlotIndex{ get; set; }
		public int Param1{ get; set; }
		public string Param1_Desc128{ get; set; }
		public int Param2{ get; set; }
		public string Param2_Desc128{ get; set; }
		public int Param3{ get; set; }
		public string Param3_Desc128{ get; set; }
		public int Param4{ get; set; }
		public string Param4_Desc128{ get; set; }
		public int index{ get;private set; }

		public RefShopGood(object[] row)
		{
			Service = byte.Parse(row[0].ToString());
			Country = int.Parse(row[1].ToString());
			RefTabCodeName = row[2].ToString();
			RefPackageItemCodeName = row[3].ToString();
			SlotIndex = byte.Parse(row[4].ToString());
			Param1 = int.Parse(row[5].ToString());
			Param1_Desc128 = row[6].ToString();
			Param2 = int.Parse(row[7].ToString());
			Param2_Desc128 = row[8].ToString();
			Param3 = int.Parse(row[9].ToString());
			Param3_Desc128 = row[10].ToString();
			Param4 = int.Parse(row[11].ToString());
			Param4_Desc128 = row[12].ToString();
			index = int.Parse(row[13].ToString());
		}
	}
}
