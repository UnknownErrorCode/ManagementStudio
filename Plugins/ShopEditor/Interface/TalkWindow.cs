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
        private protected NpcShopData NpcShopInformation;

        public TalkWindow()
        {
            InitializeComponent();
        }

        internal void OnNpcClick(string npcName)
        {

        }
       
    }
}
