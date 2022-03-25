using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerFrameworkRes.BasicControls
{
    public partial class vSroButtonList : UserControl
    {
        Dictionary<string, vSroListButton> AllButtonsOnTable2 = new Dictionary<string, vSroListButton>();
        private List<vSroListButton> AllButtonsOnTable = new List<vSroListButton>();
        public vSroListButton LatestSelectedButton { get; private set; }

        public event EventHandler OnIndCh;
        public event Action OnSelectChanged;
        public event Action OnAddButton;

        public bool ContainsTitle(string title) => AllButtonsOnTable.Exists(itm => itm.ButtonName.Equals(title));


        public vSroButtonList()
        {
            InitializeComponent();
        }

        private void RefreshTable()
        {
            if (this.InvokeRequired)
            {
                var invoke = this.BeginInvoke(new Action(() =>
                {
                    this.SuspendLayout();
                    this.Controls.Clear();
                    foreach (var item in AllButtonsOnTable)
                    {
                        item.Click += recolorItems;
                        item.labelButtonName.Click += recolorItems;

                        this.Controls.Add(item);
                    }
                    this.ResumeLayout();
                }));
                this.EndInvoke(invoke);
            }
            else
            {
                this.SuspendLayout();
                this.Controls.Clear();
                foreach (var item in AllButtonsOnTable)
                {
                    this.Controls.Add(item);
                }
                this.ResumeLayout();
            }

        }

        private void recolorItems(object sender, EventArgs e)
        {
            AllButtonsOnTable.Where(button => button != (vSroListButton)sender).ToList().ForEach(buttn => buttn.labelButtonName.ForeColor = Color.White);
        }

        /// <summary>
        /// Adds a Button with 'incomeButtonName' name on the List
        /// </summary>
        /// <param name="incomeButtonName"></param>
        public void AddSingleButtonToList(string incomeButtonName, object tag = null)
        {
            if (!AllButtonsOnTable.Exists(btn => btn.ButtonName == incomeButtonName))
            {
                vSroListButton singleButton = new vSroListButton(incomeButtonName);
                singleButton.Tag = tag;
                singleButton.Click += ResetSelectionOnClick;
                singleButton.labelButtonName.Click += LabelButtonName_Click;
                singleButton.Location = new Point(6, 6 + (((AllButtonsOnTable.Count) * singleButton.Height)));
                if (this.InvokeRequired)
                {
                    var invoke = this.BeginInvoke(new Action(() =>
                    {
                        this.Controls.Add(singleButton);
                    }));
                    this.EndInvoke(invoke);
                }
                else
                {
                    this.Controls.Add(singleButton);
                }
                AllButtonsOnTable.Add(singleButton);
               // OnAddButton();
            }
        }

        private void LabelButtonName_Click(object sender, EventArgs e)
        {
            ResetSelectionOnClick((vSroListButton)((Label)sender).Parent, e);
        }

        public void Clear()
        {
            AllButtonsOnTable.Clear();
            this.RefreshTable();
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
            OnIndCh(LatestSelectedButton, e);
            //AllButtonsOnTable.Values.Where(button => button != (vSroListButton)sender).ToList().ForEach(buttn => buttn.BackgroundImage = buttn.imageListSingleButton.Images[0]);
            //AllButtonsOnTable.Values.Where(button => button != (vSroListButton)sender).ToList().ForEach(buttn => buttn.labelButtonName.ForeColor = Color.White);
        }

        public void AddSingleButtonToList(vSroListButton singleButton)
        {
            if (!AllButtonsOnTable.Contains(singleButton))
            {
                singleButton.Click += ResetSelectionOnClick;
                AllButtonsOnTable.Add(singleButton);


                singleButton.Location = new Point(6, 6 + (((AllButtonsOnTable.Count - 1) * singleButton.Height)));
                if (this.InvokeRequired)
                {
                    var invoke = this.BeginInvoke(new Action(() =>
                    {
                        this.Controls.Add(singleButton);
                    }));
                    this.EndInvoke(invoke);
                }
                else
                {
                    this.Controls.Add(singleButton);
                }
            }
        }

        public void RemoveSingleButtonFromList(string buttonToDelete)
        {
            if (AllButtonsOnTable.Exists(btn => btn.ButtonName == buttonToDelete))
            {
                AllButtonsOnTable.Remove(AllButtonsOnTable.Single(btn => btn.ButtonName == buttonToDelete));
                RefreshTable();
            }
        }
    }
}
