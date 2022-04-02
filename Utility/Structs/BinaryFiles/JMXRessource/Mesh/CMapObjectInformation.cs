namespace Structs.BinaryFiles.JMXRessource.Mesh
{
    public struct CMapObjectInformation
    {
        /// <summary>
        /// from m_sObjectInfo (object.ifo)
        /// </summary>
        public uint ObjectIndex;

        /// <summary>
        /// relative to the region
        /// </summary>
        public SVector3 LocalPosition;

        /// <summary>
        /// Weather the MapObject is static or not. 0 = No, 0xFFFF = Yes.
        /// </summary>
        public short IsStatic;

        /// <summary>
        /// Yaw of MapObject.
        /// </summary>
        public float Yaw;

        /// <summary>
        /// Unique identifier
        /// </summary>
        public uint UID;

        /// <summary>
        /// exeeds region size
        /// </summary>
        public byte IsBig;

        /// <summary>
        ///  Defines if MapObject has "objectstring.ifo".
        /// </summary>
        public byte IsStruct;

        public WRegionID RegionID;
    }
}