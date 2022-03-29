namespace StudioServer.Handler.PacketHandler.Skills.SkillInterfaces.MonsterSkills
{
    internal class MobSpawnSkill
    {
        #region Public Fields

        public BasicMobSkill basicSkillInfos;
        public int MaxSpawnCount;
        public int MinSpawnCount;
        public string MobToSpawnCodeName;
        public byte Rarity;

        #endregion Public Fields

        //tinyint
        //varchar
    }
}