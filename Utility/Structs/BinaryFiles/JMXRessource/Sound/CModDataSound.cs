namespace Structs.Pk2.BinaryFiles.JMXRessource
{
    public class CModDataSound : CModData
    {
        /// <summary>
        /// if this lowerEqual 0 
        /// <br>return;</br>
        /// </summary>
        public uint nSndSetNum { get; set; }
        public CModDataSoundConfig cModDataSoundConfig { get; set; }

    }
}
