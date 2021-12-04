using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day1
    {

        public static int AOC1_1()
        {
            int counter = 0;
            int lastValue = -1;
            int currentValue;

            foreach (string line in File.ReadLines(@"aoc1-1.txt"))
            {
                currentValue = int.Parse(line);
                if (lastValue == -1)
                {
                    lastValue = currentValue;
                    continue;
                }
                if (currentValue > lastValue)
                    counter++;
                lastValue = currentValue;
            }

            return counter;
        }

        public static int AOC1_2()
        {
            int counter = 0;
            int lastValue = -1;
            int currentValue;

            var lines = File.ReadLines(@"aoc1-1.txt").ToList();

            for (int i = 0; i < lines.Count - 2; i++)
            {
                currentValue = ChristmasService.AddStrings(lines[i], lines[i + 1], lines[i + 2]);
                if (lastValue == -1)
                {
                    lastValue = currentValue;
                    continue;
                }
                if (currentValue > lastValue)
                    counter++;
                lastValue = currentValue;
            }

            return counter;
        }
    }
}