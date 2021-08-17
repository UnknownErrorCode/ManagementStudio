using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioServer.Handler.PacketHandler.Trigger.ActionInterfaces
{
   public class ITRIGGER_ACTION_MONSTER_ACTIVE_NEST
    {
        public string TriggerName { get; set; }
        public string CommonTriggerCondition { get; set; }
        public int Delay { get; set; }
        public int NestID { get; set; }
    }
}
