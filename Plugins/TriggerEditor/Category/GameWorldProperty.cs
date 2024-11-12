using Structs.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerEditor.Category
{
    public class GameWorldProperty
    {
        public RefGame_World refGame_World;
        public List<RefGameWorldBindTriggerCategory> bcat;
        public Dictionary<RefTriggerCategory, RefTrigger[]> cat;

        public List<RefTriggerCategoryBindTrigger> bct;

        public List<RefTrigger> _t;


        public GameWorldProperty()
        {
            
            cat = new Dictionary<RefTriggerCategory, RefTrigger[]>();
            bcat = new List<Structs.Database.RefGameWorldBindTriggerCategory>();
            bct = new List<Structs.Database.RefTriggerCategoryBindTrigger>();
            _t = new List<Structs.Database.RefTrigger> ();
        }
        public GameWorldProperty(RefGame_World world)
        {
            refGame_World = world;
            bcat = new List<RefGameWorldBindTriggerCategory>();
            cat = new Dictionary<RefTriggerCategory, RefTrigger[]>();
            bct = new List<RefTriggerCategoryBindTrigger>();
            _t = new List<RefTrigger>();

            if (PluginFramework.Database.SRO_VT_SHARD._RefGameWorldBindTriggerCategory.Any(bgc => bgc.Value.GameWorldID==world.ID))
            {
               

                var collection = PluginFramework.Database.SRO_VT_SHARD._RefGameWorldBindTriggerCategory.Where(bindCat => bindCat.Value.GameWorldID == world.ID);
                foreach (var categ in collection)
                {
                    bcat.Add(categ.Value);
                    var category =PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategory.Single(ct => ct.Value.ID == categ.Value.TriggerCategoryID).Value;
                    
                    List<RefTrigger> list = new List<RefTrigger>();
                    if (PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategoryBindTrigger.Values.Any(cbt => cbt.TriggerCategoryID == categ.Value.TriggerCategoryID))
                    {
                        foreach (var bindCatTrigger in PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategoryBindTrigger.Values.Where(cbt => cbt.TriggerCategoryID == categ.Value.TriggerCategoryID))
                        {
                            list.Add(PluginFramework.Database.SRO_VT_SHARD._RefTrigger.Values.Single(tr => tr.ID == bindCatTrigger.TriggerID));
                        }
                    }

                    cat.Add(category, list.ToArray());

                }
            }
        }
    }
}
