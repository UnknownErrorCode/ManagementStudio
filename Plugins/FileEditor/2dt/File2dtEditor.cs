using System;
using System.IO;
using System.Windows.Forms;

namespace FileEditor._2dt
{
    public partial class File2dtEditor : UserControl
    {

        private BinaryFiles.PackFile.Media.JMX2dtFile file;
        private string fileName;
        public File2dtEditor()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dir = new OpenFileDialog())
            {
                dir.Filter = "All files|*.*|2dt file|*.2dt";
                dir.Multiselect = false;
                dir.Title = "Select a 2dt file.";
                dir.ShowDialog();

                if (dir.FileName.Length > 0 && dir.FileName.EndsWith(".2dt"))
                {
                    var rawFile = File.ReadAllBytes(dir.FileName);
                    fileName = Path.GetFileName(dir.FileName);
                    file = new BinaryFiles.PackFile.Media.JMX2dtFile(rawFile, fileName);
                    propertyGrid1.SelectedObject = file;
                    toolStripButtonViewSelected2dt.Enabled = true;
                }
            }
        }

        private void toolStripButtonViewSelected2dt_Click(object sender, EventArgs e)
        {
            ViewerJMX2dt.Show(file, fileName);
        }
    }
}