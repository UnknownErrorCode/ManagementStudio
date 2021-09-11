using System.Windows.Forms;
using ServerFrameworkRes.Network.Security;
using System.IO;
using System.Drawing;
using System.Reflection;
using WorldMapSpawnEditor.Controls;
using ClientDataStorage.Client.Files;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing.Imaging;
using ClientDataStorage.Client;
using System.Linq;
using System.Collections.Generic;

namespace WorldMapSpawnEditor
{
    public partial class WorldMapSpawnEditorControl : UserControl
    {
        mFile Mfile;// = ClientDataStorage.Client.Map.AllmFiles[200];
        internal static ServerData StaticServerData { get; set; }
        //  public Controls.xMap Minimap_pnlMap = new Controls.xMap();
        //  public Controls.xMapControl Minimap_xmcCharacterMark = new Controls.xMapControl();
        private protected static string ExtractedClientPath { get => ClientDataStorage.Config.StaticConfig.ClientExtracted; }

        private protected static string MinimapFileDirectory { get => Path.Combine(ExtractedClientPath, "media", "minimap"); }
        public WorldMapSpawnEditorControl(ServerData data)
        {
            InitializeComponent();

        }
        public void Render()
        {
            if (mapLoaded)
            {

                GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadIdentity();

                GL.PushMatrix();
                GL.Translate(960f, 960f, 0.0f);
                GL.Scale(this.zoom, this.zoom, this.zoom);
                GL.Rotate((double)0 / 100.0, 0.0, 1.0, 0.0);
                GL.Rotate((double)0 / 100.0, 1.0, 0.0, 0.0);
                GL.Translate(-960f, -960f, 0.0f);
                this.Draw(Mfile);
                mapLoaded = false;
                GL.PopMatrix();
            }


            mapControlMainWindow.SwapBuffers();

        }

        private void Draw(mFile file)
        {
            GL.Color3(byte.MaxValue, byte.MaxValue, byte.MaxValue);


            try
            {
                var counter = 0;
                for (int blockx = 0; blockx < 6; ++blockx)
                {
                    for (int blocky = 0; blocky < 6; blocky++)
                    {
                        for (int index2 = 0; index2 < 16; ++index2)
                        {
                            for (int index3 = 0; index3 < 16; ++index3)
                            {
                                var test = file.Blocks[new Point(blockx, blocky)].MapCells[new Point(index2, index3)].texture;
                                GL.Enable(EnableCap.Texture2D);
                                GL.BindTexture(TextureTarget.Texture2D, BindGLTexturewithOwntextureID[test]);
                                GL.Begin(BeginMode.TriangleStrip);
                                GL.TexCoord2((float)index3 / 2f, (float)index2 / 2f);
                                GL.Vertex3((double)(index3 * 20 + counter % 6 * 320), (double)(index2 * 20) + Math.Floor((double)counter / 6.0) * 320.0, (double)file.Blocks[new Point(blockx, blocky)].MapCells[new Point(index3, index2)].Height);
                                GL.TexCoord2((float)(index3 + 1) / 2f, (float)index2 / 2f);
                                GL.Vertex3((double)((index3 + 1) * 20 + counter % 6 * 320), (double)(index2 * 20) + Math.Floor((double)counter / 6.0) * 320.0, (double)file.Blocks[new Point(blockx, blocky)].MapCells[new Point(index3 + 1, index2)].Height);
                                GL.TexCoord2((float)index3 / 2f, (float)(index2 + 1) / 2f);
                                GL.Vertex3((double)(index3 * 20 + counter % 6 * 320), (double)((index2 + 1) * 20) + Math.Floor((double)counter / 6.0) * 320.0, (double)file.Blocks[new Point(blockx, blocky)].MapCells[new Point(index3, index2 + 1)].Height);
                                GL.TexCoord2((float)(index3 + 1) / 2f, (float)(index2 + 1) / 2f);
                                GL.Vertex3((double)((index3 + 1) * 20 + counter % 6 * 320), (double)((index2 + 1) * 20) + Math.Floor((double)counter / 6.0) * 320.0, (double)file.Blocks[new Point(blockx, blocky)].MapCells[new Point(index3 + 1, index2 + 1)].Height);
                                GL.End();
                                GL.Disable(EnableCap.Texture2D);
                            }
                        }
                        counter++;
                    }

                }
            }
            catch (Exception e)
            {

                throw;
            }


        }

