using BinaryFiles.PackFile;
using System.Drawing;
using System.Windows.Forms;

namespace WorldMapSpawnEditor.MapGuide
{
    internal class WMapGuidePanelButtonFocus : Panel
    {
        public Bitmap wmap_big_button_world;
        public Bitmap wmap_big_button_world_focus;
        public Bitmap wmap_big_button_world_press;

        private const string smap_big_button_world = "Media\\interface\\worldmap\\wmap_big_button_world.ddj";

        private const string smap_big_button_world_focus = "Media\\interface\\worldmap\\wmap_big_button_world_focus.ddj";

        private const string smap_big_button_world_press = "Media\\interface\\worldmap\\wmap_big_button_world_press.ddj";

        public WMapGuidePanelButtonFocus()
        {
            if (!PackFile.MediaPack.Reader.GetByteArrayByDirectory(smap_big_button_world, out byte[] btn))
                Initialized = false;

            if (!PackFile.MediaPack.Reader.GetByteArrayByDirectory(smap_big_button_world_focus, out byte[] btnF))
                Initialized = false;

            if (!PackFile.MediaPack.Reader.GetByteArrayByDirectory(smap_big_button_world_press, out byte[] btnP))
                Initialized = false;

            if (!Initialized)
                return;

            wmap_big_button_world = new JMXddjFile(btn).BitmapImage;
            wmap_big_button_world_focus = new JMXddjFile(btnF).BitmapImage;
            wmap_big_button_world_press = new JMXddjFile(btnP).BitmapImage;

            DoubleBuffered = true;
            Size fixedSize = new Size(32, 32);
            MinimumSize = fixedSize;
            Size = fixedSize;
            MaximumSize = fixedSize;
            Location = new Point(660, 29);
            BackColor = Color.Black;

            MouseMove += OnMouseMove;
            MouseDown += OnMouseDown;
            MouseUp += OnMouseUp;
            MouseLeave += OnMouseLeave;
            MouseClick += OnMouseClick;
        }

        public delegate void OwnMouseClick();

        public event OwnMouseClick OnParentMouseClick;

        public bool Initialized { get; } = true;

        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            OnParentMouseClick();
        }

        private void OnMouseLeave(object sender, System.EventArgs e)
        {
            BackgroundImage = wmap_big_button_world;
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            BackgroundImage = wmap_big_button_world;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            //throw new System.NotImplementedException();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            BackgroundImage = wmap_big_button_world_focus;
            //throw new System.NotImplementedException();
        }
    }
}