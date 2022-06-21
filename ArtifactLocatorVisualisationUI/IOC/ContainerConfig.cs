using Autofac;
using ArtifactLocator;
using ArtifactLocator.Tests;
using ArtifactLocator.Definitions;
using ClusterAlgorithms.KMeans;
using Filters.ClusterDiameter;

namespace ArtifactLocatorVisualisationUI.IOC
{
    internal static class ContainerConfig
    {
        internal static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Locator>().As<ILocator>();
            builder.RegisterType<KMeansClusterAlgorithm>().As<IClusterAlgorithm>();
            builder.Register(c => new ClusterDiameterFilter(TestConfig.MaxClusterDiameter, TestConfig.MinimumClusterSize)).As<ICoordinateFilter>();

            return builder.Build();
        }
    }
}
