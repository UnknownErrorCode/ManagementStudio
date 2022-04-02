using System.Runtime.InteropServices;

namespace PackFile
{
    /// <summary>
    /// EntryBlock Contains 20 Entries
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = 2560)] //Header contains 256 byte 
    public struct Pk2EntryBlock
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public Pk2Entry[] entries;
    }

}
