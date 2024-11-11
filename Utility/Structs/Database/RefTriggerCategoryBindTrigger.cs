namespace Structs.Database
{
    public struct RefTriggerCategoryBindTrigger
    {
        private int service;
        private int iD;
        private int triggerCategoryID;
        private int triggerID;

        public RefTriggerCategoryBindTrigger(object[] row)
        {
            service = int.Parse(row[0].ToString());
            iD = int.Parse(row[1].ToString());
            triggerCategoryID = int.Parse(row[2].ToString());
            triggerID = int.Parse(row[3].ToString());
        }

        public int Service { get => service; set => service = value; }
        public int ID { get => iD; set => iD = value; }
        public int TriggerCategoryID { get => triggerCategoryID; set => triggerCategoryID = value; }
        public int TriggerID { get => triggerID; set => triggerID = value; }
    }
}