using System.Collections.Generic;

namespace ClientDataStorage.Client.Files.bsr
{
    internal class CPrimAniTypeData
    {
        AnimationType animationType;
        uint animationFileIndex;
        uint AnimationEventCount;

        List<AnimationEvent> AnimationEventList;


        uint walkPointCnt;
        float walkLength;
        List<float[]> WalkGraphPointList


    }
}