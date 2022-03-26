using System.Collections.Generic;

namespace ClientDataStorage.Client.Files.bsr
{
    internal class CPrimAniTypeData
    {
        AnimationType animationType { get; set; }
        uint animationFileIndex { get; set; }
        uint AnimationEventCount { get; set; }

        List<AnimationEvent> AnimationEventList { get; set; } = new List<AnimationEvent>();

        uint walkPointCnt { get; set; }
        float walkLength { get; set; }
        List<float[]> WalkGraphPointList { get; set; } = new List<float[]>();

    }
}