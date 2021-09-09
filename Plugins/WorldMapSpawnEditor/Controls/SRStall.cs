namespace WorldMapSpawnEditor.Controls
{
	public class SRStall
	{
		public string Title { get; set; }
		public uint DecorationID { get; set; }
		public string Note { get; set; }
		public xList<SRItemStall> Inventory { get; set; }

		public SRStall()
		{

		}
	}
}