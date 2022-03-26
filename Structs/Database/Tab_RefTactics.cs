
namespace Structs.Database
{
    public struct Tab_RefTactics
    {
		public readonly int dwTacticsID;
        public int dwObjID;
        public byte btAIQoS;
        public int nMaxStamina;
        public byte btMaxStaminaVariance;
        public int nSightRange;
        public byte btAggressType;
        public int AggressData;
        public byte btChangeTarget;
        public byte btHelpRequestTo;
        public byte btHelpResponseTo;
        public byte btBattleStyle;
        public int BattleStyleData;
        public byte btDiversionBasis;
        public int DiversionBasisData1;
        public int DiversionBasisData2;
        public int DiversionBasisData3;
        public int DiversionBasisData4;
        public int DiversionBasisData5;
        public int DiversionBasisData6;
        public int DiversionBasisData7;
        public int DiversionBasisData8;
        public byte btDiversionKeepBasis;
        public int DiversionKeepBasisData1;
        public int DiversionKeepBasisData2;
        public int DiversionKeepBasisData3;
        public int DiversionKeepBasisData4;
        public int DiversionKeepBasisData5;
        public int DiversionKeepBasisData6;
        public int DiversionKeepBasisData7;
        public int DiversionKeepBasisData8;
        public byte btKeepDistance;
        public int KeepDistanceData;
        public byte btTraceType;
        public byte btTraceBoundary;
        public int TraceData;
        public byte btHomingType;
        public int HomingData;
        public byte btAggressTypeOnHoming;
        public byte btFleeType;
        public int dwChampionTacticsID;
        public int AdditionOptionFlag;
        public string szDescString128;

        public Tab_RefTactics(object[] row)
        {
            dwTacticsID = int.Parse(row[0].ToString());
            dwObjID = int.Parse(row[1].ToString());
            btAIQoS = byte.Parse(row[2].ToString());
            nMaxStamina = int.Parse(row[3].ToString());
            btMaxStaminaVariance = byte.Parse(row[4].ToString());
            nSightRange = int.Parse(row[5].ToString());
            btAggressType = byte.Parse(row[6].ToString());
            AggressData = int.Parse(row[7].ToString());
            btChangeTarget = byte.Parse(row[8].ToString());
            btHelpRequestTo = byte.Parse(row[9].ToString());
            btHelpResponseTo = byte.Parse(row[10].ToString());
            btBattleStyle = byte.Parse(row[11].ToString());
            BattleStyleData = int.Parse(row[12].ToString());
            btDiversionBasis = byte.Parse(row[13].ToString());
            DiversionBasisData1 = int.Parse(row[14].ToString());
            DiversionBasisData2 = int.Parse(row[15].ToString());
            DiversionBasisData3 = int.Parse(row[16].ToString());
            DiversionBasisData4 = int.Parse(row[17].ToString());
            DiversionBasisData5 = int.Parse(row[18].ToString());
            DiversionBasisData6 = int.Parse(row[19].ToString());
            DiversionBasisData7 = int.Parse(row[20].ToString());
            DiversionBasisData8 = int.Parse(row[21].ToString());
            btDiversionKeepBasis = byte.Parse(row[22].ToString());
            DiversionKeepBasisData1 = int.Parse(row[23].ToString());
            DiversionKeepBasisData2 = int.Parse(row[24].ToString());
            DiversionKeepBasisData3 = int.Parse(row[25].ToString());
            DiversionKeepBasisData4 = int.Parse(row[26].ToString());
            DiversionKeepBasisData5 = int.Parse(row[27].ToString());
            DiversionKeepBasisData6 = int.Parse(row[28].ToString());
            DiversionKeepBasisData7 = int.Parse(row[29].ToString());
            DiversionKeepBasisData8 = int.Parse(row[30].ToString());
            btKeepDistance = byte.Parse(row[31].ToString());
            KeepDistanceData = int.Parse(row[32].ToString());
            btTraceType = byte.Parse(row[33].ToString());
            btTraceBoundary = byte.Parse(row[34].ToString());
            TraceData = int.Parse(row[35].ToString());
            btHomingType = byte.Parse(row[36].ToString());
            HomingData = int.Parse(row[37].ToString());
            btAggressTypeOnHoming = byte.Parse(row[38].ToString());
            btFleeType = byte.Parse(row[39].ToString());
            dwChampionTacticsID = int.Parse(row[40].ToString());
            AdditionOptionFlag = int.Parse(row[41].ToString());
            szDescString128 = row[42].ToString();
        }
    }
}
