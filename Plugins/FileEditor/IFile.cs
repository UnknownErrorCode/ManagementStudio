namespace FileEditor
{
    internal interface IFile
    {
        BinaryFiles.PackFile.IJMXFile JMXFile { get; set; }

        void PaintGraphics(System.Drawing.Graphics g);
    }
}
