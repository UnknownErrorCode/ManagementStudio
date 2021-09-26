using System;

namespace Structs.Database
{
	/// <summary>
	/// This is the Hive of vSro.
	/// </summary>
	public struct Tab_RefHive
	{
		/// <summary>
		/// This is the Identifier of the hive.
		/// </summary>
		public int dwHiveID { get; private set; }
		public byte btKeepMonsterCountType { get; set; }
		public int dwOverwriteMaxTotalCount { get; set; }
		public float fMonsterCountPerPC { get; set; }
		public int dwSpawnSpeedIncreaseRate { get; set; }
		public int dwMaxIncreaseRate { get; set; }
		public byte btFlag { get; set; }
		public Int16 GameWorldID { get; set; }
		public Int16 HatchObjType { get; set; }
		public string szDescString128 { get; set; }

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
