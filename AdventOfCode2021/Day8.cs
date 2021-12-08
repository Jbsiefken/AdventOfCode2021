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
                keys = new Dictionary<string, string>();
                input = lines[i].Substring(0, lines[0].IndexOf(" |")).Split(" ");
                output = lines[i].Substring(lines[0].LastIndexOf("| ") + 1).Split(" ", StringSplitOptions.RemoveEmptyEntries);
                result = "";
                // Gets 1, 4, 7, and 8
                foreach(var number in input)
                {
                    if(number.Length == 2)
                    {
                        numbers["1"] = number;
                        keys[number] = "1";
                    }
                    else if(number.Length == 3)
                    {
                        numbers["7"] = number;
                        keys[number] = "7";
                    }
                    else if(number.Length == 4)
                    {
                        numbers["4"] = number;
                        keys[number] = "4";
                    }
                    else if(number.Length == 7)
                    {
                        numbers["8"] = number;
                        keys[number] = "8";
                    }
                }
                // 3
                foreach(var number in input)
                {
                    if(number.Length == 5 && numbers["7"].All(c => number.Contains(c)))
                    {
                        numbers["3"] = number;
                        keys[number] = "3";
                        break;
                    }
                }
                // 6
                foreach (var number in input)
                {
                    if (number.Length == 6 && !numbers["7"].All(c => number.Contains(c)))
                    {
                        numbers["6"] = number;
                        keys[number] = "6";
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
                        keys[number] = "2";
                        break;
                    }
                }
                // 5
                foreach (var number in input)
                {
                    if (number.Length == 5 && !numbers["7"].All(c => number.Contains(c)) && !number.Contains(upperRightVertical))
                    {
                        numbers["5"] = number;
                        keys[number] = "5";
                        break;
                    }
                }
                // 9
                foreach (var number in input)
                {
                    if (number.Length == 6 && numbers["3"].All(c => number.Contains(c)))
                    {
                        numbers["9"] = number;
                        keys[number] = "9";
                        break;
                    }
                }
                // 0
                foreach (var number in input)
                {
                    if (number.Length == 6 && !numbers.ContainsValue(number))
                    {
                        numbers["0"] = number;
                        keys[number] = "0";
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
