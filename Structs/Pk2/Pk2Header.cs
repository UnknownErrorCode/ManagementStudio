using System.Runtime.InteropServices;

namespace Structs.Pk2
{
    [StructLayout(LayoutKind.Sequential, Size = 256)]// Header contains 256 byte 
    public struct Pk2Header
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        public string name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] version;
        [MarshalAs(UnmanagedType.I1, SizeConst = 1)]
        public byte encryption;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] verify;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 205)]
        public byte[] reserved;
    }
}
