namespace Structs.Database
{
    public struct RefSkillGroup
    {
        public int ID;
        public string Code;

        public RefSkillGroup(object[] row)
        {
            ID = int.Parse(row[0].ToString());
            Code = row[1].ToString();
        }
    }
}
