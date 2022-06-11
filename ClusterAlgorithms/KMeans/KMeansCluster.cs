using Maths = System.Math;

namespace ClusterAlgorithms.KMeans
{
    internal class KMeansCluster : Cluster
    {
        internal int Size => Coordinates.Count;

        internal KMean CalculateKMean()
        {
            if (Size == 0) return null;

            int sumX = 0, sumY = 0;   

            foreach ((ushort X, ushort Y) coordinates in Coordinates)
            {
                sumX += coordinates.X;
                sumY += coordinates.Y;
            }

            ushort meanX = (ushort)Maths.Round(sumX / (float)Coordinates.Count);
            ushort meanY = (ushort)Maths.Round(sumY / (float)Coordinates.Count);

            return new KMean(meanX, meanY);
        }
    }
}
