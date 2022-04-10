using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldMapSpawnEditor.MapGraphics
{
    public partial class PositionStorage : Form
    {
        public static Dictionary<string, NewPosition> Collection = new Dictionary<string, NewPosition>();
        public NewPosition SelectedPosition;
        public bool isSelected = false;

        public PositionStorage()
        {
            InitializeComponent();
            foreach (var pos in Collection.Values)
            {
                ListViewItem i = new ListViewItem(pos.Text) { Tag = pos };
                listView1.Items.Add(i);
            }
        }

        internal static void StorePosition(string name, NewPosition position)
        {
            if (Collection.ContainsKey(name))
            {
                int i = 2;
                while (true)
                {
                    if (!Collection.ContainsKey($"{name}{i}"))
                    {
                        position.Text = $"{name}{i}";
                        Collection.Add(position.Text, position);
                        break;
                    }
                    i++;
                }
            }
            else
            {
                Collection.Add(name, position);
            }
        }

        internal static bool SelectPoint(out NewPosition pos)
        {
            using (var selecter = new PositionStorage())
            {
                selecter.ShowDialog();
                if (selecter.isSelected)
                {
                    pos = selecter.SelectedPosition;
                    return true;
                }
                pos = default(NewPosition);
                return false;
            }
        }

        private void PositionStorage_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                propertyGrid1.SelectedObject = (NewPosition)listView1.SelectedItems[0].Tag;
                buttonSelect.Enabled = true;
                buttonDelete.Enabled = true;
            }
            else
            {
                propertyGrid1.SelectedObject = null;
                buttonSelect.Enabled = false;
                buttonDelete.Enabled = false;
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            SelectedPosition = (NewPosition)listView1.SelectedItems[0].Tag;
            isSelected = true;
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Collection.Remove(SelectedPosition.Text);
            listView1.Items.RemoveByKey(SelectedPosition.Text);
            propertyGrid1.SelectedObject = null;
            buttonDelete.Enabled = false;
            buttonSelect.Enabled = false;
        }

        private void PositionStorage_Load(object sender, EventArgs e)
        {
        }

        private void buttonCharPosition_Click(object sender, EventArgs e)
        {
        }
    }
}