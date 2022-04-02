namespace Structs.Pk2.BinaryFiles.JMXRessource
{
    public class CModDataMultiTexture : IModData
    {
        public CModDataMultiTexture(CModData data)
        {
            Data = data;
            Type = ModDataType.ModDataMultiTex;
        }
        #region Properties

        public uint unkUInt5 { get; set; }

        [System.Obsolete]
        public uint TextureLength { get; set; }

        /// <summary>
        /// .ddj
        /// </summary>
        public string Texture { get; set; }

        public uint unkUInt6 { get; set; }
        public CModData Data { get; }
        public ModDataType Type { get; }

        #endregion Properties
    }
}