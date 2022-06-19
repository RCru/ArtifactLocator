using ArtifactLocator.Definitions;

namespace ArtifactLocator.Results
{
    public class AreaOfInterest
    {
        public Coordinates Coordinates => Cluster.CentrePoint;

        public Cluster Cluster { get; }

        public AreaOfInterest(Cluster cluster)
        {
            Cluster = cluster;
        }
    }
}
