namespace Filtering
{
    public interface ICoordinateFilter
    {
        public List<(ushort X, ushort Y)> Filter(List<(ushort X, ushort Y)> coordinates);
    }
}
