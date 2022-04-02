namespace Structs.Pk2.BinaryFiles.JMXRessource
{
    public struct CModDataSoundSet
    {
        public uint NameLength { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// MAX_SOUND_TRACK_PER_ANI = 15
        /// </summary>
        public uint nTrackCount { get; set; }
    }
}
