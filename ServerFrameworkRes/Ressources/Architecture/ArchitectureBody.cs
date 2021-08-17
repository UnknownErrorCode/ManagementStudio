using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerFrameworkRes.Network.AsyncNetwork;
using ServerFrameworkRes.Network.Security;
using ServerFrameworkRes.Ressources.ServerBody;
namespace ServerFrameworkRes.Ressources
{
    public partial class ArchitectureBody : UserControl
    {
        public Dictionary<ServerBodyState, Image> ServerBodyImages = new Dictionary<ServerBodyState, Image>();
        public  ServerData SelfBody;
        public Point BodyLocation { get; set; }
        public Point DockChordsPoint { get => new Point(this.Location.X+25,this.Location.Y+25); }
        public ArchitectureBody(ServerData IncomeSelfBody,Point Locationee)
        {
            BodyLocation = Locationee;
            SelfBody = IncomeSelfBody;
            
            InitializeComponent();
            this.Location = BodyLocation;
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
            if (e.Button==MouseButtons.Left)
            {
                this.clickPosition.X = e.X;
                this.clickPosition.Y = e.Y;
            }
        }

        private void ArchitectureBody_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.SuspendLayout();
                Point DeltaXY = new Point((Size)clickPosition - (Size)e.Location);
                this.Location = new Point((Size)Location- (Size)DeltaXY);
                this.ResumeLayout(false);
            }
            
        }
    }
}
