
using System.Windows.Forms;

namespace ServerFrameworkRes.BasicControls
{
    public partial class vSroEditor : Form
    {
        public vSroEditor(object o)
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = o;
        }
    }
}
