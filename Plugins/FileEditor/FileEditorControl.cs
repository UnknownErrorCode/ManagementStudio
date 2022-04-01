using System.IO;
using System.Windows.Forms;

namespace FileEditor
{
    public partial class FileEditorControl : UserControl
    {
        #region Constructors

        public FileEditorControl()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void vSroSmallButton1_vSroClickEvent()
        {
        }

        #endregion Methods

        private void loadToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            using (OpenFileDialog dir = new OpenFileDialog())
            {
                dir.Filter = "All files|*.*|Mesh file |*.m| Object file |*.o2| Dungeon file |*.dof| IndexFormat |*.ifo| All supported txt formats|*.txt";
                dir.InitialDirectory = ClientDataStorage.Config.StaticConfig.ClientExtracted;
                dir.Multiselect = false;
                dir.Title = "Select supported JMX File formats.";
                dir.ShowDialog();
                if (dir.FileName.Length > 0)
                {
                    var rawFile = File.ReadAllBytes(dir.FileName);
                    BinaryFiles.PackFile.Data.Dungeon.DungeonFile file = new BinaryFiles.PackFile.Data.Dungeon.DungeonFile(rawFile);
                    propertyGrid1.SelectedObject = file;
                }
            }


        }
    }
}