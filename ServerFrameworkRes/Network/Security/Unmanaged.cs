using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ServerFrameworkRes.Network.Security
{
    public static class Unmanaged
    {

        public static unsafe byte[] Serialize<T>(T value) where T : unmanaged
        {
            byte[] buffer = new byte[sizeof(T)];

            fixed (byte* bufferPtr = buffer)
            {
                Buffer.MemoryCopy(&value, bufferPtr, sizeof(T), sizeof(T));
            }

            return buffer;
        }

        public static unsafe T Deserialize<T>(byte[] buffer) where T : unmanaged
        {
            T result = new T();

            fixed (byte* bufferPtr = buffer)
            {
                Buffer.MemoryCopy(bufferPtr, &result, sizeof(T), sizeof(T));
            }

            return result;
        }


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
        public static T BufferToStruct2<T>(byte[] buffer, int offset = 0) where T : struct
        {
            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            T str = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return str;
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
        public static byte[] StructToBuffer2<T>(T structure) where T : struct
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
