namespace StudioServer.Handler.PacketHandler.Trigger.ActionInterfaces
{
    public class ITRIGGER_ACTION_SWITCH_EVENTZONE
    {

        public string TriggerName;
        public string CommonTriggerCondition;
        public int Delay;

        public string Eventzone;
        public string ONOFF;
        public ITRIGGER_ACTION_SWITCH_EVENTZONE(string _Eventzone, bool _ONOFF)
        {
            Eventzone = _Eventzone;
            switch (_ONOFF)
            {
                case true:
                    ONOFF = "ON";
                    break;
                case false:
                    ONOFF = "OFF";
                    break;
                default:
                    ONOFF = "OFF";
                    break;
            }
        }
    }
}
