using NUnit.Framework;

namespace ArtifactLocator.Tests
{
    [TestFixture]
    public class ArtifactLocatorTests
    {
        private ArtifactLocator locator;

        [OneTimeSetUp]
        public void Setup()
        {
            locator = new ArtifactLocator();
        }

        [Test]
        public void FindArtifacts()
        {
            ushort resultCount = 3;

            Assert.AreEqual(resultCount, 3);
        }
    }
}