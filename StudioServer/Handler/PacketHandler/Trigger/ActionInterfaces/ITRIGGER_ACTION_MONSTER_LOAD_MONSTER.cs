namespace StudioServer.Handler.PacketHandler.Trigger.ActionInterfaces
{
    public class ITRIGGER_ACTION_MONSTER_LOAD_MONSTER
    {
        public string TriggerName { get; set; }
        public string CommonTriggerCondition { get; set; }
        public int Delay { get; set; }
        public int MobRarity { get; set; }
        public string MobName { get; set; }
        public string TargetPlayer { get; set; }
        public string SpawnRate { get; set; }
        public int SpawnCount { get; set; }
    }
}
