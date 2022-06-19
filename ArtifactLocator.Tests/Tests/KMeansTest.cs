using NUnit.Framework;
using ClusterAlgorithms.KMeans;
using Filters.ClusterDiameter;
using ArtifactLocator.Results;
using ArtifactLocator.Definitions;

namespace ArtifactLocator.Tests
{
    [TestFixture]
    public class KMeansTest : BaseArtifactLocatorTest
    {
        public KMeansTest() : base()
        {
            locator = new Locator(new KMeansClusterAlgorithm(), new ClusterDiameterFilter(TestConfig.MaxClusterDiameter, TestConfig.MinimumClusterSize));
        }

        [Test]
        public override void FindArtifacts()
        {
            if (testData == null)
            {
                Assert.Fail($"TestData {nameof(BaseArtifactLocatorTest)}.testData was not generated correctly.");
            }

            ushort expectedResultsCount = 3;

            List<AreaOfInterest> results = locator.Run(testData, expectedResultsCount);
            Assert.AreEqual(results.Count, expectedResultsCount);

            List<Coordinates> expectedCoordinates = TestConfig.ArtifactLocations.Select(al => new Coordinates(al.X, al.Y)).ToList();
            Assert.IsTrue(LocationsMatchExpectations(results, expectedCoordinates));
        }

        private bool LocationsMatchExpectations(List<AreaOfInterest> results, List<Coordinates> expectedCoordinates)
        {
            foreach (Coordinates expectedPoint in expectedCoordinates)
            {
                float distanceToClosestRealResult = results.Min(r => r.Coordinates.DistanceFrom(expectedPoint));
                if (distanceToClosestRealResult > TestConfig.MaxArtifactLocationDeviance)
                {
                    return false;
                }
            }

            return true;
        }
    }
}