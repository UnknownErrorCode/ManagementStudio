using System.Runtime.InteropServices;

namespace Structs.Database
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Size = 268)]
    public struct Tab_RefTactics
    {
        private readonly int dwTacticsID;
        private int dwObjID;
        private byte btAIQoS;
        private int nMaxStamina;
        private byte btMaxStaminaVariance;
        private int nSightRange;
        private byte btAggressType;
        private int aggressData;
        private byte btChangeTarget;
        private byte btHelpRequestTo;
        private byte btHelpResponseTo;
        private byte btBattleStyle;
        private int battleStyleData;
        private byte btDiversionBasis;
        private int diversionBasisData1;
        private int diversionBasisData2;
        private int diversionBasisData3;
        private int diversionBasisData4;
        private int diversionBasisData5;
        private int diversionBasisData6;
        private int diversionBasisData7;
        private int diversionBasisData8;
        private byte btDiversionKeepBasis;
        private int diversionKeepBasisData1;
        private int diversionKeepBasisData2;
        private int diversionKeepBasisData3;
        private int diversionKeepBasisData4;
        private int diversionKeepBasisData5;
        private int diversionKeepBasisData6;
        private int diversionKeepBasisData7;
        private int diversionKeepBasisData8;
        private byte btKeepDistance;
        private int keepDistanceData;
        private byte btTraceType;
        private byte btTraceBoundary;
        private int traceData;
        private byte btHomingType;
        private int homingData;
        private byte btAggressTypeOnHoming;
        private byte btFleeType;
        private int dwChampionTacticsID;
        private int additionOptionFlag;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string szDescString128;

        private byte btAggroType;

        public Tab_RefTactics(object[] row)
        {
            dwTacticsID = int.Parse(row[0].ToString());
            dwObjID = int.Parse(row[1].ToString());
            btAIQoS = byte.Parse(row[2].ToString());
            nMaxStamina = int.Parse(row[3].ToString());
            btMaxStaminaVariance = byte.Parse(row[4].ToString());
            nSightRange = int.Parse(row[5].ToString());
            btAggressType = byte.Parse(row[6].ToString());
            aggressData = int.Parse(row[7].ToString());
            btChangeTarget = byte.Parse(row[8].ToString());
            btHelpRequestTo = byte.Parse(row[9].ToString());
            btHelpResponseTo = byte.Parse(row[10].ToString());
            btBattleStyle = byte.Parse(row[11].ToString());
            battleStyleData = int.Parse(row[12].ToString());
            btDiversionBasis = byte.Parse(row[13].ToString());
            diversionBasisData1 = int.Parse(row[14].ToString());
            diversionBasisData2 = int.Parse(row[15].ToString());
            diversionBasisData3 = int.Parse(row[16].ToString());
            diversionBasisData4 = int.Parse(row[17].ToString());
            diversionBasisData5 = int.Parse(row[18].ToString());
            diversionBasisData6 = int.Parse(row[19].ToString());
            diversionBasisData7 = int.Parse(row[20].ToString());
            diversionBasisData8 = int.Parse(row[21].ToString());
            btDiversionKeepBasis = byte.Parse(row[22].ToString());
            diversionKeepBasisData1 = int.Parse(row[23].ToString());
            diversionKeepBasisData2 = int.Parse(row[24].ToString());
            diversionKeepBasisData3 = int.Parse(row[25].ToString());
            diversionKeepBasisData4 = int.Parse(row[26].ToString());
            diversionKeepBasisData5 = int.Parse(row[27].ToString());
            diversionKeepBasisData6 = int.Parse(row[28].ToString());
            diversionKeepBasisData7 = int.Parse(row[29].ToString());
            diversionKeepBasisData8 = int.Parse(row[30].ToString());
            btKeepDistance = byte.Parse(row[31].ToString());
            keepDistanceData = int.Parse(row[32].ToString());
            btTraceType = byte.Parse(row[33].ToString());
            btTraceBoundary = byte.Parse(row[34].ToString());
            traceData = int.Parse(row[35].ToString());
            btHomingType = byte.Parse(row[36].ToString());
            homingData = int.Parse(row[37].ToString());
            btAggressTypeOnHoming = byte.Parse(row[38].ToString());
            btFleeType = byte.Parse(row[39].ToString());
            dwChampionTacticsID = int.Parse(row[40].ToString());
            additionOptionFlag = int.Parse(row[41].ToString());
            szDescString128 = row[42].ToString();
            btAggroType = row.Length > 42 ? byte.Parse(row[43].ToString()) : (byte)0;
        }

        public int DwTacticsID => dwTacticsID;

        public int DwObjID { get => dwObjID; set => dwObjID = value; }
        public byte BtAIQoS { get => btAIQoS; set => btAIQoS = value; }
        public int NMaxStamina { get => nMaxStamina; set => nMaxStamina = value; }
        public byte BtMaxStaminaVariance { get => btMaxStaminaVariance; set => btMaxStaminaVariance = value; }
        public int NSightRange { get => nSightRange; set => nSightRange = value; }
        public byte BtAggressType { get => btAggressType; set => btAggressType = value; }
        public int AggressData { get => aggressData; set => aggressData = value; }
        public byte BtChangeTarget { get => btChangeTarget; set => btChangeTarget = value; }
        public byte BtHelpRequestTo { get => btHelpRequestTo; set => btHelpRequestTo = value; }
        public byte BtHelpResponseTo { get => btHelpResponseTo; set => btHelpResponseTo = value; }
        public byte BtBattleStyle { get => btBattleStyle; set => btBattleStyle = value; }
        public int BattleStyleData { get => battleStyleData; set => battleStyleData = value; }
        public byte BtDiversionBasis { get => btDiversionBasis; set => btDiversionBasis = value; }
        public int DiversionBasisData1 { get => diversionBasisData1; set => diversionBasisData1 = value; }
        public int DiversionBasisData2 { get => diversionBasisData2; set => diversionBasisData2 = value; }
        public int DiversionBasisData3 { get => diversionBasisData3; set => diversionBasisData3 = value; }
        public int DiversionBasisData4 { get => diversionBasisData4; set => diversionBasisData4 = value; }
        public int DiversionBasisData5 { get => diversionBasisData5; set => diversionBasisData5 = value; }
        public int DiversionBasisData6 { get => diversionBasisData6; set => diversionBasisData6 = value; }
        public int DiversionBasisData7 { get => diversionBasisData7; set => diversionBasisData7 = value; }
        public int DiversionBasisData8 { get => diversionBasisData8; set => diversionBasisData8 = value; }
        public byte BtDiversionKeepBasis { get => btDiversionKeepBasis; set => btDiversionKeepBasis = value; }
        public int DiversionKeepBasisData1 { get => diversionKeepBasisData1; set => diversionKeepBasisData1 = value; }
        public int DiversionKeepBasisData2 { get => diversionKeepBasisData2; set => diversionKeepBasisData2 = value; }
        public int DiversionKeepBasisData3 { get => diversionKeepBasisData3; set => diversionKeepBasisData3 = value; }
        public int DiversionKeepBasisData4 { get => diversionKeepBasisData4; set => diversionKeepBasisData4 = value; }
        public int DiversionKeepBasisData5 { get => diversionKeepBasisData5; set => diversionKeepBasisData5 = value; }
        public int DiversionKeepBasisData6 { get => diversionKeepBasisData6; set => diversionKeepBasisData6 = value; }
        public int DiversionKeepBasisData7 { get => diversionKeepBasisData7; set => diversionKeepBasisData7 = value; }
        public int DiversionKeepBasisData8 { get => diversionKeepBasisData8; set => diversionKeepBasisData8 = value; }
        public byte BtKeepDistance { get => btKeepDistance; set => btKeepDistance = value; }
        public int KeepDistanceData { get => keepDistanceData; set => keepDistanceData = value; }
        public byte BtTraceType { get => btTraceType; set => btTraceType = value; }
        public byte BtTraceBoundary { get => btTraceBoundary; set => btTraceBoundary = value; }
        public int TraceData { get => traceData; set => traceData = value; }
        public byte BtHomingType { get => btHomingType; set => btHomingType = value; }
        public int HomingData { get => homingData; set => homingData = value; }
        public byte BtAggressTypeOnHoming { get => btAggressTypeOnHoming; set => btAggressTypeOnHoming = value; }
        public byte BtFleeType { get => btFleeType; set => btFleeType = value; }
        public int DwChampionTacticsID { get => dwChampionTacticsID; set => dwChampionTacticsID = value; }
        public int AdditionOptionFlag { get => additionOptionFlag; set => additionOptionFlag = value; }
        public string SzDescString128 { get => szDescString128; set => szDescString128 = value; }
        public byte BtAggroType { get => btAggroType; set => btAggroType = value; }
    }
}