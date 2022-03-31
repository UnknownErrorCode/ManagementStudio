namespace Structs.Database
{
    public struct RefSkillMastery
    {
        public int ID;
        public string Code;
        public byte Weapon;

        public RefSkillMastery(object[] row)
        {
            ID = int.Parse(row[0].ToString());
            Code = row[1].ToString();
            Weapon = byte.Parse(row[2].ToString());
        }
    }
}
