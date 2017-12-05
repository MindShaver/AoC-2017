namespace DayFive
{
    public class DayRunner
    {
        private readonly int[] _memory;

        public DayRunner(int[] memory)
        {
            _memory = memory;
        }

        public int RunPartOne()
        {
            var programCounter = 0;
            var stepCounter = 0;

            while (programCounter < _memory.Length)
            {
                var currentProgramCounter = programCounter;
                var currentValue = _memory[programCounter];

                programCounter += _memory[programCounter];
                _memory[currentProgramCounter] = currentValue + 1;
                stepCounter++;
            }

            return stepCounter;
        }

        public int RunPartTwo()
        {
            var programCounter = 0;
            var stepCounter = 0;

            while (programCounter < _memory.Length)
            {
                var currentProgramCounter = programCounter;
                var currentValue = _memory[programCounter];

                programCounter += _memory[programCounter];

                if (currentValue >= 3)
                {
                    _memory[currentProgramCounter] = currentValue - 1;
                }
                else
                {
                    _memory[currentProgramCounter] = currentValue + 1;
                }
                stepCounter++;
            }

            return stepCounter;
        }
    }
}
