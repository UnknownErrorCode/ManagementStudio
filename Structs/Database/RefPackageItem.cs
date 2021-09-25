using System.Data;

namespace Structs.Database
{
    public struct RefPackageItem
    {
        public  byte Service { get; set; }
        public  string CodeName128 { get; set; }
        public  string NameStrID { get; set; }
        public  string DescStrID { get; set; }
        public  string AssocFileIcon { get; set; }

        public  RefPackageItem(DataRow row)
        {
            Service = row.Field<byte>("Service");
            CodeName128 = row.Field<string>("CodeName128");
            NameStrID = row.Field<string>("NameStrID");
            DescStrID = row.Field<string>("DescStrID");
            AssocFileIcon = row.Field<string>("AssocFileIcon");
        }
    }
}
