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
                dir.Filter = "All files|*.*|Mesh file|*.m|Ressource file|*.bsr| Object file |*.o2| Dungeon file |*.dof| IndexFormat |*.ifo| All supported txt formats|*.txt";
                dir.InitialDirectory = ClientFrameworkRes.Config.StaticConfig.ClientExtracted;
                dir.Multiselect = false;
                dir.Title = "Select supported JMX File formats.";
                dir.ShowDialog();
                if (dir.FileName.Length > 0)
                {
                    var rawFile = File.ReadAllBytes(dir.FileName);
                    if (dir.FileName.EndsWith(".dof"))
                    {
                        BinaryFiles.PackFile.Data.Dungeon.JMXdofFile file = new BinaryFiles.PackFile.Data.Dungeon.JMXdofFile(rawFile);
                        propertyGrid1.SelectedObject = file;
                    }
                    else if (dir.FileName.EndsWith(".bsr"))
                    {
                        BinaryFiles.PackFile.Data.bsr.JMXbsrFile file = new BinaryFiles.PackFile.Data.bsr.JMXbsrFile(rawFile);
                        propertyGrid1.SelectedObject = file;
                    }

                }
            }
        }
    }
}