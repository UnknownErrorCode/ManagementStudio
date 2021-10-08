using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structs.Database
{
    public struct RefSkill
    {
        public object[] SkillAsArray;
        public byte Service { get; set; }
        public int ID { get; private set; }
        public int GroupID { get; set; }
        public string Basic_Code { get; set; }
        public string Basic_Name { get; set; }
        public string Basic_Group { get; set; }
        public int Basic_Original { get; set; }
        public byte Basic_Level { get; set; }
        public byte Basic_Activity { get; set; }
        public int Basic_ChainCode { get; set; }
        public int Basic_RecycleCost { get; set; }
        public int Action_PreparingTime { get; set; }
        public int Action_CastingTime { get; set; }
        public int Action_ActionDuration { get; set; }
        public int Action_ReuseDelay { get; set; }
        public int Action_CoolTime { get; set; }
        public int Action_FlyingSpeed { get; set; }
        public byte Action_Interruptable { get; set; }
        public int Action_Overlap { get; set; }
        public byte Action_AutoAttackType { get; set; }
        public byte Action_InTown { get; set; }
        public Int16 Action_Range { get; set; }
        public byte Target_Required { get; set; }
        public byte TargetType_Animal { get; set; }
        public byte TargetType_Land { get; set; }
        public byte TargetType_Building { get; set; }
        public byte TargetGroup_Self { get; set; }
        public byte TargetGroup_Ally { get; set; }
        public byte TargetGroup_Party { get; set; }
        public byte TargetGroup_Enemy_M { get; set; }
        public byte TargetGroup_Enemy_P { get; set; }
        public byte TargetGroup_Neutral { get; set; }
        public byte TargetGroup_DontCare { get; set; }
        public byte TargetEtc_SelectDeadBody { get; set; }
        public int ReqCommon_Mastery1 { get; set; }
        public int ReqCommon_Mastery2 { get; set; }
        public byte ReqCommon_MasteryLevel1 { get; set; }
        public byte ReqCommon_MasteryLevel2 { get; set; }
        public Int16 ReqCommon_Str { get; set; }
        public Int16 ReqCommon_Int { get; set; }
        public int ReqLearn_Skill1 { get; set; }
        public int ReqLearn_Skill2 { get; set; }
        public int ReqLearn_Skill3 { get; set; }
        public byte ReqLearn_SkillLevel1 { get; set; }
        public byte ReqLearn_SkillLevel2 { get; set; }
        public byte ReqLearn_SkillLevel3 { get; set; }
        public int ReqLearn_SP { get; set; }
        public byte ReqLearn_Race { get; set; }
        public byte Req_Restriction1 { get; set; }
        public byte Req_Restriction2 { get; set; }
        public byte ReqCast_Weapon1 { get; set; }
        public byte ReqCast_Weapon2 { get; set; }
        public Int16 Consume_HP { get; set; }
        public Int16 Consume_MP { get; set; }
        public Int16 Consume_HPRatio { get; set; }
        public Int16 Consume_MPRatio { get; set; }
        public byte Consume_WHAN { get; set; }
        public byte UI_SkillTab { get; set; }
        public byte UI_SkillPage { get; set; }
        public byte UI_SkillColumn { get; set; }
        public byte UI_SkillRow { get; set; }
        public string UI_IconFile { get; set; }
        public string UI_SkillName { get; set; }
        public string UI_SkillToolTip { get; set; }
        public string UI_SkillToolTip_Desc { get; set; }
        public string UI_SkillStudy_Desc { get; set; }
        public Int16 AI_AttackChance { get; set; }
        public byte AI_SkillType { get; set; }
        public int Param1 { get; set; }
        public int Param2 { get; set; }
        public int Param3 { get; set; }
        public int Param4 { get; set; }
        public int Param5 { get; set; }
        public int Param6 { get; set; }
        public int Param7 { get; set; }
        public int Param8 { get; set; }
        public int Param9 { get; set; }
        public int Param10 { get; set; }
        public int Param11 { get; set; }
        public int Param12 { get; set; }
        public int Param13 { get; set; }
        public int Param14 { get; set; }
        public int Param15 { get; set; }
        public int Param16 { get; set; }
        public int Param17 { get; set; }
        public int Param18 { get; set; }
        public int Param19 { get; set; }
        public int Param20 { get; set; }
        public int Param21 { get; set; }
        public int Param22 { get; set; }
        public int Param23 { get; set; }
        public int Param24 { get; set; }
        public int Param25 { get; set; }
        public int Param26 { get; set; }
        public int Param27 { get; set; }
        public int Param28 { get; set; }
        public int Param29 { get; set; }
        public int Param30 { get; set; }
        public int Param31 { get; set; }
        public int Param32 { get; set; }
        public int Param33 { get; set; }
        public int Param34 { get; set; }
        public int Param35 { get; set; }
        public int Param36 { get; set; }
        public int Param37 { get; set; }
        public int Param38 { get; set; }
        public int Param39 { get; set; }
        public int Param40 { get; set; }
        public int Param41 { get; set; }
        public int Param42 { get; set; }
        public int Param43 { get; set; }
        public int Param44 { get; set; }
        public int Param45 { get; set; }
        public int Param46 { get; set; }
        public int Param47 { get; set; }
        public int Param48 { get; set; }
        public int Param49 { get; set; }
        public int Param50 { get; set; }

        public RefSkill(object[] row)
        {
            SkillAsArray = row;
            Service = byte.Parse(row[0].ToString());
            ID = int.Parse(row[1].ToString());
            GroupID = int.Parse(row[2].ToString());
            Basic_Code = row[3].ToString();
            Basic_Name = row[4].ToString();
            Basic_Group = row[5].ToString();
            Basic_Original = int.Parse(row[6].ToString());
            Basic_Level = byte.Parse(row[7].ToString());
            Basic_Activity = byte.Parse(row[8].ToString());
            Basic_ChainCode = int.Parse(row[9].ToString());
            Basic_RecycleCost = int.Parse(row[10].ToString());
            Action_PreparingTime = int.Parse(row[11].ToString());
            Action_CastingTime = int.Parse(row[12].ToString());
            Action_ActionDuration = int.Parse(row[13].ToString());
            Action_ReuseDelay = int.Parse(row[14].ToString());
            Action_CoolTime = int.Parse(row[15].ToString());
            Action_FlyingSpeed = int.Parse(row[16].ToString());
            Action_Interruptable = byte.Parse(row[17].ToString());
            Action_Overlap = int.Parse(row[18].ToString());
            Action_AutoAttackType = byte.Parse(row[19].ToString());
            Action_InTown = byte.Parse(row[20].ToString());
            Action_Range = Int16.Parse(row[21].ToString());
            Target_Required = byte.Parse(row[22].ToString());
            TargetType_Animal = byte.Parse(row[23].ToString());
            TargetType_Land = byte.Parse(row[24].ToString());
            TargetType_Building = byte.Parse(row[25].ToString());
            TargetGroup_Self = byte.Parse(row[26].ToString());
            TargetGroup_Ally = byte.Parse(row[27].ToString());
            TargetGroup_Party = byte.Parse(row[28].ToString());
            TargetGroup_Enemy_M = byte.Parse(row[29].ToString());
            TargetGroup_Enemy_P = byte.Parse(row[30].ToString());
            TargetGroup_Neutral = byte.Parse(row[31].ToString());
            TargetGroup_DontCare = byte.Parse(row[32].ToString());
            TargetEtc_SelectDeadBody = byte.Parse(row[33].ToString());
            ReqCommon_Mastery1 = int.Parse(row[34].ToString());
            ReqCommon_Mastery2 = int.Parse(row[35].ToString());
            ReqCommon_MasteryLevel1 = byte.Parse(row[36].ToString());
            ReqCommon_MasteryLevel2 = byte.Parse(row[37].ToString());
            ReqCommon_Str = Int16.Parse(row[38].ToString());
            ReqCommon_Int = Int16.Parse(row[39].ToString());
            ReqLearn_Skill1 = int.Parse(row[40].ToString());
            ReqLearn_Skill2 = int.Parse(row[41].ToString());
            ReqLearn_Skill3 = int.Parse(row[42].ToString());
            ReqLearn_SkillLevel1 = byte.Parse(row[43].ToString());
            ReqLearn_SkillLevel2 = byte.Parse(row[44].ToString());
            ReqLearn_SkillLevel3 = byte.Parse(row[45].ToString());
            ReqLearn_SP = int.Parse(row[46].ToString());
            ReqLearn_Race = byte.Parse(row[47].ToString());
            Req_Restriction1 = byte.Parse(row[48].ToString());
            Req_Restriction2 = byte.Parse(row[49].ToString());
            ReqCast_Weapon1 = byte.Parse(row[50].ToString());
            ReqCast_Weapon2 = byte.Parse(row[51].ToString());
            Consume_HP = Int16.Parse(row[52].ToString());
            Consume_MP = Int16.Parse(row[53].ToString());
            Consume_HPRatio = Int16.Parse(row[54].ToString());
            Consume_MPRatio = Int16.Parse(row[55].ToString());
            Consume_WHAN = byte.Parse(row[56].ToString());
            UI_SkillTab = byte.Parse(row[57].ToString());
            UI_SkillPage = byte.Parse(row[58].ToString());
            UI_SkillColumn = byte.Parse(row[59].ToString());
            UI_SkillRow = byte.Parse(row[60].ToString());
            UI_IconFile = row[61].ToString();
            UI_SkillName = row[62].ToString();
            UI_SkillToolTip = row[63].ToString();
            UI_SkillToolTip_Desc = row[64].ToString();
            UI_SkillStudy_Desc = row[65].ToString();
            AI_AttackChance = Int16.Parse(row[66].ToString());
            AI_SkillType = byte.Parse(row[67].ToString());
            Param1 = int.Parse(row[68].ToString());
            Param2 = int.Parse(row[69].ToString());
            Param3 = int.Parse(row[70].ToString());
            Param4 = int.Parse(row[71].ToString());
            Param5 = int.Parse(row[72].ToString());
            Param6 = int.Parse(row[73].ToString());
            Param7 = int.Parse(row[74].ToString());
            Param8 = int.Parse(row[75].ToString());
            Param9 = int.Parse(row[76].ToString());
            Param10 = int.Parse(row[77].ToString());
            Param11 = int.Parse(row[78].ToString());
            Param12 = int.Parse(row[79].ToString());
            Param13 = int.Parse(row[80].ToString());
            Param14 = int.Parse(row[81].ToString());
            Param15 = int.Parse(row[82].ToString());
            Param16 = int.Parse(row[83].ToString());
            Param17 = int.Parse(row[84].ToString());
            Param18 = int.Parse(row[85].ToString());
            Param19 = int.Parse(row[86].ToString());
            Param20 = int.Parse(row[87].ToString());
            Param21 = int.Parse(row[88].ToString());
            Param22 = int.Parse(row[89].ToString());
            Param23 = int.Parse(row[90].ToString());
            Param24 = int.Parse(row[91].ToString());
            Param25 = int.Parse(row[92].ToString());
            Param26 = int.Parse(row[93].ToString());
            Param27 = int.Parse(row[94].ToString());
            Param28 = int.Parse(row[95].ToString());
            Param29 = int.Parse(row[96].ToString());
            Param30 = int.Parse(row[97].ToString());
            Param31 = int.Parse(row[98].ToString());
            Param32 = int.Parse(row[99].ToString());
            Param33 = int.Parse(row[100].ToString());
            Param34 = int.Parse(row[101].ToString());
            Param35 = int.Parse(row[102].ToString());
            Param36 = int.Parse(row[103].ToString());
            Param37 = int.Parse(row[104].ToString());
            Param38 = int.Parse(row[105].ToString());
            Param39 = int.Parse(row[106].ToString());
            Param40 = int.Parse(row[107].ToString());
            Param41 = int.Parse(row[108].ToString());
            Param42 = int.Parse(row[109].ToString());
            Param43 = int.Parse(row[110].ToString());
            Param44 = int.Parse(row[111].ToString());
            Param45 = int.Parse(row[112].ToString());
            Param46 = int.Parse(row[113].ToString());
            Param47 = int.Parse(row[114].ToString());
            Param48 = int.Parse(row[115].ToString());
            Param49 = int.Parse(row[116].ToString());
            Param50 = int.Parse(row[117].ToString());
        }
    }
}
