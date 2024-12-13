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
        private bool calcEnabled = true;

        public Day3(string inputFile)
        {
            this.inputFile = inputFile;
            this.Solution = 0;
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

        private List<string> ParseOnSegments(string line, bool isEnabled)
        {
            // takes a string and returns the "on" substrings based on do/don't found
            // bool tells you what to do about the start of the line
            List<string> onSegments = new List<string>();
            int currentIndex = 0;   // start of on if ON, otherwise update to the next do()

            // find indices of dos and donts
            List<int> dos = new List<int>();
            int index = line.IndexOf(startPattern);
            while (index != -1)
            {
                dos.Add(index);
                index = line.IndexOf(startPattern, index + 1); // Search from the next position
            }
            Console.WriteLine("do() indices: " + string.Join(", ", dos));

            List<int> donts = new List<int>();
            index = line.IndexOf(stopPattern);
            while (index != -1)
            {
                donts.Add(index);
                index = line.IndexOf(stopPattern, index + 1); // Search from the next position
            }
            Console.WriteLine("don't() indices: " + string.Join(", ", donts));

            // TODO: parse the string into multipliable chunks
            /* the stuff above is a start, it gives all indices but then you have to sort and figure them out
            one way: until you get to the end of the string, like above, if it's on, find the next dont to know where to stop and turn it off
            if it's off, look for next do to know where to start again and turn it on
            remember the indices to know how to chunk it
            */

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
                    List<string> segmentsToCalc = ParseOnSegments(line, calcEnabled);
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