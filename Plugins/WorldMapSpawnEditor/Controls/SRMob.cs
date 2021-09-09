namespace WorldMapSpawnEditor.Controls
{
	public class SRMob : SRNpc
	{
		public Mob MobType { get; set; }
		public byte Appearence { get; internal set; }

		public SRMob(uint ID) : base(ID) { }
		public SRMob(string ServerName) : base(ServerName) { }
		public SRMob(SRNpc value) : base(value) { }


		public enum Mob : byte
		{
			General = 0,
			Champion = 1,
			Giant = 4,
			Titan = 5,
			Strong = 6,
			Elite = 7,
			Unique = 8,
			PartyGeneral = 0x10,
			PartyChampion = 0x11,
			PartyGiant = 0x14,
			Event = 0xFF
		}
	}
}