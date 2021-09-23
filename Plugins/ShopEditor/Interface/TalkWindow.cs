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
        /// <summary>
        /// Storing NpcData into the application to prevent recreate when needed.
        /// </summary>
        private Dictionary<string, NpcShopData> NpcShopInformation = new Dictionary<string, NpcShopData>();

        /// <summary>
        /// Communication window like click on an NPC. This window has to be static and aviable only 1 times in the entired application!!!
        /// </summary>
        public TalkWindow()
           => InitializeComponent();

        /// <summary>
        /// Task to complete when NPC gets selected.
        /// </summary>
        /// <param name="npcName">NPC CodeName128 from _RefObjCommon</param>
        internal void OnNpcClick(string npcName)
        {
            foreach (IDisposable item in this.splitContainer1.Panel2.Controls)
                item.Dispose();

            this.splitContainer1.Panel2.Controls.Clear();

            if (!NpcShopInformation.ContainsKey(npcName))
                NpcShopInformation.Add(npcName, new NpcShopData(npcName));

            foreach (var group in NpcShopInformation[npcName].ShopGroups)
                foreach (var store in group.ShopGroup)
                    foreach (var tabgroup in store.TabGroups)
                        this.splitContainer1.Panel2.Controls.Add(new Label() { AutoSize = true, Text = tabgroup.StrID128Name, Tag = npcName, Location = new Point(0, 20 * this.splitContainer1.Panel2.Controls.Count) });
        }
    }
}
