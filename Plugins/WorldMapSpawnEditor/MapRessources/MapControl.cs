
using ClientDataStorage.Client.Files;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WorldMapSpawnEditor.MapRessources
{
    class MapControl : OpenTK.GLControl, IMapControl
    {
        RegionTerrain CurrentTerrain;

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

        public void Draw(mFile meshFile)
        {
            newload = false;
            if (this.ContextStatus != MapStatus.Stopped && this.ContextStatus != MapStatus.Unload)
                return;

            x = 0; y = 0;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Viewport(0, 0, this.Width, this.Width);

            CurrentTerrain = new RegionTerrain(meshFile);
            this.ContextStatus = MapStatus.Finished;

        }
        public void Draw(mFile meshFile, bool lo)
        {
            newload = true;
            if (this.ContextStatus != MapStatus.Stopped && this.ContextStatus != MapStatus.Unload)
                return;

            x = 0; y = 0;
            GL.MatrixMode(MatrixMode.Projection);
            GL.Viewport(0, 0, this.Width, this.Width);

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

        public void Scarle(int x, int y, int z)
        {
            throw new System.NotImplementedException();
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
            GL.Viewport(0, 0, ViewPoint.Width, ViewPoint.Width);
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
            if (this.Zoom >= 0.1)
                return;
            this.Zoom = 0.1;
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
                y += 10;
            else if (e.KeyCode == Keys.S)
                y -= 10;
            else if (e.KeyCode == Keys.D)
                x += 10;
            else if (e.KeyCode == Keys.A)
                x -= 10;
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
