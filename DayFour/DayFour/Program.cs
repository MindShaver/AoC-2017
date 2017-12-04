using System;
using System.Linq;

namespace DayFour
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var count = 0;
            var duplicate = false;
            foreach (var line in new LineReader().ReadLine("INPUT.txt"))
            {
                var words = line.Split(' ');

                // Part One

                //for (var i = 0; i < words.Length; i++)
                //{
                //    for (var j = i + 1; j < words.Length; j++)
                //    {
                //        if (words[i].Equals(words[j]))
                //        {
                //            duplicate = true;
                //        }
                //    }
                //}

                // Part Two

                for (var i = 0; i < words.Length; i++)
                {
                    for (var j = i + 1; j < words.Length; j++)
                    {
                        if (string.Concat(words[i].OrderBy(c => c)).Equals(string.Concat(words[j].OrderBy(c => c))))
                        {
                            duplicate = true;
                        }
                    }
                }

                if (duplicate == false)
                {
                    count++;
                }
                else
                {
                    duplicate = false;
                }
            }
            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
}
