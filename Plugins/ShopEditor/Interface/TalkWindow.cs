using ServerFrameworkRes.BasicControls;
using ShopEditor.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopEditor
{
    public partial class TalkWindow : UserControl
    {
        private Dictionary<string, NpcShopData> NpcShopInformation = new Dictionary<string, NpcShopData>();

        public TalkWindow()
        {
            InitializeComponent();
        }

        internal void OnNpcClick(string npcName)
        {
            if (!NpcShopInformation.ContainsKey(npcName))
                NpcShopInformation.Add(npcName, new NpcShopData(npcName));

            foreach (var sn_string in NpcShopInformation[npcName].RefShopTabGroups.Values)
            {
                this.splitContainer1.Panel2.Controls.Add(new Label() { Text = sn_string, Tag = npcName, Location = new Point(0, 25 * this.splitContainer1.Panel2.Controls.Count) });
            }

        }

    }
}
