using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.DataStructures;
using AdventOfCode.HelperFunctions;

namespace AdventOfCode
{
    public class Day4
    {
        private string inputFile {get; set;}
        private int Solution {get; set;}
        private List<List<string>> puzzleGrid {get; set;}
        private int height {get; set;}
        private int width {get; set;}

        public Day4(string inputFile)
        {
            this.inputFile = inputFile;
            this.Solution = 0;
            this.puzzleGrid = new List<List<string>>();
            this.width = 0;
            this.height = 0;
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

            // in each line, search for first letter
            // then search the 8 directions for the second letter
            // any direction that matches sets the direction to continue searching
            for (int i = 0; i < puzzleGrid.Count; i++)
            {
                for (int j = 0; j < puzzleGrid[i].Count; j++)
                {
                    Coordinate curCoord = new Coordinate{row=i, col=j};
                    
                    if (target[0] == Convert.ToChar(puzzleGrid[i][j]))
                    {
                        // get valid next coordinates
                        HashSet<Coordinate> validDirs = TwoDimGrid.GetNewCoordinates(curCoord, this.height, this.width);

                        // get directions to look for the rest of the word
                        HashSet<Directions> searchThis = new HashSet<Directions>();
                        
                        // check which are equal to second letter
                        foreach (var step in validDirs)
                        {
                            if (target[1] == Convert.ToChar(puzzleGrid[step.row][step.col]))
                            {
                                searchThis.Add(TwoDimGrid.GetDirection(curCoord, step));
                            }
                        }
                        
                        foreach (Directions dir in searchThis)
                        {
                            bool wordFound = true;

                            // move cursor to second letter
                            curCoord.row = i + TwoDimGrid.DirToCoord[dir].row;
                            curCoord.col = j + TwoDimGrid.DirToCoord[dir].col;
                            for (int k=2; k<target.Length; k++)
                            {
                                Coordinate nextCoord = new Coordinate();
                                nextCoord.row = curCoord.row + TwoDimGrid.DirToCoord[dir].row;
                                nextCoord.col = curCoord.col + TwoDimGrid.DirToCoord[dir].col;
                                if (target[k] != Convert.ToChar(puzzleGrid[nextCoord.row][nextCoord.col]))
                                {
                                    wordFound = false;
                                    break;
                                }
                                else
                                {
                                    curCoord = nextCoord;
                                }
                            }

                            if (wordFound)
                                wordsFound++;
                        }
                    }
                }
            }

            return wordsFound;
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
                    this.puzzleGrid.Add(lineLetters);  
                    this.height += 1; 
                }

                this.width = this.puzzleGrid[0].Count; 

                this.Solution = WordSearch(targetWord);
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