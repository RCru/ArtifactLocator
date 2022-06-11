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

        private Queue<Pen> pens = new Queue<Pen>();

        public ResultsMap(int width, int height)
        {
            this.width = width;
            this.height = height;

            pens.Enqueue(Pens.Red);
            pens.Enqueue(Pens.Blue);
            pens.Enqueue(Pens.Green);
            pens.Enqueue(Pens.Red);
            pens.Enqueue(Pens.Blue);
            pens.Enqueue(Pens.Green);

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

        public void AddCoordinatePoints(List<(ushort X, ushort Y)> coordinateList, float scalingAdjustment)
        {
            List<Rectangle> boundingBoxes = GenerateBoundingBoxes(coordinateList, scalingAdjustment);
            Pen pen = pens.Dequeue();

            using (Graphics g = Graphics.FromImage(image))
            {
                foreach (Rectangle boundingBox in boundingBoxes)
                {
                    g.DrawEllipse(pen, boundingBox);
                }
            }
        }

        public void AddCentrePoints(List<(ushort X, ushort Y)> coordinateList, float scalingAdjustment)
        {
            List<Rectangle> boundingBoxes = GenerateBoundingBoxes(coordinateList, scalingAdjustment, 2);

            using (Graphics g = Graphics.FromImage(image))
            {
                foreach (Rectangle boundingBox in boundingBoxes)
                {
                    g.DrawEllipse(Pens.Black, boundingBox);
                }
            }
        }

        public void Clear()
        {
            GenerateTemplate();
        }

        private List<Rectangle> GenerateBoundingBoxes(List<(ushort X, ushort Y)> coordinateList, float scalingAdjustment, ushort zoom = 1)
        {
            var boundingBoxes = new List<Rectangle>(coordinateList.Count);

            //intentionally exploiting implicit Math.Floor in int division
            int dataPointCetralisingOffset = dataPointDiameterPixels / 2;

            foreach ((ushort X, ushort Y) in coordinateList)
            {
                int topLeftX = Maths.Max((int)(X * scalingAdjustment) - (dataPointCetralisingOffset * zoom), 0);
                int topLeftY = Maths.Max((int)(Y * scalingAdjustment) - (dataPointCetralisingOffset * zoom), 0);

                var box = new Rectangle(topLeftX, topLeftY, dataPointDiameterPixels * zoom, dataPointDiameterPixels * zoom);
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
