using ClientDataStorage.Database;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMapSpawnEditor._2dMapViewer
{
    internal class Continent
    {
        string ContinentName { get; set; }

        internal Region[] Regions { get; set; }

        internal Continent(string name)
        {
            ContinentName = name;
            var allRegions = SRO_VT_SHARD.dbo.Tables["_RefRegion"].Rows.OfType<DataRow>().Where(row => row.Field<string>("ContinentName") == this.ContinentName).ToArray();
            Regions = new Region[allRegions.Length];

            for (int i = 0; i < Regions.Length; i++)
                Regions[i] = new Region(allRegions[i].Field<short>("wRegionID"));
        }
    }
}
