using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriggerEditor.Category
{
    public class GameWorldProperty
    {
        public List<Structs.Database.RefTriggerCategory> cat;
        public List<Structs.Database.RefGameWorldBindTriggerCategory> bcat;

        public GameWorldProperty()
        {
            cat = new List<Structs.Database.RefTriggerCategory>();
            bcat = new List<Structs.Database.RefGameWorldBindTriggerCategory>();
        }

    }
}
