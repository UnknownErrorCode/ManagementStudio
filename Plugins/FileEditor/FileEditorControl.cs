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
                //dir.InitialDirectory = ClientFrameworkRes.Config.StaticConfig.ClientExtracted;
                dir.Multiselect = true;
                dir.Title = "Select supported JMX File formats.";
                dir.ShowDialog();

                foreach (var item in dir.FileNames)
                {
                    if (item.Length > 0)
                    {
                        var rawFile = File.ReadAllBytes(item);
                        if (item.EndsWith(".dof"))
                        {
                            BinaryFiles.PackFile.Data.Dungeon.JMXdofFile file = new BinaryFiles.PackFile.Data.Dungeon.JMXdofFile(rawFile);
                            //propertyGrid1.SelectedObject = file;
                            return;
                        }
                        else if (item.EndsWith(".bsr"))
                        {
                            BinaryFiles.PackFile.Data.bsr.JMXbsrFile file = new BinaryFiles.PackFile.Data.bsr.JMXbsrFile(rawFile);
                            //propertyGrid1.SelectedObject = file;
                            return;
                        }
                        else if (item.EndsWith(".2dt"))
                        {
                            BinaryFiles.PackFile.Media.JMX2dtFile file = new BinaryFiles.PackFile.Media.JMX2dtFile(rawFile, Path.GetFileName(dir.FileName));
                            //propertyGrid1.SelectedObject = file;
                            ViewerJMX2dt.Show(file, item);

                        }
                        else if (item.EndsWith(".m"))
                        {
                            BinaryFiles.PackFile.Map.m.JMXmFile file = new BinaryFiles.PackFile.Map.m.JMXmFile(rawFile);
                            //propertyGrid1.SelectedObject = file;
                            return;
                        }
                        else if (item.EndsWith(".o"))
                        {
                            BinaryFiles.PackFile.Map.o2.JMXo2File file = new BinaryFiles.PackFile.Map.o2.JMXo2File(rawFile, true);
                            //propertyGrid1.SelectedObject = file;
                            return;
                        }
                        else if (item.EndsWith(".o2"))
                        {
                            BinaryFiles.PackFile.Map.o2.JMXo2File file = new BinaryFiles.PackFile.Map.o2.JMXo2File(rawFile, false);
                            //propertyGrid1.SelectedObject = file;
                            return;
                        }
                    }

                }
            }
        }
    }
}