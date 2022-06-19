using ArtifactLocator.Definitions;

namespace ClusterAlgorithms.KMeans
{
    internal class KMean : Coordinates
    {
        internal KMean((ushort X, ushort Y) mean) : base(mean.X, mean.Y)
        {
        }

        internal KMean(Coordinates coordinates) : base(coordinates)
        {
        }
    }
}
