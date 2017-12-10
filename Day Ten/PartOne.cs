using System.Linq;

namespace DayTen
{
    public class PartOne
    {
        public int Solve()
        {
            var lengthSequence = new[] { 14, 58, 0, 116, 179, 16, 1, 104, 2, 254, 167, 86, 255, 55, 122, 244 };
            var list = new int[256];
            var skip = 0;
            var counter = 0;

            for (var i = 0; i < list.Length; i++)
            {
                list[i] = i;
            }

            foreach (var instruction in lengthSequence)
            {
                var arraySubset = new int[instruction];
                var localCount = counter;
                for (var i = 0; i < instruction; i++)
                {
                    if (localCount >= list.Length)
                    {
                        localCount = 0;
                    }

                    arraySubset[i] = list[localCount];
                    localCount++;
                }

                var reverse = arraySubset.Reverse().ToArray();
                localCount = counter;

                for (var i = 0; i < instruction; i++)
                {
                    if (localCount >= list.Length)
                    {
                        localCount = 0;
                    }

                    list[localCount] = reverse[i];

                    localCount++;
                }

                counter += instruction + skip;
                
                counter = counter % list.Length;
                
                skip++;
            }

            return list[0] * list[1];
        }
    }
}