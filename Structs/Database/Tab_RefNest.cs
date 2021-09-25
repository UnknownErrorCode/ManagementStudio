namespace Structs.Database
{
	public struct Tab_RefNest
	{
		public int dwNestID;
		public int dwHiveID;
		public int dwTacticsID;
		public short nRegionDBID;
		public float fLocalPosX;
		public float fLocalPosY;
		public float fLocalPosZ;
		public short wInitialDir;
		public int nRadius;
		public int nGenerateRadius;
		public int nChampionGenPercentage;
		public int dwDelayTimeMin;
		public int dwDelayTimeMax;
		public int dwMaxTotalCount;
		public byte btFlag;
		public byte btRespawn;
		public byte btType;

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
