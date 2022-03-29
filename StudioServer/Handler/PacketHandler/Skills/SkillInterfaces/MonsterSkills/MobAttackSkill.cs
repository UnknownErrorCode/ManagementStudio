namespace StudioServer.Handler.PacketHandler.Skills.SkillInterfaces.MonsterSkills
{
    internal struct MobAttackSkill
    {
        public BasicMobSkill basicSkillInfos;
        public int SkillType;
        public int NumberOfHits;
        public int ReinforceMin;
        public int ReinforceMax;
        public int PowerMin;
        public int PowerMax;
    }
}
