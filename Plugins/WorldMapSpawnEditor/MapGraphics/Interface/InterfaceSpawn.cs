using Structs;
using Structs.Tool;

namespace WorldMapSpawnEditor.MapGraphics.Interface
{
    internal interface InterfaceSpawn
    {
        #region Properties

        int GameWorldID { get; }
        int ID { get; }
        WRegionID RegionID { get; }
        SpawnType SpawnType { get; }
        float XLocation { get; }
        float YLocation { get; }
        float ZLocation { get; }

        #endregion Properties
    }
}