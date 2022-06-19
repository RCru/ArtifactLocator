using ArtifactLocator.Definitions;

namespace ClusterAlgorithms.KMeans
{
    internal class KMeansCluster : Cluster
    {
        internal KMean CalculateKMean()
        {
            if (Size == 0) return null;
            return new KMean(CentrePoint);
        }
    }
}
