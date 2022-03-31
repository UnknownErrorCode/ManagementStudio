using System.Collections.Generic;

namespace ClientDataStorage.Client.Files.bsr
{
    internal class CPrimAniTypeData
    {
        #region Properties

        private uint AnimationEventCount { get; set; }
        private List<AnimationEvent> AnimationEventList { get; set; } = new List<AnimationEvent>();
        private uint animationFileIndex { get; set; }
        private AnimationType animationType { get; set; }
        private List<float[]> WalkGraphPointList { get; set; } = new List<float[]>();
        private float walkLength { get; set; }
        private uint walkPointCnt { get; set; }

        #endregion Properties
    }
}