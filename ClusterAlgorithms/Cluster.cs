using Maths = System.Math;

namespace ClusterAlgorithms
{
    public abstract class Cluster
    {
        public List<(ushort X, ushort Y)> Coordinates { get; set; } = new List<(ushort X, ushort Y)>();

        public int Size => Coordinates.Count;

        public (ushort X, ushort Y) CentrePoint
        {
            get
            {
                if (Size == 0) return default;

                int sumX = 0, sumY = 0;

                foreach ((ushort X, ushort Y) coordinates in Coordinates)
                {
                    sumX += coordinates.X;
                    sumY += coordinates.Y;
                }

                ushort meanX = (ushort)Maths.Round(sumX / (float)Coordinates.Count);
                ushort meanY = (ushort)Maths.Round(sumY / (float)Coordinates.Count);

                return (meanX, meanY);
            }
        }
    }
}
