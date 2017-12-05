using System.Collections.Generic;
using System.IO;

namespace DayFive
{
    public class LineReader
    {
        public IEnumerable<string> ReadLine(string fileName)
        {
            using (var stream = new StreamReader(fileName))
            {
                string line;
                while (null != (line = stream.ReadLine()))
                {
                    yield return line;
                }
            }
        }
    }
}
