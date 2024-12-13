using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day2
    {
        private string inputFile {get; set;}
        private int NumLines {get; set;}
        private int Solution {get; set;}

        public Day2(string inputFile)
        {
            this.inputFile = inputFile;
            this.NumLines = 0;
            this.Solution = 0;
            //InputPart1Parser();
            InputPart2Parser();
        }
        
        public string Part1Solver()
        {
            // solved during IO, so this only returns the string
            return this.Solution.ToString();
        }

        public string Part2Solver()
        {   
            return this.Solution.ToString();
        }

        private bool IsReportValid(List<int> nums)
        {
            // return 1 if valid (all increasing/decreasing and 1-2 apart)
            bool validLine = true;
            // first check if it's increasing or decreasing
            bool increasing = false;
            if (nums[1] > nums[0])
                increasing = true;

            for (int i = 0; i < nums.Count-1; i++)
            {
                int delta = Math.Abs(nums[i+1] - nums[i]);
                // increasing but the next num is equal or smaller
                if (increasing && nums[i+1] <= nums[i])
                {
                    validLine = false;
                    break;
                }
                // decreasing but the next item is bigger or equal
                else if (!increasing && nums[i+1] >= nums[i])
                {
                    validLine = false;
                    break;
                }
                // check the next num is 1-2 difference
                else if (delta == 0 || delta > 3)
                {
                    validLine = false;
                    break;
                }
            }
            return validLine;
        }

        private bool IsReportValidWithDampener(List<int> nums)
        {
            // checks if line is valid, and if not does the same for slices
            bool validLine  = false;
            if (!IsReportValid(nums))
            {
                // check list slices until one is valid
                for (int i = 0; i < nums.Count; i++)
                {
                    List<int> numSubset = nums.ToList();
                    numSubset.RemoveAt(i);
                    //Console.WriteLine("line not valid, checking this subline: " + string.Join(", ", numSubset));
                    if (IsReportValid(numSubset))
                    {
                        validLine = true;
                        break;
                    }
                }
            }
            else
            {
                validLine = true;
            }
            return validLine;
        }

        public void InputPart1Parser()
        {
            // parse the input into whatever data structure makes sense
            using (StreamReader sr = new StreamReader(inputFile))
            {
                string ? line;
                while ((line = sr.ReadLine()) != null)
                {
                    this.NumLines++;
                    string[] input = line.Split(' ',  StringSplitOptions.RemoveEmptyEntries);
                    List<int> nums = new List<int>();
                    foreach (string num in input)
                    {
                        if (int.TryParse(num, out int n))
                            nums.Add(n);
                    }
                    //Console.WriteLine($"Line {this.NumLines}: {IsReportValid(nums)}");
                    if (IsReportValid(nums))
                        this.Solution++;
                }
            }
        }

        public void InputPart2Parser()
        {
            // parse the input into whatever data structure makes sense
            using (StreamReader sr = new StreamReader(inputFile))
            {
                string ? line;
                while ((line = sr.ReadLine()) != null)
                {
                    this.NumLines++;
                    string[] input = line.Split(' ',  StringSplitOptions.RemoveEmptyEntries);
                    List<int> nums = new List<int>();
                    foreach (string num in input)
                    {
                        if (int.TryParse(num, out int n))
                            nums.Add(n);
                    }
                    
                    if (IsReportValidWithDampener(nums))
                        this.Solution++;
                }
            }
        }
    }
}