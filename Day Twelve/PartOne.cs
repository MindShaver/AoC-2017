using System;
using System.Collections.Generic;
using System.Linq;

namespace DayTwelve
{
    public class PartOne
    {
        public int Solve()
        {
            var map = new Dictionary<int, List<int>>();
            foreach (var line in new LineReader().ReadLine("INPUT.txt"))
            {
                var parsedLine = line.Split(new [] { "<->" }, StringSplitOptions.RemoveEmptyEntries);
                  
                var root = int.Parse(parsedLine[0]);
                var children = parsedLine[1].Split(',').Select(int.Parse).ToArray();
                if (!map.ContainsKey(root))
                {
                    map.Add(root, new List<int>());
                }
                foreach (var child in children)
                {
                    if (!map.ContainsKey(child))
                    {
                        map.Add(child, new List<int>());
                    }

                    if (!map[root].Contains(child))
                    {
                        map[root].Add(child);
                    }

                    if (!map[child].Contains(root))
                    {
                        map[child].Add(root);
                    }
                }

            }
            
            var currentQueue = new Queue<int>();
            var visited = new HashSet<int>();

            currentQueue.Enqueue(0);
            visited.Add(0);

            while (currentQueue.Count > 0)
            {
                var current = currentQueue.Dequeue();
                foreach (var child in map[current])
                {
                    if (visited.Contains(child))
                        continue;

                    currentQueue.Enqueue(child);
                    visited.Add(child);
                }
            }

            return visited.Count;
        }
    }
}