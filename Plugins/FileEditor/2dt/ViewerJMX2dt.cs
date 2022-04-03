using BinaryFiles.PackFile.Media;
using System.Drawing;
using System.Windows.Forms;

namespace FileEditor
{
    public partial class ViewerJMX2dt : Form
    {
        _2dt.Graphics2dt g;

        public ViewerJMX2dt(JMX2dtFile file, string name)
        {
            InitializeComponent();
            Text = name;
            g = new _2dt.Graphics2dt(file);
            Width = g.maxX;
            Height = g.maxY;

        }

        private void EditorJMX2dt_Paint(object sender, PaintEventArgs e) => EditorJMX2dt_Paint(e.Graphics);

        public void EditorJMX2dt_Paint(Graphics g) => this.g.EditorJMX2dt_Paint(g);


        internal static void Show(JMX2dtFile file, string item) => System.Threading.Tasks.Task.Run(() =>
                                                                 {
                                                                     using (ViewerJMX2dt e = new ViewerJMX2dt(file, item))
                                                                     {
                                                                         e.ShowDialog();
                                                                     }
                                                                 });
    }
}