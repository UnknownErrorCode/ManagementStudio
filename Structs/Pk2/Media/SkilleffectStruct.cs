using System.Collections.Generic;

namespace Structs.Pk2.Media
{
    public struct SkilleffectStruct
    {
        public List<CharakterInfo> AllCharakterInfos;
        public List<AniSet2> AllAniSet2s;
        public List<EffectSet> AllEffectSets;
    }

    public struct CharakterInfo
    {
        public object[] ObjectArray { get; set; }

        public object CodeName128 { get; set; }
        public object RessourceTypName { get; set; }
        public object Size { get; set; }
        public object Ride { get; set; }
        public object Type { get; set; }
        public object DieBsr { get; set; }
        public object DieEffect { get; set; }
        public object DamageBone { get; set; }
        public object DamagePos { get; set; }
        public object BloodType { get; set; }
        public object DeadEffect { get; set; }
        public object[] buffer { get; set; }

        public CharakterInfo(string[] incomeLine)
        {
            ObjectArray = incomeLine;
            CodeName128 = incomeLine[0];
            RessourceTypName = incomeLine[1];
            Size = incomeLine[2];
            Ride = incomeLine[3];
            Type = incomeLine[4];
            DieBsr = incomeLine[5];
            DieEffect = incomeLine[6];
            DamageBone = incomeLine[7];
            DamagePos = incomeLine[8];
            BloodType = incomeLine[9];
            DeadEffect = incomeLine[10];
            var lastarray = new List<string>();
            if (incomeLine.Length > 11)
            {
                for (int i = 11; i < incomeLine.Length; i++)
                {
                    lastarray.Add(incomeLine[i]);
                }
            }
            buffer = lastarray.ToArray();
        }
    }


    public struct AniSet2
    {
        public object[] ObjectArray { get; set; }
        public object Service { get; set; }
        public object EffectSetLink { get; set; }
        public object Basic_Code { get; set; }
        public object Priority { get; set; }
        public object AniTRUE { get; set; }
        public object HideWeapon { get; set; }
        public object AniGroup { get; set; }
        public object AniReady { get; set; }
        public object AniWait { get; set; }
        public object AnimationCode { get; set; }
        public object AniPlayTime { get; set; }
        public object ActW { get; set; }
        public object ActS { get; set; }
        public object DefenseEfp { get; set; }
        public object DamageEfp { get; set; }
        public object Lenght { get; set; }
        public object Color { get; set; }
        public object OP { get; set; }
        public object texture { get; set; }
        public object[] buffer { get; set; }


        public AniSet2(string[] incomeLine)
        {
            ObjectArray = incomeLine;
            Service = incomeLine[0];
            EffectSetLink = incomeLine[1];
            Basic_Code = incomeLine[2];
            Priority = incomeLine[3];
            AniTRUE = incomeLine[4];
            HideWeapon = incomeLine[5];
            AniGroup = incomeLine[6];
            AniReady = incomeLine[7];
            AniWait = incomeLine[8];
            AnimationCode = incomeLine[9];
            AniPlayTime = incomeLine[10];
            ActW = incomeLine[11];
            ActS = incomeLine[12];
            DefenseEfp = incomeLine[13];
            DamageEfp = incomeLine[14];
            Lenght = incomeLine[15];
            Color = incomeLine[16];
            OP = incomeLine[17];
            texture = incomeLine[18];

            var lastarray = new List<string>();
            if (incomeLine.Length > 19)
            {
                for (int i = 19; i < incomeLine.Length; i++)
                {
                    lastarray.Add(incomeLine[i]);
                }
            }
            buffer = lastarray.ToArray();
        }
    }


    public struct EffectSet
    {
        public object[] ObjectArray { get; set; }
        public object Basic_Name { get; set; }
        public object SkillEffectID { get; set; }
        public object AniType { get; set; }
        public object StartEvent { get; set; }
        public object DMG { get; set; }
        public object Event { get; set; }
        public object DamageType { get; set; }
        public object Scale { get; set; }
        public object ID { get; set; }
        public object Attach { get; set; }
        public object Trade { get; set; }
        public object Kill { get; set; }
        public object CreateCnt { get; set; }
        public object Fade { get; set; }
        public object ActType { get; set; }
        public object MovTypeSpeed { get; set; }
        public object Param { get; set; }
        public object Act { get; set; }
        public object Option { get; set; }
        public object Obj { get; set; }
        public object Path { get; set; }
        public object ObjName { get; set; }
        public object StartBone { get; set; }
        public object StartOffset { get; set; }
        public object TargetBone { get; set; }
        public object TargetOffset { get; set; }
        public object ObjName2 { get; set; }
        public object Rotate { get; set; }
        public object Script { get; set; }
        public object SndBegin { get; set; }
        public object SndEnd { get; set; }
        public object[] buffer { get; set; }


        public EffectSet(string[] incomeLine)
        {
            ObjectArray = incomeLine;
            Basic_Name = incomeLine[0];
            SkillEffectID = incomeLine[1];
            AniType = incomeLine[2];
            StartEvent = incomeLine[3];
            DMG = incomeLine[4];
            Event = incomeLine[5];
            DamageType = incomeLine[6];
            Scale = incomeLine[7];
            ID = incomeLine[8];
            Attach = incomeLine[9];
            Trade = incomeLine[10];
            Kill = incomeLine[11];
            CreateCnt = incomeLine[12];
            Fade = incomeLine[13];
            ActType = incomeLine[14];
            MovTypeSpeed = incomeLine[15];
            Param = incomeLine[16];
            Act = incomeLine[17];
            Option = incomeLine[18];
            Obj = incomeLine[19];
            Path = incomeLine[20];
            ObjName = incomeLine[21];
            StartBone = incomeLine[22];
            StartOffset = incomeLine[23];
            TargetBone = incomeLine[24];
            TargetOffset = incomeLine[25];
            ObjName2 = incomeLine[26];
            Rotate = incomeLine[27];
            Script = incomeLine[28];
            SndBegin = incomeLine[29];
            SndEnd = incomeLine[30];
            var lastarray = new List<string>();
            if (incomeLine.Length > 31)
            {
                for (int i = 31; i < incomeLine.Length; i++)
                {
                    lastarray.Add(incomeLine[i]);
                }
            }
            buffer = lastarray.ToArray();
        }
    }



    public enum SkillEffectSection
    {
        CharakterInfo = 0,
        skillaniset2 = 1,
        skilleffectset = 2,
        None = 3,
    }
}
