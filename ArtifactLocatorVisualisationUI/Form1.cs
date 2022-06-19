using ArtifactLocator;
using ArtifactLocator.Definitions;
using ArtifactLocator.Results;
using ArtifactLocator.Tests;
using ArtifactLocator.Tests.TestData;
using ArtifactLocatorVisualisationUI.UserNotification;
using ClusterAlgorithms.KMeans;
using Filters.ClusterDiameter;

namespace ArtifactLocatorVisualisationUI
{
    public partial class Form1 : Form
    {
        private List<bool[][]> artifactMaps;
        private ResultsMap resultsMap;

        public Form1()
        {
            InitializeComponent();

            artifactMaps = LoadTestData();
            PopulateResultsMap(artifactMaps);
        }

        private List<bool[][]> LoadTestData()
        {
            try
            {
                var dataGenerator = new TestDataGenerator();
                return dataGenerator.GenerateTestData();
            }
            catch (Exception ex)
            {
                UserMessageForm.Error($"Unable to generate test data: {ex.Message}");
                return null;
            }
        }

        private void PopulateResultsMap(List<bool[][]> artifactMaps)
        {
            if (artifactMaps == null) return;

            resultsMap = new ResultsMap(visualisationPictureBox.Width, visualisationPictureBox.Height);
            float scalingAdjustment = visualisationPictureBox.Width / (float)TestConfig.TestDataInstanceSize;
            resultsMap.SetScalingAdjustment(scalingAdjustment);

            List<Coordinates> artifactCoordinates = artifactMaps.SelectMany(map => map.Interpret()).ToList();
            resultsMap.AddTestDataPoints(artifactCoordinates);

            visualisationPictureBox.Image = resultsMap.Image;
            EnableRunButton();
        }

        private void EnableRunButton()
        {
            runButton.Enabled = true;
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            List<AreaOfInterest> areasOfInterest = null;

            try
            {
                var locator = new Locator(new KMeansClusterAlgorithm(), new ClusterDiameterFilter(TestConfig.MaxClusterDiameter, TestConfig.MinimumClusterSize));
                areasOfInterest = locator.Run(artifactMaps, TestConfig.ExpectedArtifactCount);
            }
            catch (Exception ex)
            {
                UserMessageForm.Error($"An error occurred during artifact location: {ex.Message}");
                return;
            }

            if (areasOfInterest == null) 
            {
                UserMessageForm.Warn($"Unexpected outcome: The artifact locator did not return a result.");
                return;
            }

            try
            {
                areasOfInterest.ForEach(a => resultsMap.AddClusteredDataPoints(a.Cluster.MemberCoordinates));
                resultsMap.AddAreasOfInterest(areasOfInterest.Select(a => a.Coordinates).ToList(), TestConfig.MaxClusterDiameter);

                visualisationPictureBox.Image = resultsMap.Image;
            }
            catch (Exception ex)
            {
                UserMessageForm.Error($"An error occurred whilst attempting to display artifact locations: {ex.Message}");
                return;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            visualisationPictureBox.Image = null;
            visualisationPictureBox.Dispose();
            resultsMap?.Dispose();
        }
    }
}