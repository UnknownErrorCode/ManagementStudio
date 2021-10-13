namespace ClientDataStorage.Client.Files.bsr
{
    internal class CModDataSet
    {
        /// <summary>
        /// Locomotion = 0, Simple = 1, Ambient = 2,
        /// </summary>
        uint Type;

        /// <summary>
        /// from PrimAnimationType
        /// </summary>
        AnimationType AniType;


        uint NameLength;
        string Name;

        uint modSetDataCnt;

        //TODO check if key can be duplicated
        Dictionary<ModDataType, byte[]> ModDataTypes;

            

        /*
         
         
    //CModDataSet
    4   uint    Type                 // Locomotion = 0, Simple = 1, Ambient = 2,
    4   uint    AnimationType       // from PrimAnimationType
    4   uint    NameLength
    *   string  Name
    
    4   uint    modSetDataCnt
    for (int i = 0; i < modSetCnt; i++)
    {
        4   uint    modDataType             // see ModDataType
        *   byte[]  modData                 // read ModData base on type...
    }
         
         */
    }
}