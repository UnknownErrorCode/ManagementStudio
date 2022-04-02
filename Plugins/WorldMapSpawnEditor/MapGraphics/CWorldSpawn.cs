using Structs.Database;
using Structs.Tool;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WorldMapSpawnEditor.MapGraphics.Interface;

namespace WorldMapSpawnEditor.MapGraphics
{
    /// <summary>
    /// Holds an <see cref="IEnumerable{T} "/> of <see cref="Spawn"/> from inherited <see cref="InterfaceSpawn"/>
    /// </summary>
    internal class CWorldSpawn : IEnumerable<InterfaceSpawn>
    {
        #region Fields

        private readonly List<InterfaceSpawn> cSpawns = new List<InterfaceSpawn>();
        private readonly List<InterfaceSpawn> pSpawns = new List<InterfaceSpawn>();

        #endregion Fields

        #region Constructors

        internal CWorldSpawn() =>
            Initialize();

        #endregion Constructors

        #region Methods

        public IEnumerator<InterfaceSpawn> GetEnumerator()
        {
            var mobSpawns = cSpawns.ToList();
            mobSpawns.AddRange(pSpawns.ToArray());
            return mobSpawns.GetEnumerator();
        }

        public IEnumerator<InterfaceSpawn> GetEnumerator(ushort wRegionID) => cSpawns.Where(s => s.RegionID.RegionID.Equals(wRegionID)).GetEnumerator();

        public IEnumerator<InterfaceSpawn> GetEnumerator(int gameWorldID) => cSpawns.Where(s => s.GameWorldID.Equals(gameWorldID)).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<InterfaceSpawn> GetPlayer(ushort wRegionID) => pSpawns.Where(s => s.RegionID.RegionID.Equals(wRegionID)).GetEnumerator();

        internal InterfaceSpawn FromSpawn<T>(Spawn spawn) where T : class
            => (InterfaceSpawn)System.Activator.CreateInstance(typeof(T), spawn.ID);

        internal void Initialize()
        {
            cSpawns.Clear();
            InitializeNest();
            InitializeChars();
            InitializeTeleports();
        }

        private void InitializeChars()
        {
            foreach (IChar ichar in ClientFrameworkRes.Database.SRO_VT_SHARD._Char.Values)
            {
                pSpawns.Add(Spawn.FromSpawn<Player>(new Spawn(ichar)));
            }
        }

        private void InitializeNest()
        {
            foreach (var nest in ClientFrameworkRes.Database.SRO_VT_SHARD.Tab_RefNest.Values)
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

        private void InitializeTeleports()
        {
            foreach (RefTeleport teleport in ClientFrameworkRes.Database.SRO_VT_SHARD._RefTeleport.Values)
            {
                if (teleport.AssocRefObjID > 0)
                    cSpawns.Add(new Spawn(teleport));
            }
        }

        #endregion Methods
    }
}