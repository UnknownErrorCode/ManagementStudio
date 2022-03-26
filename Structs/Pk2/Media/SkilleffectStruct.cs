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
        public object[] ObjectArray;

        public object CodeName128;
        public object RessourceTypName;
        public object Size;
        public object Ride;
        public object Type;
        public object DieBsr;
        public object DieEffect;
        public object DamageBone;
        public object DamagePos;
        public object BloodType;
        public object DeadEffect;
        public object[] buffer;

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
        public object[] ObjectArray;
        public object Service;
        public object EffectSetLink;
        public object Basic_Code;
        public object Priority;
        public object AniTRUE;
        public object HideWeapon;
        public object AniGroup;
        public object AniReady;
        public object AniWait;
        public object AnimationCode;
        public object AniPlayTime;
        public object ActW;
        public object ActS;
        public object DefenseEfp;
        public object DamageEfp;
        public object Lenght;
        public object Color;
        public object OP;
        public object texture;
        public object[] buffer;


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
        public object[] ObjectArray;
        public object Basic_Name;
        public object SkillEffectID;
        public object AniType;
        public object StartEvent;
        public object DMG;
        public object Event;
        public object DamageType;
        public object Scale;
        public object ID;
        public object Attach;
        public object Trade;
        public object Kill;
        public object CreateCnt;
        public object Fade;
        public object ActType;
        public object MovTypeSpeed;
        public object Param;
        public object Act;
        public object Option;
        public object Obj;
        public object Path;
        public object ObjName;
        public object StartBone;
        public object StartOffset;
        public object TargetBone;
        public object TargetOffset;
        public object ObjName2;
        public object Rotate;
        public object Script;
        public object SndBegin;
        public object SndEnd;
        public object[] buffer;


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
