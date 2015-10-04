using System;

namespace PutMeDown
{
    public struct SensorChange : IEquatable<SensorChange>
    {
        public bool Equals(SensorChange other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                hashCode = (hashCode*397) ^ Y.GetHashCode();
                hashCode = (hashCode*397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

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

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}