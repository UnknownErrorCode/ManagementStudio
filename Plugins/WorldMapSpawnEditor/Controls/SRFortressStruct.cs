namespace WorldMapSpawnEditor.Controls
{
	public class SRFortressStruct : SRNpc
	{
		public uint refEventStructID { get; set; }
		public ushort State { get; set; }

		public SRFortressStruct(uint ID) : base(ID) { }
		public SRFortressStruct(string ServerName) : base(ServerName) { }
		public SRFortressStruct(SRNpc value) : base(value) { }

	}
}