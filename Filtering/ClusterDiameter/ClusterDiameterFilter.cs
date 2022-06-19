using ArtifactLocator.Definitions;

namespace Filters.ClusterDiameter
{
    public class ClusterDiameterFilter : ICoordinateFilter
    {
        private float maxRadius;

        private readonly ushort minClusterSize;

        public ClusterDiameterFilter(ushort maxDiameter, ushort minClusterSize)
        {
            maxRadius = maxDiameter / 2f;
            this.minClusterSize = minClusterSize;
        }

        public bool TryFilter(Cluster cluster)
        {
            if (cluster == null || !cluster.MemberCoordinates.Any()) return false;

            while (ClusterSpreadExceedsMaximum(cluster))
            {
                Coordinates outlier = SelectMostRemoteOutlier(cluster);
                cluster.MemberCoordinates.Remove(outlier);
            }

            return cluster.Size >= minClusterSize;
        }

        private bool ClusterSpreadExceedsMaximum(Cluster cluster)
        {
            return cluster.MemberCoordinates.Any(coord => coord.DistanceFrom(cluster.CentrePoint) > maxRadius);
        }

        private Coordinates SelectMostRemoteOutlier(Cluster cluster)
        {
            return cluster.MemberCoordinates.MaxBy(coord => coord.DistanceFrom(cluster.CentrePoint)); ;
        }
    }
}
