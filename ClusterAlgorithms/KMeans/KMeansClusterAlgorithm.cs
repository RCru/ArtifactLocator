using random = Utilities.RandomNumbers.RandomNumberGenerator;
using Maths = System.Math;
using ArtifactLocator.Definitions;

namespace ClusterAlgorithms.KMeans
{
    public class KMeansClusterAlgorithm : IClusterAlgorithm
    {
        private List<Coordinates> coordinateList;

        public List<Cluster> Process(List<Coordinates> coordinateList, ushort expectedClusterCount)
        {
            if (coordinateList == null)
            {
                throw new ArgumentNullException("coordinateList");
            }

            this.coordinateList = coordinateList;

            List<KMean> startingMeans = null;
            List<KMeansCluster> clusters = null;

            do
            {
                startingMeans = GenerateStartingMeans(expectedClusterCount);
                clusters = Cluster(startingMeans);
            }
            while (clusters.Any(c => c.Size == 0));

            return clusters.Cast<Cluster>().ToList();
        }

        private List<KMeansCluster> Cluster(List<KMean> kMeans)
        {
            var clusters = new List<KMeansCluster>(kMeans.Count);
            kMeans.ForEach(x => clusters.Add(new KMeansCluster()));

            foreach (Coordinates coordinates in coordinateList)
            {
                float minDistance = float.MaxValue;
                int index = -1;

                for (int i = 0; i < kMeans.Count; ++i)
                {
                    float distance = kMeans[i].DistanceFrom(coordinates);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        index = i;
                    }
                }

                clusters[index].MemberCoordinates.Add(coordinates);
            }

            List<KMean> newKMeans = clusters.Select(c => c.CalculateKMean()).ToList();

            for (int i = 0; i < newKMeans.Count; ++i)
            {
                //this will occur if a kmean cluster is empty.
                //In this case, we use the last kmean that wasn't empty
                if (newKMeans[i] == null) newKMeans[i] = kMeans[i];
            }

            for (int i = 0; i < newKMeans.Count; ++i)
            {
                if (!kMeans[i].IsSameAs(newKMeans[i]))
                {
                    return Cluster(newKMeans);
                }
            }

            return clusters;
        }

        private List<KMean> GenerateStartingMeans(ushort expectedClusterCount)
        {
            var startingMeans = new List<KMean>(expectedClusterCount);

            ushort lowerBound = Maths.Min(coordinateList.Min(c => c.X), coordinateList.Min(c => c.Y));
            ushort upperBound = Maths.Max(coordinateList.Max(c => c.X), coordinateList.Max(c => c.Y));

            for (int i = 0; i < expectedClusterCount; ++i)
            {
                (ushort X, ushort Y) startingMean = random.GeneratePair(lowerBound, upperBound);
                startingMeans.Add(new KMean(startingMean));
            }

            return startingMeans;
        }
    }
}
