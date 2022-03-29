using System;
namespace Structs.Database
{
    public struct RefTeleport
    {
        public int Service;
        public int ID;
        public string CodeName128;
        public string AssocRefObjCodeName128;
        public int AssocRefObjID;
        public string ZoneName128;
        public Int16 GenRegionID;
        public Int16 GenPos_X;
        public Int16 GenPos_Y;
        public Int16 GenPos_Z;
        public Int16 GenAreaRadius;
        public byte CanBeResurrectPos;
        public byte CanGotoResurrectPos;
        public Int16 GenWorldID;
        public byte BindInteractionMask;
        public byte FixedService;

        public RefTeleport(object[] row)
        {
            Service = int.Parse(row[0].ToString());
            ID = int.Parse(row[1].ToString());
            CodeName128 = row[2].ToString();
            AssocRefObjCodeName128 = row[3].ToString();
            AssocRefObjID = int.Parse(row[4].ToString());
            ZoneName128 = row[5].ToString();
            GenRegionID = Int16.Parse(row[6].ToString());
            GenPos_X = Int16.Parse(row[7].ToString());
            GenPos_Y = Int16.Parse(row[8].ToString());
            GenPos_Z = Int16.Parse(row[9].ToString());
            GenAreaRadius = Int16.Parse(row[10].ToString());
            CanBeResurrectPos = byte.Parse(row[11].ToString());
            CanGotoResurrectPos = byte.Parse(row[12].ToString());
            GenWorldID = Int16.Parse(row[13].ToString());
            BindInteractionMask = byte.Parse(row[14].ToString());
            FixedService = byte.Parse(row[15].ToString());
        }
    }
}
