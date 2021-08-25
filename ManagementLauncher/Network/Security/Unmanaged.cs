using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ManagementLauncher.Network.Security
{
    public static class Unmanaged
    {
        public static T BufferToStruct<T>(byte[] buffer, int offset = 0) where T : IMarshalled
        {
            unsafe
            {
                fixed (byte* ptr = &buffer[offset])
                {
                    return (T)Marshal.PtrToStructure((IntPtr)ptr, typeof(T));
                }
            }
        }

        public static byte[] StructToBuffer<T>(T structure) where T : IMarshalled
        {
            var buffer = new byte[Marshal.SizeOf(typeof(T))];
            unsafe
            {
                fixed (byte* ptr = &buffer[0])
                {
                    Marshal.StructureToPtr(structure, (IntPtr)ptr, false);
                    return buffer;
                }
            }
        }

        public interface IMarshalled
        {
        }
    }
}
