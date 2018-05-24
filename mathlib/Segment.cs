namespace mathlib
{
    public struct Segment
    {
        public double Start;
        public double End;

        public Segment(double start, double end)
        {
            Start = start;
            End = end;
        }

        public double Length => End - Start;
    }
}