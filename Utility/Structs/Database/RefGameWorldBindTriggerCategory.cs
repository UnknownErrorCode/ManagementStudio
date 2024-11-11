namespace Structs.Database
{
    public struct RefGameWorldBindTriggerCategory
    {
        private int service;
        private int iD;
        private int gameWorldID;
        private int triggerCategoryID;

        public RefGameWorldBindTriggerCategory(object[] row)
        {
            service = int.Parse(row[0].ToString());
            iD = int.Parse(row[1].ToString());
            gameWorldID = int.Parse(row[2].ToString());
            triggerCategoryID = int.Parse(row[3].ToString());
        }


        public int Service { get => service; set => service = value; }
        public int ID { get => iD; set => iD = value; }
        public int GameWorldID { get => gameWorldID; set => gameWorldID = value; }
        public int TriggerCategoryID { get => triggerCategoryID; set => triggerCategoryID = value; }
    }
}