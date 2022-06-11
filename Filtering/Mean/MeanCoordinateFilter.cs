namespace Filtering.Implementations
{
    public class MeanCoordinateFilter : ICoordinateFilter
    {
        private ushort toleratedDeviance;

        public MeanCoordinateFilter(ushort toleratedDeviance)
        {
            this.toleratedDeviance = toleratedDeviance;
        }

        public List<(ushort X, ushort Y)> Filter(List<(ushort X, ushort Y)> coordinates)
        {
            throw new NotImplementedException();
        }
    }
}
