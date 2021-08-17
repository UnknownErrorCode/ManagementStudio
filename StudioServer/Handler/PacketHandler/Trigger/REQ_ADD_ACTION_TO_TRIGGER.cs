using ServerFrameworkRes.Network.Security;
using StudioServer.Handler.PacketHandler.Trigger.ActionInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Handler.PacketHandler.Trigger
{
    public class REQ_ADD_ACTION_TO_TRIGGER
    {
        internal static Packet TriggerActionToTrigger(Packet opcode, string UserName) //0x7002
        {
            SqlParameter[] AddActionParams = null;
            var Question = "";

            var ActionType = opcode.ReadAscii();


            switch (ActionType)
            {
                /*
                ALTER PROCEDURE [dbo].[_ADD_TRIGGERACTION]
	            @TriggerName VARCHAR(128),
	            @CommonCondition varchar(128),
	            @Delay int,
	            @Value1 varchar(128) ='non',
	            @Value2 varchar(128)='non',
	            @Value3 varchar(128)='non',
	            @Value4 varchar(128)='non',
	            @Value5 varchar(128)='non',
	            @Value6 varchar(128)='non',
	            @Value7 varchar(128)='non',
	            @Value8 varchar(128)='non'
                     */
                case "TRIGGER_ACTION_MONSTER_LOAD_MONSTER":
                    var LMTriggerName = opcode.ReadAscii();
                    var LMCommonTriggerCondition = opcode.ReadAscii();
                    var LMDelay = opcode.ReadInt();
                    var LMMobRarity = opcode.ReadInt();
                    var LMMobName = opcode.ReadAscii();
                    var LMTargetPlayer = opcode.ReadAscii();
                    var LMSpawnRate = opcode.ReadAscii();
                    var LMSpawnCount = opcode.ReadInt();


                    var ITAMonster = new ITRIGGER_ACTION_MONSTER_LOAD_MONSTER()
                    {
                        TriggerName = LMTriggerName,
                        CommonTriggerCondition = LMCommonTriggerCondition,
                        Delay = LMDelay,
                        MobRarity = LMMobRarity,
                        MobName = LMMobName,
                        TargetPlayer = LMTargetPlayer,
                        SpawnRate = LMSpawnRate,
                        SpawnCount = LMSpawnCount
                    };

                    AddActionParams = new SqlParameter[8]
                    {
                            new SqlParameter("@TriggerName",SqlDbType.VarChar,128){Value = ITAMonster.TriggerName},
                            new SqlParameter("@CommonCondition",SqlDbType.VarChar,128){ Value=ITAMonster.CommonTriggerCondition},
                            new SqlParameter("@Delay",SqlDbType.Int){Value= ITAMonster.Delay },
                            new SqlParameter("@Value1",SqlDbType.VarChar,128){ Value = ITAMonster.MobRarity},
                            new SqlParameter("@Value2",SqlDbType.VarChar,128){Value = ITAMonster.MobName },
                            new SqlParameter("@Value3",SqlDbType.VarChar,128){Value =ITAMonster.TargetPlayer},
                            new SqlParameter("@Value4",SqlDbType.VarChar,128){Value = ITAMonster.SpawnRate},
                            new SqlParameter("@Value5",SqlDbType.VarChar,128){ Value = ITAMonster.SpawnCount}
                    };

                    break;


                case "TRIGGER_ACTION_MONSTER_ACTIVE_NEST":

                    var ANTriggerName = opcode.ReadAscii();
                    var ANCommonTriggerCondition = opcode.ReadAscii();
                    var ANDelay = opcode.ReadInt();
                    var ANNestID = opcode.ReadInt();

                    var man = new ITRIGGER_ACTION_MONSTER_ACTIVE_NEST()
                    {
                        TriggerName = ANTriggerName,
                        CommonTriggerCondition = ANCommonTriggerCondition,
                        Delay = ANDelay,
                        NestID = ANNestID
                    };

                    AddActionParams = new SqlParameter[4]
                       {
                            new SqlParameter("@TriggerName",SqlDbType.VarChar,128) {Value = man.TriggerName },
                            new SqlParameter("@CommonCondition",SqlDbType.VarChar,128){Value=man.CommonTriggerCondition },
                            new SqlParameter("@Delay",SqlDbType.Int){Value = man.Delay },
                            new SqlParameter("@Value1",SqlDbType.VarChar,128){ Value = man.NestID.ToString() }
                       };
                   


                    break;
                case "TRIGGER_ACTION_CREATEOBJECT_TELEPORT":

                    break;
                case "TRIGGER_ACTION_SWITCH_EVENTZONE":
                    var SETriggerName = opcode.ReadAscii();
                    var SECommonTriggerCondition=opcode.ReadAscii(); 
                    var SEDelay=opcode.ReadInt();

                    var SEEventzone=opcode.ReadAscii();
                    var SEONOFF =opcode.ReadBool();

                    ITRIGGER_ACTION_SWITCH_EVENTZONE unsereEventZone = new ITRIGGER_ACTION_SWITCH_EVENTZONE(SEEventzone, SEONOFF)
                    {
                        TriggerName = SETriggerName,
                        CommonTriggerCondition = SECommonTriggerCondition,
                        Delay = SEDelay
                    };
                    AddActionParams = new SqlParameter[5]
                      {
                            new SqlParameter("@TriggerName",SqlDbType.VarChar,128) {Value = unsereEventZone.TriggerName },
                            new SqlParameter("@CommonCondition",SqlDbType.VarChar,128){Value=unsereEventZone.CommonTriggerCondition },
                            new SqlParameter("@Delay",SqlDbType.Int){Value = unsereEventZone.Delay },
                            new SqlParameter("@Value1",SqlDbType.VarChar,128){ Value = unsereEventZone.Eventzone},
                            new SqlParameter("@Value2",SqlDbType.VarChar,128){ Value = unsereEventZone.ONOFF},
                      };

                    break;


                case "TRIGGER_ACTION_MESSAGE_NOTIFY_WINDOW":

                   var NWTriggerName= opcode.ReadAscii();
                   var NWCommonTriggerCondition = opcode.ReadAscii();
                   var NWDelay = opcode.ReadInt();
                   var NWSTRING_INPUT = opcode.ReadAscii();
                   var NWTARGET_PLAYER_INS_SELECT = opcode.ReadBool();
                   

                    ITRIGGER_ACTION_MESSAGE_NOTIFY_WINDOW OwnNotifyMsg = new ITRIGGER_ACTION_MESSAGE_NOTIFY_WINDOW(NWSTRING_INPUT, NWTARGET_PLAYER_INS_SELECT)
                    {
                        TriggerName = NWTriggerName,
                        CommonTriggerCondition = NWCommonTriggerCondition,
                        Delay = NWDelay
                    };
                    AddActionParams = new SqlParameter[5]
                     {
                            new SqlParameter("@TriggerName",SqlDbType.VarChar,128) {Value = OwnNotifyMsg.TriggerName },
                            new SqlParameter("@CommonCondition",SqlDbType.VarChar,128){Value=OwnNotifyMsg.CommonTriggerCondition },
                            new SqlParameter("@Delay",SqlDbType.Int){Value = OwnNotifyMsg.Delay },
                            new SqlParameter("@Value1",SqlDbType.VarChar,128){ Value = OwnNotifyMsg.STRING_INPUT},
                            new SqlParameter("@Value2",SqlDbType.VarChar,128){ Value = OwnNotifyMsg.TARGET_PLAYER_INS_SELECT},
                     };

                    break;


                case "TRIGGER_ACTION_MESSAGE_SYSTEM_WINDOW":


                    var SWTriggerName = opcode.ReadAscii();
                    var SWCommonTriggerCondition = opcode.ReadAscii();
                    var SWDelay = opcode.ReadInt();
                    var SWSTRING_INPUT = opcode.ReadAscii();
                    var SWTARGET_PLAYER_INS_SELECT = opcode.ReadBool();

                    ITRIGGER_ACTION_MESSAGE_SYSTEM_WINDOW OwnNotifySysMsg = new ITRIGGER_ACTION_MESSAGE_SYSTEM_WINDOW(SWSTRING_INPUT, SWTARGET_PLAYER_INS_SELECT)
                    {
                        TriggerName = SWTriggerName,
                        CommonTriggerCondition = SWCommonTriggerCondition,
                        Delay = SWDelay
                    };
                    AddActionParams = new SqlParameter[5]
                     {
                            new SqlParameter("@TriggerName",SqlDbType.VarChar,128) {Value = OwnNotifySysMsg.TriggerName },
                            new SqlParameter("@CommonCondition",SqlDbType.VarChar,128){Value=OwnNotifySysMsg.CommonTriggerCondition },
                            new SqlParameter("@Delay",SqlDbType.Int){Value = OwnNotifySysMsg.Delay },
                            new SqlParameter("@Value1",SqlDbType.VarChar,128){ Value = OwnNotifySysMsg.STRING_INPUT},
                            new SqlParameter("@Value2",SqlDbType.VarChar,128){ Value = OwnNotifySysMsg.TARGET_PLAYER_INS_SELECT},
                     };

                    break;
                default:
                    opcode = null;
                    break;
            }

            DataRow ResultActionToTrigger = SQL.ReturnDataTableByProcedure("_ADD_TRIGGERACTION", StudioServer.settings.DBDev, AddActionParams).Rows[0];
            bool ok = bool.Parse(ResultActionToTrigger[0].ToString());
            var resultText = ResultActionToTrigger[1].ToString();
            if (ok)
            {
                StudioServer.StaticCertificationGrid.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.notify, resultText);
                ServerMembory.SendUpdateSuccessNoticeToAll(resultText, UserName);
                ServerMembory.RefreshTableForAll("_RefTriggerActionParam");
                ServerMembory.RefreshTableForAll("_RefTriggerAction");
                ServerMembory.RefreshTableForAll("_RefTriggerBindAction");
            }
            else
            {
                StudioServer.StaticCertificationGrid.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.warning, resultText);
                opcode = new Packet(0xA009);
                opcode.WriteAscii(resultText);
                return opcode;
            }
            return null;


        }
    }
}
