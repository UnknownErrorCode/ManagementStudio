namespace Structs.Database
{
    public struct RefGameWorldBindTriggerCategory
    {
        public int Service { get; set; }
        public int ID { get; set; }
        public int GameWorldID { get; set; }
        public int TriggerCategoryID { get; set; }

        public RefGameWorldBindTriggerCategory(object[] row)
        {
            Service = int.Parse(row[0].ToString());
            ID = int.Parse(row[1].ToString());
            GameWorldID = int.Parse(row[2].ToString());
            TriggerCategoryID = int.Parse(row[3].ToString());
        }
    }
}