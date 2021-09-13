using System.Data;

namespace ShopEditor.Interface.ShopInterface
{
    internal struct RefPackageItem
    {
       internal byte Service { get; set; }
       internal string CodeName128 { get; set; }
       internal string NameStrID { get; set; }
       internal string DescStrID { get; set; }
       internal string AssocFileIcon { get; set; }

        internal RefPackageItem(DataRow row)
        {
            Service = row.Field<byte>("Service");
            CodeName128 = row.Field<string>("CodeName128");
            NameStrID = row.Field<string>("NameStrID");
            DescStrID = row.Field<string>("DescStrID");
            AssocFileIcon = row.Field<string>("AssocFileIcon");
        }
    }
}