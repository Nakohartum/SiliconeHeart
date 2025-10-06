using System;

namespace _Root.Code.Shared.GridPos
{
    [Serializable]
    public struct GridPos : IEquatable<GridPos>
    {
        public float X;
        public float Y;

        public GridPos(float x, float y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(GridPos other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override bool Equals(object obj)
        {
            return obj is GridPos other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}