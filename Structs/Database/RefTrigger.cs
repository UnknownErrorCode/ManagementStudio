namespace Structs.Database
{
    public struct RefTrigger
    {
        public int Service ;
        public int ID ;
        public string CodeName128 ;
        public byte IsActive ;
        public byte IsRepeat ;
        public string Comment512 ;
        public int IndexNumber ;

        public RefTrigger(object[] row)
        {
            Service = int.Parse(row[0].ToString());
            ID = int.Parse(row[1].ToString());
            CodeName128 = row[2].ToString();
            IsActive = byte.Parse(row[3].ToString());
            IsRepeat = byte.Parse(row[4].ToString());
            Comment512 = row[5].ToString();
            IndexNumber = int.Parse(row[6].ToString());
        }
    }
}