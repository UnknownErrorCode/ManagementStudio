using Editors.Shop;
using ServerFrameworkRes.Network.Security;
using System.Collections.Generic;

namespace ShopEditor.Interface.ShopInterface
{
    internal class EditorInterface
    {
        #region Fields

        private readonly Editors.Shop.ShopEditor editor;
        private readonly List<Packet> PacketsToSend = new List<Packet>();

        #endregion Fields

        #region Constructors

        public EditorInterface(CIShopGood good)
        {
            editor = new Editors.Shop.ShopEditor(good);
            editor.OnUpdatePricePolicy += Editor_OnUpdatePricePolicy;
            editor.Show();
        }

        #endregion Constructors

        #region Methods

        private void Editor_OnUpdatePricePolicy()
        {
        }

        #endregion Methods
    }
}