using Structs.Database;
using System.Linq;
using System.Windows.Forms;
using TriggerEditor.PacketFormat;

namespace TriggerEditor.EditorLayouts
{
    public partial class AddTriggerToCategory : UserControl
    {
        private RefTriggerCategory categoryLink;

        public AddTriggerToCategory()
        {
            InitializeComponent();
            var trigger = new RefTrigger()
            {
                Service = 1,
                //ID = 0,
                CodeName128 = "TRI_",
                IsActive = 1,
                IsRepeat = 0,
                Comment512 = "<any info>",
                IndexNumber = 0,
            };
            propertyGrid1.SelectedObject = trigger;
        }

        public AddTriggerToCategory(RefTriggerCategory _categoryLink)
        {
            categoryLink = _categoryLink;
            InitializeComponent();

            var count = PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategoryBindTrigger.Values
     .Where(bind => bind.TriggerCategoryID == categoryLink.ID && bind.Service == 1)
     .Select(bind => bind.TriggerCategoryID)
      .Distinct()
     .ToList();

            var trigger = new RefTrigger()
            {
                Service = 1,
                //ID = 0,
                CodeName128 = "TRI_",
                IsActive = 1,
                IsRepeat = 0,
                Comment512 = "<any info>",
                IndexNumber = count.Count,
            };
            propertyGrid1.SelectedObject = trigger;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            RefTrigger trigger = (RefTrigger)propertyGrid1.SelectedObject;
            if (trigger.CodeName128 != "TRI_" && trigger.CodeName128.Length > 0 &&
                trigger.Comment512.Length > 0)
            {
                MessageBox.Show("input okay");

                PluginFramework.ClientCore.Send(TriggerEditorPacket.AddRefTrigger(trigger, categoryLink.ID));
            }
        }
    }
}