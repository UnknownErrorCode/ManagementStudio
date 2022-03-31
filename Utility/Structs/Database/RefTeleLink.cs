namespace Structs.Database
{
    public struct RefTeleLink
    {
        public int Service;
        public int OwnerTeleport;
        public int TargetTeleport;
        public int Fee;
        public byte RestrictBindMethod;
        public byte RunTimeTeleportMethod;
        public byte CheckResult;
        public int Restrict1;
        public int Data1_1;
        public int Data1_2;
        public int Restrict2;
        public int Data2_1;
        public int Data2_2;
        public int Restrict3;
        public int Data3_1;
        public int Data3_2;
        public int Restrict4;
        public int Data4_1;
        public int Data4_2;
        public int Restrict5;
        public int Data5_1;
        public int Data5_2;

        public RefTeleLink(object[] row)
        {
            Service = int.Parse(row[0].ToString());
            OwnerTeleport = int.Parse(row[1].ToString());
            TargetTeleport = int.Parse(row[2].ToString());
            Fee = int.Parse(row[3].ToString());
            RestrictBindMethod = byte.Parse(row[4].ToString());
            RunTimeTeleportMethod = byte.Parse(row[5].ToString());
            CheckResult = byte.Parse(row[6].ToString());
            Restrict1 = int.Parse(row[7].ToString());
            Data1_1 = int.Parse(row[8].ToString());
            Data1_2 = int.Parse(row[9].ToString());
            Restrict2 = int.Parse(row[10].ToString());
            Data2_1 = int.Parse(row[11].ToString());
            Data2_2 = int.Parse(row[12].ToString());
            Restrict3 = int.Parse(row[13].ToString());
            Data3_1 = int.Parse(row[14].ToString());
            Data3_2 = int.Parse(row[15].ToString());
            Restrict4 = int.Parse(row[16].ToString());
            Data4_1 = int.Parse(row[17].ToString());
            Data4_2 = int.Parse(row[18].ToString());
            Restrict5 = int.Parse(row[19].ToString());
            Data5_1 = int.Parse(row[20].ToString());
            Data5_2 = int.Parse(row[21].ToString());
        }
    }
}
