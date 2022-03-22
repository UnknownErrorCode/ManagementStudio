namespace Structs.Database
{
    public struct RefTriggerCategoryBindTrigger
    {
        public int Service { get; set; }
        public int ID { get; set; }
        public int TriggerCategoryID { get; set; }
        public int TriggerID { get; set; }

        public RefTriggerCategoryBindTrigger(object[] row)
        {
            Service = int.Parse(row[0].ToString());
            ID = int.Parse(row[1].ToString());
            TriggerCategoryID = int.Parse(row[2].ToString());
            TriggerID = int.Parse(row[3].ToString());
        }
    }
}