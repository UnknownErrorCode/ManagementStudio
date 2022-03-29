using System.Drawing;
using System.Windows.Forms;

namespace WorldMapSpawnEditor.MapGuide
{
    public partial class MapGuideForm : Form
    {
        readonly MapGuidePanel GuidePanel = new MapGuidePanel() { Location = new Point(42, 72) };
        public MapGuideForm()
        {
            InitializeComponent();
            vSroSizableWindow1.Controls.Add(GuidePanel);
        }
    }
}
