using PackFile.Media.Textdata;

namespace PackFile.Media
{
    internal class ServerDependencies
    {
        #region Methods

        internal static bool GetSkillEffect(out SkillEffect skillEffect)
        {
            skillEffect = null;

            if (!MediaPack.Reader.GetByteArrayByDirectory("Media\\server_dep\\silkroad\\textdata\\skilleffect.txt", out byte[] skilleffect))
                return false;

            skillEffect = new SkillEffect(skilleffect);

            return skillEffect.Initialized;
        }

        internal static bool GetTextDataName(out TextDataName textDataName)
        {
            textDataName = null;
            if (!MediaPack.Reader.GetByteArrayByDirectory("Media\\server_dep\\silkroad\\textdata\\textdataname.txt", out byte[] textuisystem_txt))
                return false;
            textDataName = new TextDataName(textuisystem_txt);
            return textDataName.Initialized;
        }

        internal static bool GetTextUISystem(out TextUISystem textUISystem)
        {
            textUISystem = null;
            if (!MediaPack.Reader.GetByteArrayByDirectory("Media\\server_dep\\silkroad\\textdata\\textuisystem.txt", out byte[] textuisystem_txt))
                return false;

            textUISystem = new TextUISystem(textuisystem_txt);
            return textUISystem.Initialized;
        }

        internal static bool GetWorldmap_Mapinfo(out Worldmap_Mapinfo worldmap_MapinfoData)
        {
            worldmap_MapinfoData = null;
            if (!MediaPack.Reader.GetByteArrayByDirectory("Media\\server_dep\\silkroad\\textdata\\worldmap_mapinfo.txt", out byte[] worldmap_mapinfo_txt))
                return false;

            worldmap_MapinfoData = new Worldmap_Mapinfo(worldmap_mapinfo_txt);
            return worldmap_MapinfoData.Initialized;
        }

        #endregion Methods
    }
}