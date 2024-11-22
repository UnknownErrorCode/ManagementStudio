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
            button1.Text = $"Add new Trigger to Category '{_categoryLink.CodeName128}'.";
            button1.Enabled = false;
            var count = PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategoryBindTrigger.Values
     .Where(bind => bind.TriggerCategoryID == categoryLink.ID && bind.Service == 1)
     .Select(bind => bind.TriggerCategoryID)
      .Distinct()
     .ToList();

            var trigger = new RefTrigger()
            {
                Service = 1,
                CodeName128 = "TRI_",
                IsActive = 1,
                IsRepeat = 0,
                Comment512 = "<any info>",
                IndexNumber = count.Count,
            };
            propertyGrid1.SelectedObject = trigger;
        }

        public AddTriggerToCategory(RefTriggerCategory _categoryLink, RefTrigger _trigger)
        {
            categoryLink = _categoryLink;
            InitializeComponent();
            button1.Text = $"Linking Trigger: {_trigger.CodeName128} to Category '{_categoryLink.CodeName128}'.";

            var count = PluginFramework.Database.SRO_VT_SHARD._RefTriggerCategoryBindTrigger.Values
     .Where(bind => bind.TriggerCategoryID == categoryLink.ID && bind.Service == 1)
     .Select(bind => bind.TriggerCategoryID)
      .Distinct()
     .ToList();

            if (_trigger.IndexNumber != count.Count)
            {
                MessageBox.Show("input okay");

            }
            propertyGrid1.SelectedObject = _trigger;
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

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            RefTrigger trigger = (RefTrigger)propertyGrid1.SelectedObject;
            button1.Enabled = (trigger.CodeName128 != "TRI_" && trigger.CodeName128.Length > 0 &&
                trigger.Comment512.Length > 0);
        }
    }
}