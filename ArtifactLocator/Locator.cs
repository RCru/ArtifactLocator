using ArtifactLocator.Definitions;
using ArtifactLocator.Results;

namespace ArtifactLocator
{
    public class Locator
    {
        private IClusterAlgorithm clusterAlgorithm;
        private ICoordinateFilter clusterFilter;

        private const ushort maxClusterAttemptCount = 10;

        public Locator(IClusterAlgorithm clusterAlgorithm, ICoordinateFilter clusterFilter)
        {
            this.clusterAlgorithm = clusterAlgorithm;
            this.clusterFilter = clusterFilter;
        }

        public List<AreaOfInterest> Run(List<bool[][]> artifactMaps, ushort expectedClusterCount)
        {
            List<Coordinates> artifacts = artifactMaps.SelectMany(map => map.Interpret()).ToList();

            List<Cluster> clusters = null;

            ushort attemptCount = 0;

            do
            {
                if (attemptCount++ > maxClusterAttemptCount)
                {
                    throw new Exception($"Unable to cluster data satisfactorily in {maxClusterAttemptCount} attempts");
                };

                clusters = clusterAlgorithm.Process(artifacts, expectedClusterCount);
            }
            while (clusters.Any(c => !clusterFilter.TryFilter(c)));

            return clusters.Select(c => new AreaOfInterest(c)).ToList();
        }
    }
}