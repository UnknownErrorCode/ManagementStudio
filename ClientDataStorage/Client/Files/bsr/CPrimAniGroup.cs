namespace ClientDataStorage.Client.Files.bsr
{
    internal class CPrimAniGroup
    {

        uint groupNameLength;
        string groupName;

        List<CPrimAniTypeData> PrimAniTypeDataList;
    //PrimAniTypeData
       uint aniCount
    for (int ii = 0; ii<aniCount; ii++)
    {                
          uint animation.Type          //see ResourceAnimationType
          uint animation.FileIndex

          uint eventCnt
        for (int iii = 0; iii<eventCnt; iii++)
        {
              uint event.KeyTime
              uint event.Type
              uint event.unkValue0
              uint event.unkValue1
        }

          uint walkPointCnt
          float walkLength
        for (int iii = 0; iii<walkPointCnt; iii++)
              Vector2 walkGraphPoint
    }
}
}