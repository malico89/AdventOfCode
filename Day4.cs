using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enums;

namespace AdventOfCode
{
    public class Day4
    {
        private string inputFile {get; set;}
        private int Solution {get; set;}
        private List<List<string>> puzzleGrid {get; set;}
        private Dictionary<Directions, (int, int)> DirToCoord = 
        {
            Directions.North = (-1, 0),
            Directions.South = (1, 0),
            Directions.East = (0, 1),
            Directions.West = (0, -1),
            Directions.NorthEast = (-1,1),
            Directions.SouthEast = (1,1),
            Directions.NorthWest = (-1,-1),
            Directions.SouthWest = (1,-1)
        };

        public Day4(string inputFile)
        {
            this.inputFile = inputFile;
            this.Solution = 0;
            this.puzzleGrid = new List<List<string>>();
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

        private int WordSearch(string target)
        {
            // returns the number of times target is in the puzzleGrid in any direction
            int wordsFound = 0;

            // TODO: in each line, search for first letter
            // then search the 8 directions for the second letter
            // any direction that matches sets the firection to continue searching
            foreach (List<string> row in puzzleGrid)
            {
                foreach (string col in row)
                {
                    if (string.Compare(target[0], col == 0))
                    {
                        HashSet<Directions> validDirections = GetDirectionsToLook(string target[1], row, col)
                        // TODO: hashset above has the valid directions where the second letter was found
                        // TODO: for each direction valid, check if the next 3 locations are MAS, otherwise continue (also continue of out of bounds)
                    }
                }
            }

            return wordsFound;
        }

        private HashSet<Directions> GetDirectionsToLook(string letter, int row, int col)
        {
            // TODO: returns where the second letter was found. this sets where to look for the rest of the word
            
        }

        private (int, int) NewCoordinates(int curRow, int curCol, int rowStep, int colStep)
        {
            // returns the new coordinates 
            return curRow + rowStep, curCol + colStep;
        }

        private bool IsCoordinateValid(int row, int col)
        {
            // checks if this is a valid position within the grid
            return row >= 0 && row < puzzleGrid.Count && col >= 0 && col < puzzleGrid[0].Count;
        }

        public void InputPart1Parser()
        {
            // parse the input into whatever data structure makes sense
            using (StreamReader sr = new StreamReader(inputFile))
            {
                string ? line;
                string targetWord = "XMAS";
                while ((line = sr.ReadLine()) != null)
                {
                    List<string> lineLetters = new List<string>{line};
                    puzzleGrid.Add(lineLetters);

                    this.Solution = WordSearch(targetWord);
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
                    List<string> lineLetters = new List<string>{line};
                    puzzleGrid.Add(lineLetters);
                }
            }
        }
    }
}