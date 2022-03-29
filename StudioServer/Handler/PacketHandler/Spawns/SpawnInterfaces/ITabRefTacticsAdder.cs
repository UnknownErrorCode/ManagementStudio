namespace StudioServer.Handler.PacketHandler.Spawns.SpawnInterfaces
{
    public class ITabRefTacticsAdder
    {
        #region Public Fields

        public byte Aggro;
        public string Desc;
        public string MobName;

        #endregion Public Fields

        #region Public Constructors

        public ITabRefTacticsAdder(string name, bool aggro, string desc)
        {
            MobName = name;
            Aggro = aggro ? (byte)2 : (byte)1;
            Desc = desc;
        }

        #endregion Public Constructors
    }
}