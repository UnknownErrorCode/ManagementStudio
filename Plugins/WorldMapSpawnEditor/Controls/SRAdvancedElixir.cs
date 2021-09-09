namespace WorldMapSpawnEditor.Controls
{
	public class SRAdvancedElixir
	{
		public uint ID { get; set; }
		public byte Slot { get; set; }
		public uint Value { get; set; }
		public SRAdvancedElixir(byte Slot, uint ID)
		{
			this.Slot = Slot;
			this.ID = ID;
		}
	}
}