using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterAlgorithms.Implementations
{
    public class KMeansClusterAlgorithm : IClusterAlgorithm
    {
        private List<(ushort X, ushort Y)> coordinateList;

        public void LoadCoordinates(List<(ushort X, ushort Y)> coordinateList)
        {
            this.coordinateList = coordinateList;
        }

        public List<(ushort X, ushort Y)> Cluster(ushort clusterCount)
        {
            if (coordinateList == null) return null;

            return new List<(ushort X, ushort Y)>();
        }
    }
}
