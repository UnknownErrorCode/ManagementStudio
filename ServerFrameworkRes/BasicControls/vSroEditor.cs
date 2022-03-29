using System.Windows.Forms;

namespace ServerFrameworkRes.BasicControls
{
    public partial class vSroEditor : Form
    {
        #region Public Constructors

        public vSroEditor(object o)
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = o;
        }

        #endregion Public Constructors
    }
}