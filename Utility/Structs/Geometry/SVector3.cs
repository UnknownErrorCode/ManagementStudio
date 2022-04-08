namespace Structs
{
    public struct SVector3
    {
        private float x;
        private float y;
        private float z;

        public SVector3(float _x, float _y, float _z)
        { x = _x; y = _y; z = _z; }

        public SVector3(int _x, int _y, int _z)
        { x = _x; y = _y; z = _z; }

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }
        public float Z { get => z; set => z = value; }
    }
}