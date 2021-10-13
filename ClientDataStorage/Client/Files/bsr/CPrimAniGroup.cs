using System.Collections.Generic;

namespace ClientDataStorage.Client.Files.bsr
{
    /// <summary>
    /// AnimationGroupName, List of AnimationTypeData.
    /// </summary>
    internal class CPrimAniGroup
    {

        uint groupNameLength{get; set;}
        string groupName{get; set;}

        uint aniCount{get; set;}
        List<CPrimAniTypeData> PrimAniTypeDataList { get; set; } = new List<CPrimAniTypeData>();
    }
}
