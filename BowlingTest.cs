namespace BowlingGame
{
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

        private static void ManyOpenFrames(int firstThrow, int secondThrow, int frameCount)
        {
            for (var frameNumber = 0; frameNumber < frameCount; frameNumber++)
                _game.OpenFrame(firstThrow, secondThrow);
        }

    }
}