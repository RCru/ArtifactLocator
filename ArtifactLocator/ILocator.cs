using ArtifactLocator.Results;

namespace ArtifactLocator
{
    public interface ILocator
    {
        List<AreaOfInterest> Run(List<bool[][]> artifactMaps, ushort expectedClusterCount);
    }
}
