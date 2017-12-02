using System.Collections.Generic;
using System.IO;

namespace DayTwo
{
    public class LineReader
    {
        public IEnumerable<string> ReadLine(string fileName)
        {
            using (var reader = new StreamReader(fileName))
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
