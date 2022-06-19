using ArtifactLocator.Tests.TestData;

namespace ArtifactLocator.Tests
{
    public abstract class BaseArtifactLocatorTest
    {
        private protected Locator locator;
        private protected List<bool[][]> testData;

        public BaseArtifactLocatorTest()
        {
            var dataGenerator = new TestDataGenerator();
            testData = dataGenerator.GenerateTestData();
        }

        public abstract void FindArtifacts();
    }
}
