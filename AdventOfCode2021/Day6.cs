using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day6
    {
        public static int PartOne()
        {
            return Spawn(80);
        }
        public static long PartTwo()
        {
            return Spawn2(256);
        }
        private static int Spawn(int numCycles)
        {
            var input = File.ReadLines("aoc6.txt").First();
            List<int> listOFish = Array.ConvertAll(input.Split(","), int.Parse).ToList();
            int newFish;
            for(int i = 0; i < numCycles; i++)
            {
                newFish = 0;
                for(int f = 0; f < listOFish.Count; f++)
                {
                    if(listOFish[f] == 0)
                    {
                        newFish++;
                        listOFish[f] = 6;
                    }
                    else
                    {
                        listOFish[f]--;
                    }
                }

                for(int f = 0; f < newFish; f++)
                {
                    listOFish.Add(8);
                }
            }

            return listOFish.Count;
        }

        private static long Spawn2(int numCycles)
        {
            var input = File.ReadLines("aoc6.txt").First();
            List<int> listOFish = Array.ConvertAll(input.Split(","), int.Parse).ToList();
            Dictionary<int, long> fishionary = new Dictionary<int, long>();
            long babies;
            long sum = 0;
            for(int i = 0; i <= 8; i++)
            {
                fishionary.Add(i, 0);
            }
            foreach(var fish in listOFish)
            {
                fishionary[fish]++;
            }

            for (int i = 0; i < numCycles; i++)
            {
                babies = fishionary[0];
                for (int d = 1; d <= 8; d++)
                {
                    fishionary[d - 1] = fishionary[d];
                }
                fishionary[6] += babies;
                fishionary[8] = babies;
            }
            for(int x = 0; x <= 8; x++)
            {
                sum += fishionary[x];
            }
            return sum;
        }
    }
}
