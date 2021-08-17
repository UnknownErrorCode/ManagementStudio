using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Handler.PacketHandler.Skills.SkillInterfaces.MonsterSkills
{
    internal class MobSpawnSkill
    {
        public BasicMobSkill basicSkillInfos;
        public byte Rarity; //tinyint
        public string MobToSpawnCodeName; //varchar
        public int MinSpawnCount;
        public int MaxSpawnCount;
    }
}
