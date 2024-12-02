using System;

namespace AdventOfCode2024
{
    class Day1
    {
        private string inputFile {get; set;}
        // raw contents
        private List<int> LeftList {get; set;}
        private List<int> RightList {get; set;}
        // key=content, value=number of appearances
        private Dictionary<int, int> LeftColumn {get; set;}
        private Dictionary<int, int> RightColumn {get; set;}

        private int NumLines {get; set;}
        private int Solution {get; set;}

        public Day1(string inputFile)
        {
            this.LeftList = new List<int>();
            this.RightList = new List<int>();
            this.LeftColumn = new Dictionary<int, int>();
            this.RightColumn = new Dictionary<int,int>();
            this.inputFile = inputFile;
            this.NumLines = 0;
            this.Solution = 0;
            //InputPart1Parser();
            InputPart2Parser();
        }
        
        public string Part1Solver()
        {
            // sort the lists
            this.LeftList.Sort();
            this.RightList.Sort();
            
            for(int i = 0; i < this.NumLines; i++)
            {
                int rowDelta = LeftList[i] - RightList[i];
                this.Solution += Math.Abs(rowDelta);
                //Console.WriteLine($"row delta = {Math.Abs(rowDelta)}");
            }
            return this.Solution.ToString();
        }

        public string Part2Solver()
        {
            foreach(int leftNum in this.LeftColumn.Keys)
            {
                if (RightColumn.ContainsKey(leftNum))
                {
                    this.Solution += this.LeftColumn[leftNum] * leftNum * this.RightColumn[leftNum];
                }
            }
            
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
                    string[] nums = line.Split(' ',  StringSplitOptions.RemoveEmptyEntries);
                    //foreach (string num in nums)
                        //Console.WriteLine(num);

                    LeftList.Add(Convert.ToInt32(nums[0]));
                    RightList.Add(Convert.ToInt32(nums[1]));
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
                    string[] nums = line.Split(' ',  StringSplitOptions.RemoveEmptyEntries);
                    //foreach (string num in nums)
                        //Console.WriteLine(num);

                    int leftNum = Convert.ToInt32(nums[0]);
                    int rightNum = Convert.ToInt32(nums[1]); 
                    
                    if (!LeftColumn.ContainsKey(leftNum))
                    {
                        LeftColumn.Add(leftNum, 0);
                    }

                    if (!RightColumn.ContainsKey(rightNum))
                    {
                        RightColumn.Add(rightNum, 0);
                    }

                    LeftColumn[leftNum]++;
                    RightColumn[rightNum]++;
                }
            }
        }
    }
}

