using System.Collections.Generic;

namespace BinaryFiles.PackFile.Data.bsr
{
    /// <summary>
    /// AnimationGroupName, List of AnimationTypeData.
    /// </summary>
    [System.Obsolete]
    internal class CPrimAniGroup
    {
        #region Fields

        private readonly uint aniCount;
        private readonly string groupName;
        private readonly uint groupNameLength;
        private readonly List<CPrimAniTypeData> PrimAniTypeDataList = new List<CPrimAniTypeData>();

        #endregion Fields
    }
}