using System.Collections.Generic;

namespace Structs.Pk2.BinaryFiles.JMXRessource
{
    /// <summary>
    /// AnimationGroupName, List of AnimationTypeData.
    /// </summary>
    [System.Obsolete]
    public struct CPrimAniGroup
    {
        #region Fields

        public uint AnimationTypeDataCount;
        public string AnimationGroupName;
        public List<CPrimAniTypeData> PrimAniTypeDataList;

        #endregion Fields
    }
}