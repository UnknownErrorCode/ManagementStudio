namespace StudioServer.Handler.PacketHandler.Skills.SkillInterfaces.MonsterSkills
{
    internal struct BasicMobSkill
    {

        public string MobName;
        public string SkillName;
        public byte SkillLevel;
        public int Range;
        public int Action_CastingTime;
        public int Action_ActionDuration;
        public int Action_ReuseDelay;
        public int Action_CoolTime;
        public int Action_FlyingSpeed;
        public bool TargetRequired;
        public int AI_Attack_Chance;
        public string SkillFlag;

    }
}
