namespace ArtifactLocator.Tests.TestData
{
    public class TestDataBuilder
    {
        public List<bool[][]> Data => data.Select(data => data.Raw).ToList();

        private List<TestDataInstance> data;

        public TestDataBuilder()
        {
            data = new List<TestDataInstance>(TestConfig.TestDataCount);
        }

        public void AddTestInstance(List<(ushort X, ushort Y)> artifactLocations)
        {
            var instance = new TestDataInstance(artifactLocations);
            data.Add(instance);

            while (data.Count > TestConfig.TestDataCount)
            {
                data.RemoveAt(0);
            }
        }
    }
}
