using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using System.IO;
using OpenTK;

namespace WorldMapSpawnEditor.OldMapGL
{
    public partial class MapViewer : UserControl
    {

        private int rotHor;
        private int rotVert;
        private Terrain terrainmap;
        private bool mapLoaded;
        private double zoom = 1.0;
        private int OX;
        private int OY;
        private int selectedObj = -1;
        private List<string> texNames = new List<string>();
        private List<int> texIDs = new List<int>();
        private bool dragging;
        private Point dragStart;
        protected int startX;
        protected int startY;
        protected int mouseInitDragX;
        protected int mouseInitDragY;
        protected bool dragging2d;
        protected bool clicked;
        protected bool editMode;
        protected int zoomx;
        protected int zoomy;






        private ServerFrameworkRes.BasicControls.vSroButton vSroButtonUnknown;
        private IContainer components;
        private static MapViewer mapviewer;
        public static MapViewer Viewer
        {
            get
            {
                if (mapviewer == null)
                    mapviewer = new MapViewer();
                return mapviewer;
            }
        }

        public MapViewer()
        {
            InitializeComponent();

            this.mapLoaded = false;
        }
      

        private void buttonSelectDataFolder_Click(object sender, EventArgs e)
        {


        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            this.glControl1.MouseWheel += new MouseEventHandler(glControl1_Scroll);
            GL.ClearColor(Color.Black);
            int width = this.glControl1.Width;
            int height = this.glControl1.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0.0, 1920.0, 0.0, 1920.0, -5000.0, 5000.0);
            GL.Viewport(0, 0, width, height);
            GL.PointSize(3f);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Enable(EnableCap.DepthTest);
            Application.Idle += new EventHandler(this.Application_Idle);

        }
        private void Application_Idle(object sender, EventArgs e)
        {
            while (this.glControl1.IsIdle)
            {
               
                    this.Render();
                
               
            }
        }

        /// <summary>
        /// <param> MapObject </param>
        /// Renders the Mapobject of objects 
        /// </summary>
        private void Render()
        {
            if (!this.glControl1.Context.IsCurrent)
                this.glControl1.MakeCurrent();
            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            List<int> intList = new List<int>();
            if (this.mapLoaded)
            {
                GL.PushMatrix();
                GL.Translate(960f, 960f, 0.0f);
                GL.Scale(this.zoom, this.zoom, this.zoom);
                GL.Rotate((double)this.rotHor / 100.0, 0.0, 1.0, 0.0);
                GL.Rotate((double)this.rotVert / 100.0, 1.0, 0.0, 0.0);
                GL.Translate(-960f, -960f, 0.0f);
                if (this.terrainmap != null && this.checkBox1.Checked)
                    this.terrainmap.Draw();
               
                if (this.checkBox3.Checked)
                {
                    if (this.rotHor != 0)
                        this.rotHor = 0;
                    if (this.rotVert != 0)
                        this.rotVert = 0;
                    GL.Color3(byte.MaxValue, (byte)0, byte.MaxValue);
                    int num1 = 6;
                    int num2 = 24;
                    for (int index1 = 0; index1 < num2; ++index1)
                    {
                        for (int index2 = 0; index2 < num1; ++index2)
                        {
                            GL.Begin(BeginMode.LineStrip);
                            GL.Vertex3(index1 * (1920 / num2), index2 * (1920 / num1), 500);
                            GL.Vertex3((index1 + 1) * (1920 / num2), index2 * (1920 / num1), 500);
                            GL.Vertex3((index1 + 1) * (1920 / num2), (index2 + 1) * (1920 / num1), 500);
                            GL.Vertex3(index1 * (1920 / num2), (index2 + 1) * (1920 / num1), 500);
                            GL.End();
                        }
                    }
                    GL.Color3(byte.MaxValue, byte.MaxValue, byte.MaxValue);
                }

                GL.PopMatrix();
            }
            this.glControl1.SwapBuffers();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            string path = this.openFileDialog1.FileName.Substring(0, this.openFileDialog1.FileName.LastIndexOf('.')) + ".m";
            if (File.Exists(path))
            {
                this.terrainmap = new Terrain(path);
            }
            else
            {
                int num = (int)MessageBox.Show("Terrain not found.");
            }
            OFile ofile = new OFile(this.openFileDialog1.FileName);
            this.OX = ofile.OX;
            this.OY = ofile.OY;
            this.Text = "SRO Map Viewer - X: " + (object)this.OX + " Y:" + (object)this.OY;
            
            this.mapLoaded = true;
            this.groupBox3.Enabled = true;
            this.button2.Enabled = true;
            //this.fillLists();
        }




      

