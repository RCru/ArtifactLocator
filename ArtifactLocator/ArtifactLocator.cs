using ClusterAlgorithms;

namespace ArtifactLocator
{
    public class ArtifactLocator
    {
        private IClusterAlgorithm clusterAlgorithm;

        public ArtifactLocator(IClusterAlgorithm clusterAlgorithm)
        {
            this.clusterAlgorithm = clusterAlgorithm;
        }

        public void Run(List<bool[][]> artifactMaps)
        {
            List<(ushort X, ushort Y)> artifacts = artifactMaps.SelectMany(map => map.Interpret()).ToList();
        }
    }
}