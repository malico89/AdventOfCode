using System;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        static void Main()
        {
            //string inputFile = "/Users/mariacardona/Documents/repos/AdventOfCode/inputs/2.txt";
            string inputFile = "/Users/mariacardona/Documents/repos/AdventOfCode/inputs/test.txt";
            
            if (File.Exists(inputFile))
            {
                //Day1 solution = new Day1(inputFile);
                Day2 solution = new Day2(inputFile);
                //Console.WriteLine($"Part 1 Solution: {solution.Part1Solver()}");
                Console.WriteLine($"Part 2 Solution: {solution.Part2Solver()}");
            }
        }
    }
}