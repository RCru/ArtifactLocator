using ArtifactLocator;
using ArtifactLocator.Tests;
using ArtifactLocator.Tests.TestData;

namespace ArtifactLocatorVisualisationUI
{
    public partial class Form1 : Form
    {
        private ResultsMap resultsMap;

        public Form1()
        {
            InitializeComponent();

            PopulateResultsMap();
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

        private void PopulateResultsMap()
        {
            resultsMap = new ResultsMap(visualisationPictureBox.Width, visualisationPictureBox.Height);

            List<bool[][]> artifactMaps = LoadTestData();
            List<(ushort X, ushort Y)> artifactCoordinates = artifactMaps.SelectMany(map => map.Interpret()).ToList();
            float scalingAdjustment = visualisationPictureBox.Width / (float)TestConfig.TestDataInstanceSize;
            resultsMap.AddDataPoints(artifactCoordinates, scalingAdjustment);

            visualisationPictureBox.Image = resultsMap.Image;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            visualisationPictureBox.Image = null;
            visualisationPictureBox.Dispose();
            resultsMap.Dispose();
        }
    }
}