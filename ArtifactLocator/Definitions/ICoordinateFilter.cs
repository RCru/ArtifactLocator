namespace ArtifactLocator.Definitions
{
    public interface ICoordinateFilter
    {
        public bool TryFilter(Cluster cluster);
    }
}
