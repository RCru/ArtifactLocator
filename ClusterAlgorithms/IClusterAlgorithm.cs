namespace ClusterAlgorithms
{
    public interface IClusterAlgorithm
    {
        public void LoadCoordinates(List<(ushort X, ushort Y)> coordinateList);
        public List<(ushort X, ushort Y)> Cluster(ushort clusterCount);
    }
}
