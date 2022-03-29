using Editors.Spawn;
using Structs.Database;
using System.Data;
using System.Linq;

namespace WorldMapSpawnEditor.MapGraphics
{
    /// <summary>
    /// A single Monster spawn Control.
    /// </summary>
    internal class Monster : ISpawn
    {
        internal Monster(SingleSpawn spawn) : base(spawn)
        {
        }
    }

    internal class SpawnMonster
    {
        public readonly Spawn Spawn;

        internal SpawnMonster(int nestID)
        {
            Tab_RefNest nest = new Tab_RefNest(ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["Tab_RefNest"].Rows.OfType<DataRow>().Single(row => row.Field<int>("dwNestID").Equals(nestID)).ItemArray);
            Spawn = new Spawn(nest.dwNestID, nest.nRegionDBID, nest.fLocalPosX, nest.fLocalPosZ, nest.fLocalPosY, GraphicsPanel.SpawnType.Monster, nest.nRadius, nest.nGenerateRadius);
        }
    }
}