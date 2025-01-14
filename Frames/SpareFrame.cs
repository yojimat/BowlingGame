namespace BowlingGame.Frames;

internal class SpareFrame(int nextBallPointer, int[] throws) : IFrame
{
    private const int FrameScore = 10;

    public int Score() => FrameScore + NextBallScore();

    public int NextBallScore()=> throws[nextBallPointer];
}