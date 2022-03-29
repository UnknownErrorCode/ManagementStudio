using Structs.Database;

namespace ServerFrameworkRes.Network.Security.PacketFormat
{
    public static class C_S_ShopItemContext
    {
        #region Public Methods

        public static Packet RefPricePolicyOfItemToPacket(RefPricePolicyOfItem arg1, EditAction action)
        {
            Packet p = new Packet(PacketID.Client.ShopDataRefPricePolicyOfItem);
            p.WriteByte(action);
            p.WriteStruct(arg1);
            return p;
        }

        #endregion Public Methods
    }
}