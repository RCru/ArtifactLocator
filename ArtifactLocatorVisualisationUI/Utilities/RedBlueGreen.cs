namespace ArtifactLocatorVisualisationUI.Utilities
{
    public static class RedBlueGreen
    {
        private static Queue<Pen> pens = new Queue<Pen>(3);

        static RedBlueGreen()
        {
            pens.Enqueue(Pens.Red);
            pens.Enqueue(Pens.Blue);
            pens.Enqueue(Pens.Green);
        }

        public static Pen Next()
        {
            Pen nextPen = pens.Dequeue();
            pens.Enqueue(nextPen);

            return nextPen;
        }
    }
}
