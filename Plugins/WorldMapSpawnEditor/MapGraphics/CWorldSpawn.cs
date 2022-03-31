using Structs.Database;
using Structs.Tool;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WorldMapSpawnEditor.MapGraphics.Interface;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class CWorldSpawn : IEnumerable<InterfaceSpawn>
    {

        #region Private Fields

        private readonly List<InterfaceSpawn> cSpawns = new List<InterfaceSpawn>();

        #endregion Private Fields

        #region Internal Constructors

        internal CWorldSpawn() =>
            Initialize();

        #endregion Internal Constructors

        #region Public Methods

        public IEnumerator<InterfaceSpawn> GetEnumerator() => cSpawns.GetEnumerator();

        public IEnumerator<InterfaceSpawn> GetEnumerator(ushort wRegionID) => cSpawns.Where(s => s.RegionID.RegionID.Equals(wRegionID)).GetEnumerator();

        public IEnumerator<InterfaceSpawn> GetEnumerator(int gameWorldID) => cSpawns.Where(s => s.GameWorldID.Equals(gameWorldID)).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion Public Methods

        #region Internal Methods

        internal void Initialize()
        {
            cSpawns.Clear();
            InitializeNest();
            InitializeChars();
            InitializeTeleports();
        }

        internal InterfaceSpawn FromSpawn<T>(Spawn spawn) where T : class
            => (InterfaceSpawn)System.Activator.CreateInstance(typeof(T), spawn.ID);

        #endregion Internal Methods

        #region Private Methods

        private void InitializeTeleports()
        {
            foreach (RefTeleport teleport in ClientDataStorage.Database.SRO_VT_SHARD._RefTeleport.Values)
            {
                if (teleport.AssocRefObjID > 0)
                    cSpawns.Add(new Spawn(teleport));
            }
        }

        private void InitializeChars()
        {
            foreach (IChar ichar in ClientDataStorage.Database.SRO_VT_SHARD._Char.Values)
            {
                cSpawns.Add(Spawn.FromSpawn<Player>(new Spawn(ichar)));
            }
        }

        private void InitializeNest()
        {
            foreach (var nest in ClientDataStorage.Database.SRO_VT_SHARD.Tab_RefNest.Values)
            {
                var spawn = new Spawn(nest);
                if (!spawn.SpawnType.Equals(SpawnType.None))
                {
                    switch (spawn.SpawnType)
                    {
                        case SpawnType.Unique:
                        case SpawnType.Monster:
                            cSpawns.Add(FromSpawn<Monster>(spawn));
                            break;

                        case SpawnType.Npc:
                            cSpawns.Add(FromSpawn<Npc>(spawn));
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        #endregion Private Methods

    }
}