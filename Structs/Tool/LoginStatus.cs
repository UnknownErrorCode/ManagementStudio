using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Structs.Tool
{


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Size = 146)]
    public struct LoginStatus
    {
        public bool Success;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string Notification;
        public byte SecurityGroup;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string UserName;

    }
}
