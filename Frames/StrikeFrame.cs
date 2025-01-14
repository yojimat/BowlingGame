namespace BowlingGame.Frames;

internal class StrikeFrame(int nextBallPointer, int[] throws) : IFrame
{
    private const int FrameScore = 10;

    public int Score() => FrameScore + FirstFollowingBall() + SecondFollowingBall();

    private int FirstFollowingBall() => throws[nextBallPointer];

    private int SecondFollowingBall() => throws[nextBallPointer + 1];
}