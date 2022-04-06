using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileEditor.dof
{
    public partial class FileDofEditor : UserControl
    {
        private BinaryFiles.PackFile.Data.Dungeon.JMXdofFile file;

        public FileDofEditor()
        {
            InitializeComponent();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dir = new OpenFileDialog())
            {
                dir.Filter = "All files|*.*|dof file|*.dof";
                dir.Multiselect = false;
                dir.Title = "Select a dof file.";
                dir.ShowDialog();

                if (dir.FileName.Length == 0 || !dir.FileName.EndsWith(".dof"))
                {
                    return;
                }
                var rawFile = File.ReadAllBytes(dir.FileName);
                var fileName = Path.GetFileName(dir.FileName);
                file = new BinaryFiles.PackFile.Data.Dungeon.JMXdofFile(rawFile);
                propertyGrid1.SelectedObject = file;
            }
        }
    }
}