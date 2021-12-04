using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class ChristmasService
    {
        public static int AddStrings(params string[] args)
        {
            int sum = 0;
            foreach (var arg in args)
            {
                sum += int.Parse(arg);
            }
            return sum;
        }
    }
}
