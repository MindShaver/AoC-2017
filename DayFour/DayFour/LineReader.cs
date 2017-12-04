using System.Collections.Generic;
using System.IO;

namespace DayFour
{
    public class LineReader
    {
        public IEnumerable<string> ReadLine(string input)
        {
            using (var reader = new StreamReader(input))
            {
                string line;
                while (null != (line = reader.ReadLine()))
                {
                    yield return line;
                }
            }
        }
    }
}
