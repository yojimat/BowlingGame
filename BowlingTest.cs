namespace BowlingGame;

[TestFixture]
public class BowlingTest
{
    private static BowlingGame _game = new();

    [SetUp]
    public void Setup()
    {
        _game = new BowlingGame();
    }

    [Test]
    public void GutterBalls()
    {
        ManyOpenFrames(0, 0, 10);
        Assert.That(_game.Score(), Is.EqualTo(0));
    }

    [Test]
    public void Threes()
    {
        ManyOpenFrames(3, 3, 10);
        Assert.That(_game.Score(), Is.EqualTo(60));
    }

    [Test]
    public void Spare()
    {
        _game.Spare(5, 5);
        _game.OpenFrame(7, 1);
        ManyOpenFrames(0, 0, 8);
        Assert.That(_game.Score(), Is.EqualTo(25));
    }

    [Test]
    public void Strike()
    {
        _game.Strike();
        _game.OpenFrame(7, 1);
        ManyOpenFrames(0, 0, 8);
        Assert.That(_game.Score(), Is.EqualTo(26));
    }

    [Test]
    public void StrikeFinalFrame()
    {
        ManyOpenFrames(0,0,9);
        _game.Strike();
        _game.BonusRoll(5);
        _game.BonusRoll(3);
        Assert.That(_game.Score(), Is.EqualTo(18));
    }

    [Test]
    public void SpareFinalFrame()
    {
        ManyOpenFrames(0,0,9);
        _game.Spare(4,6);
        _game.BonusRoll(5);
        Assert.That(_game.Score(), Is.EqualTo(15));
    }

    [Test]
    public void PerfectGame()
    {
        for (var frameNumber = 0; frameNumber < 10; frameNumber++)
            _game.Strike();
        _game.BonusRoll(10);
        _game.BonusRoll(10);
        Assert.That(_game.Score(), Is.EqualTo(300));
    }
    
    [Test]
    public void AlternatingGame()
    {
        for (var frameNumber = 0; frameNumber < 5; frameNumber++)
        {
            _game.Strike();
            _game.Spare(4,6);
        }
        _game.BonusRoll(10);
        Assert.That(_game.Score(), Is.EqualTo(200));
    }

    private static void ManyOpenFrames(int firstThrow, int secondThrow, int frameCount)
    {
        for (var frameNumber = 0; frameNumber < frameCount; frameNumber++)
            _game.OpenFrame(firstThrow, secondThrow);
    }

}