using Editors.Shop;
using ServerFrameworkRes.Network.Security;
using Structs.Database;
using System;
using System.Collections.Generic;

namespace ShopEditor.Interface.ShopInterface
{
    internal class EditorInterface
    {
        private readonly Editors.Shop.ShopEditor editor;
        private readonly List<Packet> PacketsToSend = new List<Packet>();

        public EditorInterface(CIShopGood good)
        {
            editor = new Editors.Shop.ShopEditor(good);
            editor.OnUpdatePricePolicy += Editor_OnUpdatePricePolicy;
            editor.Show();
        }

        private void Editor_OnUpdatePricePolicy()
        {
        }

        private bool ShopItemPricePolicyOfItemUpdateRequest(RefPricePolicyOfItem pricePolicyOfItem, EditAction action, out Packet packet)
        {
            try
            {
                packet = new Packet(PacketID.Client.ShopDataRefPricePolicyOfItem, false, true);
                packet.WriteByte(action);
                packet.WriteStruct(pricePolicyOfItem);
                return true;
            }
            catch (Exception ex)
            {
                packet = null;
                return false;
            }
        }
    }
}