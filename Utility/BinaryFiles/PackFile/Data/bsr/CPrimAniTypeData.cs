using System.Collections.Generic;

namespace BinaryFiles.PackFile.Data.bsr
{
    [System.Obsolete]
    internal class CPrimAniTypeData
    {
        #region Fields

        private uint AnimationEventCount;
        private List<AnimationEvent> AnimationEventList = new List<AnimationEvent>();
        private uint animationFileIndex;
        private AnimationType animationType;
        private List<float[]> WalkGraphPointList = new List<float[]>();
        private float walkLength;
        private uint walkPointCnt;

        #endregion Fields
    }
}