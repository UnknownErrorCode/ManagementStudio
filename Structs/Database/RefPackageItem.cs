using System.Data;

namespace Structs.Database
{
    public struct RefPackageItem
    {
        public byte Service;
        public string CodeName128;
        public string NameStrID;
        public string DescStrID;
        public string AssocFileIcon;

        public RefPackageItem(DataRow row)
        {
            Service = row.Field<byte>("Service");
            CodeName128 = row.Field<string>("CodeName128");
            NameStrID = row.Field<string>("NameStrID");
            DescStrID = row.Field<string>("DescStrID");
            AssocFileIcon = row.Field<string>("AssocFileIcon");
        }
    }
}
