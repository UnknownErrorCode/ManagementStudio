﻿namespace Structs
{
    public struct SVector3
    {
        public float X;
        public float Y;
        public float Z;

        public SVector3(float x, float y, float z)
        { X = x; Y = y; Z = z; }

        public SVector3(int x, int y, int z)
        { X = x; Y = y; Z = z; }
    }

}