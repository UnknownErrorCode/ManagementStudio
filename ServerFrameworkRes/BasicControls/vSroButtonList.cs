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
        Dictionary<string, vSroListButton> AllButtonsOnTable = new Dictionary<string, vSroListButton>();
        private vSroListButton LatestSelectedButton { get; set; }
     
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
                        item.Value.Click += recolorItems;
                        item.Value.labelButtonName.Click += recolorItems;

                        this.Controls.Add(item.Value);
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
                    this.Controls.Add(item.Value);
                }
                this.ResumeLayout();
            }
          
        }

        private void recolorItems(object sender, EventArgs e)
        {
            AllButtonsOnTable.Values.Where(button => button != (vSroListButton)sender).ToList().ForEach(buttn => buttn.labelButtonName.ForeColor = Color.White);
        }

        /// <summary>
        /// Adds a Button with 'incomeButtonName' name on the List
        /// </summary>
        /// <param name="incomeButtonName"></param>
        public void AddSingleButtonToList(string incomeButtonName)
        {
            if (!AllButtonsOnTable.ContainsKey(incomeButtonName))
            {
                vSroListButton singleButton = new vSroListButton(incomeButtonName);
                singleButton.Click += ResetSelectionOnClick;

                singleButton.Location = new Point(6, 6 + (((AllButtonsOnTable.Count ) * singleButton.Height)));
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
                AllButtonsOnTable.Add(incomeButtonName, singleButton);
            }
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

            //AllButtonsOnTable.Values.Where(button => button != (vSroListButton)sender).ToList().ForEach(buttn => buttn.BackgroundImage = buttn.imageListSingleButton.Images[0]);
            //AllButtonsOnTable.Values.Where(button => button != (vSroListButton)sender).ToList().ForEach(buttn => buttn.labelButtonName.ForeColor = Color.White);
        }

        public void AddSingleButtonToList(vSroListButton singleButton)
        {
            if (!AllButtonsOnTable.ContainsKey(singleButton.ButtonName))
            {
                singleButton.Click += ResetSelectionOnClick;
                AllButtonsOnTable.Add(singleButton.ButtonName, singleButton);


                singleButton.Location = new Point(6, 6 + (((AllButtonsOnTable.Count - 1) * singleButton.Height)));
                if (this.InvokeRequired)
                {
                    var invoke = this.BeginInvoke(new Action(() =>
                    { this.Controls.Add(singleButton);
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
            if (AllButtonsOnTable.ContainsKey(buttonToDelete))
            {
                AllButtonsOnTable.Remove(buttonToDelete);
                RefreshTable();
            }
        }
    }
}
