using ServerFrameworkRes.Network.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerFrameworkRes.Network.ServerStructs.PaddedString
{
    public interface IPaddedString : Unmanaged.IMarshalled
    {
        string Value { get; set; }
        int Padding { get; }
    }
}
