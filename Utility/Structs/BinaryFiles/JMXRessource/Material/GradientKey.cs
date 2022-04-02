using System.Collections.Generic;

namespace Structs.Pk2.BinaryFiles.JMXRessource
{
    public struct GradientKey
    {
        /// <summary>
        /// In milliseconds.
        /// </summary>
        public uint Time { get; set; }

        /// <summary>
        /// Color4 ??
        /// </summary>
        public List<float> Values { get; set; }
    }
}
