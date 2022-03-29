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
        #region Internal Constructors

        internal Monster(SingleSpawn spawn) : base(spawn)
        {
        }

        #endregion Internal Constructors
    }

    internal class SpawnMonster
    {
        #region Public Fields

        public readonly Spawn Spawn;

        #endregion Public Fields

        #region Internal Constructors

        internal SpawnMonster(int nestID)
        {
            TabRefNest nest = new TabRefNest(ClientDataStorage.Database.SRO_VT_SHARD.dbo.Tables["Tab_RefNest"].Rows.OfType<DataRow>().Single(row => row.Field<int>("dwNestID").Equals(nestID)).ItemArray);
            Spawn = new Spawn(nest.dwNestID, nest.nRegionDBID, nest.fLocalPosX, nest.fLocalPosZ, nest.fLocalPosY, nest.nRadius, nest.nGenerateRadius);
        }

        #endregion Internal Constructors
    }
}