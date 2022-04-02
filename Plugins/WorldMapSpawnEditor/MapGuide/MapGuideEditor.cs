using System.Windows.Forms;

namespace WorldMapSpawnEditor.MapGuide
{
    public partial class MapGuideEditor : Form
    {
        public MapGuideEditor()
        {
            InitializeComponent();
        }
        internal MapGuideEditor(MapGuidePanel panel)
        {
            InitializeComponent();
            panel.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(panel);
        }
    }
}
