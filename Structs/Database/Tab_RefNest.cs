namespace Structs.Database
{
	public struct Tab_RefNest
	{
		public int dwNestID { get; set; }
		public int dwHiveID { get; set; }
		public int dwTacticsID { get; set; }
		public short nRegionDBID { get; set; }
		public float fLocalPosX { get; set; }
		public float fLocalPosY { get; set; }
		public float fLocalPosZ { get; set; }
		public short wInitialDir { get; set; }
		public int nRadius { get; set; }
		public int nGenerateRadius { get; set; }
		public int nChampionGenPercentage { get; set; }
		public int dwDelayTimeMin { get; set; }
		public int dwDelayTimeMax { get; set; }
		public int dwMaxTotalCount { get; set; }
		public byte btFlag { get; set; }
		public byte btRespawn { get; set; }
		public byte btType { get; set; }

		public Tab_RefNest(object[] row)
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
	}
}
