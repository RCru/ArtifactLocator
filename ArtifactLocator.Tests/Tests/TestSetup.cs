using NUnit.Framework;
using System;

namespace ArtifactLocator.Tests.Utilities
{
    [SetUpFixture]
    class TestSetup
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
        }
    }
}
