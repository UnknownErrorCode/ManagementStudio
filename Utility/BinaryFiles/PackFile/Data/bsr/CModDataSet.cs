using System.Collections.Generic;

namespace BinaryFiles.PackFile.Data.bsr
{
    [System.Obsolete]
    internal class CModDataSet
    {
        #region Fields

        /// <summary>
        /// from PrimAnimationType
        /// </summary>
        private AnimationType AniType;

        //TODO check if key can be duplicated
        private Dictionary<ModDataType, byte[]> ModDataTypes;

        private uint modSetDataCnt;

        private string Name;

        private uint NameLength;

        /// <summary>
        /// Locomotion = 0, Simple = 1, Ambient = 2,
        /// </summary>
        private uint Type;

        #endregion Fields
    }
}