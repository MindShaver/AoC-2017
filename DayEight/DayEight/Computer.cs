using System;
using System.Collections.Generic;
using System.Linq;

namespace DayEight
{
    public class Computer
    {
        private readonly string[] _input;
        private static Dictionary<string, int> _registers = new Dictionary<string, int>();

        public Computer(string[] input)
        {
            _input = input;
        }

        public int SolvePartOne()
        {
            foreach (var line in _input)
            {
                var parsedLine = line.Split(' ');
                var registerToModify = parsedLine[0];
                var instruction = parsedLine[1];
                var value = int.Parse(parsedLine[2]);
                var conditionalRegister = parsedLine[4];
                var conditionalOperator = parsedLine[5];
                var conditionalValue = int.Parse(parsedLine[6]);

                if (!_registers.ContainsKey(registerToModify))
                {
                    _registers.Add(registerToModify, 0);
                }

                if (!_registers.ContainsKey(conditionalRegister))
                {
                    _registers.Add(conditionalRegister, 0);
                }

                var isTrue = ConditionalCheck(conditionalRegister, conditionalValue, conditionalOperator);

                ExecuteInstruction(isTrue, instruction, registerToModify, value);
            }

            return _registers.Values.ToList().Max();
        }

        public int SolvePartTwo()
        {
            _registers = new Dictionary<string, int>();
            var max = 0;
            foreach (var line in _input)
            {
                var parsedLine = line.Split(' ');
                var registerToModify = parsedLine[0];
                var instruction = parsedLine[1];
                var value = int.Parse(parsedLine[2]);
                var conditionalRegister = parsedLine[4];
                var conditionalOperator = parsedLine[5];
                var conditionalValue = int.Parse(parsedLine[6]);

                if (!_registers.ContainsKey(registerToModify))
                {
                    _registers.Add(registerToModify, 0);
                }

                if (!_registers.ContainsKey(conditionalRegister))
                {
                    _registers.Add(conditionalRegister, 0);
                }

                var isTrue = ConditionalCheck(conditionalRegister, conditionalValue, conditionalOperator);

                ExecuteInstruction(isTrue, instruction, registerToModify, value);

                max = _registers.Values.Concat(new[] {max}).Max();
            }

            return max;
        }
    

        private static void ExecuteInstruction(bool isTrue, string instruction, string registerToModify, int value)
        {
            if (!isTrue) return;

            switch (instruction)
            {
                case ("inc"):
                    _registers[registerToModify] += value;
                    break;
                case ("dec"):
                    _registers[registerToModify] -= value;
                    break;
                default:
                    Console.WriteLine("Instruction not found.");
                    break;
            }
        }

        private static bool ConditionalCheck(string conditionalRegister, int conditionalValue, string conditionalOperator)
        {
            var isTrue = false;
            switch (conditionalOperator)
            {
                case "==":
                    isTrue = _registers[conditionalRegister] == conditionalValue;
                    break;
                case "<=":
                    isTrue = _registers[conditionalRegister] <= conditionalValue;
                    break;
                case "<":
                    isTrue = _registers[conditionalRegister] < conditionalValue;
                    break;
                case ">=":
                    isTrue = _registers[conditionalRegister] >= conditionalValue;
                    break;
                case ">":
                    isTrue = _registers[conditionalRegister] > conditionalValue;
                    break;
                case "!=":
                    isTrue = _registers[conditionalRegister] != conditionalValue;
                    break;
                default:
                    Console.WriteLine("Unknown Operator.");
                    break;
            }

            return isTrue;
        }
    }
}
