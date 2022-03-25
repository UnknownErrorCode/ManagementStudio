using System;
using System.Runtime.InteropServices;

namespace Structs.Dashboard
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Size = 1024)]
    public struct DashboardMessage
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string Title;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string Author;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string Created;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 924)]
        public string Text;

        public DashboardMessage(string title, string text, string author)
        {
            Title = title;
            Author = author;
            Created = DateTime.UtcNow.ToString("dd.MM.yyyy  HH:mm:ss");
            Text = $"{text}\n\nCreated:{Created}";
        }
        public DashboardMessage(DashboardMessage msg)
        {
            this = msg;
        }
    }
}
