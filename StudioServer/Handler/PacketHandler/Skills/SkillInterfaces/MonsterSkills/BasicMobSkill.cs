namespace StudioServer.Handler.PacketHandler.Skills.SkillInterfaces.MonsterSkills
{
    internal struct BasicMobSkill
    {
        #region Public Fields

        public int Action_ActionDuration;
        public int Action_CastingTime;
        public int Action_CoolTime;
        public int Action_FlyingSpeed;
        public int Action_ReuseDelay;
        public int AI_Attack_Chance;
        public string MobName;
        public int Range;
        public string SkillFlag;
        public byte SkillLevel;
        public string SkillName;
        public bool TargetRequired;

        #endregion Public Fields
    }
}