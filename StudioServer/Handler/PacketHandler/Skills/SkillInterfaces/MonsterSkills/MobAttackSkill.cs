namespace StudioServer.Handler.PacketHandler.Skills.SkillInterfaces.MonsterSkills
{
    internal struct MobAttackSkill
    {
        #region Public Fields

        public BasicMobSkill basicSkillInfos;
        public int NumberOfHits;
        public int PowerMax;
        public int PowerMin;
        public int ReinforceMax;
        public int ReinforceMin;
        public int SkillType;

        #endregion Public Fields
    }
}