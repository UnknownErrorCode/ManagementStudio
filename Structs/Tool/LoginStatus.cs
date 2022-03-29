using System.Runtime.InteropServices;

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