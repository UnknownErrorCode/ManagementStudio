using System;

namespace Structs.Database
{
	public struct Tab_RefHive
	{
		public int dwHiveID;
		public byte btKeepMonsterCountType;
		public int dwOverwriteMaxTotalCount;
		public float fMonsterCountPerPC;
		public int dwSpawnSpeedIncreaseRate;
		public int dwMaxIncreaseRate;
		public byte btFlag;
		public Int16 GameWorldID;
		public Int16 HatchObjType;
		public string szDescString128;

		public Tab_RefHive(object[] row)
		{
			dwHiveID = int.Parse(row[0].ToString());
			btKeepMonsterCountType = byte.Parse(row[1].ToString());
			dwOverwriteMaxTotalCount = int.Parse(row[2].ToString());
			fMonsterCountPerPC = float.Parse(row[3].ToString());
			dwSpawnSpeedIncreaseRate = int.Parse(row[4].ToString());
			dwMaxIncreaseRate = int.Parse(row[5].ToString());
			btFlag = byte.Parse(row[6].ToString());
			GameWorldID = Int16.Parse(row[7].ToString());
			HatchObjType = Int16.Parse(row[8].ToString());
			szDescString128 = row[9].ToString();
		}
	}
}
