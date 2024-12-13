using System;
using System.IO;

namespace AdventOfCode
{
    class Program
    {
        static void Main()
        {
            // uncomment to run real input
            //string inputFile = "/Users/mariacardona/Documents/repos/AdventOfCode/inputs/3.txt";
            // uncomment to run test case
            string inputFile = "/Users/mariacardona/Documents/repos/AdventOfCode/inputs/test.txt";
            
            if (File.Exists(inputFile))
            {
                // uncomment the day you want to solve
                //Day1 solution = new Day1(inputFile);
                //Day2 solution = new Day2(inputFile);
                Day3 solution = new Day3(inputFile);

                // uncomment for whatever part you want to solve
                //Console.WriteLine($"Part 1 Solution: {solution.Part1Solver()}");
                Console.WriteLine($"Part 2 Solution: {solution.Part2Solver()}");
            }
        }
    }
}