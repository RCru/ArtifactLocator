using ArtifactLocator.Definitions;
using ArtifactLocatorVisualisationUI.Utilities;
using Maths = System.Math;

namespace ArtifactLocatorVisualisationUI
{
    //For testing and visualisation purposes only
    //Since Winforms is depreciated, it doesn't support a graph library in .NET 6
    //This class creates a scatter plot "map" by drawing circles on a bitmap
    public class ResultsMap : IDisposable
    {
        public Bitmap Image => image;

        private int width;
        private int height;
        private Bitmap image;

        private const ushort dataPointDiameterPixels = 5;
        private float scalingAdjustment = 1;

        public ResultsMap(int width, int height)
        {
            this.width = width;
            this.height = height;

            GenerateTemplate();
        }

        private void GenerateTemplate()
        {
            image = new Bitmap(width, height);

            Rectangle boundary = new Rectangle(0, 0, image.Width - 1, image.Height - 1);

            using (Graphics g = Graphics.FromImage(image))
            {
                g.DrawRectangle(Pens.Black, boundary);
            }
        }

        public void SetScalingAdjustment(float scalingAdjustment)
        {
            this.scalingAdjustment = scalingAdjustment;
        }

        public void AddTestDataPoints(List<Coordinates> coordinateList)
        {
            Pen pen = Pens.Black;
            DrawCircles(coordinateList, pen);
        }

        public void AddClusteredDataPoints(List<Coordinates> coordinateList)
        {
            Pen pen = RedBlueGreen.Next();
            DrawCircles(coordinateList, pen);
        }

        public void AddAreasOfInterest(List<Coordinates> coordinateList, ushort maxClusterDiameter)
        {
            Pen pen = Pens.Black;
            DrawCircles(coordinateList, pen, (ushort)(maxClusterDiameter * scalingAdjustment));
        }

        private void DrawCircles(List<Coordinates> coordinateList, Pen pen, ushort diameterPixelsOverride = 0)
        {
            List<Rectangle> boundingBoxes = GenerateBoundingBoxes(coordinateList, diameterPixelsOverride);

            using (Graphics g = Graphics.FromImage(image))
            {
                foreach (Rectangle boundingBox in boundingBoxes)
                {
                    g.DrawEllipse(pen, boundingBox);
                }
            }
        }

        private List<Rectangle> GenerateBoundingBoxes(List<Coordinates> coordinateList, ushort diameterPixelsOverride)
        {
            var boundingBoxes = new List<Rectangle>(coordinateList.Count);

            int dataPointCetralisingOffset, rectLength;

            if (diameterPixelsOverride != 0)
            {
                //intentionally exploiting implicit Math.Floor in int division
                dataPointCetralisingOffset = diameterPixelsOverride / 2;
                rectLength = diameterPixelsOverride;
            }
            else
            {
                dataPointCetralisingOffset = dataPointDiameterPixels / 2;
                rectLength = dataPointDiameterPixels;
            }

            foreach (Coordinates coordinates in coordinateList)
            {
                int topLeftX = Maths.Max((int)(coordinates.X * scalingAdjustment) - dataPointCetralisingOffset, 0);
                int topLeftY = Maths.Max((int)(coordinates.Y * scalingAdjustment) - dataPointCetralisingOffset, 0);

                var box = new Rectangle(topLeftX, topLeftY, rectLength, rectLength);
                boundingBoxes.Add(box);
            }

            return boundingBoxes;
        }



        public void Clear()
        {
            GenerateTemplate();
        }

        public void Dispose()
        {
            image.Dispose();
        }
    }
}
