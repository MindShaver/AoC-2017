using System;
using System.Collections.Generic;
using System.Linq;

namespace DayThirteen
{
    public class Runner
    {
        public Dictionary<int, Layer> Depths = new Dictionary<int, Layer>();

        public int SolvePartOne()
        {
            var scanner = new int[96];
            var totalSeverity = 0;

            foreach (var line in new LineReader().ReadLine("INPUT.txt"))
            {
                var parsedLine = line.Split(':', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var depth = parsedLine[0];
                var range = parsedLine[1];
                Depths.Add(parsedLine[0], new Layer(depth, range));
            }

            for (var i = 0; i < scanner.Length; i++)
            {
                if (Depths.ContainsKey(i))
                {
                    if (Depths[i].Caught)
                    {
                        totalSeverity += Depths[i].Severity;
                    }
                }

                foreach (var layer in Depths.Values)
                {
                    layer.Move();
                }
            }

            return totalSeverity;
        }

        public int SolvePartTwo()
        {
            var shallowDepths = new List<Layer>();
            var delay = 0;

            foreach (var line in new LineReader().ReadLine("INPUT.txt"))
            {
                var parsedLine = line.Split(':', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var depth = parsedLine[0];
                var range = parsedLine[1];
                shallowDepths.Add(new Layer(depth, range));
            }

            while (true)
            {
                var found = false;
                if (shallowDepths.Any(layer => (delay + layer.Depth) % (layer.Range * 2 - 2) == 0))
                {
                    delay++;
                    found = true;
                }
                if (!found) break;
            }

            return delay;
        }
    }

    public class Layer
    {
        public int Depth { get; set; }
        public int Range { get; set; }
        public int Severity { get; set; }
        public int Position;
        public bool Forward = true;
        public bool Caught = true;

        public Layer(int depth, int range)
        {
            Depth = depth;
            Range = range;
            Severity = depth * range;
        }

        public void Move()
        {
            if (Forward)
            {
                Position++;
                if (Position == Range - 1)
                {
                    Forward = !Forward;
                }
            }
            else
            {
                Position--;
                if (Position == 0)
                {
                    Forward = !Forward;
                }
            }

            Caught = Position == 0;
        }
    }
}