namespace Structs.Pk2.BinaryFiles.JMXRessource
{
    public struct CModDataSoundTrack
    {
        /// <summary>
        /// if hasValue != 1, return
        /// </summary>
        public uint hasValue { get; set; }
        public uint FileNameLength { get; set; }
        /// <summary>
        /// .wav file
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// in milliseconds
        /// </summary>
        public uint KeyTime { get; set; }
        public uint EventLength { get; set; }
        public string EventName { get; set; }


    }
}
