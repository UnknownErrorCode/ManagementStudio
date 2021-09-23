using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldMapSpawnEditor.MapGame
{
    class Game : GameWindow
    {

        public Game(string title)
        {
            this.Title = title;
            base.Load += OnLoadGame;
            base.Resize += OnResizeGame;
            base.RenderFrame += OnRenderGame;
        }

        private void OnRenderGame(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, 1920.0 , 0, 1920.0 , -5000.0, 5000.0);

        }

        private void OnResizeGame(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, this.Width, this.Width);
        }

        private void OnLoadGame(object sender, EventArgs e)
        {
            base.VSync = VSyncMode.On;
        }
    }
}
