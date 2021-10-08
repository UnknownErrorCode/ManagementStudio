using ClientDataStorage.Database;
using Structs.Database;
using System.Collections.Generic;

namespace Editors.Skills
{
    public class Monster
    {
        public RefObjCommon ObjCommon { get; set; }
        public RefObjChar ObjChar { get; set; }
        public List<RefSkill> Skills { get; set; } = new List<RefSkill>();

        public Monster(int ObjCommonID)
        {
            ObjCommon = SRO_VT_SHARD._RefObjCommon[ObjCommonID];
            ObjChar = SRO_VT_SHARD._RefObjChar[ObjCommon.Link];

            if (ObjChar.DefaultSkill_1 > 0)
                Skills.Add(SRO_VT_SHARD._RefSkill[ObjChar.DefaultSkill_1]);
            if (ObjChar.DefaultSkill_2 > 0)
                Skills.Add(SRO_VT_SHARD._RefSkill[ObjChar.DefaultSkill_2]);
            if (ObjChar.DefaultSkill_3 > 0)
                Skills.Add(SRO_VT_SHARD._RefSkill[ObjChar.DefaultSkill_3]);
            if (ObjChar.DefaultSkill_4 > 0)
                Skills.Add(SRO_VT_SHARD._RefSkill[ObjChar.DefaultSkill_4]);
            if (ObjChar.DefaultSkill_5 > 0)
                Skills.Add(SRO_VT_SHARD._RefSkill[ObjChar.DefaultSkill_5]);
            if (ObjChar.DefaultSkill_6 > 0)
                Skills.Add(SRO_VT_SHARD._RefSkill[ObjChar.DefaultSkill_6]);
            if (ObjChar.DefaultSkill_7 > 0)
                Skills.Add(SRO_VT_SHARD._RefSkill[ObjChar.DefaultSkill_7]);
            if (ObjChar.DefaultSkill_8 > 0)
                Skills.Add(SRO_VT_SHARD._RefSkill[ObjChar.DefaultSkill_8]);
            if (ObjChar.DefaultSkill_9 > 0)
                Skills.Add(SRO_VT_SHARD._RefSkill[ObjChar.DefaultSkill_9]);
            if (ObjChar.DefaultSkill_10 > 0)
                Skills.Add(SRO_VT_SHARD._RefSkill[ObjChar.DefaultSkill_10]);
        }
    }
}