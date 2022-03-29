namespace StudioServer.Handler.PacketHandler.Trigger.ActionInterfaces
{
    public class ITRIGGER_ACTION_MONSTER_ACTIVE_NEST
    {
        #region Public Properties

        public string CommonTriggerCondition { get; set; }
        public int Delay { get; set; }
        public int NestID { get; set; }
        public string TriggerName { get; set; }

        #endregion Public Properties
    }
}