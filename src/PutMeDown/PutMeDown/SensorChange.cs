using System;

namespace PutMeDown
{
    public struct SensorChange
    {
        public double X;
        public double Y;
        public double Z;

        public SensorChange(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return string.Format("x={0}, y={1}, z={2}", X, Y, Z);
        }
    }
}