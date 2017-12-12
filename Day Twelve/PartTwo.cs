using System;
using System.Collections.Generic;
using System.Linq;

namespace DayTwelve
{
    public class PartTwo
    {
        private readonly HashSet<int> _visited = new HashSet<int>();
        private readonly Dictionary<int, List<int>> _map = new Dictionary<int, List<int>>();
        private int _counter = 0;

        public int Solve()
        {
            foreach (var line in new LineReader().ReadLine("INPUT.txt"))
            {
                var parsedLine = line.Split(new[] { "<->" }, StringSplitOptions.RemoveEmptyEntries);

                var root = int.Parse(parsedLine[0]);
                var children = parsedLine[1].Split(',').Select(int.Parse).ToArray();
                if (!_map.ContainsKey(root))
                {
                    _map.Add(root, new List<int>());
                }
                foreach (var child in children)
                {
                    if (!_map.ContainsKey(child))
                    {
                        _map.Add(child, new List<int>());
                    }

                    if (!_map[root].Contains(child))
                    {
                        _map[root].Add(child);
                    }

                    if (!_map[child].Contains(root))
                    {
                        _map[child].Add(root);
                    }
                }
            }

            Search(0);
            _counter++;

            foreach (var key in _map.Keys)
            {
                if (_visited.Contains(key))
                    continue;

                Search(key);
                _counter++;
            }

            return _counter;
        }

        private void Search(int key)
        {
            var currentQueue = new Queue<int>();
            currentQueue.Enqueue(key);
            _visited.Add(key);

            while (currentQueue.Count > 0)
            {
                var current = currentQueue.Dequeue();
                foreach (var child in _map[current])
                {
                    if (_visited.Contains(child))
                        continue;

                    currentQueue.Enqueue(child);
                    _visited.Add(child);
                }
            }
        }
    }
}
