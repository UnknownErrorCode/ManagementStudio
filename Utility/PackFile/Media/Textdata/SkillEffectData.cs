using System;
using System.Collections.Generic;
using System.Linq;

namespace PackFile.Media.Textdata
{
    public abstract class SkillEffectData
    {
        #region Fields

        public readonly SkilleffectStruct Skilleffects;

        internal readonly bool Initialized = true;

        #endregion Fields

        #region Constructors

        public SkillEffectData(byte[] rawfile)
        {
            try
            {
                string[] FileAsLineArray = Utility.TextParser.ConvertByteArrayToTextArray(rawfile);

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
                        else if (newline.Contains("#section\tskillaniset2"))// TODO change to sartWith
                        {
                            coordinationFlag = SkillEffectSection.skillaniset2;
                            continue;
                        }
                        else if (newline.StartsWith("#section") && newline.Contains("skilleffectset"))
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
            catch (Exception)
            {
                Initialized = false;
            }
        }

        #endregion Constructors
    }
}