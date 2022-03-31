using Structs.Database;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class CWorld
    {
        #region Internal Fields

        internal Dictionary<string, Continent> Continents;

        #endregion Internal Fields

        #region Public Constructors

        public CWorld(IEnumerable<RefRegion> allRegions)
        {
            Continents = new Dictionary<string, Continent>();
            foreach (var item in allRegions)
            {
                if (!Continents.ContainsKey(item.ContinentName))
                {
                    Continents.Add(item.ContinentName, new Continent(allRegions.Where(reg => reg.ContinentName == item.ContinentName).ToArray()));
                }
            }
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

        internal bool ContainsRegion(Point p)
        {
            foreach (var item in Continents.Values)
            {
                if (item.ContainsRegion(p))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion Public Constructors
    }
}