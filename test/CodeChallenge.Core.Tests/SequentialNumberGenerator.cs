using CodeChallenge.Core.Implementations;

namespace CodeChallenge.Core.Tests
{
    public class SequentialNumberGenerator : INumberGenerator
    {
        private int _prev;
        public SequentialNumberGenerator()
        {
            _prev = 0;
        }
        public int GenerateNumber(int maxInclusive)
        {
            if (_prev == maxInclusive)
            {
                _prev = 0;
            }
            return ++_prev;
        }
    }
}
