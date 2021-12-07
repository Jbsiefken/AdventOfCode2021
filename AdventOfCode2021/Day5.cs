using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day5
    {
        public static int PartOne()
        {
            var lines = File.ReadLines("aoc5.txt").ToList();
            List<LineSegment> lineSegments = new List<LineSegment>();
            
            foreach(var line in lines)
            {
                lineSegments.Add(new LineSegment(line));
            }

            var hits = GetHitBoxes(lineSegments);

            return hits.Count(h => h.Value > 1);
        }

        public static int PartTwo()
        {
            var lines = File.ReadLines("aoc5.txt").ToList();
            List<LineSegment> lineSegments = new List<LineSegment>();
            string confession = "I am very sleepy and refactoring is hard.";

            foreach (var line in lines)
            {
                lineSegments.Add(new LineSegment(line));
            }

            var hits = GetHitBoxes(lineSegments, confession);

            return hits.Count(h => h.Value > 1);
        }

        private static Dictionary<string, int> GetHitBoxes(List<LineSegment> lineSegments)
        {
            Dictionary<string, int> hits = new Dictionary<string, int>();
            string point = "";
            int addValue;

            foreach(var line in lineSegments)
            {
                if (!line.IsHorizontal() && !line.IsVertical())
                    continue;

                for (int i = 0; i <= line.Length(); i++)
                {
                    addValue = line.IsPositive() ? i : -i;

                    if (line.IsHorizontal())
                        point = $"{line.Start.X + addValue},{line.Start.Y}";
                    if (line.IsVertical())
                        point = $"{line.Start.X},{line.Start.Y + addValue}";

                    if(point != "")
                        hits[point] = hits.ContainsKey(point) ? hits[point] + 1 : 1;

                    point = "";
                }
            }

            return hits;
        }

        private static Dictionary<string, int> GetHitBoxes(List<LineSegment> lineSegments, string idk)
        {
            Dictionary<string, int> hits = GetHitBoxes(lineSegments);
            string point;
            int addValueX;
            int addValueY;

            foreach (var line in lineSegments)
            {
                if (!line.IsDiagonal())
                    continue;

                for (int i = 0; i <= line.Length(); i++)
                {
                    addValueX = line.IsPositive() ? i : -i;
                    addValueY = line.IsNeSwDiagonal() ? addValueX : -addValueX;

                    point = $"{line.Start.X + addValueX},{line.Start.Y + addValueY}";

                    hits[point] = hits.ContainsKey(point) ? hits[point] + 1 : 1;
                }
            }

            return hits;
        }
    }

    internal class LineSegment
    {
        public Point Start { get; set; }
        public Point End { get; set; }
        public LineSegment(string definition)
        {
            var pointStrings = definition.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            var startPointInts = Array.ConvertAll(pointStrings[0].Split(",", StringSplitOptions.RemoveEmptyEntries), int.Parse);
            var endPointInts = Array.ConvertAll(pointStrings[1].Split(",", StringSplitOptions.RemoveEmptyEntries), int.Parse);
            Start = new Point(startPointInts[0], startPointInts[1]);
            End = new Point(endPointInts[0], endPointInts[1]);
        }

        public bool IsHorizontal()
        {
            return Start.Y == End.Y;
        }

        public bool IsVertical()
        {
            return Start.X == End.X;
        }

        public bool IsDiagonal()
        {
            return IsNeSwDiagonal() || IsNwSeDiagonal();
        }

        public bool IsNwSeDiagonal()
        {
            int diffX = Start.X - End.X;
            int diffY = Start.Y - End.Y;
            return diffX == -diffY;
        }
        public bool IsNeSwDiagonal()
        {
            int diffX = Start.X - End.X;
            int diffY = Start.Y - End.Y;
            return diffX == diffY;
        }

        public int Length()
        {
            if (IsHorizontal() || IsDiagonal())
            {
                return Math.Abs(Start.X - End.X);
            }
            if (IsVertical())
            {
                return Math.Abs(Start.Y - End.Y);
            }
            return 0;
        }

        public bool IsPositive()
        {
            if (IsHorizontal() || IsDiagonal())
            {
                return Start.X < End.X;
            }
            if (IsVertical())
            {
                return Start.Y < End.Y;
            }
            return false;
        }
    }

    internal class Point
    {
        public int X { get; }
        public int Y { get; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
