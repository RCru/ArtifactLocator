using NUnit.Framework;
using ClusterAlgorithms.KMeans;

namespace ArtifactLocator.Tests
{
    [TestFixture]
    public class KMeansTest : BaseArtifactLocatorTest
    {
        public KMeansTest() : base()
        {
            locator = new Locator(new KMeansClusterAlgorithm());
        }

        [Test]
        public override void FindArtifacts()
        {
            if (testData == null)
            {
                Assert.Fail($"TestData {nameof(BaseArtifactLocatorTest)}.testData was not generated correctly.");
            }

            ushort resultCount = 3;

            Assert.AreEqual(resultCount, 3);
        }
    }
}