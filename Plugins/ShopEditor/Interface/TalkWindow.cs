using ShopEditor.Interface;
using ShopEditor.Interface.ShopInterface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ShopEditor
{
    public partial class TalkWindow : UserControl
    {
        /// <summary>
        /// Storing NpcData into the application to prevent recreate when needed.
        /// </summary>
        private readonly Dictionary<string, NpcShopData> NpcShopInformation = new Dictionary<string, NpcShopData>();

        public static ToolTip ShopToolTip = new ToolTip();

        /// <summary>
        /// Communication window like click on an NPC. This window has to be static and aviable only 1 times in the entired application!!!
        /// </summary>
        public TalkWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Task to complete when NPC gets selected.
        /// </summary>
        /// <param name="npcName">NPC CodeName128 from _RefObjCommon</param>
        internal void OnNpcClick(string npcName)
        {
            foreach (IDisposable item in splitContainer1.Panel2.Controls)
            {
                item.Dispose();
            }

            splitContainer1.Panel2.Controls.Clear();

            if (!NpcShopInformation.ContainsKey(npcName))
            {
                NpcShopInformation.Add(npcName, new NpcShopData(npcName));
            }

            foreach (RefShopGroup group in NpcShopInformation[npcName].ShopGroups)
            {
                foreach (RefShop store in group.ShopGroup)
                {
                    foreach (RefShopTabGroup tabgroup in store.TabGroups)
                    {
                        if (tabgroup.StrID128Name == null)
                        {
                            continue;
                        }

                        splitContainer1.Panel2.Controls.Add(CreateLabel(npcName, tabgroup));
                    }
                }
            }
        }

        private Label CreateLabel(string npcName, RefShopTabGroup shopTabGroup)
        {
            Label label = new Label()
            {
                AutoSize = true,
                Location = new Point(0, 20 * splitContainer1.Panel2.Controls.Count),
                Text = ClientDataStorage.Client.Media.StaticTextuiSystem.UIIT_Strings.TryGetValue(shopTabGroup.StrID128Name, out Structs.Pk2.Media.TextUISystemStruct element) ? element.Viethnam : shopTabGroup.StrID128Name,
                Tag = shopTabGroup
            };

            label.MouseEnter += Label_MouseEnter;
            label.MouseLeave += Label_MouseLeave;
            label.MouseClick += Label_MouseClick;

            return label;
        }

        private void Label_MouseClick(object sender, MouseEventArgs e)
        {
            new ShopTabGroupWindow((RefShopTabGroup)((Label)sender).Tag).Show();
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.FromArgb(239, 218, 164);
        }

        private void Label_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.FromArgb(255, 138, 0);
        }
    }
}