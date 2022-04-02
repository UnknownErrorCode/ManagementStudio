namespace Structs
{

    public struct Point8
    {
        private byte X;
        private byte Y;

        public Point8(byte x, byte y)
        {
            X = x;
            Y = y;
        }
        public static Point8 FromXY(byte x, byte y)
            => new Point8(x, y);
    }

    public struct Point16
    {
        private short X;
        private short Y;

        public Point16(short x, short y)
        {
            X = x;
            Y = y;
        }
    }

    public struct Point32
    {
        private float X;
        private float Y;

        public Point32(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point32(float x, float y)
        {
            X = x;
            Y = y;
        }
    }

    public struct Point64
    {
        private double X;
        private double Y;

        public Point64(long x, long y)
        {
            X = x;
            Y = y;
        }

        public Point64(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    public struct Point128
    {
        private decimal X;
        private decimal Y;

        public Point128(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }
    }
}