using System.Collections.Generic;

namespace ClientDataStorage.Client.Files.bsr
{
    internal class CModDataSet
    {
        #region Properties

        /// <summary>
        /// from PrimAnimationType
        /// </summary>
        private AnimationType AniType { get; set; }

        //TODO check if key can be duplicated
        private Dictionary<ModDataType, byte[]> ModDataTypes { get; set; }

        private uint modSetDataCnt { get; set; }

        private string Name { get; set; }

        private uint NameLength { get; set; }

        /// <summary>
        /// Locomotion = 0, Simple = 1, Ambient = 2,
        /// </summary>
        private uint Type { get; set; }

        #endregion Properties
    }
}