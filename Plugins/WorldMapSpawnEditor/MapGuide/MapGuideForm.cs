using System.Drawing;
using System.Windows.Forms;

namespace WorldMapSpawnEditor.MapGuide
{
    public partial class MapGuideForm : Form
    {
        #region Fields

        private readonly MapGuidePanel GuidePanel = new MapGuidePanel() { Location = new Point(42, 72) };

        #endregion Fields

        #region Constructors

        public MapGuideForm()
        {
            InitializeComponent();
            vSroSizableWindow1.Controls.Add(GuidePanel);
        }

        #endregion Constructors
    }
}