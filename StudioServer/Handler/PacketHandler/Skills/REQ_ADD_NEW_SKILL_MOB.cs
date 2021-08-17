using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudioServer.Handler.PacketHandler.Skills.SkillInterfaces.MonsterSkills;

namespace StudioServer.Handler.PacketHandler.Skills
{
   internal static class REQ_ADD_NEW_SKILL_MOB
    {



        private static int GetAttackType(string aType)
        {
            int rValue = 10;
            switch (aType)
            {
                case "Physical":
                    rValue = 5;
                    break;
                case "Magical":
                    rValue = 10;
                    break;
                default:
                    break;
            }
            return rValue;
        }

        internal static Packet NewMobSkill(Packet packet, string AccName)
        {
            List<SqlParameter> SqlParamList = new List<SqlParameter>();


            BasicMobSkill basicSkill = new BasicMobSkill()
            {

                MobName = packet.ReadAscii(),
                SkillName = packet.ReadAscii(),
                SkillLevel = packet.ReadByte(),
                TargetRequired = packet.ReadBool(),
                Action_CastingTime = packet.ReadInt(),
                Action_ActionDuration = packet.ReadInt(),
                Action_CoolTime = packet.ReadInt(),
                Action_ReuseDelay = packet.ReadInt(),
                Action_FlyingSpeed = packet.ReadInt(),
                Range = packet.ReadInt(),
                AI_Attack_Chance = packet.ReadInt(),
                SkillFlag = packet.ReadAscii(),
            };
            var TargetReq = (basicSkill.TargetRequired ? (byte)1 : (byte)0);

            SqlParamList.Add(new SqlParameter("@MobName", SqlDbType.VarChar, 128) { Value = basicSkill.MobName });
            SqlParamList.Add(new SqlParameter("@SkillName", SqlDbType.VarChar, 128) { Value = basicSkill.SkillName });
            SqlParamList.Add(new SqlParameter("@SkillLevel", SqlDbType.TinyInt) { Value = basicSkill.SkillLevel });
            SqlParamList.Add(new SqlParameter("@Range", SqlDbType.Int) { Value = basicSkill.Range });
            SqlParamList.Add(new SqlParameter("@Action_CastingTime", SqlDbType.Int) { Value = basicSkill.Action_CastingTime });
            SqlParamList.Add(new SqlParameter("@Action_ActionDuration", SqlDbType.Int) { Value = basicSkill.Action_ActionDuration });
            SqlParamList.Add(new SqlParameter("@Action_ReuseDelay", SqlDbType.Int) { Value = basicSkill.Action_ReuseDelay });
            SqlParamList.Add(new SqlParameter("@Action_CoolTime", SqlDbType.Int) { Value = basicSkill.Action_CoolTime });
            SqlParamList.Add(new SqlParameter("@Action_FlyingSpeed", SqlDbType.Int) { Value = basicSkill.Action_FlyingSpeed });
            SqlParamList.Add(new SqlParameter("@AI_AttackChance", SqlDbType.Int) { Value = basicSkill.AI_Attack_Chance });
            SqlParamList.Add(new SqlParameter("@Target_Required", SqlDbType.TinyInt) { Value = TargetReq });
            SqlParamList.Add(new SqlParameter("@SkillTypeFlag", SqlDbType.VarChar, 64) { Value = basicSkill.SkillFlag });



            switch (basicSkill.SkillFlag)
            {
                /*
            if(@SkillTypeFlag='Mob-Spawn')

   DECLARE @MobID INT
   SELECT @MobID = ID from SRO_VT_SHARD.._RefObjCommon where CodeName128 = @Value1
   SELECT	@ParamValue1 = 1936945013, --Say it is Spawn Skill
           @ParamValue2 = @Value2,  --Rarity
           @ParamValue3 = @MobID,  --MobID to Spawn
           @ParamValue4 = @Value3,	 -- Min SpawnCount
           @ParamValue5 = @Value4	 -- Max SpawnCount

            */
                case "Mob-Spawn":

                    MobSpawnSkill SpawnSkill = new MobSpawnSkill()
                    {
                        basicSkillInfos = basicSkill,
                        Rarity = packet.ReadByte(),
                        MobToSpawnCodeName = packet.ReadAscii(),
                        MaxSpawnCount = packet.ReadInt(),
                        MinSpawnCount = packet.ReadInt(),
                    };
                    SqlParamList.Add(new SqlParameter("@Value1", SqlDbType.VarChar) { Value = SpawnSkill.MobToSpawnCodeName });
                    SqlParamList.Add(new SqlParameter("@Value2", SqlDbType.VarChar) { Value = SpawnSkill.Rarity.ToString() });
                    SqlParamList.Add(new SqlParameter("@Value3", SqlDbType.VarChar) { Value = SpawnSkill.MinSpawnCount.ToString() });
                    SqlParamList.Add(new SqlParameter("@Value4", SqlDbType.VarChar) { Value = SpawnSkill.MaxSpawnCount.ToString() });

                

                    break;
                case "Attack":
                    /*
                     
                     else if(@SkillTypeFlag='Attack')
	SELECT	@ParamValue1 = 6386804, --Say it is Attack Skill
				@ParamValue2 = Convert(int,@Value1),  --Physical or Magical    5 0r 10
				@ParamValue3 = Convert(int,@Value2),  --Reinforce Min
				@ParamValue4 = Convert(int,@Value3),	 -- Min Power
				@ParamValue5 = Convert(int,@Value4),	 -- Max Power
				@ParamValue6 = Convert(int,@Value5),	 -- Reinforce Max
				@ParamValue7 = 28003,	 -- MultiShot Value
				@ParamValue8 = 2,	 -- Assign as Monster Skill
				@ParamValue9 = Convert(int,@Value6)-- Number of Hits
                     */
                    MobAttackSkill ASkill = new MobAttackSkill()
                    {
                        basicSkillInfos = basicSkill,
                        SkillType = packet.ReadInt(),
                        NumberOfHits = packet.ReadInt(),
                        ReinforceMin = packet.ReadInt(),
                        ReinforceMax = packet.ReadInt(),
                        PowerMin = packet.ReadInt(),
                        PowerMax = packet.ReadInt(),
                    };
                    SqlParamList.Add(new SqlParameter("@Value1", SqlDbType.VarChar, 128) { Value = ASkill.SkillType });
                    SqlParamList.Add(new SqlParameter("@Value2", SqlDbType.VarChar, 128) { Value = ASkill.ReinforceMin.ToString() });
                    SqlParamList.Add(new SqlParameter("@Value3", SqlDbType.VarChar, 128) { Value = ASkill.PowerMin.ToString() });
                    SqlParamList.Add(new SqlParameter("@Value4", SqlDbType.VarChar, 128) { Value = ASkill.PowerMax.ToString() });
                    SqlParamList.Add(new SqlParameter("@Value5", SqlDbType.VarChar, 128) { Value = ASkill.ReinforceMax.ToString() });
                    SqlParamList.Add(new SqlParameter("@Value6", SqlDbType.VarChar, 128) { Value = ASkill.NumberOfHits.ToString() });
                   
                    break;
                case "Buff":
                    break;
                case "Debuff":
                    break;
                default:
                    break;
            }

            DataRow resuult = SQL.ReturnDataTableByProcedure("_ADD_NEW_SKILL_MONSTER", StudioServer.settings.DBDev, SqlParamList.ToArray()).Rows[0];
            var booler = bool.Parse(resuult[0].ToString()); 
            var returnString = resuult[0].ToString();

            if (booler)
            {
                ServerMembory.SendUpdateSuccessNoticeToAll(returnString, AccName);
                ServerMembory.RefreshTableForAll("_RefSkill");
                ServerMembory.RefreshTableForAll("_RefObjChar");
            }
            else
            {
                StudioServer.StaticCertificationGrid.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.warning,$"{AccName} : {returnString}");
                packet = new Packet(0xA009);
                packet.WriteAscii(returnString);
                return packet;
            }
            return null;
        }
    }
}
