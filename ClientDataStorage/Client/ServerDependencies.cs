using ClientDataStorage.Client.Textdata;

namespace ClientDataStorage.Client
{
    public class ServerDependencies
    {
        #region Fields

        private SkillEffect skillEffect;
        private TextUISystem textUISystem;

        #endregion Fields

        #region Properties

        public SkillEffect SkillEffect { get => skillEffect; set => skillEffect = value; }

        public TextUISystem TextUISystem { get => textUISystem; set => textUISystem = value; }

        #endregion Properties

        #region Methods

        internal bool Initialize()
        {
            if (!Media.MediaPk2.GetByteArrayByDirectory("Media\\server_dep\\silkroad\\textdata\\textuisystem.txt", out byte[] textuisystem))
                return false;

            if (!Media.MediaPk2.GetByteArrayByDirectory("Media\\server_dep\\silkroad\\textdata\\skilleffect.txt", out byte[] skilleffect))
                return false;

            skillEffect = new SkillEffect(skilleffect);
            textUISystem = new TextUISystem(textuisystem);

            return true;
        }

        #endregion Methods
    }
}