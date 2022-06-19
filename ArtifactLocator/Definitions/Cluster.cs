using Maths = System.Math;

namespace ArtifactLocator.Definitions
{
    public abstract class Cluster
    {
        public List<Coordinates> MemberCoordinates { get; set; } = new List<Coordinates>();

        public int Size => MemberCoordinates.Count;

        public Coordinates CentrePoint
        {
            get
            {
                if (Size == 0) return default;

                int sumX = 0, sumY = 0;

                foreach (Coordinates coordinates in MemberCoordinates)
                {
                    sumX += coordinates.X;
                    sumY += coordinates.Y;
                }

                ushort meanX = (ushort)Maths.Round(sumX / (float)MemberCoordinates.Count);
                ushort meanY = (ushort)Maths.Round(sumY / (float)MemberCoordinates.Count);

                return new Coordinates(meanX, meanY);
            }
        }
    }
}
