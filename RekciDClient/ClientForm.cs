using ServerFrameworkRes.Ressources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RekciDClient
{
    public partial class ClientForm : Form
    {
        internal static LogGridView Logger = new LogGridView() { Dock = DockStyle.Bottom};
        public ClientForm()
        {
            InitializeComponent();
            this.Controls.Add(Logger);
            Logger.WriteLogLine("Successfully initialized!");
        }
    }
}
