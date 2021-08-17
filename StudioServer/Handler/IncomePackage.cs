using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Handler
{
    public static class IncomePackage
    {


        /*
         Currently after 2001 and 2005, we send 
             
             */
        public static Packet HandlePackage(Packet opcode, ServerData context_data)
        {
            switch (opcode.Opcode)
            {
                case 0x2001:
                    opcode = packet0x2001(opcode);
                    break;
                case 0x2005:
                    opcode = packet0x2005(opcode);
                    break;
                case 0x2006:
                    opcode = PacketHandler.REQUEST_DATATABLE.Request(opcode);
                    break;
                case 0x2008:
                    opcode = PacketHandler.REQUEST_SINGLE_DATATABLE.Request(opcode);
                    break;
                case 0xB001:
                    opcode = p0xA000(opcode);
                    break;
                case 0xDE00:
                    opcode = PacketHandler.Dashboard.DELETE_TOPIC.DELETE(opcode);
                    break;
                case 0xD000:
                    opcode = PacketHandler.Login.REQUEST_CURRENT_VERSION.VersionSame(opcode, context_data.m_security); //0xD011
                    break;
                case 0xD003:
                    opcode = PacketHandler.Login.REQUEST_ALL_GUIDES.GetFromDirectory(context_data.m_security); //0xD003
                    break;
                case 0xD111:
                    opcode = PacketHandler.Login.REQ_LATEST_FILES.AllFiles(opcode, context_data.m_security); //0xD101 --End 0xD110
                    break;
                case 0xDD2D:
                    opcode = PacketHandler.Dashboard.REC_NEW_TOPICGUIDE.WriteNewTopic(opcode); //0xD101 --End 0xD110
                    break;
                case 0xA100:
                    opcode = PacketHandler.Login.REQUEST_LOGIN.LoginPackage(opcode, context_data);
                    break;
                case 0xA102:
                    opcode = PacketHandler.Login.REQUEST_ONLINE_ACCOUNTS.NAMES(opcode);
                    break;
                case 0x1010:
                    opcode = PacketHandler.Chat.ManageChat.IncomeAllChat(opcode, context_data);
                    break;
                case 0x1011:
                    opcode = PacketHandler.Chat.ManageChat.IncomePrivateChat(opcode, context_data);
                    break;
                case 0x1717:
                    opcode = PacketHandler.Chat.ManageChat.RequestAll_AllChatLog(ChatServer.AllChatLogTXT);
                    break;
                case 0x1818:
                    opcode = PacketHandler.Chat.ManageChat.RequestAllPrivateChatLog(opcode, context_data);
                    break;
                case 0X1099:
                    opcode = PacketHandler.DataStorage.AllStoredData.SendAllStoredDataStrings();
                    break;
                case 0X1098:
                    opcode = PacketHandler.DataStorage.AllStoredData.SendSingleData(opcode);
                    break;
                case 0x7001:
                    opcode = PacketHandler.Trigger.REQUEST_ADD_CATEGORY_TO_GAMEWORLD.TriggerCategoryToGameWorld(opcode, context_data.AccountName);
                    break;
                case 0x7002:
                    opcode = PacketHandler.Trigger.REQ_ADD_ACTION_TO_TRIGGER.TriggerActionToTrigger(opcode, context_data.AccountName);
                    break;
                case 0x7003:
                    opcode = PacketHandler.Trigger.REQ_ADD_TRIGGER_TO_CATEGORY.TriggerToCategory(opcode, context_data.AccountName);
                    break;
                case 0x7004:
                    opcode = PacketHandler.Trigger.REQ_ADD_CONDITION_TO_TRIGGER.AddConditionToTrigger(opcode, context_data.AccountName);
                    break;
                case 0x7005:
                    opcode = PacketHandler.Trigger.REQ_ADD_EVENT_TO_TRIGGER.EventToTrigger(opcode, context_data.AccountName);
                    break;
                case 0x7010:
                    opcode = PacketHandler.Spawns.REQ_ADD_NEW_TACTICS.NEW_TACTICS(opcode, context_data.AccountName);
                    break;
                case 0x7011:
                    opcode = PacketHandler.Spawns.REQ_ADD_NEW_HIVE.AddNewHive(opcode, context_data.AccountName);
                    break;
                case 0x7012:
                    opcode = PacketHandler.Spawns.REQ_ADD_NEW_NEST.AddNewNest(opcode, context_data.AccountName);
                    break;
                case 0x7013:
                    opcode = PacketHandler.Spawns.REQ_UPDATE_NEST.UpdateNest(opcode, context_data.AccountName);
                    break;
                case 0x7014:
                    opcode = PacketHandler.Monster.REQUEST_UPDATE_MONSTER_STATS.UpdateMonsterStat(opcode, context_data.AccountName);
                    break;
                case 0x7020:
                    opcode = PacketHandler.Skills.REQ_ADD_NEW_SKILL_MOB.NewMobSkill(opcode, context_data.AccountName);
                    break;
                case 0x7021:
                    opcode = PacketHandler.Skills.REQ_UPDATE_SKILL.UPDATE_SKILL(opcode, context_data.AccountName);
                    break;
                case 0x7030:
                    opcode = PacketHandler.Drops.REQ_ADD_NEW_MONSTERDROP.AddNewMonsterAssignedDrop(opcode, context_data.AccountName);
                    break;
                case 0x7050:
                    opcode = PacketHandler.Teleporter.REQ_UPDATE_TELEPORT.UpdateTeleport(opcode, context_data.AccountName);
                    break;
                case 0x7051:
                    opcode = PacketHandler.Teleporter.REQ_UPDATE_TELELINK.UpdateTeleLink(opcode, context_data.AccountName);
                    break;
                case 0x7500:
                    opcode = PacketHandler.REQ_UPDATE_TABLE.UpdateTable(opcode, context_data.AccountName);
                    break;
                case 0x7550:
                    opcode = PacketHandler.Shops.REQ_UPDATE_PAYMENTDEVICE.UpdateDevice(opcode, context_data.AccountName);
                    break;
                case 0x7551:
                    opcode = PacketHandler.Shops.REQ_ADD_GOOD_TO_TAB.Add(opcode, context_data.AccountName);
                    break;

                default:
                    opcode = null;
                    break;
            }
            return opcode;
        }

        public static Packet packet0x2001(Packet packet)
        {
            String name = packet.ReadAscii();
            byte flag = packet.ReadByte();
            Packet response = new Packet(0x2001);
            if (flag == 1)
            {
                if (name == "Tool_Client")
                {
                    response.WriteAscii("Tool_Server");
                    response.WriteByte(1);
                }
                else if (name == "Tool_Launcher")
                {
                    response = OutgoingPackets.CurrentVersion();
                }
            }
            return response;
        }
        public static Packet packet0x2005(Packet packet)
        {
            var test = packet.ReadAscii();
            return OutgoingPackets.SuccessOfCertification(test);
        }
       
      
        public static Packet p0xA000(Packet packet)
        {
            String name = packet.ReadAscii();
            String ip = packet.ReadAscii();

            // todo: verify data against certification info //

            Packet response = new Packet(0xA000);
            response.WriteByte(1);
            response.WriteAscii("CertOK");
            return response;

        }
    }
}


