namespace Structs.Pk2.BinaryFiles.JMXRessource
{
    public struct CModDataParticleStruct
    {

        public uint IsEnabled;

        [System.Obsolete]
        public uint FileNameLength;
        /// <summary>
        /// .efp file
        /// </summary>
        public string FileName;

        [System.Obsolete]
        public uint BoneLength;

        public string Bone;
        /// <summary>
        /// relative to origin or bone if present
        /// </summary>
        public SVector3 BonePosition;

        /// <summary>
        /// in ms
        /// </summary>
        public uint BirthTime;

        public byte UnkByte0;
        public byte UnkByte1;
        public byte UnkByte2;
        public byte UnkByte3;

        /// <summary>
        /// if <see cref="UnkByte3"/> == 1
        /// <br>initial velocity?</br>
        /// </summary>
        public SVector3 UnkVector;
    }
}