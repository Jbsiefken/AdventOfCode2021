using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day2
    {

        public static int AOC2_1()
        {
            int position = 0;
            int depth = 0;
            int amount;
            var lines = File.ReadLines(@"aoc2.txt").ToList();

            foreach (var line in lines)
            {
                amount = int.Parse(line.Substring(line.LastIndexOf(" ") + 1));
                if (line.Contains("forward"))
                {
                    position += amount;
                }
                else if (line.Contains("down"))
                {
                    depth += amount;
                }
                else
                {
                    depth -= amount;
                }
            }
            return position * depth;
        }

        public static int AOC2_2()
        {
            int position = 0;
            int depth = 0;
            int aim = 0;
            int amount;
            var lines = File.ReadLines(@"aoc2.txt").ToList();

            foreach (var line in lines)
            {
                amount = int.Parse(line.Substring(line.LastIndexOf(" ") + 1));
                if (line.Contains("forward"))
                {
                    position += amount;
                    depth += aim * amount;
                }
                else if (line.Contains("down"))
                {
                    aim += amount;
                }
                else
                {
                    aim -= amount;
                }
            }
            return position * depth;
        }
    }
}