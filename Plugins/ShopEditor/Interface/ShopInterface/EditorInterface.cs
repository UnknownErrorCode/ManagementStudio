using Editors.Shop;
using ServerFrameworkRes.BasicControls;
using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopEditor.Interface.ShopInterface
{
    class EditorInterface 
    {
        Editors.Shop.ShopEditor editor;
        private List<Packet> PacketsToSend = new List<Packet>();


        public EditorInterface(CIShopGood good)
        {
            editor = new Editors.Shop.ShopEditor(good);
            editor.OnUpdatePricePolicy += Editor_OnUpdatePricePolicy;
            editor.Show();
        }

        private void Editor_OnUpdatePricePolicy()
        {

            foreach (var item in editor.Good.PricePolicyOfItem)
            {
                if (!editor.OldGood.PricePolicyOfItem.Contains(item))
                    if (PacketID.Client.ShopItemPriceUpdate(item, out Packet packet))
                        PacketsToSend.Add(packet);
            }

            vSroMessageBox.Show($"Added {PacketsToSend.Count} packets.");

            foreach (var item in PacketsToSend)
                ShopEditorControl.StaticData.m_security.Send(item);
        }
    }
}
