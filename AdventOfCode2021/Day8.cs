using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day8
    {
        public static int PartOne()
        {
            var lines = File.ReadLines("aoc8.txt").ToList();
            int sum = 0;
            for(int i = 0; i < lines.Count; i++)
            {
                sum += lines[i].Substring(lines[i].LastIndexOf("| ") + 1).Split(" ").Count(l => l.Length == 2 || l.Length == 3 || l.Length == 4 || l.Length == 7);
            }
            return sum;
        }

        public static int PartTwo()
        {
            var lines = File.ReadLines("aoc8.txt").ToList();
            int sum = 0;
            Dictionary<string, string> numbers;
            Dictionary<string, string> keys;
            string upperRightVertical = " ";
            string[] input;
            string[] output;
            string result;
            for(int i = 0; i < lines.Count; i++)
            {
                numbers = new Dictionary<string, string>();
                input = lines[i].Substring(0, lines[0].IndexOf(" |")).Split(" ");
                output = lines[i].Substring(lines[0].LastIndexOf("| ") + 1).Split(" ", StringSplitOptions.RemoveEmptyEntries);
                result = "";
                // Gets 1, 4, 7, and 8
                foreach(var number in input)
                {
                    if(number.Length == 2)
                    {
                        numbers["1"] = number;
                    }
                    else if(number.Length == 3)
                    {
                        numbers["7"] = number;
                    }
                    else if(number.Length == 4)
                    {
                        numbers["4"] = number;
                    }
                    else if(number.Length == 7)
                    {
                        numbers["8"] = number;
                    }
                }
                // 3
                foreach(var number in input)
                {
                    if(number.Length == 5 && numbers["7"].All(c => number.Contains(c)))
                    {
                        numbers["3"] = number;
                        break;
                    }
                }
                // 6
                foreach (var number in input)
                {
                    if (number.Length == 6 && !numbers["7"].All(c => number.Contains(c)))
                    {
                        numbers["6"] = number;
                        break;
                    }
                }
                // Helpful line
                foreach(var c in numbers["1"])
                {
                    if (!numbers["6"].Contains(c))
                    {
                        upperRightVertical = c.ToString();
                        break;
                    }
                }
                // 2
                foreach (var number in input)
                {
                    if (number.Length == 5 && !numbers["7"].All(c => number.Contains(c)) && number.Contains(upperRightVertical))
                    {
                        numbers["2"] = number;
                        break;
                    }
                }
                // 5
                foreach (var number in input)
                {
                    if (number.Length == 5 && !numbers["7"].All(c => number.Contains(c)) && !number.Contains(upperRightVertical))
                    {
                        numbers["5"] = number;
                        break;
                    }
                }
                // 9
                foreach (var number in input)
                {
                    if (number.Length == 6 && numbers["3"].All(c => number.Contains(c)))
                    {
                        numbers["9"] = number;
                        break;
                    }
                }
                // 0
                foreach (var number in input)
                {
                    if (number.Length == 6 && !numbers.ContainsValue(number))
                    {
                        numbers["0"] = number;
                        break;
                    }
                }
                foreach(var outputNum in output)
                {
                    var value = numbers.Keys.Single(k => outputNum.All(r => numbers[k].Contains(r)) && numbers[k].All(kc => outputNum.Contains(kc)));
                    result = $"{result}{value}";
                }
                sum += int.Parse(result);
            }
            return sum;
        }
    }
}
