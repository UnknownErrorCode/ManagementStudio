﻿using Structs;
using Structs.Database;

namespace Editors.Shop
{
    public class DataModelRefPricePolicyOfItem
    {
        private RefPricePolicyOfItem policy;

        #region public properties

        public byte Service { get => policy.Service; set => policy.Service = value; }
        public int Country { get => policy.Country; set => policy.Country = value; }
        public string PackageItemCodeName { get => policy.RefPackageItemCodeName; set => policy.RefPackageItemCodeName = value; }
        public PaymentDevice PaymentDevice { get => policy.PaymentDevice; set => policy.PaymentDevice = value; }
        public int Cost { get => policy.Cost; set => policy.Cost = value; }

        public RefPricePolicyOfItem PricePolicyOfItem { get => policy; }
        #endregion

        public DataModelRefPricePolicyOfItem(object[] itemArray)
        {
            policy = new RefPricePolicyOfItem(itemArray);
        }

        public DataModelRefPricePolicyOfItem()
        {
            policy = new RefPricePolicyOfItem()
            {
                Service = 1,
                Country = 15,
                RefPackageItemCodeName = "",
                PaymentDevice = PaymentDevice.Gold,
                PreviousCost = 0,
                Cost = 1,
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
    }
}