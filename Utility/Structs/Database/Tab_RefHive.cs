using System;
using System.Runtime.InteropServices;

namespace Structs.Database
{
    /// <summary>
    /// This is the Hive of vSro.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Size = 154)]
    public struct Tab_RefHive
    {
        /// <summary>
        /// This is the Identifier of the hive.
        /// </summary>
        private readonly int DwHiveID;

        //[FieldOffset(4)]
        private byte btKeepMonsterCountType;

        //[FieldOffset(5)]
        private int dwOverwriteMaxTotalCount;

        //[FieldOffset(9)]
        private float fMonsterCountPerPC;

        //[FieldOffset(13)]
        private int dwSpawnSpeedIncreaseRate;

        //[FieldOffset(17)]
        private int dwMaxIncreaseRate;

        //[FieldOffset(21)]
        private byte btFlag;

        //[FieldOffset(22)]
        private short gameWorldID;

        //[FieldOffset(24)]
        private short hatchObjType;

        //[FieldOffset(26)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string szDescString128;

        public Tab_RefHive(object[] row)
        {
            DwHiveID = int.Parse(row[0].ToString());
            btKeepMonsterCountType = byte.Parse(row[1].ToString());
            dwOverwriteMaxTotalCount = int.Parse(row[2].ToString());
            fMonsterCountPerPC = float.Parse(row[3].ToString());
            dwSpawnSpeedIncreaseRate = int.Parse(row[4].ToString());
            dwMaxIncreaseRate = int.Parse(row[5].ToString());
            btFlag = byte.Parse(row[6].ToString());
            gameWorldID = Int16.Parse(row[7].ToString());
            hatchObjType = Int16.Parse(row[8].ToString());
            szDescString128 = row[9].ToString();
        }

        public int dwHiveID => DwHiveID;

        public byte BtKeepMonsterCountType { get => btKeepMonsterCountType; set => btKeepMonsterCountType = value; }
        public int DwOverwriteMaxTotalCount { get => dwOverwriteMaxTotalCount; set => dwOverwriteMaxTotalCount = value; }
        public float FMonsterCountPerPC { get => fMonsterCountPerPC; set => fMonsterCountPerPC = value; }
        public int DwSpawnSpeedIncreaseRate { get => dwSpawnSpeedIncreaseRate; set => dwSpawnSpeedIncreaseRate = value; }
        public int DwMaxIncreaseRate { get => dwMaxIncreaseRate; set => dwMaxIncreaseRate = value; }
        public byte BtFlag { get => btFlag; set => btFlag = value; }
        public short GameWorldID { get => gameWorldID; set => gameWorldID = value; }
        public short HatchObjType { get => hatchObjType; set => hatchObjType = value; }
        public string SzDescString128 { get => szDescString128; set => szDescString128 = value; }
    }
}