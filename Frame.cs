namespace BowlingGame
{
    internal class Frame(int firstThrow, int secondThrow):IFrame
    {
        private readonly int _frameScore = firstThrow + secondThrow;

        public int Score()
        {
            return _frameScore;
        }
    }
}
