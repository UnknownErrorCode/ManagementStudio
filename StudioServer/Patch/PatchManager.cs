using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StudioServer.Patch
{
    public partial class PatchManager : Form
    {
        public PatchManager()
        {
            InitializeComponent();
            Initialize2ndComponent();

        }

        private void Initialize2ndComponent()
        {
            SuspendLayout();
            Text = $"Studio Server Version: [{StudioServer.settings.Version}]";
            listView1.Items.Clear();
            dataGridView1.DataSource = SQL.ReturnDataTable("SELECT * from _ToolUpdates ;", StudioServer.settings.DBDev);
            string[] AllFiles = Directory.GetFiles(StudioServer.settings.PatchFolderDirectory, "*", SearchOption.AllDirectories);
            FileCount.Text = $"Files to patch: {AllFiles.Length}";
            int size = 0;
            foreach (string item in AllFiles)
            {
                size += File.ReadAllBytes(item).Length;
                string nToBePatched = item.Remove(0, StudioServer.settings.PatchFolderDirectory.Length + 1);
                ListViewItem itemList = new ListViewItem(nToBePatched);

                listView1.Items.Add(itemList);
            }
            FileSize.Text = $"Total Size ={size / 1000} KB";
            ResumeLayout();
        }


        private void deleteFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems.OfType<ListViewItem>())
            {
                if (item.SubItems.Count == 0)
                {
                    if (File.Exists(Path.Combine(StudioServer.settings.PatchFolderDirectory, item.Text)))
                    {
                        File.Delete(Path.Combine(StudioServer.settings.PatchFolderDirectory, item.Text));
                    }
                }
                else
                {
                    if (File.Exists(Path.Combine(StudioServer.settings.PatchFolderDirectory, item.Text)))
                    {
                        Directory.Delete(Path.Combine(StudioServer.settings.PatchFolderDirectory, item.Text), true);
                    }
                }
            }
            Initialize2ndComponent();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Initialize2ndComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Initialize2ndComponent();
            listView1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            Initialize2ndComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PatchProces.Exaggurate();
            button3_Click(sender, e);
        }
    }
}
