namespace WorldMapSpawnEditor.Controls
{
	public class SRSkillZone : SREntity
	{
		public SRSkill Skill { get; private set; }
		public ushort unkUShort01 { get; set; }
		public uint SkillID
		{
			get
			{
				if (Skill != null)
					return Skill.ID;
				return 0;
			}
			set
			{
				Skill = new SRSkill(value);
				Name = Skill.Name + " (Skill)";
				ServerName = Skill.ServerName;
			}
		}
		public SRSkillZone()
		{
			ID = uint.MaxValue;
		}
	}
}