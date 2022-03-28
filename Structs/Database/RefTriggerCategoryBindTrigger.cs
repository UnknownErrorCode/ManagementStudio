namespace Structs.Database
{
    public struct RefTriggerCategoryBindTrigger
    {
        public int Service;
        public int ID;
        public int TriggerCategoryID;
        public int TriggerID;

        public RefTriggerCategoryBindTrigger(object[] row)
        {
            Service = int.Parse(row[0].ToString());
            ID = int.Parse(row[1].ToString());
            TriggerCategoryID = int.Parse(row[2].ToString());
            TriggerID = int.Parse(row[3].ToString());
        }
    }
}