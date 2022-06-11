﻿using ArtifactLocator.Results;
using ClusterAlgorithms;
using Filtering;

namespace ArtifactLocator
{
    public class Locator
    {
        private IClusterAlgorithm clusterAlgorithm;
        private ICoordinateFilter clusterFilter;

        public Locator(IClusterAlgorithm clusterAlgorithm)
        {
            this.clusterAlgorithm = clusterAlgorithm;
        }

        public List<AreaOfInterest> Run(List<bool[][]> artifactMaps, ushort expectedClusterCount)
        {
            List<(ushort X, ushort Y)> artifacts = artifactMaps.SelectMany(map => map.Interpret()).ToList();

            clusterAlgorithm.LoadCoordinates(artifacts);
            List<Cluster> clusters = clusterAlgorithm.Process(expectedClusterCount);

            return clusters.Select(c => new AreaOfInterest(c)).ToList();
        }
    }
}