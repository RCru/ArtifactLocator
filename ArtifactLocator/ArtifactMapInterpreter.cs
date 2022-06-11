namespace ArtifactLocator
{
    public static class ArtifactMapInterpreter
    {
        public static List<(ushort X, ushort Y)> Interpret(this bool[][] map, ushort initialCapacity = 3)
        {
            var result = new List<(ushort X,ushort Y)>(initialCapacity);

            for (ushort i = 0; i < map.Length; ++i)
            {
                for (ushort j = 0; j < map[i].Length; ++j)
                {
                    if (map[i][j])
                    {
                        result.Add((i, j));
                    }
                }
            }

            return result;
        }
    }
}
