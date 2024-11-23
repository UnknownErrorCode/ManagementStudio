using Structs.Database;
using System.Windows.Forms;

namespace TriggerEditor.EditorLayouts
{
    public partial class AddEventToTrigger : UserControl
    {
        private RefTriggerBindEvent RefTriggerBindEvent;
        private RefTrigger RefTrigger;
        private RefTriggerEvent refTriggerEvent;

        public AddEventToTrigger()
        {
            InitializeComponent();
            InitializeUI();
        }

        public AddEventToTrigger(RefTrigger refTrigger)
        {
            RefTrigger = refTrigger;
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            foreach (var item in PluginFramework.Database.SRO_VT_SHARD._RefTriggerCommon.Values)
            {
                if (item.CodeName128.StartsWith("TRIGGER_EVENT_"))
                    treeView1.Nodes.Add(new TreeNode(item.CodeName128) { Tag = item });
            }
            treeView1.Nodes[0].Checked = true;
            refTriggerEvent = new RefTriggerEvent()
            {
                RefTriggerCommonID = 1,
                Service = 1,
            };

            button1.Enabled = false;
            propertyGrid1.SelectedObject = this.refTriggerEvent;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            refTriggerEvent.RefTriggerCommonID = ((RefTriggerCommon)treeView1.SelectedNode.Tag).ID;
            propertyGrid1.SelectedObject = refTriggerEvent;
        }
    }
}