namespace WorldMapSpawnEditor.Controls
{
	public class SRBuff : SRSkill
	{
		public uint UniqueID { get; set; }
		public uint TargetUniqueID { get; set; }
		public uint CasterUniqueID { get; set; }
		public SRBuff(uint ID) : base(ID)
		{

		}
		public SRBuff(string ServerName) : base(ServerName)
		{

		}
		public bool hasAutoTransferEffect()
		{
			return Params.Contains("|" + (uint)Controls.Params.Effect.AUTO_TRANSFER);
		}
	}
}