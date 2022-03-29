namespace StudioServer.Handler.PacketHandler.Spawns.SpawnInterfaces
{
    public class ITabRefTacticsAdder
    {
        public string MobName;
        public byte Aggro;
        public string Desc;

        public ITabRefTacticsAdder(string name, bool aggro, string desc)
        {
            MobName = name;
            Aggro = aggro ? (byte)2 : (byte)1;
            Desc = desc;
        }
    }
}
