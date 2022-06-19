namespace ArtifactLocator.Tests
{
    //Do not do this for reals. Quick hack for setting up test data.
    public static class TestConfig
    {
        public static ushort ExpectedArtifactCount = 3;
        internal static ushort TestDataCount = 10;
        public static ushort TestDataInstanceSize = 100;

        internal static List<(ushort X, ushort Y)> ArtifactLocations = new List<(ushort X, ushort Y)>
        {
            (17, 83),
            (48, 27),
            (82, 70)
        };

        internal static ushort MaxArtifactLocationDeviance = 4;

        public static ushort MaxClusterDiameter = 10;

        public static ushort MinimumClusterSize = 3;
    }
}
