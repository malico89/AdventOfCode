using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Template
    {
        private string inputFile {get; set;}
        private int NumLines {get; set;}
        private int Solution {get; set;}

        public Template(string inputFile)
        {
            this.inputFile = inputFile;
            this.NumLines = 0;
            this.Solution = 0;
            InputPart1Parser();
            //InputPart2Parser();
        }
        
        public string Part1Solver()
        {
            return this.Solution.ToString();
        }

        public string Part2Solver()
        {   
            return this.Solution.ToString();
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
                }
            }
        }
    }
}