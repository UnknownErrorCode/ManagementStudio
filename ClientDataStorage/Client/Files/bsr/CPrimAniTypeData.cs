using System.Collections.Generic;

namespace ClientDataStorage.Client.Files.bsr
{
    internal class CPrimAniTypeData
    {
        private AnimationType animationType { get; set; }
        private uint animationFileIndex { get; set; }
        private uint AnimationEventCount { get; set; }

        private List<AnimationEvent> AnimationEventList { get; set; } = new List<AnimationEvent>();

        private uint walkPointCnt { get; set; }
        private float walkLength { get; set; }
        private List<float[]> WalkGraphPointList { get; set; } = new List<float[]>();
    }
}