using System.Collections;

namespace BowlingGame
{
    internal class BowlingGame
    {
        private readonly ArrayList _frames = [];
        private readonly int[] _throws = new int[21];
        private int _throwIndex;

        public void OpenFrame(int firstThrow, int secondThrow)
        {
            AddThrow(firstThrow);
            AddThrow(secondThrow);
            _frames.Add(new Frame(firstThrow, secondThrow));
        }

        public void Spare(int firstThrow, int secondThrow)
        {
            AddThrow(firstThrow);
            AddThrow(secondThrow);
            _frames.Add(new SpareFrame(_throwIndex, _throws));
        }

        public int Score()
        {
            return _frames.Cast<IFrame>().Sum(f => f.Score());
        }

        private void AddThrow(int @throw)
        {
            _throws[_throwIndex++] = @throw;
        }

        public void Strike()
        {
           AddThrow(10); 
           _frames.Add(new StrikeFrame(_throwIndex, _throws));
        }
    }
}
