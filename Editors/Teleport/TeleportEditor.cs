using System.Windows.Forms;

namespace Editors.Teleport
{
    public partial class TeleportEditor : Form
    {
        private readonly SingleTeleport Teleport;
        public TeleportEditor(SingleTeleport teleport)
        {
            InitializeComponent();
            Teleport = teleport;
            propertyGridRefTeleLink.SelectedObject = Teleport;
            propertyGridRefTeleport.SelectedObject = Teleport.Teleport;
        }
    }
}
