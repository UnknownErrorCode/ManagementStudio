using Structs.Database;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class CWorld
    {
        #region Fields

        internal Dictionary<string, Continent> Continents;
        internal Dictionary<string, Dungeon[]> Dungeons;
        Continent UnassignedRegions;

        #endregion Fields

        #region Constructors

        public CWorld(IEnumerable<RefRegion> allRegions)
        {
            Continents = new Dictionary<string, Continent>();
            Dungeons = new Dictionary<string, Dungeon[]>();
            foreach (var item in allRegions)
            {
                if (!Continents.ContainsKey(item.ContinentName))
                {
                    var continent = new Continent(item.ContinentName, allRegions.Where(reg => reg.ContinentName == item.ContinentName).ToArray());
                    if (!Dungeons.ContainsKey(item.AreaName) && continent.HasDungeon)
                    {
                        Dungeons.Add(item.ContinentName, continent.GetDungeons());
                    }
                    Continents.Add(item.ContinentName, continent);
                }
            }
        }

        #endregion Constructors

        #region Methods

        internal bool ContainsRegion(Point p)
        {
            foreach (var item in Continents.Values)
            {
                if (item.ContainsRegion(p))
                {
                    return true;
                }
            }
            Continents.Values.ToList().Exists(c => c.ContainsRegion(p));
            return false;
        }

        internal bool GetContinentView(string continent, int width, int height, out Point viewPoint, out int size)
        {
            viewPoint = Point.Empty;
            size = 128;
            if (!Continents.ContainsKey(continent))
                return false;

            Continents[continent].GetView(width, height, out int x, out int y, out size);

            viewPoint.X = x;
            viewPoint.Y = y;
            return true;
        }

        #endregion Methods
    }
}