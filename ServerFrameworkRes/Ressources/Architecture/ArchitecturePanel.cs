using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerFrameworkRes.Ressources.ServerBody;
using ServerFrameworkRes.Network.AsyncNetwork;

namespace ServerFrameworkRes.Ressources.Architecture
{
    public partial class ArchitecturePanel : UserControl
    {

        private ArchitectureBody CertificationBody { get; set; }
        private Dictionary<string, ArchitectureBody> srNodeDataDictionary = new Dictionary<string, ArchitectureBody>();


        public ArchitecturePanel()
        {
            InitializeComponent();
        }
        public ArchitecturePanel(List<ArchitectureBody> listOfNodeDatas)
        {
            InitializeComponent();
            foreach (var item in listOfNodeDatas)
            {
                srNodeDataDictionary.Add(item.SelfBody.AccountName, item);
            }
        }


        private void InitializeArchitecture()
        {


        }


        private void showArchitectureTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point Certpoint = new Point(CertificationBody.Location.X + 70, CertificationBody.Location.Y);
            foreach (ArchitectureBody item2 in srNodeDataDictionary.Values)
            {
                if (item2.SelfBody.UserIP == "94.130.10.181")
                {
                    continue;
                }
                item2.Location = Certpoint;
                item2.pictureBoxCertification.Visible = true;
                item2.pictureBoxCertification.Image = CertificationBody.ServerBodyImages[ServerBodyState.None];
                Certpoint.Y += 50;
                this.Controls.Add(item2);
                Certpoint.Y = 20;
                Certpoint.X += 50;

            }
        }

        private void loadCertificationFromCertificationManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
