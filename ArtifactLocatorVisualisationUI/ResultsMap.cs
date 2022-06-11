using Maths = System.Math;

namespace ArtifactLocatorVisualisationUI
{
    //Since Winforms is depreciated, it doesn't graph library in .NET 6
    //This class creates a scatter plot "map" by drawing circles on an image
    public class ResultsMap : IDisposable
    {
        public Bitmap Image => image;

        private int width;
        private int height;
        private Bitmap image;

        private const ushort dataPointDiameterPixels = 5;

        public ResultsMap(int width, int height)
        {
            this.width = width;
            this.height = height;

            image = new Bitmap(width, height);
        }

        public void AddDataPoints(List<(ushort X, ushort Y)> coordinateList, float scalingAdjustment)
        {
            Rectangle boundary = new Rectangle(0, 0, image.Width - 1, image.Height - 1);

            List<Rectangle> boundingBoxes = GenerateBoundingBoxes(coordinateList, scalingAdjustment);

            using (Graphics g = Graphics.FromImage(image))
            {
                g.DrawRectangle(Pens.Blue, boundary);

                foreach(Rectangle boundingBox in boundingBoxes)
                {
                    g.DrawEllipse(Pens.Blue, boundingBox);
                }
            }
        }

        public void Clear()
        {
            image = new Bitmap(width, height);
        }

        private List<Rectangle> GenerateBoundingBoxes(List<(ushort X, ushort Y)> coordinateList, float scalingAdjustment)
        {
            var boundingBoxes = new List<Rectangle>(coordinateList.Count);

            //intentionally exploiting implicit Math.Floor in ushort division
            ushort dataPointCetralisingOffset = dataPointDiameterPixels / 2;

            foreach ((ushort X, ushort Y) in coordinateList)
            {
                int topLeftX = Maths.Max((int)(X * scalingAdjustment) - dataPointCetralisingOffset, 0);
                int topLeftY = Maths.Max((int)(Y * scalingAdjustment) - dataPointCetralisingOffset, 0);

                var box = new Rectangle(topLeftX, topLeftY, dataPointDiameterPixels, dataPointDiameterPixels);
                boundingBoxes.Add(box);
            }

            return boundingBoxes;
        }

        public void Dispose()
        {
            image.Dispose();
        }
    }
}
