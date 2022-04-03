
namespace Structs
{
    public struct SRectangle
    {
        private int x;
        private int y;
        private int width;
        private int higth;

        public int X { get => x; }
        public int Y { get => y; }
        public int Width { get => width; }
        public int Higth { get => higth; }

        public SRectangle(int _x, int _y, int _width, int _higth)
        {
            x = _x;
            y = _y;
            width = _width;
            higth = _higth;
        }
    }
}