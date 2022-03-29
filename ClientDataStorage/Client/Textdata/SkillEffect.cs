using Structs.Pk2.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClientDataStorage.Client.Textdata
{
    public class SkillEffect
    {
        #region Public Fields

        public SkilleffectStruct Skilleffects;

        #endregion Public Fields

        #region Public Constructors

        public SkillEffect()
        {
            if (Media.MediaPk2.GetByteArrayByDirectory("Media\\server_dep\\silkroad\\textdata\\skilleffect.txt", out byte[] rawfile))
            {
                string[] FileAsLineArray = TextParser.StaticTextParser.ConvertByteArrayToTextArray(rawfile);

                Skilleffects.AllCharakterInfos = new List<CharakterInfo>();
                Skilleffects.AllAniSet2s = new List<AniSet2>();
                Skilleffects.AllEffectSets = new List<EffectSet>();

                SkillEffectSection coordinationFlag = SkillEffectSection.None;
                foreach (string line in FileAsLineArray)
                {
                    if (line.Split(new string[] { "//" }, StringSplitOptions.None)[0].Length > 0)
                    {
                        string newline = line.Split(new string[] { "//" }, StringSplitOptions.None)[0];
                        if (newline == "")
                        {
                            continue;
                        }
                        if (newline.Contains("#section\tcharacterInfo"))
                        {
                            coordinationFlag = SkillEffectSection.CharakterInfo;
                            continue;
                        }
                        else if (newline.Contains("#section\tskillaniset2"))
                        {
                            coordinationFlag = SkillEffectSection.skillaniset2;
                            continue;
                        }
                        else if (newline.Contains("#section\tskilleffectset"))
                        {
                            coordinationFlag = SkillEffectSection.skilleffectset;
                            continue;
                        }
                        List<string> splittedSingleLine = newline.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                        switch (coordinationFlag)
                        {
                            case SkillEffectSection.CharakterInfo:
                                while (splittedSingleLine.Count < 12)
                                {
                                    splittedSingleLine.Add("0");
                                }
                                Skilleffects.AllCharakterInfos.Add(new CharakterInfo(splittedSingleLine.ToArray()));
                                break;

                            case SkillEffectSection.skillaniset2:
                                while (splittedSingleLine.Count < 20)
                                {
                                    splittedSingleLine.Add("0");
                                }
                                Skilleffects.AllAniSet2s.Add(new AniSet2(splittedSingleLine.ToArray()));
                                break;

                            case SkillEffectSection.skilleffectset:
                                while (splittedSingleLine.Count < 33)
                                {
                                    splittedSingleLine.Add("0");
                                }
                                Skilleffects.AllEffectSets.Add(new EffectSet(splittedSingleLine.ToArray()));
                                break;

                            case SkillEffectSection.None:
                                break;

                            default:
                                break;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        #endregion Public Constructors
    }
}