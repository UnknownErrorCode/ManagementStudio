namespace Structs.Database
{
    public struct RefRegionBindAssocServer
    {
        public string AreaName;
        public int AssocServer;

        public RefRegionBindAssocServer(object[] row)
        {
            AreaName = row[0].ToString();
            AssocServer = int.Parse(row[1].ToString());
        }
    }
}
