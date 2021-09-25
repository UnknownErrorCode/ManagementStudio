using System.Data;

namespace Structs.Database
{
    public struct RefPricePolicyOfItem
    {
        internal byte Service { get; set; }
        internal string RefPackageItemCodeName { get; set; }
        internal int PaymentDevice { get; set; }
        internal int Cost { get; set; }

        public RefPricePolicyOfItem(DataRow row)
        {
            Service = row.Field<byte>("Service");
            RefPackageItemCodeName = row.Field<string>("RefPackageItemCodeName");
            PaymentDevice = row.Field<int>("PaymentDevice");
            Cost = row.Field<int>("Cost");
        }
    }
}
