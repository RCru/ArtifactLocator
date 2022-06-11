using ClusterAlgorithms;

namespace ArtifactLocator.Results
{
    public class AreaOfInterest
    {
        public (ushort X, ushort Y) Coordinates => Cluster.CentrePoint;

        public Cluster Cluster { get; }

        public AreaOfInterest(Cluster cluster)
        {
            Cluster = cluster;
        }
    }
}
