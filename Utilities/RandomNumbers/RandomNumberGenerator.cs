using Maths = System.Math;

namespace Utilities.RandomNumbers
{
    //This utility class deliberately contains no exception handling. Exceptions should be thrown and handled higher
    //in the stack trace to allow meaningful debugging.
    public static class RandomNumberGenerator
    {
        private static Random seed = new Random();

        public static ushort Generate(ushort lowerLimit, ushort upperLimit)
        {
            return (ushort)seed.Next(lowerLimit, upperLimit);
        }

        public static (ushort X, ushort Y) GeneratePair(ushort upperLimit) => GeneratePair(0, upperLimit);

        public static (ushort X, ushort Y) GeneratePair(ushort lowerLimit, ushort upperLimit)
        {
            ushort x = (ushort)seed.Next(lowerLimit, upperLimit);
            ushort y = (ushort)seed.Next(lowerLimit, upperLimit);

            return (x, y);
        }

        public static (ushort X, ushort Y) GeneratePair((ushort X, ushort Y) root, ushort maxDeviance, ushort upperLimit)
        {
            ushort xLowerLimit = (ushort)Maths.Max(0, root.X - maxDeviance);
            ushort xUpperLimit = (ushort)Maths.Min(upperLimit, root.X + maxDeviance);



            ushort x = (ushort)seed.Next(xLowerLimit, xUpperLimit);

            ushort yLowerLimit = (ushort)Maths.Max(0, root.Y - maxDeviance);
            ushort yUpperLimit = (ushort)Maths.Min(upperLimit, root.Y + maxDeviance);
            ushort y = (ushort)seed.Next(yLowerLimit, yUpperLimit);

            return (x, y);
        }
    }
}
