using Structs.Database;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WorldMapSpawnEditor.MapGraphics
{
    internal class Continent
    {

        internal readonly string ContinentName;

        internal readonly int minX = 255
                                    , minY = 255
                            , maxX = 0
                            , maxY = 0;


        /// <summary>
        /// Each dungeon on the continent.
        /// </summary>
        private readonly Dictionary<short, Dungeon> Dungeons = new Dictionary<short, Dungeon>();

        /// <summary>
        /// Regions which X and Z from Database are not equal to wRegion x n z.
        /// </summary>
        private readonly Dictionary<short, RegionGraphic> ErrorRegions = new Dictionary<short, RegionGraphic>();

        /// <summary>
        /// Consists of all RegionGraphics on the WorldMap existing in the DB.
        /// </summary>
        private readonly Dictionary<Point, RegionGraphic> Regions = new Dictionary<Point, RegionGraphic>();

        public Continent(string continentname, RefRegion[] enumerable)
        {
            ContinentName = continentname;
            var pointer = Point.Empty;
            for (int i = 0; i < enumerable.Length; i++)
            {
                var region = new RegionGraphic(enumerable[i].wRegionID, enumerable[i].AreaName);
                pointer.X = region.RegionID.X;
                pointer.Y = region.RegionID.Z;

                if (!region.RegionID.IsDungeon && (pointer.X != enumerable[i].X || pointer.Y != enumerable[i].Z))
                    ErrorRegions.Add(enumerable[i].wRegionID, region);
                else
                {
                    try
                    {
                        if (region.RegionID.IsDungeon)
                            Dungeons.Add(enumerable[i].wRegionID, new Dungeon(continentname, enumerable[i].wRegionID));
                        else
                        {
                            minX = minX > pointer.X ? pointer.X : minX;
                            minY = minY > pointer.Y ? pointer.Y : minY;

                            maxX = maxX < pointer.X ? pointer.X : maxX;
                            maxY = maxY < pointer.Y ? pointer.Y : maxY;

                            Regions.Add(pointer, region);
                        }
                    }
                    catch (System.Exception e)
                    {
                        ErrorRegions.Add(enumerable[i].wRegionID, region);
                        ServerFrameworkRes.Log.Logger.WriteLogLine(e, "Catches wrong region.");
                    }
                }
            }
            if (ErrorRegions.Count > 0)
                ServerFrameworkRes.Log.Logger.WriteLogLine(ServerFrameworkRes.Ressources.LogLevel.warning, $"Loaded {ErrorRegions.Count} wrong regions at continent {continentname}.");
        }
        /// <summary>
        /// Indicates weather the Continent contains a dungeon or not.
        /// </summary>
        public bool HasDungeon => Dungeons?.Count > 0;

        /// <summary>
        /// Gets all dungeons from the dictionary.
        /// </summary>
        internal Dungeon[] DungeonArray => Dungeons?.Values.ToArray();

        /// <summary>
        /// Indicates weather the Continent contains a region or not.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        internal bool ContainsRegion(Point p)
             => Regions.ContainsKey(p);

        /// <summary>
        /// Get all regions that intersects with the rectangle.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        internal IEnumerable<RegionGraphic> GetRegions(Rectangle range)
        {
            var list = new List<RegionGraphic>();
            foreach (var item in Regions.Keys) // x n Z from DBRegion
            {
                if (item.X >= range.X && item.X <= range.X + range.Width)
                {
                    if (item.Y <= range.Y && item.Y >= range.Y - range.Height)
                    {
                        list.Add(Regions[item]);
                    }
                }
            }
            foreach (var ereg in ErrorRegions.Values)
            {
                if (ereg.RegionID.X >= range.X && ereg.RegionID.X <= range.X + range.Width)
                {
                    if (ereg.RegionID.Z <= range.Y && ereg.RegionID.Z >= range.Y - range.Height)
                    {
                        list.Add(ereg);
                    }
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// Get view position of the continent.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="picSize"></param>
        internal void GetView(int width, int height, out int x, out int y, out int picSize)
        {
            var rangeX = maxX - minX;
            var rangeY = maxY - minY;

            var rel1 = width / rangeX;
            var rel2 = height / rangeY;

            picSize = rel1 < rel2 ? rel1 : rel2;
            picSize = picSize < 15 ? 15 : picSize;
            x = -minX * picSize;
            y = (maxY * picSize) - (128 * picSize) + picSize;
        }

    }
}