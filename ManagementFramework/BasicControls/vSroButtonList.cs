using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ManagementFramework.BasicControls
{
    public partial class vSroButtonList : UserControl
    {
        private readonly List<vSroListButton> AllButtonsOnTable = new List<vSroListButton>();

        public vSroButtonList()
        {
            InitializeComponent();
        }

        public event EventHandler OnIndCh;

        public vSroListButton LatestSelectedButton { get; private set; }

        /// <summary>
        /// Adds a Button with 'incomeButtonName' name on the List
        /// </summary>
        /// <param name="incomeButtonName"></param>
        public void AddSingleButtonToList(string incomeButtonName, object tag = null)
        {
            if (!AllButtonsOnTable.Exists(btn => btn.ButtonName == incomeButtonName))
            {
                vSroListButton singleButton = new vSroListButton(incomeButtonName)
                {
                    Tag = tag
                };
                AddSingleButtonToList(singleButton);
            }
        }

        public bool ContainsTitle(string title) => AllButtonsOnTable.Exists(itm => itm.ButtonName.Equals(title));

        public void RemoveButton(string buttonToDelete)
        {
            if (AllButtonsOnTable.Exists(btn => btn.ButtonName == buttonToDelete))
            {
                AllButtonsOnTable.Remove(AllButtonsOnTable.Single(btn => btn.ButtonName == buttonToDelete));
                RefreshTable();
            }
        }

        private void AddSingleButtonToList(vSroListButton singleButton)
        {
            if (!AllButtonsOnTable.Contains(singleButton))
            {
                singleButton.Click += ResetSelectionOnClick;
                singleButton.labelButtonName.Click += LabelButtonName_Click;
                AllButtonsOnTable.Add(singleButton);

                singleButton.Location = new Point(6, 6 + (((AllButtonsOnTable.Count - 1) * singleButton.Height)));
                if (InvokeRequired)
                {
                    IAsyncResult invoke = BeginInvoke(new Action(() =>
                    {
                        Controls.Add(singleButton);
                    }));
                    EndInvoke(invoke);
                }
                else
                {
                    Controls.Add(singleButton);
                }
            }
        }

        private void LabelButtonName_Click(object sender, EventArgs e) => ResetSelectionOnClick((vSroListButton)((Label)sender).Parent, e);

        private void ResetSelectionOnClick(object sender, EventArgs e)
        {
            if (LatestSelectedButton != null)
            {
                LatestSelectedButton.BackgroundImage = LatestSelectedButton.imageListSingleButton.Images[0];
                LatestSelectedButton.labelButtonName.ForeColor = Color.White;
            }
            LatestSelectedButton = (vSroListButton)sender;
            AllButtonsOnTable.Where(button => button != (vSroListButton)sender).ToList().ForEach(buttn => buttn.labelButtonName.ForeColor = Color.White);

            if (OnIndCh != null)
            {
                OnIndCh(LatestSelectedButton, e);
            }
        }

        private void RefreshTable()
        {
            SuspendLayout();
            if (InvokeRequired)
            {
                IAsyncResult invoke = BeginInvoke(new Action(() =>
                {
                    Controls.Clear();
                    foreach (vSroListButton item in AllButtonsOnTable)
                    {
                        item.Location = new Point(6, 6 + (((AllButtonsOnTable.Count - 1) * item.Height)));
                        Controls.Add(item);
                    }
                }));
                EndInvoke(invoke);
            }
            else
            {
                Controls.Clear();
                foreach (vSroListButton item in AllButtonsOnTable)
                {
                    item.Location = new Point(6, 6 + (((AllButtonsOnTable.Count - 1) * item.Height)));
                    Controls.Add(item);
                }
            }
            ResumeLayout();
        }
    }
}