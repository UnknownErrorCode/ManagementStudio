﻿using ClientDataStorage.Client;
using ClientDataStorage.Client.Files;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WorldMapSpawnEditor.MapRessources;

namespace WorldMapSpawnEditor.MapGame
{
    class MapControl : OpenTK.GLControl, IMapControl
    {
        MapCamera camera;
        RegionTerrain CurrentTerrain;
        Dictionary<Point, RegionTerrain> AllTerrains = new Dictionary<Point, RegionTerrain>();
        Dictionary<Point, RegionTerrain> LinkedRegions = new Dictionary<Point, RegionTerrain>(8);
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

        public MapControl()
        {
            base.Dock = DockStyle.Fill;
            this.Load += LoadGL;
        }
        bool newload = false;

        /// <summary>
        /// Defines the .m file from Map.pk2
        /// </summary>
        /// <param name="meshFile"></param>
        public void Draw(mFile meshFile, bool lo)
        {
            if (meshFile.Blocks.Count != 36)
                return;

            if (this.ContextStatus != MapStatus.Stopped && this.ContextStatus != MapStatus.Unload)
                return;

            x = 0; y = 0; Zoom = 1.0d;

            if (LinkedRegions.Count > 0)
                LinkedRegions.Clear();

            ///  ^
            ///  Y
            ///  |
            ///  |
            ///  |
            ///  |
            ///  |
            ///  |
            ///  |_________________ x >




            if (Map.MapPk2.FileExists($"Map\\{meshFile.Y - 1}\\{meshFile.X - 1}.m"))
            {
                var newPoint = new Point(meshFile.X - 1, meshFile.Y - 1);
                if (!Map.AllmFiles.ContainsKey(newPoint))
                    Map.AllmFiles.Add(newPoint, new mFile(Map.MapPk2.GetFileByDirectory($"Map\\{newPoint.Y }\\{newPoint.X}.m")));

                if (!AllTerrains.ContainsKey(newPoint))
                    AllTerrains.Add(newPoint, new RegionTerrain(Map.AllmFiles[newPoint]));

                LinkedRegions.Add(new Point(-1, -1), AllTerrains[newPoint]);
            }

            if (Map.MapPk2.FileExists($"Map\\{meshFile.Y - 1}\\{meshFile.X }.m"))
            {
                var newPoint = new Point(meshFile.X, meshFile.Y - 1);
                if (!Map.AllmFiles.ContainsKey(newPoint))
                    Map.AllmFiles.Add(newPoint, new mFile(Map.MapPk2.GetFileByDirectory($"Map\\{newPoint.Y }\\{newPoint.X}.m")));


                if (!AllTerrains.ContainsKey(newPoint))
                    AllTerrains.Add(newPoint, new RegionTerrain(Map.AllmFiles[newPoint]));

                LinkedRegions.Add(new Point(0, -1), AllTerrains[newPoint]);
            }

            if (Map.MapPk2.FileExists($"Map\\{meshFile.Y - 1}\\{meshFile.X + 1}.m"))
            {
                var newPoint = new Point(meshFile.X + 1, meshFile.Y - 1);
                if (!Map.AllmFiles.ContainsKey(newPoint))
                    Map.AllmFiles.Add(newPoint, new mFile(Map.MapPk2.GetFileByDirectory($"Map\\{newPoint.Y }\\{newPoint.X}.m")));

                if (!AllTerrains.ContainsKey(newPoint))
                    AllTerrains.Add(newPoint, new RegionTerrain(Map.AllmFiles[newPoint]));

                LinkedRegions.Add(new Point(1, -1), AllTerrains[newPoint]);
            }

            if (Map.MapPk2.FileExists($"Map\\{meshFile.Y + 1}\\{meshFile.X - 1}.m"))
            {
                var newPoint = new Point(meshFile.X - 1, meshFile.Y + 1);
                if (!Map.AllmFiles.ContainsKey(newPoint))
                    Map.AllmFiles.Add(newPoint, new mFile(Map.MapPk2.GetFileByDirectory($"Map\\{newPoint.Y }\\{newPoint.X}.m")));

                if (!AllTerrains.ContainsKey(newPoint))
                    AllTerrains.Add(newPoint, new RegionTerrain(Map.AllmFiles[newPoint]));

                LinkedRegions.Add(new Point(-1, 1), AllTerrains[newPoint]);
            }

            if (Map.MapPk2.FileExists($"Map\\{meshFile.Y + 1}\\{meshFile.X}.m"))
            {
                var newPoint = new Point(meshFile.X, meshFile.Y + 1);
                if (!Map.AllmFiles.ContainsKey(newPoint))
                    Map.AllmFiles.Add(newPoint, new mFile(Map.MapPk2.GetFileByDirectory($"Map\\{newPoint.Y }\\{newPoint.X}.m")));

                if (!AllTerrains.ContainsKey(newPoint))
                    AllTerrains.Add(newPoint, new RegionTerrain(Map.AllmFiles[newPoint]));

                LinkedRegions.Add(new Point(0, 1), AllTerrains[newPoint]);
            }

            if (Map.MapPk2.FileExists($"Map\\{meshFile.Y + 1}\\{meshFile.X + 1}.m"))
            {
                var newPoint = new Point(meshFile.X + 1, meshFile.Y + 1);
                if (!Map.AllmFiles.ContainsKey(newPoint))
                    Map.AllmFiles.Add(newPoint, new mFile(Map.MapPk2.GetFileByDirectory($"Map\\{newPoint.Y }\\{newPoint.X}.m")));

                if (!AllTerrains.ContainsKey(newPoint))
                    AllTerrains.Add(newPoint, new RegionTerrain(Map.AllmFiles[newPoint]));

                LinkedRegions.Add(new Point(1, 1), AllTerrains[newPoint]);
            }

            if (Map.MapPk2.FileExists($"Map\\{meshFile.Y }\\{meshFile.X + 1}.m"))
            {
                var newPoint = new Point(meshFile.X + 1, meshFile.Y);
                if (!Map.AllmFiles.ContainsKey(newPoint))
                    Map.AllmFiles.Add(newPoint, new mFile(Map.MapPk2.GetFileByDirectory($"Map\\{newPoint.Y }\\{newPoint.X}.m")));

                if (!AllTerrains.ContainsKey(newPoint))
                    AllTerrains.Add(newPoint, new RegionTerrain(Map.AllmFiles[newPoint]));

                LinkedRegions.Add(new Point(1, 0), AllTerrains[newPoint]);
            }

            if (Map.MapPk2.FileExists($"Map\\{meshFile.Y}\\{meshFile.X - 1 }.m"))
            {
                var newPoint = new Point(meshFile.X - 1, meshFile.Y);
                if (!Map.AllmFiles.ContainsKey(newPoint))
                    Map.AllmFiles.Add(newPoint, new mFile(Map.MapPk2.GetFileByDirectory($"Map\\{newPoint.Y }\\{newPoint.X}.m")));

                if (!AllTerrains.ContainsKey(newPoint))
                    AllTerrains.Add(newPoint, new RegionTerrain(Map.AllmFiles[newPoint]));

                LinkedRegions.Add(new Point(-1, 0), AllTerrains[newPoint]);
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

                GL.MatrixMode(MatrixMode.Projection);
                GL.Viewport(0, 0, this.Width, this.Width);
                GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
                // var lookAt = camera.GetView();
                // GL.LoadMatrix(ref lookAt);
                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadIdentity();
                GL.PushMatrix();
                GL.Translate(960f, 960f, 0.0f);
                GL.Scale(this.Zoom, this.Zoom, this.Zoom);
                GL.Rotate((double)this.RotationHorizontal / 100.0, 0.0, 1.0, 0.0);
                GL.Rotate((double)this.RotateVertical / 100.0, 1.0, 0.0, 0.0);
                // GL.Viewport(x, y, this.Width, this.Width);

                var model =  camera.GetView();
               // GL.LoadMatrix(ref model);
                var lookAt = camera.GetProjectionMatrix();
                GL.LoadMatrix(ref model);
                GL.Translate(-960f, -960f, 0.0f);

                //{(0.305695, 0.452855, -0.8375398, 0)\n(5.934954E-09, 0.879649, 0.4756234, 0)\n(0.9521295, -0.1453957, 0.2689043, 0)\n(-0.2856389, 0.04361872, -0.0806713, 1)}
                //{(0.305695, 0.452855, -0.8375398, 0)\n(5.934954E-09, 0.879649, 0.4756234, 0)\n(0.9521295, -0.1453957, 0.2689043, 0)\n(-0.2856389, 0.04361872, -0.0806713, 1)}

                CurrentTerrain.DrawTerrain(true);
                foreach (var item in LinkedRegions)
                    item.Value.DrawTerrain(true, item.Key);

                GL.PopMatrix();
                this.ContextStatus = MapStatus.Stopped;
            }
            this.SwapBuffers();
        }


