using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day3
    {
        private string inputFile {get; set;}
        private int Solution {get; set;}
        private string pattern = @"mul\(\d+,\d+\)";
        private string stopPattern = "don't()";
        private string startPattern = "do()";
        private string flagPattern = @"do(n't)?\(\)";
        private bool calcEnabled {get; set;}

        public Day3(string inputFile)
        {
            this.inputFile = inputFile;
            this.Solution = 0;
            this.calcEnabled = true;
            //InputPart1Parser();
            InputPart2Parser();
        }
        
        public string Part1Solver()
        {
            return this.Solution.ToString();
        }

        public string Part2Solver()
        {   
            return this.Solution.ToString();
        }

        private List<string> ParseOnSegments(string line)
        {
            // takes a string and returns the "on" substrings based on do/don't found
            // bool tells you what to do about the start of the line
            List<string> onSegments = new List<string>();
            int currentIndex = 0;   // start of on if ON, otherwise update to the next do()

            MatchCollection matches = Regex.Matches(line, flagPattern);

            foreach (Match match in matches)
            {
                // do()
                if (string.Compare(match.Value, startPattern) == 0)
                {
                    // if this was off, turn on calcs and update the current index
                    if (!calcEnabled)
                    {
                        calcEnabled = true;
                        currentIndex = match.Index;
                    }
                }
                // don't()
                else if (string.Compare(match.Value, stopPattern) == 0)
                {
                    // end the current substring if already enabled
                    if (calcEnabled)
                    {
                        calcEnabled = false;
                        string subsegment = line.Substring(currentIndex, match.Index - currentIndex);
                        currentIndex = match.Index;     // update index to the don't location, but not needed...
                        Console.WriteLine($"added this ON segment: {subsegment}");
                        onSegments.Add(subsegment);
                    }
                }
            }
            // now handle the rest of the string, only add if do()
            if (calcEnabled)
            {
                string subsegment = line.Substring(currentIndex, line.Length - currentIndex);
                Console.WriteLine($"added this ON segment: {subsegment}");
                onSegments.Add(subsegment);
            }

            // // find indices of dos and donts
            // List<int> dos = new List<int>();
            // int index = line.IndexOf(startPattern);
            // while (index != -1)
            // {
            //     dos.Add(index);
            //     index = line.IndexOf(startPattern, index + 1); // Search from the next position
            // }
            // Console.WriteLine("do() indices: " + string.Join(", ", dos));

            return onSegments;
        }

        private List<string> ParseLineForPattern(string line, string pattern)
        {
            // returns list of strings that match the pattern
            List<string> chunks = new List<string>();
            MatchCollection matches = Regex.Matches(line, pattern);
            foreach (Match match in matches)
            {
                //Console.WriteLine($"{match}");
                chunks.Add(match.Value);
            }

            return chunks;
        }

        private int CalcChunks(List<string> chunks)
        {
            int total = 0;
            // for p1 we're just multiplying the chunks
            foreach (string chunk in chunks)
            {
                int subtotal = 1;
                MatchCollection nums = Regex.Matches(chunk, @"\d+");
                foreach (Match num in nums)
                {
                    if (int.TryParse(num.Value, out int result))
                    {
                        subtotal *= result;
                    }
                }
                total += subtotal;
            }

            return total;
        }

        public void InputPart1Parser()
        {
            // parse the input into whatever data structure makes sense
            using (StreamReader sr = new StreamReader(inputFile))
            {
                string pattern = @"mul\(\d+,\d+\)";
                string ? line;
                while ((line = sr.ReadLine()) != null)
                {
                    List<string> segments = ParseLineForPattern(line, pattern);
                    this.Solution += CalcChunks(segments);
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
                    // for each line pass the chunks that have multiply enabled
                    List<string> segmentsToCalc = ParseOnSegments(line);
                    foreach (string segment in segmentsToCalc)
                    {
                        List<string> chunks = ParseLineForPattern(segment, pattern);
                        this.Solution += CalcChunks(chunks);
                    }
                }
            }
        }
    }
}