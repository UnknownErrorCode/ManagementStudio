namespace Structs.Database
{
    public struct RefTriggerCategory
    {
        public int Service { get; set; }
        public int ID { get; set; }
        public string CodeName128 { get; set; }
        public string ObjName128 { get; set; }
        public int IndexNumber { get; set; }

        public RefTriggerCategory(object[] row)
        {
            Service = int.Parse(row[0].ToString());
            ID = int.Parse(row[1].ToString());
            CodeName128 = row[2].ToString();
            ObjName128 = row[3].ToString();
            IndexNumber = int.Parse(row[4].ToString());
        }
    }
}