        public void LoadGL(object sender, EventArgs arg)
        {
            camera = new MapCamera(this.Width / this.Height);
            this.MouseWheel += new MouseEventHandler(glControl1_Scroll);
            this.KeyDown += OnKeyboardCameraMove;
            this.MouseMove += MapControl_MouseMove;
            this.MouseDown += MapControl_MouseDown;
            this.MouseUp += MapControl_MouseUp;
            GL.ClearColor(Color.Black);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            var model = Matrix4.Identity * camera.GetView();
            GL.LoadMatrix(ref model);
            //  GL.Ortho(0.0, 1920.0 * 6, 0.0, 1920.0 * 6, -5000.0, 5000.0);
            // var lookAt = camera.GetProjectionMatrix();
            // GL.LoadMatrix(ref lookAt);
            //Matrix4.CreateOrthographic( 1920.0f * 6, 1920.0f * 6, -5000.0f, 5000.0f, out Matrix4 currMatrix);
            // GL.LoadMatrix(ref currMatrix);
            GL.Viewport(0, 0, this.Width, this.Width);
            GL.PointSize(3f);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusDstAlpha);
            GL.Enable(EnableCap.DepthTest);
            Application.Idle += new EventHandler(this.Application_Idle);
        }

        private void MapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (Clicked && e.Button == MouseButtons.Left)
                Clicked = false;
        }

        private bool Clicked = false;
        private void MapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (!Clicked && e.Button == MouseButtons.Left)
                Clicked = true;
        }
        private Vector2 _lastPos = new Vector2(0, 0);
        private void MapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (ContextStatus == MapStatus.Unload || ContextStatus == MapStatus.Loading)
                return;

            if (Clicked)
            {
                var deltaX = e.X - _lastPos.X;
                var deltaY = e.Y - _lastPos.Y;
                _lastPos = new Vector2(e.X, e.Y);

                // Apply the camera pitch and yaw (we clamp the pitch in the camera class)
                camera.Yaw += deltaX * sensitivity;
                camera.Pitch -= deltaY * sensitivity; // Reversed since y-coordinates range from bottom to top

                ContextStatus = MapStatus.Finished;
            }
        }

        const float sensitivity = 0.2f;
        private void glControl1_Scroll(object sender, MouseEventArgs e)
        {
            var cp = this.PointToClient(e.Location);
            if (this.ContextStatus != MapStatus.Stopped || this.ContextStatus == MapStatus.Unload || e.X >= this.Width || e.Y >= this.Height)
                return;
            this.Zoom += (double)e.Delta / 300.0; ;
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
camera.Move(e);
            
            if (e.KeyCode == Keys.S)
                if (y < 320 * 256)
                    y += 100;
                else
                    return;
            else if (e.KeyCode == Keys.W)
                if (y > 99)
                    y -= 100;
                else
                    return;
            else if (e.KeyCode == Keys.A)
                if (x < 320 * 256)
                    x += 100;
                else
                    return;
            else if (e.KeyCode == Keys.D)
                if (x > 99)
                    x -= 100;
                else
                    return;
            else if (e.KeyCode == Keys.Q)
                if (RotateVertical <= 18000)
                    RotateVertical += 1000;
                else
                    return;
            else if (e.KeyCode == Keys.E)
                if (RotateVertical >= 1000)
                    RotateVertical -= 1000;
                else
                    return;
            

            ContextStatus = MapStatus.Finished;
        }
    }
}



