using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldMapSpawnEditor.MapGuide
{
    public partial class MapGuideForm : Form
    {

        MapGuidePanel GuidePanel = new MapGuidePanel() { Location = new Point(42, 72) };
        public MapGuideForm()
        {
            InitializeComponent();
            this.vSroSizableWindow1.Controls.Add(GuidePanel);
        }
    }
}
