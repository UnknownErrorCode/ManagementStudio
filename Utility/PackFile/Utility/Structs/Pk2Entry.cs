using System;
using System.Runtime.InteropServices;

namespace PackFile
{
    public enum Pk2EntryType : byte
    {
        Exit = 0x00,
        Folder = 0x01,
        File = 0x02
    }

    /// <summary>
    /// type, name, accesstime, createtime, modifytime, position, size, nextChain, passing
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = 128)]
    public struct Pk2Entry
    {
        [MarshalAs(UnmanagedType.I1)]
        public Pk2EntryType type;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 81)]
        public string name;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] accessTime;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] createTime;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] modifyTime;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] position;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] size;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] nextChain;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] padding;

        public long nChain => BitConverter.ToInt64(nextChain, 0);
        public long Position => BitConverter.ToInt64(position, 0);
        public uint Size => BitConverter.ToUInt32(size, 0);
    }
}