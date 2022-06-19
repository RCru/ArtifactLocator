using Maths = System.Math;

namespace ArtifactLocator.Definitions
{
    public class Coordinates
    {
        public ushort X { get; set; }
        public ushort Y { get; set; }

        public Coordinates(ushort x, ushort y)
        {
            X = x;
            Y = y;
        }

        public Coordinates(Coordinates coordinates)
        {
            X = coordinates.X;
            Y = coordinates.Y;
        }

        public float DistanceFrom(Coordinates coordinates)
        {
            return (float)Maths.Sqrt(Maths.Pow(Y - coordinates.Y, 2) + Maths.Pow(X - coordinates.X, 2));
        }

        public bool IsSameAs(Coordinates comparator)
        {
            return X == comparator.X && Y == comparator.Y;
        }
    }
}
