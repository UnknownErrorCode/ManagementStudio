using System.Drawing;
using System.Windows.Forms;

namespace WorldMapSpawnEditor.MapGuide
{
    public partial class MapGuideForm : Form
    {
        #region Fields

        private readonly MapGuidePanel GuidePanel = new MapGuidePanel() { Location = new Point(35, 70) };

        private readonly WMapGuidePanelButtonFocus ButtonFocus = new WMapGuidePanelButtonFocus();

        #endregion Fields

        #region Constructors

        public MapGuideForm()
        {
            InitializeComponent();
            vSroSizableWindow1.Controls.Add(GuidePanel);

            if (ButtonFocus.Initialized)
            {
                ButtonFocus.OnParentMouseClick += OnmouseClick;
                Controls.Add(ButtonFocus);
            }
        }

        private void OnmouseClick()
        {
            GuidePanel.ViewPoint = Point.Empty;
        }

        #endregion Constructors
    }
}