namespace Structs.Database
{
    public struct RefTriggerCategory
    {
        public int Service;
        public int ID;
        public string CodeName128;
        public string ObjName128;
        public int IndexNumber;

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