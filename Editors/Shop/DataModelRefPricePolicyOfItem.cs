using Structs;
using Structs.Database;

namespace Editors.Shop
{
    public class DataModelRefPricePolicyOfItem
    {
        #region Private Fields

        private RefPricePolicyOfItem policy;

        #endregion Private Fields

        #region public properties

        public int Cost { get => policy.Cost; set => policy.Cost = value; }
        public int Country { get => policy.Country; set => policy.Country = value; }
        public string PackageItemCodeName { get => policy.RefPackageItemCodeName; set => policy.RefPackageItemCodeName = value; }
        public PaymentDevice PaymentDevice { get => policy.PaymentDevice; set => policy.PaymentDevice = value; }
        public RefPricePolicyOfItem PricePolicyOfItem => policy;
        public byte Service { get => policy.Service; set => policy.Service = value; }

        #endregion public properties

        #region Public Constructors

        public DataModelRefPricePolicyOfItem(object[] itemArray)
        {
            policy = new RefPricePolicyOfItem(itemArray);
        }

        public DataModelRefPricePolicyOfItem(RefPricePolicyOfItem _policy)
        {
            policy = _policy;
        }

        public DataModelRefPricePolicyOfItem(byte service = 1, string codeName = "", int cost = 1, PaymentDevice device = PaymentDevice.Gold)
        {
            policy = new RefPricePolicyOfItem()
            {
                Service = service,
                Country = 15,
                RefPackageItemCodeName = codeName,
                PaymentDevice = device,
                PreviousCost = 0,
                Cost = cost,
                Param1 = -1,
                Param1_Desc128 = "xxx",
                Param2 = -1,
                Param2_Desc128 = "xxx",
                Param3 = -1,
                Param3_Desc128 = "xxx",
                Param4 = -1,
                Param4_Desc128 = "xxx"
            };
        }

        #endregion Public Constructors
    }
}