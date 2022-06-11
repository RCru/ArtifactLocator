namespace ClusterAlgorithms
{
    public abstract class Cluster
    {
        public List<(ushort X, ushort Y)> Coordinates { get; set; } = new List<(ushort X, ushort Y)> ();
    }
}
