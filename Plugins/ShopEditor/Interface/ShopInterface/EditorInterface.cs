using ManagementFramework.Network.Security;
using System.Collections.Generic;

namespace ShopEditor.Interface.ShopInterface
{
    internal class EditorInterface
    {
        #region Fields

        private readonly List<Packet> PacketsToSend = new List<Packet>();

        #endregion Fields

        #region Constructors

        public EditorInterface(CIShopGood good)
        {
        }

        #endregion Constructors

        #region Methods

        private void Editor_OnUpdatePricePolicy()
        {
        }

        #endregion Methods
    }
}