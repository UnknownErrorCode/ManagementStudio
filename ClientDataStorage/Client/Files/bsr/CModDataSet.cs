using System.Collections.Generic;

namespace ClientDataStorage.Client.Files.bsr
{
    internal class CModDataSet
    {
        /// <summary>
        /// Locomotion = 0, Simple = 1, Ambient = 2,
        /// </summary>
        uint Type { get; set; }

        /// <summary>
        /// from PrimAnimationType
        /// </summary>
        AnimationType AniType { get; set; }


        uint NameLength { get; set; }
        string Name { get; set; }

        uint modSetDataCnt { get; set; }

        //TODO check if key can be duplicated
        Dictionary<ModDataType, byte[]> ModDataTypes { get; set; }
    }
}