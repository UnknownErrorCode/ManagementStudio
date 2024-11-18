using Structs.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriggerEditor.EditorLayouts
{
    public partial class UserControlAddCategoryToWorld : UserControl
    {
        private int worldID = 0;
        private string triggerCategoryName = "";
        private string categoryDesc = "";

        public UserControlAddCategoryToWorld()
        {
            InitializeComponent();
        }

        public UserControlAddCategoryToWorld(RefGame_World world)
        {
            InitializeComponent();
            labelWorldName.Text =world.WorldCodeName128;
        }

        private void buttonAddCategoryToWorld_Click(object sender, EventArgs e)
        {
            if (PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategory.Values.Any(cat => cat.CodeName128 == comboBoxAddCategoryToWorld.Text))
                return;
        }
    }
}
