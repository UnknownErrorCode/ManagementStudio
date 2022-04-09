using System;
using System.IO;
using System.Windows.Forms;

namespace FileEditor._2dt
{
    public partial class File2dtEditor : UserControl
    {
        internal static PackFile.Media.Textdata.TextUISystem TextUISystem;
        private ViewerJMX2dt editor;
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

                if (dir.FileName.Length == 0 || !dir.FileName.EndsWith(".2dt"))
                {
                    return;
                }
                var rawFile = File.ReadAllBytes(dir.FileName);
                fileName = Path.GetFileName(dir.FileName);
                file = new BinaryFiles.PackFile.Media.JMX2dtFile(rawFile, fileName);
                editor = new ViewerJMX2dt(file, fileName);
                splitContainer2dt.Panel2.Invalidate();
                propertyGrid1.SelectedObject = file;
                toolStripButtonViewSelected2dt.Enabled = true;
            }
        }

        private void toolStripButtonViewSelected2dt_Click(object sender, EventArgs e)
        {
            ViewerJMX2dt.Show(file, fileName);
        }

        private void splitContainer2dt_Panel2_Paint(object sender, PaintEventArgs e)
        {
            editor?.EditorJMX2dt_Paint(e.Graphics);
        }

        private void toolStripButtonLoadResinfo_Click(object sender, EventArgs e)
        {
        }

        private void Loading(object sender, EventArgs e)
        {
            if (!PackFile.MediaPack.GetTextUISystem(out TextUISystem))
                ManagementFramework.Log.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.warning, "Failed to get textuiSystem.txt");

            if (!PackFile.PackFileManager.ExtractIfInterfaces())
                ManagementFramework.Log.Logger.WriteLogLine(ManagementFramework.Ressources.LogLevel.warning, "Failed to get resinfo interface files");
        }
    }
}