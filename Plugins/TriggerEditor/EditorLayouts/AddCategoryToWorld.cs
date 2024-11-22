using Structs.Database;
using System;
using System.Linq;
using System.Windows.Forms;

namespace TriggerEditor.EditorLayouts
{
    public partial class UCAddCategoryToWorld : UserControl
    {
        private RefGame_World world;
        private string TriggerCategoryName { get => comboBoxAddCategoryToWorld.Text; }

        public UCAddCategoryToWorld()
        {
            InitializeComponent();
        }

        public UCAddCategoryToWorld(RefGame_World _world)
        {
            world = _world;
            InitializeComponent();
            labelWorldName.Text = world.WorldCodeName128;
        }

        private void buttonAddCategoryToWorld_Click(object sender, EventArgs e)
        {
            // Check for duplicate category names
            if (PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategory.Values.Any(cat => cat.CodeName128 == TriggerCategoryName))
            {
                MessageBox.Show("Category name already exists. Please use a unique name.", "Duplicate Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var count = PluginFramework.Database.SRO_VT_SHARD._RefGameWorldBindTriggerCategory.Values
        .Where(bind => bind.GameWorldID == world.ID && bind.Service == 1)
        .Select(bind => bind.TriggerCategoryID)
         .Distinct()
        .ToList();
            // Calculate next index
            int nextIndex = PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategory.Values
                .Where(cat => PluginFramework.Database.SRO_VT_SHARD._RefGameWorldBindTriggerCategory.Values
                    .Any(bind => bind.GameWorldID == world.ID && bind.TriggerCategoryID == cat.ID && bind.Service == 1))
                .Select(cat => cat.IndexNumber)
                .DefaultIfEmpty(0)
                .Max();

            // Create new category
            RefTriggerCategory newCategory = new RefTriggerCategory
            {
                CodeName128 = TriggerCategoryName,
                Service = 1,
                IndexNumber = nextIndex,
                ObjName128 = textBoxAddCategoryComment.Text,
                ID = 0 // New category
            };

            // Send Add Category Packet
            PluginFramework.ClientCore.Send(TriggerEditor.PacketFormat.TriggerEditorPacket.AddRefTriggerCategory(newCategory, world.ID));

            MessageBox.Show($"Category '{newCategory.CodeName128}' successfully added and linked to '{world.WorldCodeName128}'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBoxAddCategoryToWorld_TextChanged(object sender, EventArgs e)
            => CheckInput();

        private void CheckInput()
        {
            buttonAddCategoryToWorld.Enabled = !string.IsNullOrWhiteSpace(comboBoxAddCategoryToWorld.Text) &&
                           comboBoxAddCategoryToWorld.Text.StartsWith("TRI_CATEGORY_") &&
                           textBoxAddCategoryComment.Text.Length > 0;
        }

        private void textBoxAddCategoryComment_TextChanged(object sender, EventArgs e)
        {
            CheckInput();
        }
    }
}