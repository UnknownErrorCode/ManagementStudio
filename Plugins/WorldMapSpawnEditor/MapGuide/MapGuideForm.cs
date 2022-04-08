using System.Drawing;
using System.Windows.Forms;

namespace WorldMapSpawnEditor.MapGuide
{
    public partial class MapGuideForm : Form
    {
        #region Fields

        private readonly MapGuidePanel GuidePanel;
        private readonly WMapGuidePanelButtonFocus ButtonFocus = new WMapGuidePanelButtonFocus();
        private LoadingForm Loading = new LoadingForm();

        #endregion Fields

        #region Constructors

        public MapGuideForm()
        {
            InitializeComponent();
            Loading.Show();
            GuidePanel = new MapGuidePanel() { Location = new Point(35, 70) };

            if (ButtonFocus.Initialized)
            {
                ButtonFocus.OnParentMouseClick += OnmouseClick;
                GuidePanel.Controls.Add(ButtonFocus.Button);
            }
            vSroSizableWindow1.Controls.Add(GuidePanel);

            Loading.Hide();
        }

        private void OnmouseClick()
        {
            GuidePanel.ViewPoint = Point.Empty;
        }

        #endregion Constructors

        private void MapGuideForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}