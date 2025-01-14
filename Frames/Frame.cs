namespace BowlingGame.Frames;

internal class Frame(int firstThrow, int secondThrow) : IFrame
{
    private readonly int _frameScore = firstThrow + secondThrow;

    public int Score() => _frameScore;
}