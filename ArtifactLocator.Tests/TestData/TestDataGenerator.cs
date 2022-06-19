using random = Utilities.RandomNumbers.RandomNumberGenerator;

namespace ArtifactLocator.Tests.TestData
{
    public class TestDataGenerator
    {
        private const ushort minArtifactCount = 2;
        private const ushort maxArtifactCount = 5;

        public List<bool[][]> GenerateTestData()
        {
            var builder = new TestDataBuilder();

            for (int i = 0; i < TestConfig.TestDataCount; ++i)
            {
                ushort artifactCount = random.Generate(minArtifactCount, maxArtifactCount + 1);

                var artifactLocations = new List<(ushort X, ushort Y)>(artifactCount);

                for (int j = 0; j < artifactCount; ++j)
                {
                    (ushort X, ushort Y) artifactCoordinates = default;

                    if (j < TestConfig.ArtifactLocations.Count)
                    {
                        artifactCoordinates = random.GeneratePair(TestConfig.ArtifactLocations[j], TestConfig.MaxArtifactLocationDeviance, TestConfig.TestDataInstanceSize);
                    }
                    else
                    {
                        //add in random noise to make things more fun
                        artifactCoordinates = random.GeneratePair(TestConfig.TestDataInstanceSize);
                    }

                    artifactLocations.Add(artifactCoordinates);
                }

                builder.AddTestInstance(artifactLocations);
            }

            return builder.Data;
        }
    }
}
