namespace Structs.Database
{
    public struct RefGameWorldBindTriggerCategory
    {
        public int Service ;
        public int ID ;
        public int GameWorldID ;
        public int TriggerCategoryID ;

        public RefGameWorldBindTriggerCategory(object[] row)
        {
            Service = int.Parse(row[0].ToString());
            ID = int.Parse(row[1].ToString());
            GameWorldID = int.Parse(row[2].ToString());
            TriggerCategoryID = int.Parse(row[3].ToString());
        }
    }
}