        private void glControl1_Scroll(object sender, MouseEventArgs e)
        {
            var cp = this.PointToClient(e.Location);
            if (!this.mapLoaded || e.X >= this.glControl1.Width || e.Y >= this.glControl1.Height)
                return;
            this.zoom += (double)e.Delta / 300.0;
            if (this.zoom >= 0.1)
                return;
            this.zoom = 0.1;
        }
        private void onGLMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right || this.dragging)
                return;
            this.dragging = true;
            this.dragStart = e.Location;
        }

        private void onGLMouseMove(object sender, MouseEventArgs e)
        {
            if (!this.dragging)
                return;
            this.rotHor += e.Location.X - this.dragStart.X;
            this.rotVert += e.Location.Y - this.dragStart.Y;
        }

        private void onGLMouseUp(object sender, MouseEventArgs e)
        {
            this.dragging = false;
        }

        private void glControl1_MouseWheel(object sender,MouseEventArgs e)
        {
            if (!this.mapLoaded || this.glControl1.PointToClient(e.Location).X >= this.glControl1.Width || this.glControl1.PointToClient(e.Location).Y >= this.glControl1.Height)
                return;
            this.zoom += (double)e.Delta / 300.0;
            if (this.zoom >= 0.1)
                return;
            this.zoom = 0.1;
        }

        private void AppendTreeViewMap(TreeView tree, string path)
        {
            Action clearTreeView = () => tree.Nodes.Clear();
            this.Invoke(clearTreeView);

            string clearedItem;
            foreach (string item in Directory.GetDirectories(path))
            {
                clearedItem = item.Replace(path + "\\", "");
                TreeNode TParent = new TreeNode(clearedItem);

                foreach (string subitems in Directory.GetFiles(item, "*.o2*"))
                {
                    TParent.Nodes.Add(subitems.Replace(item + "\\", ""));
                }
                Action showTreeView = () => tree.Nodes.Add(TParent);
                this.Invoke(showTreeView);
            }
        }

       




        

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

     

        private void checkBoxEditMode_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxEditMode.CheckState == CheckState.Checked)
            {
                editMode = true;
            }
            else if (this.checkBoxEditMode.CheckState == CheckState.Unchecked)
            {
                editMode = false;
            }
        }

        private void mapPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseInitDragX = Cursor.Position.X - this.startX;
            this.mouseInitDragY = Cursor.Position.Y - this.startY;
            this.clicked = true;
        }

       

        private void InitializeComponentForMyown()
        {
           
            

        }


        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TreeView treeViewMapPk2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelRegionID;
        private System.Windows.Forms.TreeView treeViewRegionIDs;
        private System.Windows.Forms.Button buttonZoomOut;
        private System.Windows.Forms.Button buttonZoomIn;
        private System.Windows.Forms.Button buttonResetZoom;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.CheckBox checkBoxEditMode;
       // public TwoDimViewer.MapPanel mapPanel1;
     

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.glControl1 = new OpenTK.GLControl();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.treeViewMapPk2 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.treeViewRegionIDs = new System.Windows.Forms.TreeView();
            this.labelRegionID = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonZoomOut = new System.Windows.Forms.Button();
            this.buttonZoomIn = new System.Windows.Forms.Button();
            this.buttonResetZoom = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.checkBoxEditMode = new System.Windows.Forms.CheckBox();
           // this.mapPanel1 = new MapPK2.Designer.TwoDimViewer.MapPanel(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.glControl1.Location = new System.Drawing.Point(5, 19);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(420, 316);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onGLMouseDown);
            this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onGLMouseMove);
            this.glControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onGLMouseUp);
            this.glControl1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseWheel);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open Map.pk2  .o2 file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Object Maps|*.o2";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(6, 14);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(99, 18);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Show Terrain";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(6, 38);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(102, 18);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.Text = "Show Objects";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(6, 60);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(83, 18);
            this.checkBox3.TabIndex = 8;
            this.checkBox3.Text = "Show Grid";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(128, 14);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(113, 18);
            this.checkBox4.TabIndex = 9;
            this.checkBox4.Text = "Highlight Fading";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(128, 38);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(130, 18);
            this.checkBox5.TabIndex = 10;
            this.checkBox5.Text = "Highlight collisions";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Location = new System.Drawing.Point(509, 369);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 86);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(606, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 107);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(11, 75);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(140, 23);
            this.button7.TabIndex = 24;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(11, 17);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(140, 23);
            this.button5.TabIndex = 22;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(11, 46);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(140, 23);
            this.button6.TabIndex = 23;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.numericUpDown3);
            this.groupBox3.Controls.Add(this.numericUpDown2);
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Controls.Add(this.trackBar1);
            this.groupBox3.Controls.Add(this.checkBox6);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(431, 196);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(331, 164);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(213, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(112, 20);
            this.textBox1.TabIndex = 36;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDown3.Location = new System.Drawing.Point(65, 135);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(88, 20);
            this.numericUpDown3.TabIndex = 35;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDown2.Location = new System.Drawing.Point(65, 113);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(88, 20);
            this.numericUpDown2.TabIndex = 34;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDown1.Location = new System.Drawing.Point(65, 91);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(88, 20);
            this.numericUpDown1.TabIndex = 33;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(162, 113);
            this.trackBar1.Maximum = 628;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(163, 45);
            this.trackBar1.TabIndex = 32;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(9, 67);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(102, 18);
            this.checkBox6.TabIndex = 11;
            this.checkBox6.Text = "Distance Fade";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(65, 24);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(130, 20);
            this.textBox2.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(159, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 14);
            this.label6.TabIndex = 30;
            this.label6.Text = "Rotation:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 14);
            this.label5.TabIndex = 29;
            this.label5.Text = "Z:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 14);
            this.label4.TabIndex = 28;
            this.label4.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 14);
            this.label3.TabIndex = 27;
            this.label3.Text = "X:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 26;
            this.label1.Text = "UniqueID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 14);
            this.label2.TabIndex = 21;
            this.label2.Text = "Type:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(62, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 14);
            this.label10.TabIndex = 19;
            this.label10.Text = "none";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(201, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 23);
            this.button3.TabIndex = 25;
            this.button3.Text = "Change Object";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 370);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Save Map.pk2  .o2 file";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonSaveMapFile_Click);
            // 
            // button33
            // 
            this.button33.Location = new System.Drawing.Point(161, 341);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(140, 23);
            this.button33.TabIndex = 14;
            this.button33.Text = "button3";
            this.button33.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(161, 370);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(3, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(155, 144);
            this.listBox1.TabIndex = 16;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 14;
            this.listBox2.Location = new System.Drawing.Point(3, 0);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(155, 144);
            this.listBox2.TabIndex = 17;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 14;
            this.listBox3.Location = new System.Drawing.Point(3, 0);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(155, 144);
            this.listBox3.TabIndex = 18;
            // 
            // treeViewMapPk2
            // 
            this.treeViewMapPk2.Location = new System.Drawing.Point(307, 383);
            this.treeViewMapPk2.Name = "treeViewMapPk2";
            this.treeViewMapPk2.Size = new System.Drawing.Size(118, 82);
            this.treeViewMapPk2.TabIndex = 20;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(786, 495);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeViewRegionIDs);
            this.tabPage1.Controls.Add(this.labelRegionID);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.treeViewMapPk2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.glControl1);
            this.tabPage1.Controls.Add(this.button33);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(778, 468);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // treeViewRegionIDs
            // 
            this.treeViewRegionIDs.Location = new System.Drawing.Point(436, 383);
            this.treeViewRegionIDs.Name = "treeViewRegionIDs";
            this.treeViewRegionIDs.Size = new System.Drawing.Size(59, 82);
            this.treeViewRegionIDs.TabIndex = 24;
            // 
            // labelRegionID
            // 
            this.labelRegionID.AutoSize = true;
            this.labelRegionID.Location = new System.Drawing.Point(76, 2);
            this.labelRegionID.Name = "labelRegionID";
            this.labelRegionID.Size = new System.Drawing.Size(45, 14);
            this.labelRegionID.TabIndex = 23;
            this.labelRegionID.Text = "default";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Location = new System.Drawing.Point(431, 19);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(169, 174);
            this.tabControl2.TabIndex = 22;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(161, 147);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Buildings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.listBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(161, 147);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Nature";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.listBox3);
            this.tabPage5.Location = new System.Drawing.Point(4, 23);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(161, 147);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Others";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 14);
            this.label7.TabIndex = 22;
            this.label7.Text = "RegionID:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonZoomOut);
            this.tabPage2.Controls.Add(this.buttonZoomIn);
            this.tabPage2.Controls.Add(this.buttonResetZoom);
            this.tabPage2.Controls.Add(this.toolStrip1);
            this.tabPage2.Controls.Add(this.checkBoxEditMode);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(778, 468);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.Location = new System.Drawing.Point(387, 376);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(87, 25);
            this.buttonZoomOut.TabIndex = 11;
            this.buttonZoomOut.Text = "Zoom out";
            this.buttonZoomOut.UseVisualStyleBackColor = true;
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.Location = new System.Drawing.Point(293, 376);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(87, 25);
            this.buttonZoomIn.TabIndex = 10;
            this.buttonZoomIn.Text = "Zoom in";
            this.buttonZoomIn.UseVisualStyleBackColor = true;
            // 
            // buttonResetZoom
            // 
            this.buttonResetZoom.Location = new System.Drawing.Point(200, 376);
            this.buttonResetZoom.Name = "buttonResetZoom";
            this.buttonResetZoom.Size = new System.Drawing.Size(87, 25);
            this.buttonResetZoom.TabIndex = 9;
            this.buttonResetZoom.Text = "Reset Zoom";
            this.buttonResetZoom.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 440);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(772, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(86, 22);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // checkBoxEditMode
            // 
            this.checkBoxEditMode.AutoSize = true;
            this.checkBoxEditMode.Location = new System.Drawing.Point(480, 383);
            this.checkBoxEditMode.Name = "checkBoxEditMode";
            this.checkBoxEditMode.Size = new System.Drawing.Size(80, 18);
            this.checkBoxEditMode.TabIndex = 7;
            this.checkBoxEditMode.Text = "Edit Mode";
            this.checkBoxEditMode.UseVisualStyleBackColor = true;
            this.checkBoxEditMode.CheckedChanged += new System.EventHandler(this.checkBoxEditMode_CheckedChanged);
            
            // 
            // MapViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MapViewer";
            this.Size = new System.Drawing.Size(792, 501);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void buttonSaveMapFile_Click(object sender, EventArgs e)
        {
            var saveDialog = new OpenFileDialog();
            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;
            
        }

    }
}
/*
partial class MapViewer
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.glControl1 = new OpenTK.GLControl();
        this.button1 = new System.Windows.Forms.Button();
        this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        this.checkBox1 = new System.Windows.Forms.CheckBox();
        this.checkBox2 = new System.Windows.Forms.CheckBox();
        this.checkBox3 = new System.Windows.Forms.CheckBox();
        this.checkBox4 = new System.Windows.Forms.CheckBox();
        this.checkBox5 = new System.Windows.Forms.CheckBox();
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.groupBox2 = new System.Windows.Forms.GroupBox();
        this.button7 = new System.Windows.Forms.Button();
        this.button5 = new System.Windows.Forms.Button();
        this.button6 = new System.Windows.Forms.Button();
        this.groupBox3 = new System.Windows.Forms.GroupBox();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
        this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
        this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
        this.trackBar1 = new System.Windows.Forms.TrackBar();
        this.checkBox6 = new System.Windows.Forms.CheckBox();
        this.textBox2 = new System.Windows.Forms.TextBox();
        this.label6 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label10 = new System.Windows.Forms.Label();
        this.button3 = new System.Windows.Forms.Button();
        this.button2 = new System.Windows.Forms.Button();
        this.button33 = new System.Windows.Forms.Button();
        this.button4 = new System.Windows.Forms.Button();
        this.listBox1 = new System.Windows.Forms.ListBox();
        this.listBox2 = new System.Windows.Forms.ListBox();
        this.listBox3 = new System.Windows.Forms.ListBox();
        this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
        this.treeViewMapPk2 = new System.Windows.Forms.TreeView();
        this.tabControl1 = new System.Windows.Forms.TabControl();
        this.tabPage1 = new System.Windows.Forms.TabPage();
        this.treeViewRegionIDs = new System.Windows.Forms.TreeView();
        this.labelRegionID = new System.Windows.Forms.Label();
        this.tabControl2 = new System.Windows.Forms.TabControl();
        this.tabPage3 = new System.Windows.Forms.TabPage();
        this.tabPage4 = new System.Windows.Forms.TabPage();
        this.tabPage5 = new System.Windows.Forms.TabPage();
        this.label7 = new System.Windows.Forms.Label();
        this.tabPage2 = new System.Windows.Forms.TabPage();
        this.buttonZoomOut = new System.Windows.Forms.Button();
        this.buttonZoomIn = new System.Windows.Forms.Button();
        this.buttonResetZoom = new System.Windows.Forms.Button();
        this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
        this.checkBoxEditMode = new System.Windows.Forms.CheckBox();
        this.mapPanel1 = new TwoDimViewer.MapPanel(this.components);
        this.groupBox1.SuspendLayout();
        this.groupBox2.SuspendLayout();
        this.groupBox3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
        this.tabControl1.SuspendLayout();
        this.tabPage1.SuspendLayout();
        this.tabControl2.SuspendLayout();
        this.tabPage3.SuspendLayout();
        this.tabPage4.SuspendLayout();
        this.tabPage5.SuspendLayout();
        this.tabPage2.SuspendLayout();
        this.toolStrip1.SuspendLayout();
        this.SuspendLayout();
        // 
        // glControl1
        // 
        this.glControl1.BackColor = System.Drawing.Color.Black;
        this.glControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.glControl1.Location = new System.Drawing.Point(5, 19);
        this.glControl1.Name = "glControl1";
        this.glControl1.Size = new System.Drawing.Size(420, 316);
        this.glControl1.TabIndex = 0;
        this.glControl1.VSync = false;
        this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
        this.glControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onGLMouseDown);
        this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.onGLMouseMove);
        this.glControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onGLMouseUp);
        this.glControl1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseWheel);


        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(15, 341);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(140, 23);
        this.button1.TabIndex = 1;
        this.button1.Text = "Open Map.pk2  .o2 file";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // openFileDialog1
        // 
        this.openFileDialog1.FileName = "openFileDialog1";
        this.openFileDialog1.Filter = "Object Maps|*.o2";
        // 
        // checkBox1
        // 
        this.checkBox1.AutoSize = true;
        this.checkBox1.Checked = true;
        this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
        this.checkBox1.Location = new System.Drawing.Point(6, 14);
        this.checkBox1.Name = "checkBox1";
        this.checkBox1.Size = new System.Drawing.Size(99, 18);
        this.checkBox1.TabIndex = 6;
        this.checkBox1.Text = "Show Terrain";
        this.checkBox1.UseVisualStyleBackColor = true;
        // 
        // checkBox2
        // 
        this.checkBox2.AutoSize = true;
        this.checkBox2.Checked = true;
        this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
        this.checkBox2.Location = new System.Drawing.Point(6, 38);
        this.checkBox2.Name = "checkBox2";
        this.checkBox2.Size = new System.Drawing.Size(102, 18);
        this.checkBox2.TabIndex = 7;
        this.checkBox2.Text = "Show Objects";
        this.checkBox2.UseVisualStyleBackColor = true;
        // 
        // checkBox3
        // 
        this.checkBox3.AutoSize = true;
        this.checkBox3.Location = new System.Drawing.Point(6, 60);
        this.checkBox3.Name = "checkBox3";
        this.checkBox3.Size = new System.Drawing.Size(83, 18);
        this.checkBox3.TabIndex = 8;
        this.checkBox3.Text = "Show Grid";
        this.checkBox3.UseVisualStyleBackColor = true;
        // 
        // checkBox4
        // 
        this.checkBox4.AutoSize = true;
        this.checkBox4.Location = new System.Drawing.Point(128, 14);
        this.checkBox4.Name = "checkBox4";
        this.checkBox4.Size = new System.Drawing.Size(113, 18);
        this.checkBox4.TabIndex = 9;
        this.checkBox4.Text = "Highlight Fading";
        this.checkBox4.UseVisualStyleBackColor = true;
        // 
        // checkBox5
        // 
        this.checkBox5.AutoSize = true;
        this.checkBox5.Location = new System.Drawing.Point(128, 38);
        this.checkBox5.Name = "checkBox5";
        this.checkBox5.Size = new System.Drawing.Size(130, 18);
        this.checkBox5.TabIndex = 10;
        this.checkBox5.Text = "Highlight collisions";
        this.checkBox5.UseVisualStyleBackColor = true;
        this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.checkBox1);
        this.groupBox1.Controls.Add(this.checkBox2);
        this.groupBox1.Controls.Add(this.checkBox3);
        this.groupBox1.Controls.Add(this.checkBox4);
        this.groupBox1.Controls.Add(this.checkBox5);
        this.groupBox1.Location = new System.Drawing.Point(509, 369);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(253, 86);
        this.groupBox1.TabIndex = 11;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "groupBox1";
        // 
        // groupBox2
        // 
        this.groupBox2.Controls.Add(this.button7);
        this.groupBox2.Controls.Add(this.button5);
        this.groupBox2.Controls.Add(this.button6);
        this.groupBox2.Enabled = false;
        this.groupBox2.Location = new System.Drawing.Point(606, 19);
        this.groupBox2.Name = "groupBox2";
        this.groupBox2.Size = new System.Drawing.Size(159, 107);
        this.groupBox2.TabIndex = 12;
        this.groupBox2.TabStop = false;
        this.groupBox2.Text = "groupBox2";
        // 
        // button7
        // 
        this.button7.Location = new System.Drawing.Point(11, 75);
        this.button7.Name = "button7";
        this.button7.Size = new System.Drawing.Size(140, 23);
        this.button7.TabIndex = 24;
        this.button7.Text = "button7";
        this.button7.UseVisualStyleBackColor = true;
        // 
        // button5
        // 
        this.button5.Location = new System.Drawing.Point(11, 17);
        this.button5.Name = "button5";
        this.button5.Size = new System.Drawing.Size(140, 23);
        this.button5.TabIndex = 22;
        this.button5.Text = "button5";
        this.button5.UseVisualStyleBackColor = true;
        // 
        // button6
        // 
        this.button6.Location = new System.Drawing.Point(11, 46);
        this.button6.Name = "button6";
        this.button6.Size = new System.Drawing.Size(140, 23);
        this.button6.TabIndex = 23;
        this.button6.Text = "button6";
        this.button6.UseVisualStyleBackColor = true;
        // 
        // groupBox3
        // 
        this.groupBox3.Controls.Add(this.textBox1);
        this.groupBox3.Controls.Add(this.numericUpDown3);
        this.groupBox3.Controls.Add(this.numericUpDown2);
        this.groupBox3.Controls.Add(this.numericUpDown1);
        this.groupBox3.Controls.Add(this.trackBar1);
        this.groupBox3.Controls.Add(this.checkBox6);
        this.groupBox3.Controls.Add(this.textBox2);
        this.groupBox3.Controls.Add(this.label6);
        this.groupBox3.Controls.Add(this.label5);
        this.groupBox3.Controls.Add(this.label4);
        this.groupBox3.Controls.Add(this.label3);
        this.groupBox3.Controls.Add(this.label1);
        this.groupBox3.Controls.Add(this.label2);
        this.groupBox3.Controls.Add(this.label10);
        this.groupBox3.Controls.Add(this.button3);
        this.groupBox3.Location = new System.Drawing.Point(431, 196);
        this.groupBox3.Name = "groupBox3";
        this.groupBox3.Size = new System.Drawing.Size(331, 164);
        this.groupBox3.TabIndex = 12;
        this.groupBox3.TabStop = false;
        this.groupBox3.Text = "groupBox3";
        // 
        // textBox1
        // 
        this.textBox1.Location = new System.Drawing.Point(213, 91);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(112, 20);
        this.textBox1.TabIndex = 36;
        // 
        // numericUpDown3
        // 
        this.numericUpDown3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
        this.numericUpDown3.Location = new System.Drawing.Point(65, 135);
        this.numericUpDown3.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
        this.numericUpDown3.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
        this.numericUpDown3.Name = "numericUpDown3";
        this.numericUpDown3.Size = new System.Drawing.Size(88, 20);
        this.numericUpDown3.TabIndex = 35;
        this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
        // 
        // numericUpDown2
        // 
        this.numericUpDown2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
        this.numericUpDown2.Location = new System.Drawing.Point(65, 113);
        this.numericUpDown2.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
        this.numericUpDown2.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
        this.numericUpDown2.Name = "numericUpDown2";
        this.numericUpDown2.Size = new System.Drawing.Size(88, 20);
        this.numericUpDown2.TabIndex = 34;
        this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
        // 
        // numericUpDown1
        // 
        this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
        this.numericUpDown1.Location = new System.Drawing.Point(65, 91);
        this.numericUpDown1.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
        this.numericUpDown1.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
        this.numericUpDown1.Name = "numericUpDown1";
        this.numericUpDown1.Size = new System.Drawing.Size(88, 20);
        this.numericUpDown1.TabIndex = 33;
        this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
        // 
        // trackBar1
        // 
        this.trackBar1.Location = new System.Drawing.Point(162, 113);
        this.trackBar1.Maximum = 628;
        this.trackBar1.Name = "trackBar1";
        this.trackBar1.Size = new System.Drawing.Size(163, 45);
        this.trackBar1.TabIndex = 32;
        this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
        // 
        // checkBox6
        // 
        this.checkBox6.AutoSize = true;
        this.checkBox6.Location = new System.Drawing.Point(9, 67);
        this.checkBox6.Name = "checkBox6";
        this.checkBox6.Size = new System.Drawing.Size(102, 18);
        this.checkBox6.TabIndex = 11;
        this.checkBox6.Text = "Distance Fade";
        this.checkBox6.UseVisualStyleBackColor = true;
        // 
        // textBox2
        // 
        this.textBox2.Location = new System.Drawing.Point(65, 24);
        this.textBox2.Name = "textBox2";
        this.textBox2.Size = new System.Drawing.Size(130, 20);
        this.textBox2.TabIndex = 31;
        // 
        // label6
        // 
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(159, 93);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(55, 14);
        this.label6.TabIndex = 30;
        this.label6.Text = "Rotation:";
        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(44, 137);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(17, 14);
        this.label5.TabIndex = 29;
        this.label5.Text = "Z:";
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(45, 117);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(16, 14);
        this.label4.TabIndex = 28;
        this.label4.Text = "Y:";
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(45, 93);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(17, 14);
        this.label3.TabIndex = 27;
        this.label3.Text = "X:";
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(6, 27);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(58, 14);
        this.label1.TabIndex = 26;
        this.label1.Text = "UniqueID:";
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(28, 50);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(36, 14);
        this.label2.TabIndex = 21;
        this.label2.Text = "Type:";
        // 
        // label10
        // 
        this.label10.AutoSize = true;
        this.label10.Location = new System.Drawing.Point(62, 50);
        this.label10.Name = "label10";
        this.label10.Size = new System.Drawing.Size(35, 14);
        this.label10.TabIndex = 19;
        this.label10.Text = "none";
        // 
        // button3
        // 
        this.button3.Location = new System.Drawing.Point(201, 23);
        this.button3.Name = "button3";
        this.button3.Size = new System.Drawing.Size(124, 23);
        this.button3.TabIndex = 25;
        this.button3.Text = "Change Object";
        this.button3.UseVisualStyleBackColor = true;
        this.button3.Click += new System.EventHandler(this.buttonChangeSelectedBsrObj);
        // 
        // button2
        // 
        this.button2.Location = new System.Drawing.Point(15, 370);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(140, 23);
        this.button2.TabIndex = 13;
        this.button2.Text = "Save Map.pk2  .o2 file";
        this.button2.UseVisualStyleBackColor = true;
        // 
        // button33
        // 
        this.button33.Location = new System.Drawing.Point(161, 341);
        this.button33.Name = "button33";
        this.button33.Size = new System.Drawing.Size(140, 23);
        this.button33.TabIndex = 14;
        this.button33.Text = "button3";
        this.button33.UseVisualStyleBackColor = true;
        // 
        // button4
        // 
        this.button4.Location = new System.Drawing.Point(161, 370);
        this.button4.Name = "button4";
        this.button4.Size = new System.Drawing.Size(140, 23);
        this.button4.TabIndex = 15;
        this.button4.Text = "button4";
        this.button4.UseVisualStyleBackColor = true;
        // 
        // listBox1
        // 
        this.listBox1.FormattingEnabled = true;
        this.listBox1.ItemHeight = 14;
        this.listBox1.Location = new System.Drawing.Point(3, 0);
        this.listBox1.Name = "listBox1";
        this.listBox1.Size = new System.Drawing.Size(155, 144);
        this.listBox1.TabIndex = 16;
        this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
        // 
        // listBox2
        // 
        this.listBox2.FormattingEnabled = true;
        this.listBox2.ItemHeight = 14;
        this.listBox2.Location = new System.Drawing.Point(3, 0);
        this.listBox2.Name = "listBox2";
        this.listBox2.Size = new System.Drawing.Size(155, 144);
        this.listBox2.TabIndex = 17;
        this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
        // 
        // listBox3
        // 
        this.listBox3.FormattingEnabled = true;
        this.listBox3.ItemHeight = 14;
        this.listBox3.Location = new System.Drawing.Point(3, 0);
        this.listBox3.Name = "listBox3";
        this.listBox3.Size = new System.Drawing.Size(155, 144);
        this.listBox3.TabIndex = 18;
        this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
        // 
        // treeViewMapPk2
        // 
        this.treeViewMapPk2.Location = new System.Drawing.Point(307, 383);
        this.treeViewMapPk2.Name = "treeViewMapPk2";
        this.treeViewMapPk2.Size = new System.Drawing.Size(118, 82);
        this.treeViewMapPk2.TabIndex = 20;
        this.treeViewMapPk2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
        // 
        // tabControl1
        // 
        this.tabControl1.Controls.Add(this.tabPage1);
        this.tabControl1.Controls.Add(this.tabPage2);
        this.tabControl1.Location = new System.Drawing.Point(3, 3);
        this.tabControl1.Name = "tabControl1";
        this.tabControl1.SelectedIndex = 0;
        this.tabControl1.Size = new System.Drawing.Size(786, 495);
        this.tabControl1.TabIndex = 21;
        // 
        // tabPage1
        // 
        this.tabPage1.Controls.Add(this.treeViewRegionIDs);
        this.tabPage1.Controls.Add(this.labelRegionID);
        this.tabPage1.Controls.Add(this.tabControl2);
        this.tabPage1.Controls.Add(this.label7);
        this.tabPage1.Controls.Add(this.groupBox2);
        this.tabPage1.Controls.Add(this.groupBox3);
        this.tabPage1.Controls.Add(this.treeViewMapPk2);
        this.tabPage1.Controls.Add(this.groupBox1);
        this.tabPage1.Controls.Add(this.button4);
        this.tabPage1.Controls.Add(this.glControl1);
        this.tabPage1.Controls.Add(this.button33);
        this.tabPage1.Controls.Add(this.button1);
        this.tabPage1.Controls.Add(this.button2);
        this.tabPage1.Location = new System.Drawing.Point(4, 23);
        this.tabPage1.Name = "tabPage1";
        this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage1.Size = new System.Drawing.Size(778, 468);
        this.tabPage1.TabIndex = 0;
        this.tabPage1.Text = "tabPage1";
        this.tabPage1.UseVisualStyleBackColor = true;
        // 
        // treeViewRegionIDs
        // 
        this.treeViewRegionIDs.Location = new System.Drawing.Point(436, 383);
        this.treeViewRegionIDs.Name = "treeViewRegionIDs";
        this.treeViewRegionIDs.Size = new System.Drawing.Size(59, 82);
        this.treeViewRegionIDs.TabIndex = 24;
        // 
        // labelRegionID
        // 
        this.labelRegionID.AutoSize = true;
        this.labelRegionID.Location = new System.Drawing.Point(76, 2);
        this.labelRegionID.Name = "labelRegionID";
        this.labelRegionID.Size = new System.Drawing.Size(45, 14);
        this.labelRegionID.TabIndex = 23;
        this.labelRegionID.Text = "default";
        // 
        // tabControl2
        // 
        this.tabControl2.Controls.Add(this.tabPage3);
        this.tabControl2.Controls.Add(this.tabPage4);
        this.tabControl2.Controls.Add(this.tabPage5);
        this.tabControl2.Location = new System.Drawing.Point(431, 19);
        this.tabControl2.Name = "tabControl2";
        this.tabControl2.SelectedIndex = 0;
        this.tabControl2.Size = new System.Drawing.Size(169, 174);
        this.tabControl2.TabIndex = 22;
        // 
        // tabPage3
        // 
        this.tabPage3.Controls.Add(this.listBox1);
        this.tabPage3.Location = new System.Drawing.Point(4, 23);
        this.tabPage3.Name = "tabPage3";
        this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage3.Size = new System.Drawing.Size(161, 147);
        this.tabPage3.TabIndex = 0;
        this.tabPage3.Text = "Buildings";
        this.tabPage3.UseVisualStyleBackColor = true;
        // 
        // tabPage4
        // 
        this.tabPage4.Controls.Add(this.listBox2);
        this.tabPage4.Location = new System.Drawing.Point(4, 23);
        this.tabPage4.Name = "tabPage4";
        this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage4.Size = new System.Drawing.Size(161, 147);
        this.tabPage4.TabIndex = 1;
        this.tabPage4.Text = "Nature";
        this.tabPage4.UseVisualStyleBackColor = true;
        // 
        // tabPage5
        // 
        this.tabPage5.Controls.Add(this.listBox3);
        this.tabPage5.Location = new System.Drawing.Point(4, 23);
        this.tabPage5.Name = "tabPage5";
        this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage5.Size = new System.Drawing.Size(161, 147);
        this.tabPage5.TabIndex = 2;
        this.tabPage5.Text = "Others";
        this.tabPage5.UseVisualStyleBackColor = true;
        // 
        // label7
        // 
        this.label7.AutoSize = true;
        this.label7.Location = new System.Drawing.Point(12, 2);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(58, 14);
        this.label7.TabIndex = 22;
        this.label7.Text = "RegionID:";
        // 
        // tabPage2
        // 
        this.tabPage2.Controls.Add(this.buttonZoomOut);
        this.tabPage2.Controls.Add(this.buttonZoomIn);
        this.tabPage2.Controls.Add(this.buttonResetZoom);
        this.tabPage2.Controls.Add(this.toolStrip1);
        this.tabPage2.Controls.Add(this.checkBoxEditMode);
        this.tabPage2.Controls.Add(this.mapPanel1);
        this.tabPage2.Location = new System.Drawing.Point(4, 23);
        this.tabPage2.Name = "tabPage2";
        this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        this.tabPage2.Size = new System.Drawing.Size(778, 468);
        this.tabPage2.TabIndex = 1;
        this.tabPage2.Text = "tabPage2";
        this.tabPage2.UseVisualStyleBackColor = true;
        // 
        // buttonZoomOut
        // 
        this.buttonZoomOut.Location = new System.Drawing.Point(387, 376);
        this.buttonZoomOut.Name = "buttonZoomOut";
        this.buttonZoomOut.Size = new System.Drawing.Size(87, 25);
        this.buttonZoomOut.TabIndex = 11;
        this.buttonZoomOut.Text = "Zoom out";
        this.buttonZoomOut.UseVisualStyleBackColor = true;
        this.buttonZoomOut.Click += new System.EventHandler(this.buttonZoomOut_Click);
        // 
        // buttonZoomIn
        // 
        this.buttonZoomIn.Location = new System.Drawing.Point(293, 376);
        this.buttonZoomIn.Name = "buttonZoomIn";
        this.buttonZoomIn.Size = new System.Drawing.Size(87, 25);
        this.buttonZoomIn.TabIndex = 10;
        this.buttonZoomIn.Text = "Zoom in";
        this.buttonZoomIn.UseVisualStyleBackColor = true;
        this.buttonZoomIn.Click += new System.EventHandler(this.buttonZoomIn_Click);
        // 
        // buttonResetZoom
        // 
        this.buttonResetZoom.Location = new System.Drawing.Point(200, 376);
        this.buttonResetZoom.Name = "buttonResetZoom";
        this.buttonResetZoom.Size = new System.Drawing.Size(87, 25);
        this.buttonResetZoom.TabIndex = 9;
        this.buttonResetZoom.Text = "Reset Zoom";
        this.buttonResetZoom.UseVisualStyleBackColor = true;
        this.buttonResetZoom.Click += new System.EventHandler(this.buttonResetZoom_Click);
        // 
        // toolStrip1
        // 
        this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
        this.toolStrip1.Location = new System.Drawing.Point(3, 440);
        this.toolStrip1.Name = "toolStrip1";
        this.toolStrip1.Size = new System.Drawing.Size(772, 25);
        this.toolStrip1.TabIndex = 8;
        this.toolStrip1.Text = "toolStrip1";
        // 
        // toolStripLabel1
        // 
        this.toolStripLabel1.Name = "toolStripLabel1";
        this.toolStripLabel1.Size = new System.Drawing.Size(86, 22);
        this.toolStripLabel1.Text = "toolStripLabel1";
        // 
        // checkBoxEditMode
        // 
        this.checkBoxEditMode.AutoSize = true;
        this.checkBoxEditMode.Location = new System.Drawing.Point(480, 383);
        this.checkBoxEditMode.Name = "checkBoxEditMode";
        this.checkBoxEditMode.Size = new System.Drawing.Size(80, 18);
        this.checkBoxEditMode.TabIndex = 7;
        this.checkBoxEditMode.Text = "Edit Mode";
        this.checkBoxEditMode.UseVisualStyleBackColor = true;
        this.checkBoxEditMode.CheckedChanged += new System.EventHandler(this.checkBoxEditMode_CheckedChanged);
        // 
        // mapPanel1
        // 
        this.mapPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.mapPanel1.Location = new System.Drawing.Point(14, 19);
        this.mapPanel1.Name = "mapPanel1";
        this.mapPanel1.Size = new System.Drawing.Size(551, 351);
        this.mapPanel1.TabIndex = 0;
        this.mapPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.mapPanel1_Paint);
        this.mapPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapPanel1_MouseDown);
        this.mapPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapPanel1_MouseMove);
        this.mapPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapPanel1_MouseUp);
        this.mapPanel1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.mapPanel1_MouseWheel);
        // 
        // MapViewer
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.tabControl1);
        this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Name = "MapViewer";
        this.Size = new System.Drawing.Size(792, 501);
        this.Load += new System.EventHandler(this.MapViewer_Load);
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        this.groupBox2.ResumeLayout(false);
        this.groupBox3.ResumeLayout(false);
        this.groupBox3.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
        this.tabControl1.ResumeLayout(false);
        this.tabPage1.ResumeLayout(false);
        this.tabPage1.PerformLayout();
        this.tabControl2.ResumeLayout(false);
        this.tabPage3.ResumeLayout(false);
        this.tabPage4.ResumeLayout(false);
        this.tabPage5.ResumeLayout(false);
        this.tabPage2.ResumeLayout(false);
        this.tabPage2.PerformLayout();
        this.toolStrip1.ResumeLayout(false);
        this.toolStrip1.PerformLayout();
        this.ResumeLayout(false);

    }

    #endregion

    private OpenTK.GLControl glControl1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.CheckBox checkBox2;
    private System.Windows.Forms.CheckBox checkBox3;
    private System.Windows.Forms.CheckBox checkBox4;
    private System.Windows.Forms.CheckBox checkBox5;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button33;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.ListBox listBox2;
    private System.Windows.Forms.ListBox listBox3;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    private System.Windows.Forms.TreeView treeViewMapPk2;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.Button button7;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button6;
    private System.Windows.Forms.TabControl tabControl2;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.TabPage tabPage4;
    private System.Windows.Forms.TabPage tabPage5;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox checkBox6;
    private System.Windows.Forms.TrackBar trackBar1;
    private System.Windows.Forms.NumericUpDown numericUpDown3;
    private System.Windows.Forms.NumericUpDown numericUpDown2;
    private System.Windows.Forms.NumericUpDown numericUpDown1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label labelRegionID;
    private System.Windows.Forms.TreeView treeViewRegionIDs;
    private System.Windows.Forms.Button buttonZoomOut;
    private System.Windows.Forms.Button buttonZoomIn;
    private System.Windows.Forms.Button buttonResetZoom;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    private System.Windows.Forms.CheckBox checkBoxEditMode;
    public TwoDimViewer.MapPanel mapPanel1;
}

*/
