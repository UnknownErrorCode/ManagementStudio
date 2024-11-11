using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerEditor.Category
{
    public class GameWorldProperty
    {
        public Dictionary<int,Structs.Database.RefTriggerCategory> cat;
        public List<Structs.Database.RefGameWorldBindTriggerCategory> bcat;

        public GameWorldProperty()
        {
            cat = new Dictionary<int,Structs.Database.RefTriggerCategory>();
            bcat = new List<Structs.Database.RefGameWorldBindTriggerCategory>();
        }

    }
}
