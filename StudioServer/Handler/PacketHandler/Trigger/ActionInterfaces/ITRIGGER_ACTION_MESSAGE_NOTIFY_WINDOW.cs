namespace StudioServer.Handler.PacketHandler.Trigger.ActionInterfaces
{
    public class ITRIGGER_ACTION_MESSAGE_NOTIFY_WINDOW
    {
        #region Public Fields

        public string CommonTriggerCondition;
        public int Delay;
        public string STRING_INPUT;
        public string TARGET_PLAYER_INS_SELECT;
        public string TriggerName;

        #endregion Public Fields

        #region Public Constructors

        public ITRIGGER_ACTION_MESSAGE_NOTIFY_WINDOW(string UIITString, bool TargetAllPlayer)
        {
            STRING_INPUT = UIITString;
            switch (TargetAllPlayer)
            {
                case true:
                    TARGET_PLAYER_INS_SELECT = "TARGET_PLAYER_ALL";
                    break;

                case false:
                    TARGET_PLAYER_INS_SELECT = "TARGET_PLAYER_EVENT_USER";
                    break;

                default:
                    break;
            }
        }

        #endregion Public Constructors
    }
}