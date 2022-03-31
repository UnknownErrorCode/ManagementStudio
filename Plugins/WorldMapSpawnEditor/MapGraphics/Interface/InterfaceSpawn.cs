using Structs;
using Structs.Tool;

namespace WorldMapSpawnEditor.MapGraphics.Interface
{
    internal interface InterfaceSpawn
    {
        int ID { get; }
        SpawnType SpawnType { get; }
        WRegionID RegionID { get; }
        float XLocation { get; }
        float YLocation { get; }
        float ZLocation { get; }
        int GameWorldID { get; }
    }
}