/*
 
 
using ClientDataStorage.Client;
using ClientDataStorage.Client.Files;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
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
        Dictionary<Point, RegionTerrain> AllTerrains = new Dictionary<Point, RegionTerrain>();
        Dictionary<Point, RegionTerrain> LinkedRegions = new Dictionary<Point, RegionTerrain>(8);
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
            if (meshFile.Blocks.Count != 36)
                return;

            newload = lo;
            if (this.ContextStatus != MapStatus.Stopped && this.ContextStatus != MapStatus.Unload)
                return;
            GL.MatrixMode(MatrixMode.Projection);

            if (lo)
            {
                x = 0; y = 0;
                // GL.Viewport(x, y, this.Width, this.Height);

                if (LinkedRegions.Count > 0)
                    LinkedRegions.Clear();

                ///  ^
                ///  Y
                ///  |
                ///  |
                ///  |
                ///  |
                ///  |
                ///  |
                ///  |_________________ x >




                if (Map.MapPk2.FileExists($"Map\\{meshFile.Y - 1}\\{meshFile.X - 1}.m"))
                {
                    var newPoint = new Point(meshFile.X - 1, meshFile.Y - 1);
                    if (!Map.AllmFiles.ContainsKey(newPoint))
                        Map.AllmFiles.Add(newPoint, new mFile(Map.MapPk2.GetFileByDirectory($"Map\\{newPoint.Y }\\{newPoint.X}.m")));

                    if (!AllTerrains.ContainsKey(newPoint))
                        AllTerrains.Add(newPoint, new RegionTerrain(Map.AllmFiles[newPoint]));

                    LinkedRegions.Add(new Point(-1, -1), AllTerrains[newPoint]);
                }

                if (Map.MapPk2.FileExists($"Map\\{meshFile.Y - 1}\\{meshFile.X }.m"))
                {
                    var newPoint = new Point(meshFile.X, meshFile.Y - 1);
                    if (!Map.AllmFiles.ContainsKey(newPoint))
                        Map.AllmFiles.Add(newPoint, new mFile(Map.MapPk2.GetFileByDirectory($"Map\\{newPoint.Y }\\{newPoint.X}.m")));


                    if (!AllTerrains.ContainsKey(newPoint))
                        AllTerrains.Add(newPoint, new RegionTerrain(Map.AllmFiles[newPoint]));

                    LinkedRegions.Add(new Point(0, -1), AllTerrains[newPoint]);
                }

                if (Map.MapPk2.FileExists($"Map\\{meshFile.Y - 1}\\{meshFile.X + 1}.m"))
                {
                    var newPoint = new Point(meshFile.X + 1, meshFile.Y - 1);
                    if (!Map.AllmFiles.ContainsKey(newPoint))
                        Map.AllmFiles.Add(newPoint, new mFile(Map.MapPk2.GetFileByDirectory($"Map\\{newPoint.Y }\\{newPoint.X}.m")));

                    if (!AllTerrains.ContainsKey(newPoint))
                        AllTerrains.Add(newPoint, new RegionTerrain(Map.AllmFiles[newPoint]));

                    LinkedRegions.Add(new Point(1, -1), AllTerrains[newPoint]);
                }

                if (Map.MapPk2.FileExists($"Map\\{meshFile.Y + 1}\\{meshFile.X - 1}.m"))
                {
                    var newPoint = new Point(meshFile.X - 1, meshFile.Y + 1);
                    if (!Map.AllmFiles.ContainsKey(newPoint))
                        Map.AllmFiles.Add(newPoint, new mFile(Map.MapPk2.GetFileByDirectory($"Map\\{newPoint.Y }\\{newPoint.X}.m")));

                    if (!AllTerrains.ContainsKey(newPoint))
                        AllTerrains.Add(newPoint, new RegionTerrain(Map.AllmFiles[newPoint]));

                    LinkedRegions.Add(new Point(-1, 1), AllTerrains[newPoint]);
                }

                if (Map.MapPk2.FileExists($"Map\\{meshFile.Y + 1}\\{meshFile.X}.m"))
                {
                    var newPoint = new Point(meshFile.X, meshFile.Y + 1);
                    if (!Map.AllmFiles.ContainsKey(newPoint))
                        Map.AllmFiles.Add(newPoint, new mFile(Map.MapPk2.GetFileByDirectory($"Map\\{newPoint.Y }\\{newPoint.X}.m")));

                    if (!AllTerrains.ContainsKey(newPoint))
                        AllTerrains.Add(newPoint, new RegionTerrain(Map.AllmFiles[newPoint]));

                    LinkedRegions.Add(new Point(0, 1), AllTerrains[newPoint]);
                }

                if (Map.MapPk2.FileExists($"Map\\{meshFile.Y + 1}\\{meshFile.X + 1}.m"))
                {
                    var newPoint = new Point(meshFile.X + 1, meshFile.Y + 1);
                    if (!Map.AllmFiles.ContainsKey(newPoint))
                        Map.AllmFiles.Add(newPoint, new mFile(Map.MapPk2.GetFileByDirectory($"Map\\{newPoint.Y }\\{newPoint.X}.m")));

                    if (!AllTerrains.ContainsKey(newPoint))
                        AllTerrains.Add(newPoint, new RegionTerrain(Map.AllmFiles[newPoint]));

                    LinkedRegions.Add(new Point(1, 1), AllTerrains[newPoint]);
                }

                if (Map.MapPk2.FileExists($"Map\\{meshFile.Y }\\{meshFile.X + 1}.m"))
                {
                    var newPoint = new Point(meshFile.X + 1, meshFile.Y);
                    if (!Map.AllmFiles.ContainsKey(newPoint))
                        Map.AllmFiles.Add(newPoint, new mFile(Map.MapPk2.GetFileByDirectory($"Map\\{newPoint.Y }\\{newPoint.X}.m")));

                    if (!AllTerrains.ContainsKey(newPoint))
                        AllTerrains.Add(newPoint, new RegionTerrain(Map.AllmFiles[newPoint]));

                    LinkedRegions.Add(new Point(1, 0), AllTerrains[newPoint]);
                }

                if (Map.MapPk2.FileExists($"Map\\{meshFile.Y}\\{meshFile.X - 1 }.m"))
                {
                    var newPoint = new Point(meshFile.X - 1, meshFile.Y);
                    if (!Map.AllmFiles.ContainsKey(newPoint))
                        Map.AllmFiles.Add(newPoint, new mFile(Map.MapPk2.GetFileByDirectory($"Map\\{newPoint.Y }\\{newPoint.X}.m")));

                    if (!AllTerrains.ContainsKey(newPoint))
                        AllTerrains.Add(newPoint, new RegionTerrain(Map.AllmFiles[newPoint]));

                    LinkedRegions.Add(new Point(-1, 0), AllTerrains[newPoint]);
                }
            }
            else
            {
                x = 0; y = 0;
                // GL.Viewport(0, 0, this.Width, this.Width);
            }

            CurrentTerrain = new RegionTerrain(meshFile);
            this.ContextStatus = MapStatus.Finished;
            // GC.Collect();
        }


        public void Render()
        {
            if (!this.Context.IsCurrent)
                this.MakeCurrent();


            if (this.ContextStatus == MapStatus.Finished)
            {
                GL.MatrixMode(MatrixMode.Projection);
                GL.Viewport(x, y, this.Width, this.Width);
                GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadIdentity();
                GL.PushMatrix();
                GL.Translate(960f, 960f, 0.0f);
                GL.Scale(this.Zoom, this.Zoom, this.Zoom);
                GL.Rotate((double)this.RotationHorizontal / 100.0, 0.0, 1.0, 0.0);
                GL.Rotate((double)this.RotateVertical / 100.0, 1.0, 0.0, 0.0);
                //GL.Viewport(x, y, 255 * 320, 255 * 320);

                GL.Translate(-960f, -960f, 0.0f);
                if (newload)
                {
                    CurrentTerrain.DrawTerrain(true);
                    foreach (var item in LinkedRegions)
                        item.Value.DrawTerrain(true, item.Key);
                }
                else
                    CurrentTerrain.DrawTerrain(true);

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
            GL.Ortho(0.0, 1920.0 * 6, 0.0, 1920.0 * 6, -5000.0, 5000.0);
            GL.Viewport(0, 0, this.Width, this.Width);
            GL.PointSize(3f);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusDstAlpha);
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
            this.Zoom += (double)e.Delta / 300.0; ;
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
            if (e.KeyCode == Keys.S)
                if (y < 320 * 256)
                    y += 100;
                else
                    return;
            else if (e.KeyCode == Keys.W)
                if (y > -1000)
                    y -= 100;
                else
                    return;
            else if (e.KeyCode == Keys.A)
                if (x < 320 * 256)
                    x += 100;
                else
                    return;
            else if (e.KeyCode == Keys.D)
                if (x > -10000)
                    x -= 100;
                else
                    return;
            else if (e.KeyCode == Keys.Q)
                if (RotateVertical <= 18000)
                    RotateVertical += 1000;
                else
                    return;
            else if (e.KeyCode == Keys.E)
                if (RotateVertical >= 1000)
                    RotateVertical -= 1000;
                else
                    return;


            ContextStatus = MapStatus.Finished;
        }
    }
}

 */