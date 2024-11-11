using Structs.BinaryFiles;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class SroStruct : Spawn
    {
        public string Name { get; }
        public SroStruct(ObjectStringIFOStruct ojs) : base(ojs)
        {
            Name = ojs.Name;
        }
    }
}
