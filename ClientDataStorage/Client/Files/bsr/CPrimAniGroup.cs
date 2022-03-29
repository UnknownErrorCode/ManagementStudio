using System.Collections.Generic;

namespace ClientDataStorage.Client.Files.bsr
{
    /// <summary>
    /// AnimationGroupName, List of AnimationTypeData.
    /// </summary>
    internal class CPrimAniGroup
    {
        private uint aniCount;
        private string groupName;
        private uint groupNameLength;
        private List<CPrimAniTypeData> PrimAniTypeDataList = new List<CPrimAniTypeData>();
    }
}