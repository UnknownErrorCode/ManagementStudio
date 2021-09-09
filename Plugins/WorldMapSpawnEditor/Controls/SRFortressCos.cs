namespace WorldMapSpawnEditor.Controls
{
	public class SRFortressCos : SRNpc
	{
		public uint GuildID { get; set; }
		public string GuildName { get; set; }

		public SRFortressCos(uint ID) : base(ID) { }
		public SRFortressCos(string ServerName) : base(ServerName) { }
		public SRFortressCos(SRNpc value) : base(value) { }

	}
}