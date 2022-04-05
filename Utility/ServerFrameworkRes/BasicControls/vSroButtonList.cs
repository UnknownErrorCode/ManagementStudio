using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ServerFrameworkRes.BasicControls
{
    public partial class vSroButtonList : UserControl
    {
        #region Fields

        private readonly List<vSroListButton> AllButtonsOnTable = new List<vSroListButton>();
        private readonly Dictionary<string, vSroListButton> AllButtonsOnTable2 = new Dictionary<string, vSroListButton>();

        #endregion Fields

        #region Constructors

        public vSroButtonList()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Events

        public event EventHandler OnIndCh;

        #endregion Events

        #region Properties

        public vSroListButton LatestSelectedButton { get; private set; }

        #endregion Properties

        #region Methods

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
                singleButton.Click += ResetSelectionOnClick;
                singleButton.labelButtonName.Click += LabelButtonName_Click;
                singleButton.Location = new Point(6, 6 + (((AllButtonsOnTable.Count) * singleButton.Height)));
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
                AllButtonsOnTable.Add(singleButton);
                // OnAddButton();
            }
        }

        public void AddSingleButtonToList(vSroListButton singleButton)
        {
            if (!AllButtonsOnTable.Contains(singleButton))
            {
                singleButton.Click += ResetSelectionOnClick;
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

        public void Clear()
        {
            AllButtonsOnTable.Clear();
            RefreshTable();
        }

        public bool ContainsTitle(string title)
        {
            return AllButtonsOnTable.Exists(itm => itm.ButtonName.Equals(title));
        }

        public void RemoveSingleButtonFromList(string buttonToDelete)
        {
            if (AllButtonsOnTable.Exists(btn => btn.ButtonName == buttonToDelete))
            {
                AllButtonsOnTable.Remove(AllButtonsOnTable.Single(btn => btn.ButtonName == buttonToDelete));
                RefreshTable();
            }
        }

        public void ResetSelectionOnClick(object sender, EventArgs e)
        {
            if (LatestSelectedButton != null)
            {
                LatestSelectedButton.BackgroundImage = LatestSelectedButton.imageListSingleButton.Images[0];
                LatestSelectedButton.labelButtonName.ForeColor = Color.White;
            }
            LatestSelectedButton = (vSroListButton)sender;
            //OnSelectChanged();
            if (OnIndCh != null)
            {
                OnIndCh(LatestSelectedButton, e);
            }

            //AllButtonsOnTable.Values.Where(button => button != (vSroListButton)sender).ToList().ForEach(buttn => buttn.BackgroundImage = buttn.imageListSingleButton.Images[0]);
            //AllButtonsOnTable.Values.Where(button => button != (vSroListButton)sender).ToList().ForEach(buttn => buttn.labelButtonName.ForeColor = Color.White);
        }

        private void LabelButtonName_Click(object sender, EventArgs e)
        {
            ResetSelectionOnClick((vSroListButton)((Label)sender).Parent, e);
        }

        private void recolorItems(object sender, EventArgs e)
        {
            AllButtonsOnTable.Where(button => button != (vSroListButton)sender).ToList().ForEach(buttn => buttn.labelButtonName.ForeColor = Color.White);
        }

        private void RefreshTable()
        {
            if (InvokeRequired)
            {
                IAsyncResult invoke = BeginInvoke(new Action(() =>
                {
                    SuspendLayout();
                    Controls.Clear();
                    foreach (vSroListButton item in AllButtonsOnTable)
                    {
                        item.Click += recolorItems;
                        item.labelButtonName.Click += recolorItems;

                        Controls.Add(item);
                    }
                    ResumeLayout();
                }));
                EndInvoke(invoke);
            }
            else
            {
                SuspendLayout();
                Controls.Clear();
                foreach (vSroListButton item in AllButtonsOnTable)
                {
                    Controls.Add(item);
                }
                ResumeLayout();
            }
        }

        #endregion Methods
    }
}