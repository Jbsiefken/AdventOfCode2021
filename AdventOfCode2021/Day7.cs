using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day7
    {
        public static int PartOne()
        {
            var input = File.ReadLines("aoc7.txt").First();
            var crabList = Array.ConvertAll(input.Split(","), int.Parse).OrderBy(c => c).ToList();
            int standardCrab = crabList[crabList.Count/2];
            int sum = 0;
            for(var i = 0; i < crabList.Count; i++)
            {
                sum += Math.Abs(crabList[i] - standardCrab);
            }
            return sum;
        }

        public static double PartTwo()
        {
            var input = File.ReadLines("aoc7.txt").First();
            var crabList = Array.ConvertAll(input.Split(","), int.Parse).OrderBy(c => c).ToList();
            double standardCrab = Math.Floor(crabList.Average());
            double sum = 0;
            double steps;
            for (var i = 0; i < crabList.Count; i++)
            {
                steps = Math.Abs(crabList[i] - standardCrab);
                for (var j = 1; j <= steps; j++)
                {
                    sum += j;
                }
            }
            return sum;
        }
    }
}
