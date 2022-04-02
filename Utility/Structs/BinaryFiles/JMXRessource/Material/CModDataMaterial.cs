using System.Collections.Generic;

namespace Structs.Pk2.BinaryFiles.JMXRessource
{
    public class CModDataMaterial : IModData
    {
        public CModDataMaterial(CModData data)
        {
            Data = data;
            Type = ModDataType.ModDataMtrl;
        }

        public CModData Data { get; }

        public ModDataType Type { get; }

        /// <summary>
        /// length in ms?
        /// </summary>
        public uint unkUInt5 { get; set; }
        /// <summary>
        /// some flag
        /// </summary>
        public uint unkUInt6 { get; set; }
        public uint unkUInt7 { get; set; }
        public uint gradientKeyCount { get; set; }
        public List<GradientKey> GradientKeys { get; set; }
        public uint curvedKeyCount { get; set; }
        public List<CurvedKey> CurvedKeys { get; set; }
        /// <summary>
        /// as 16 byte struct -> Color4?, Vector4?, Quaternion?
        /// </summary>
        public uint unkUInt8 { get; set; }
        public uint unkUInt9 { get; set; }
        public uint unkUInt10 { get; set; }
        public uint unkUInt11 { get; set; }


        public uint unkUInt12 { get; set; }
        public uint unkUInt13 { get; set; }
        public uint unkUInt14 { get; set; }
        public uint unkUInt15 { get; set; }
        public uint unkUInt16 { get; set; }
    }
}
