using System;
using System.Linq;

namespace DayFive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var memory = new LineReader().ReadLine("INPUT.txt").Select(int.Parse).ToArray();
            var runner = new DayRunner(memory);

            Console.WriteLine(runner.RunPartTwo());
            Console.ReadKey();
        }
    }
}
