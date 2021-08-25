using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementLauncher.Network.Security
{
    public interface IPaddedString : Unmanaged.IMarshalled
    {
        string Value { get; set; }
        int Padding { get; }
    }
}
