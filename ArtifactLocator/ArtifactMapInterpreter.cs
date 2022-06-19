using ArtifactLocator.Definitions;

namespace ArtifactLocator
{
    public static class ArtifactMapInterpreter
    {
        public static List<Coordinates> Interpret(this bool[][] map, ushort initialCapacity = 3)
        {
            var result = new List<Coordinates>(initialCapacity);

            for (ushort i = 0; i < map.Length; ++i)
            {
                for (ushort j = 0; j < map[i].Length; ++j)
                {
                    if (map[i][j])
                    {
                        result.Add(new Coordinates(i, j));
                    }
                }
            }

            return result;
        }
    }
}
