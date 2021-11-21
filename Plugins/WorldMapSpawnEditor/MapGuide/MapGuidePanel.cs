using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Windows.Forms;

namespace WorldMapSpawnEditor.MapGuide
{
    class MapGuidePanel : Panel
    {

        private Point DrawStartPoint;

        private Point LastMousePosition;

        private const string FilePath = "Media\\interface\\worldmap\\map";

        internal MapGuidePanel()
        {
            this.DoubleBuffered = true;
            this.Size = new Size(652, 424);

            this.Paint += MapGuidePanel_Paint;
            this.MouseUp += MapGuidePanel_MouseUp;
            this.MouseDown += MapGuidePanel_MouseDown;
            InitializeMapImages();
        }


        private void InitializeMapImages()
        {

            var filesExist = ClientDataStorage.Client.Media.MediaPk2.GetFilesInFolder(FilePath, out Structs.Pk2.Pk2File[] files);

            foreach (var i in files)
            {

                var name = i.name;

                if (!name.StartsWith("map_world_"))
                    continue;


                var Coordinates = name.Replace("map_world_", "").Replace(".ddj", "").Split('x');


                if (byte.TryParse(Coordinates[0], out byte x) && byte.TryParse(Coordinates[1], out byte y))
                    if (ClientDataStorage.Client.Media.MediaPk2.GetByteArrayByDirectory(System.IO.Path.Combine(FilePath, i.name), out byte[] file))
                        imgDic.TryAdd(new Point(x, y), new ClientDataStorage.Client.Files.DDSImage(file, true).BitmapImage);


            }
        }

        private void MapGuidePanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                DrawStartPoint.X = DrawStartPoint.X + (e.X - LastMousePosition.X);
                DrawStartPoint.Y = DrawStartPoint.Y + (e.Y - LastMousePosition.Y);
                this.Invalidate();
            }
        }

        private void MapGuidePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
                this.LastMousePosition = e.Location;
        }
        ConcurrentDictionary<Point, Bitmap> imgDic = new ConcurrentDictionary<Point, Bitmap>();
        private void MapGuidePanel_Paint(object sender, PaintEventArgs e)
        {

            var g = this.CreateGraphics();
            foreach (var item in imgDic)
            {
                g.DrawImage(item.Value, item.Key);
            }

            /*
               var allfiles = Directory.GetFiles("D:\\projects\\resources\\map2");
            imgDic = new Dictionary<Point, Image>(allfiles.Length - 1);


            foreach (var i in allfiles)
            {

                var name = Path.GetFileNameWithoutExtension(i);

                if (!name.StartsWith("map_world_"))
                    continue;


                var Coordinates = name.Replace("map_world_", "").Split("x");

                if (byte.TryParse(Coordinates[0], out byte x) && byte.TryParse(Coordinates[1], out byte y))
                    imgDic.TryAdd(new Point(x, y), Image.FromFile(i));

            }
             */
        }
    }
}