        private void InitializePerformance(Control c)
        {
            if (typeof(Panel) == c.GetType())
            {
                typeof(Panel).InvokeMember("DoubleBuffered",
                    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, c, new object[] { true });
            }
        }


        Dictionary<ushort, int> BindGLTexturewithOwntextureID = new Dictionary<ushort, int>();
        private void loadToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Mfile = new mFile(Map.MapPk2.GetFileByDirectory("Map\\100\\100.m"));

            this.mapLoaded = false;
            if (Mfile != null)
            {
                BindGLTexturewithOwntextureID = new Dictionary<ushort, int>();
                foreach (var block in Mfile.Blocks)
                {
                    Point cellCounter = new Point(0, 0);
                    foreach (var item2 in block.Value.MapCells)
                    {

                        if (BindGLTexturewithOwntextureID.ContainsKey(item2.Value.texture))
                            continue;

                        int texture = GL.GenTexture();
                        GL.BindTexture(TextureTarget.Texture2D, texture);
                        byte[] numArray = new byte[0];
                        //var t = BitConverter.GetBytes(item2.Value.texture);
                        //var str = t[0];
                        //var str2 = t[1];
                        //var test1 = Map.MapPk2.GetFileByDirectory($"Map\\tile2d\\{Map.Tile2d_ifo.TexturePaths[str]}");
                        //var test2 = Map.MapPk2.GetByteArrayByFile(test1);
                        //System.Drawing.Bitmap bitmapImage = new DDSImage(test2.Skip<byte>(20).ToArray<byte>(), false).BitmapImage;
                        System.Drawing.Bitmap bitmapImage = Map.TileTextureDictionary[item2.Value.texture].BitmapImage;
                        BitmapData bitmapdata = bitmapImage.LockBits(new Rectangle(0, 0, bitmapImage.Width, bitmapImage.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bitmapdata.Width, bitmapdata.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapdata.Scan0);
                        bitmapImage.UnlockBits(bitmapdata);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, 9729);

                        BindGLTexturewithOwntextureID.Add(item2.Value.texture, texture);

                    }
                }
                this.mapLoaded = true;
            }
        }

        private void Minimap_pnlMap_Scroll(object sender, ScrollEventArgs e)
        {
            //   var Delta = e.OldValue - e.NewValue;
            //   if (Delta > 0)
            //       Minimap_pnlMap.Zoom++;
            //   else
            //       Minimap_pnlMap.Zoom--;
        }

        private void mapControlMainWindow_Load(object sender, EventArgs e)
        {

            this.mapControlMainWindow.MouseWheel += new MouseEventHandler(glControl1_Scroll);
            this.mapControlMainWindow.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseWheel);

            GL.ClearColor(Color.Black);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Ortho(0.0, 1920.0, 0.0, 1920.0, -5000.0, 5000.0);
            GL.Viewport(0, 0, this.mapControlMainWindow.Width, this.mapControlMainWindow.Height);
            GL.PointSize(3f);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Enable(EnableCap.DepthTest);
            Application.Idle += new EventHandler(this.Application_Idle);
        }

        private void glControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!this.mapLoaded || this.mapControlMainWindow.PointToClient(e.Location).X >= this.mapControlMainWindow.Width || this.mapControlMainWindow.PointToClient(e.Location).Y >= this.mapControlMainWindow.Height)
                return;
            this.zoom += (double)e.Delta / 300.0;
            if (this.zoom >= 0.1)
                return;
            this.zoom = 0.1;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            while (this.mapControlMainWindow.IsIdle)
            {
                this.Render();
            }
        }

        private double zoom = 1.0;
        private bool mapLoaded;
        private void glControl1_Scroll(object sender, MouseEventArgs e)
        {
            var cp = this.PointToClient(e.Location);
            if (!this.mapLoaded || e.X >= this.mapControlMainWindow.Width || e.Y >= this.mapControlMainWindow.Height)
                return;
            this.zoom += (double)e.Delta / 300.0;
            if (this.zoom >= 0.1)
                return;
            this.zoom = 0.1;
        }
    }
}
