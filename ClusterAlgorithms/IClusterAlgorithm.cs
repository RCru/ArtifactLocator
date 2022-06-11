namespace ClusterAlgorithms
{
    public interface IClusterAlgorithm
    {
        public void LoadCoordinates(List<(ushort X, ushort Y)> coordinateList);
        public List<Cluster> Process(ushort clusterCount);
    }
}
