namespace Structs.Database
{
    public struct RefTrigger
    {
        public int Service { get; set; }
        public int ID { get; set; }
        public string CodeName128 { get; set; }
        public byte IsActive { get; set; }
        public byte IsRepeat { get; set; }
        public string Comment512 { get; set; }
        public int IndexNumber { get; set; }

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