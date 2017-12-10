using System;
using System.Linq;

namespace DayNine
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = new LineReader().ReadLine("INPUT.txt").ToArray();
            var inputStringLiteral = input[0];
            var garbage = false;
            var nest = 0;
            var score = 0;
            var garbageCount = 0;

            for (var i = 0; i < inputStringLiteral.Length; i++)
            {
                if (inputStringLiteral[i] == '!')
                {
                    i++;
                }
                else if (inputStringLiteral[i] == '<' && !garbage)
                {
                    garbage = true;
                }
                else if (inputStringLiteral[i] == '>' && garbage)
                {
                    garbage = false;
                }
                else if (inputStringLiteral[i] == '{' && !garbage)
                {
                    nest++;
                }
                else if (inputStringLiteral[i] == '}' && !garbage)
                {
                    score += nest;
                    nest--;
                }
                else if (garbage)
                {
                    garbageCount++;
                }
            }
            
            Console.WriteLine($"Score = {score}");
            Console.WriteLine($"Garbage Count = {garbageCount}");
            Console.ReadKey();
        }
    }
}
