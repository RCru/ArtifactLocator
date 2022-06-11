using Maths = System.Math;

namespace ClusterAlgorithms.KMeans
{
    internal class KMean
    {
        internal ushort X { get; set; }
        internal ushort Y { get; set; }

        internal KMean((ushort X, ushort Y) mean)
        {
            X = mean.X;
            Y = mean.Y;
        }

        internal KMean(ushort x, ushort y)
        {
            X = x;
            Y = y;
        }

        internal float DistanceFrom((ushort X, ushort Y) coordinates)
        {
            return (float)Maths.Sqrt(Maths.Pow(Y - coordinates.Y, 2) + Maths.Pow(X - coordinates.X, 2));
        }

        internal bool IsSameAs(KMean comparator)
        {
            return X == comparator.X && Y == comparator.Y;
        }
    }
}
