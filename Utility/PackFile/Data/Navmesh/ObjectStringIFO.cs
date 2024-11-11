using PackFile.Data.Dungeon;
using System.Text;
using System.Threading.Tasks;
using static PackFile.Data.Navmesh.ObjectStringIFOData;

namespace PackFile.Data.Navmesh
{
    public class ObjectStringIFO : ObjectStringIFOData
    {
        public ObjectStringIFO(byte[] file) : base(file)
        {
        }
    }
}
