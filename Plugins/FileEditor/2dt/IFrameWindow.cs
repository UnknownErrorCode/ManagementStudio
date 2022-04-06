using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEditor._2dt
{
    internal class IFrameWindow
    {
        private Bitmap left_up;
        private Bitmap left_side;
        private Bitmap left_down;

        private Bitmap right_up;
        private Bitmap right_side;
        private Bitmap right_down;

        private Bitmap mid_up;
        private Bitmap mid_down;

        internal IFrameWindow(string framePath, string frame_name)
        {
            if (!PackFile.MediaPack.Reader.GetByteArrayByDirectory($"{framePath}\\{frame_name}left_up.ddj", out byte[] lu))
                return;
            if (!PackFile.MediaPack.Reader.GetByteArrayByDirectory($"{framePath}\\{frame_name}left_side.ddj", out byte[] ls))
                return;
            if (!PackFile.MediaPack.Reader.GetByteArrayByDirectory($"{framePath}\\{frame_name}left_down.ddj", out byte[] ld))
                return;
            if (!PackFile.MediaPack.Reader.GetByteArrayByDirectory($"{framePath}\\{frame_name}right_up.ddj", out byte[] ru))
                return;
            if (!PackFile.MediaPack.Reader.GetByteArrayByDirectory($"{framePath}\\{frame_name}right_side.ddj", out byte[] rs))
                return;
            if (!PackFile.MediaPack.Reader.GetByteArrayByDirectory($"{framePath}\\{frame_name}right_down.ddj", out byte[] rd))
                return;
            if (!PackFile.MediaPack.Reader.GetByteArrayByDirectory($"{framePath}\\{frame_name}mid_up.ddj", out byte[] mu))
                return;
            if (!PackFile.MediaPack.Reader.GetByteArrayByDirectory($"{framePath}\\{frame_name}mid_down.ddj", out byte[] md))
                return;

            left_up = new BinaryFiles.PackFile.JMXddjFile(lu).BitmapImage;
            left_side = new BinaryFiles.PackFile.JMXddjFile(ls).BitmapImage;
            left_down = new BinaryFiles.PackFile.JMXddjFile(ld).BitmapImage;
            right_up = new BinaryFiles.PackFile.JMXddjFile(ru).BitmapImage;
            right_side = new BinaryFiles.PackFile.JMXddjFile(rs).BitmapImage;
            right_down = new BinaryFiles.PackFile.JMXddjFile(rd).BitmapImage;
            mid_up = new BinaryFiles.PackFile.JMXddjFile(mu).BitmapImage;
            mid_down = new BinaryFiles.PackFile.JMXddjFile(md).BitmapImage;
        }
    }
}