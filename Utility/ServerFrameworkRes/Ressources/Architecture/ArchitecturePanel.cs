﻿using ServerFrameworkRes.Ressources.ServerBody;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ServerFrameworkRes.Ressources.Architecture
{
    public partial class ArchitecturePanel : UserControl
    {
        #region Fields

        private readonly Dictionary<string, ArchitectureBody> srNodeDataDictionary = new Dictionary<string, ArchitectureBody>();

        #endregion Fields

        #region Constructors

        public ArchitecturePanel()
        {
            InitializeComponent();
        }

        public ArchitecturePanel(List<ArchitectureBody> listOfNodeDatas)
        {
            InitializeComponent();
            foreach (ArchitectureBody item in listOfNodeDatas)
            {
                // srNodeDataDictionary.Add(item.SelfBody.AccountName, item);
            }
        }

        #endregion Constructors

        #region Properties

        private ArchitectureBody CertificationBody { get; set; }

        #endregion Properties

        #region Methods

        private void InitializeArchitecture()
        {
        }

        private void loadCertificationFromCertificationManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void showArchitectureTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point Certpoint = new Point(CertificationBody.Location.X + 70, CertificationBody.Location.Y);
            foreach (ArchitectureBody item2 in srNodeDataDictionary.Values)
            {
                if (item2.SelfBody.UserIP == "94.130.10.181")
                {
                    continue;
                }
                item2.Location = Certpoint;
                item2.pictureBoxCertification.Visible = true;
                item2.pictureBoxCertification.Image = CertificationBody.ServerBodyImages[ServerBodyState.None];
                Certpoint.Y += 50;
                Controls.Add(item2);
                Certpoint.Y = 20;
                Certpoint.X += 50;
            }
        }

        #endregion Methods
    }
}