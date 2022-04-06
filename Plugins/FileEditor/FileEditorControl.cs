using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileEditor
{
    public partial class FileEditorControl : UserControl
    {
        private TabControl tabControl = new TabControl() { Dock = DockStyle.Fill };
        private _2dt.File2dtEditor InterfaceEditor;
        private dof.FileDofEditor DungeonFileEditor;

        public FileEditorControl()
        {
            InitializeComponent();
            InterfaceEditor = new _2dt.File2dtEditor() { Dock = DockStyle.Fill };
            DungeonFileEditor = new dof.FileDofEditor() { Dock = DockStyle.Fill };
            var page = new TabPage("*.2dt");
            var page2 = new TabPage("*.dof");
            page.Controls.Add(InterfaceEditor);
            page2.Controls.Add(DungeonFileEditor);
            tabControl.TabPages.Add(page);
            tabControl.TabPages.Add(page2);

            Controls.Add(tabControl);
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
        }
    }
}