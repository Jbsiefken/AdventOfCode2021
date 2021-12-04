using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    public class Day3
    {

        public static int AOC3_1()
        {
            var lines = File.ReadLines(@"aoc3.txt").ToList();
            int[] totalsArray = new int[lines[0].Length];
            int gamma = 0;
            int epsilon = 0;

            foreach (var line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '0')
                    {
                        totalsArray[i]--;
                    }
                    else
                    {
                        totalsArray[i]++;
                    }
                }
            }
            for (int i = 0; i < totalsArray.Length; i++)
            {
                if (totalsArray[totalsArray.Length - (i + 1)] > 0)
                {
                    gamma += Convert.ToInt32(Math.Pow(2, i));
                }
                else
                {
                    epsilon += Convert.ToInt32(Math.Pow(2, i));
                }
            }
            return gamma * epsilon;
        }

        public static int AOC3_2()
        {
            var lines = File.ReadLines(@"aoc3.txt").ToList();
            int bits = lines[0].Length;
            List<string> oxygenList = new List<string>(lines).OrderBy(o => o).ToList();
            List<string> co2List = new List<string>(lines).OrderBy(c => c).ToList();
            int oxygen = 0;
            int co2 = 0;

            for (int i = 0; i < bits; i++)
            {
                if (oxygenList.Count > 1)
                {
                    if (oxygenList.Count(o => o[i] == '1') >= oxygenList.Count(o => o[i] == '0'))
                    {
                        oxygenList = oxygenList.Where(o => o[i] == '1').ToList();
                    }
                    else
                    {
                        oxygenList = oxygenList.Where(o => o[i] == '0').ToList();
                    }
                }
                if (co2List.Count > 1)
                {
                    if (co2List.Count(o => o[i] == '0') <= co2List.Count(o => o[i] == '1'))
                    {
                        co2List = co2List.Where(o => o[i] == '0').ToList();
                    }
                    else
                    {
                        co2List = co2List.Where(o => o[i] == '1').ToList();
                    }
                }

                if (oxygenList.Count == 1 && co2List.Count == 1)
                {
                    break;
                }
            }
            for (int i = 0; i < bits; i++)
            {
                if (oxygenList.First()[bits - (i + 1)] == '1')
                {
                    oxygen += Convert.ToInt32(Math.Pow(2, i));
                }
                if (co2List.First()[bits - (i + 1)] == '1')
                {
                    co2 += Convert.ToInt32(Math.Pow(2, i));
                }
            }

            return oxygen * co2;
        }
    }
}