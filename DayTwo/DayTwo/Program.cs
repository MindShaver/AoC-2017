using System;
using System.Collections.Generic;
using System.Linq;

namespace DayTwo
{
    public class Program
    {
        public static int sum = 0;
        static void Main(string[] args)
        {
            // Part One

            //foreach (var line in new LineReader().ReadLine("INPUT.txt"))
            //{
            //    var splitInput = line.Split(' ');
            //    var numbers = splitInput.ToArray().Select(s => int.Parse(s.ToString()));
            //    sum += numbers.Max() - numbers.Min();
            //}

            // Part Two

            foreach (var line in new LineReader().ReadLine("INPUT.txt"))
            {
                var splitInput = line.Split(' ');
                var numbers = splitInput.ToArray().Select(s => int.Parse(s.ToString()));

                FindDivisibleNumbers(numbers);
            }

            Console.WriteLine(sum);
            Console.ReadKey();
        }

        private static void FindDivisibleNumbers(IEnumerable<int> numbers)
        {
            foreach (var number in numbers)
            {
                var goodNumbers = numbers.Where(x => x % number == 0 && x != number).Select(x => x / number);

                if (goodNumbers.Count() != 0)
                {
                    sum += goodNumbers.First();
                }
            }
        }
    }
}
