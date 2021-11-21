using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editors.Teleport
{
    public partial class TeleportEditor : Form
    {
        private SingleTeleport Teleport;
        public TeleportEditor(SingleTeleport teleport)
        {
            InitializeComponent();
            Teleport = teleport;
            propertyGridRefTeleLink.SelectedObject = Teleport;
            propertyGridRefTeleport.SelectedObject = Teleport.Teleport;
        }
    }
}
