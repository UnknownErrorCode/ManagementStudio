using ServerFrameworkRes.Network.Security;
using ServerFrameworkRes.Ressources.ServerBody;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace ServerFrameworkRes.Ressources
{
    public partial class ArchitectureBody : UserControl
    {
        public Dictionary<ServerBodyState, Image> ServerBodyImages = new Dictionary<ServerBodyState, Image>();
        public ServerData SelfBody;
        public Point BodyLocation { get; set; }
        public Point DockChordsPoint => new Point(Location.X + 25, Location.Y + 25);
        public ArchitectureBody(ServerData IncomeSelfBody, Point Locationee)
        {
            BodyLocation = Locationee;
            SelfBody = IncomeSelfBody;

            InitializeComponent();
            Location = BodyLocation;
            ServerBodyImages.Add(ServerBodyState.None, pictureBoxCertification.BackgroundImage);
            ServerBodyImages.Add(ServerBodyState.Cert, pictureBoxCertification.InitialImage);
            ServerBodyImages.Add(ServerBodyState.Exit, pictureBoxCertification.ErrorImage);
            ServerBodyImages.Add(ServerBodyState.Gray, pictureBoxWaitForStart.BackgroundImage);
            ServerBodyImages.Add(ServerBodyState.Wait, pictureBoxWaitForStart.InitialImage);
            ServerBodyImages.Add(ServerBodyState.Hide, pictureBoxWaitForStart.ErrorImage);
            ServerBodyImages.Add(ServerBodyState.Blue, pictureBoxActive.BackgroundImage);
            ServerBodyImages.Add(ServerBodyState.Busy, pictureBoxActive.InitialImage);
            ServerBodyImages.Add(ServerBodyState.Red, pictureBoxActive.ErrorImage);


        }


        protected Point clickPosition;
        protected Point scrollPosition;
        private void ArchitectureBody_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                clickPosition.X = e.X;
                clickPosition.Y = e.Y;
            }
        }

        private void ArchitectureBody_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SuspendLayout();
                Point DeltaXY = new Point((Size)clickPosition - (Size)e.Location);
                Location = new Point((Size)Location - (Size)DeltaXY);
                ResumeLayout(false);
            }

        }
    }
}
