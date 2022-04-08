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

        /// <summary>
        /// Consists of all RegionGraphics on the WorldMap that does not existing in the DB but -m file is aviable.
        /// </summary>
        internal Dictionary<Point, RegionGraphic> UnassignedRegions;

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
                    if (continent.HasDungeon && !Dungeons.ContainsKey(item.AreaName))
                        Dungeons.Add(item.ContinentName, continent.DungeonArray);

                    Continents.Add(item.ContinentName, continent);
                }
            }

            //Add images which are not present inside the database

            UnassignedRegions = new Dictionary<Point, RegionGraphic>();

            Point p = Point.Empty;
            if (PackFile.MediaPack.Reader.GetFilesInFolder("Media\\minimap", out PackFile.Pk2File[] files))
            {
                foreach (var item in files)
                {
                    var name = item.name.ToLower().Replace(".ddj", "").Split('x');
                    if (byte.TryParse(name[0], out byte x) && byte.TryParse(name[1], out byte z))
                    {
                        p.X = x;
                        p.Y = z;
                        if (!ContinentsContainsRegion(p))
                        {
                            var regLayer = new RegionGraphic(Structs.WRegionID.GetRegionID(x, z), "Unassigned", "Unassigned");
                            if (regLayer.HasLayer)
                            {
                                UnassignedRegions.Add(p, regLayer);
                            }
                        }
                    }
                }
            }

            System.GC.Collect();
        }

        #endregion Constructors

        #region Methods

        internal bool ContinentsContainsRegion(Point p)
        {
            return Continents.Values.Any(cont => cont.ContainsRegion(p));
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

        internal IEnumerable<RegionGraphic> UnassignedRegionsSpan(Rectangle span)
        {
            List<RegionGraphic> list = new List<RegionGraphic>();
            Point curserPoint = Point.Empty;
            for (int x = span.X; x < span.Width; x++)
            {
                for (int z = span.Height; z < span.Y; z++)
                {
                    curserPoint.X = x;
                    curserPoint.Y = z;
                    if (UnassignedRegions.ContainsKey(curserPoint))
                    {
                        list.Add(UnassignedRegions[curserPoint]);
                    }
                }
            }
            return list;
        }

        #endregion Methods
    }
}