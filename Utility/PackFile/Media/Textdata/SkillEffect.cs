using System.Collections.Generic;

namespace PackFile.Media.Textdata
{
    public class SkillEffect : SkillEffectData
    {
        #region Constructors

        /// <summary>
        /// Skilleffect from Media.pk2
        /// </summary>
        public SkillEffect(byte[] rawfile) : base(rawfile)
        {
        }

        #endregion Constructors

        #region Methods

        public bool ExistsAniSet2s(string currentlySelectedBasicCode) => Skilleffects.AllAniSet2s.Exists(singleAniSet2 => (string)singleAniSet2.Basic_Code == currentlySelectedBasicCode);

        public bool ExistsCharInfoCodename128(string codeName128) => Skilleffects.AllCharakterInfos.Exists(charInfo => (string)charInfo.CodeName128 == codeName128);

        public bool ExistsEffectSets(string currentlySelectedBasicCode) => Skilleffects.AllEffectSets.Exists(singleEffect => (string)singleEffect.SkillEffectID == currentlySelectedBasicCode);

        public IEnumerable<AniSet2> GetAniSet2s(string currentlySelectedBasicCode) => Skilleffects.AllAniSet2s.FindAll(singleAniSet2 => (string)singleAniSet2.Basic_Code == currentlySelectedBasicCode);

        public IEnumerable<CharakterInfo> GetCharakterInfos(string codeName128) => Skilleffects.AllCharakterInfos.FindAll(charInfo => (string)charInfo.CodeName128 == codeName128);

        #endregion Methods
    }
}