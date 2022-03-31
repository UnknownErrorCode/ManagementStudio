using Editors.Shop;
using ServerFrameworkRes.Network.Security;
using System.Collections.Generic;

namespace ShopEditor.Interface.ShopInterface
{
    internal class EditorInterface
    {
        #region Private Fields

        private readonly Editors.Shop.ShopEditor editor;
        private readonly List<Packet> PacketsToSend = new List<Packet>();

        #endregion Private Fields

        #region Public Constructors

        public EditorInterface(CIShopGood good)
        {
            editor = new Editors.Shop.ShopEditor(good);
            editor.OnUpdatePricePolicy += Editor_OnUpdatePricePolicy;
            editor.Show();
        }

        #endregion Public Constructors

        #region Private Methods

        private void Editor_OnUpdatePricePolicy()
        {
        }



        #endregion Private Methods
    }
}