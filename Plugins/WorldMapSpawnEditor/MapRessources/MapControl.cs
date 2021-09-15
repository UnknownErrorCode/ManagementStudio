
using ClientDataStorage.Client.Files;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WorldMapSpawnEditor.MapRessources
{
    /// <summary>
    /// GLControl used to illustrate the 3d models to the user
    /// </summary>
    class MapControl : OpenTK.GLControl, IMapControl
    {
        RegionTerrain CurrentTerrain;

        /// <summary>
        /// Defines the current status of the GLControl
        /// </summary>
        private enum MapStatus
        {
            Unload = 0x00,
            Stopped = 0x01,
            Loading = 0x02,
            Finished = 0x04

        }
        private MapStatus ContextStatus { get; set; }
        private double Zoom { get; set; } = 1.0d;
        private double RotationHorizontal { get; set; } = 0.0d;
        private double RotateVertical { get; set; } = 0.0d;
        private protected Size ViewPoint { get; set; }

        public MapControl(Control parentControl)
        {
            base.Dock = DockStyle.Fill;
            ViewPoint = parentControl.Size;
            this.Load += LoadGL;

            parentControl.Controls.Add(this);
        }
        bool newload = false;

        /// <summary>
        /// Defines the .m file from Map.pk2
        /// </summary>
        /// <param name="meshFile"></param>
        public void Draw(mFile meshFile, bool lo)
        {
            newload = lo;
            if (this.ContextStatus != MapStatus.Stopped && this.ContextStatus != MapStatus.Unload)
                return;
            GL.MatrixMode(MatrixMode.Projection);

            if (lo)
            {
                x = meshFile.X * 320; y = meshFile.Y * 320;
                GL.Viewport(x, y, this.Width, this.Width);

            }
            else
            {
                x = 0; y = 0;
                GL.Viewport(0, 0, this.Width, this.Width);
            }

            CurrentTerrain = new RegionTerrain(meshFile);
            this.ContextStatus = MapStatus.Finished;

        }


        public void Render()
        {
            if (!this.Context.IsCurrent)
                this.MakeCurrent();


            if (this.ContextStatus == MapStatus.Finished)
            {
                GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadIdentity();
                GL.PushMatrix();
                GL.Translate(960f, 960f, 0.0f);
                GL.Scale(this.Zoom, this.Zoom, this.Zoom);
                GL.Rotate((double)this.RotationHorizontal / 100.0, 0.0, 1.0, 0.0);
                GL.Rotate((double)this.RotateVertical / 100.0, 1.0, 0.0, 0.0);
                //GL.Viewport(x, y, 255 * 320, 255 * 320);
                GL.Viewport(x, y, this.Width, this.Width);
                GL.Translate(-960f, -960f, 0.0f);
                if (newload)
                    CurrentTerrain.DrawTerrain(true);
                else
                    CurrentTerrain.DrawTerrain();

                GL.PopMatrix();
                this.ContextStatus = MapStatus.Stopped;
            }
            this.SwapBuffers();
        }


        public void LoadGL(object sender, EventArgs arg)
        {
            this.MouseWheel += new MouseEventHandler(glControl1_Scroll);
            this.KeyDown += OnKeyboardCameraMove;
            this.MouseMove += MapControl_MouseMove;
            GL.ClearColor(Color.Black);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0.0, 1920.0, 0.0, 1920.0, -5000.0, 5000.0);
            GL.Viewport(0, 0, this.Width, this.Width);
            GL.PointSize(3f);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Enable(EnableCap.DepthTest);
            Application.Idle += new EventHandler(this.Application_Idle);
        }

        private void MapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (ContextStatus == MapStatus.Unload)
                return;
        }

        private void glControl1_Scroll(object sender, MouseEventArgs e)
        {
            var cp = this.PointToClient(e.Location);
            if (this.ContextStatus != MapStatus.Stopped || this.ContextStatus == MapStatus.Unload || e.X >= this.Width || e.Y >= this.Height)
                return;
            this.Zoom += (double)e.Delta / 300.0;
            this.ContextStatus = MapStatus.Finished;
            if (this.Zoom >= 0.01)
                return;
            this.Zoom = 0.01;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            while (this.IsIdle)
                this.Render();
        }

        int x = 0;
        int y = 0;

        public void OnKeyboardCameraMove(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                if (y < 320 * 256)
                    y += 100;
                else
                    return;
            else if (e.KeyCode == Keys.S)
                if (y > -1000)
                    y -= 100;
                else
                    return;
            else if (e.KeyCode == Keys.D)
                if (x < 320 * 256)
                    x += 100;
                else
                    return;
            else if (e.KeyCode == Keys.A)
                if (x > 0)
                    x -= 100;
                else
                    return;
            else if (e.KeyCode == Keys.Q)
            {
                if (RotateVertical <= 18000)
                { RotateVertical += 100; }
            }
            else if (e.KeyCode == Keys.E)
                if (RotateVertical >= 100)
                    RotateVertical -= 100;
            ContextStatus = MapStatus.Finished;
        }
    }
}
