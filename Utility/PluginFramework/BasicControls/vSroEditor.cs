using System.Windows.Forms;

namespace PluginFramework.BasicControls
{
    public partial class vSroEditor : Form
    {
        #region Constructors

        public vSroEditor(object o)
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = o;
        }

        #endregion Constructors
    }
}