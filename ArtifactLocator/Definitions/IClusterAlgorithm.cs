namespace ArtifactLocator.Definitions
{
    public interface IClusterAlgorithm
    {
        public List<Cluster> Process(List<Coordinates> coordinateList, ushort clusterCount);
    }
}
