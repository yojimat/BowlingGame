namespace BowlingGame
{
    internal class SpareFrame(int nextBallPointer, int[] throws) : IFrame
    {
        private const int FrameScore = 10;

        public int Score()
        {
            return FrameScore + throws[nextBallPointer];
        }
    }
}
