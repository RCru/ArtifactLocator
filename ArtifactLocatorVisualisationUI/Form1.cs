using ArtifactLocator;
using ArtifactLocator.Results;
using ArtifactLocator.Tests;
using ArtifactLocator.Tests.TestData;
using ClusterAlgorithms.KMeans;

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
            EnableRunButton();
        }

        private void EnableRunButton()
        {
            runButton.Enabled = true;
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
                return null;
            }
        }

        private void PopulateResultsMap(List<bool[][]> artifactMaps)
        {
            resultsMap = new ResultsMap(visualisationPictureBox.Width, visualisationPictureBox.Height);

            List<(ushort X, ushort Y)> artifactCoordinates = artifactMaps.SelectMany(map => map.Interpret()).ToList();
            float scalingAdjustment = visualisationPictureBox.Width / (float)TestConfig.TestDataInstanceSize;
            resultsMap.AddCoordinatePoints(artifactCoordinates, scalingAdjustment);

            visualisationPictureBox.Image = resultsMap.Image;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            visualisationPictureBox.Image = null;
            visualisationPictureBox.Dispose();
            resultsMap.Dispose();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            try
            {
                var locator = new Locator(new KMeansClusterAlgorithm());
                List<AreaOfInterest> areasOfInterest = locator.Run(artifactMaps, TestConfig.ExpectedArtifactCount);

                if (areasOfInterest == null) return;

                resultsMap.Clear();

                float scalingAdjustment = visualisationPictureBox.Width / (float)TestConfig.TestDataInstanceSize;

                areasOfInterest.ForEach(a => resultsMap.AddCoordinatePoints(a.Cluster.Coordinates, scalingAdjustment));
                resultsMap.AddCentrePoints(areasOfInterest.Select(a => a.Coordinates).ToList(), scalingAdjustment);

                visualisationPictureBox.Image = resultsMap.Image;
            }
            catch (Exception ex)
            {
                //exception message to user here
            }
        }
    }
}