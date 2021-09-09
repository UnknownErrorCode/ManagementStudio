namespace WorldMapSpawnEditor.Controls
{
	public class SRSocket
	{
		public uint ID { get; set; }
		public byte Slot { get; set; }
		public uint Value { get; set; }
		public SRSocket(byte Slot, uint ID)
		{
			this.Slot = Slot;
			this.ID = ID;
		}
	}
}