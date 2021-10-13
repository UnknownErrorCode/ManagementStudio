using System.Collections.Generic;

namespace ClientDataStorage.Client.Files.bsr
{
    internal class CPrimAniGroup
    {

        uint groupNameLength;
        string groupName;

        uint aniCount;
        List<CPrimAniTypeData> PrimAniTypeDataList;
    }
   
}
