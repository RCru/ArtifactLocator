namespace ArtifactLocator.Tests.TestData
{
    public class TestDataInstance
    {
        public bool[][] Raw => data;

        private bool[][] data;

        public TestDataInstance(List<(ushort X, ushort Y)> artifactLocations)
        {
            PopulateEmptyData();
            artifactLocations.ForEach(l => AddArtifact(l));
        }

        private void PopulateEmptyData()
        {
            data = new bool[TestConfig.TestDataInstanceSize][];

            for (int i = 0; i < TestConfig.TestDataInstanceSize; ++i)
            {
                data[i] = new bool[TestConfig.TestDataInstanceSize];
            }
        }

        private void AddArtifact((ushort X, ushort Y) coordinates)
        {
            data[coordinates.X][coordinates.Y] = true;
        }
    }
}
