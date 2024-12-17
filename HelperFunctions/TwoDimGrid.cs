using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.DataStructures;

namespace AdventOfCode.HelperFunctions
{
    /// <summary>
    /// Helper functions for dealing with 2D grids, will expand as functionality needed
    /// </summary>
    public static class TwoDimGrid
    {
        public static Dictionary<Directions, Coordinate> DirToCoord = new Dictionary<Directions, Coordinate>
        {
            {Directions.North, new Coordinate {row = -1, col = 0}},
            {Directions.South, new Coordinate {row = 1, col = 0}},
            {Directions.East, new Coordinate {row = 0, col = 1}},
            {Directions.West, new Coordinate {row = 0, col = -1}},
            {Directions.NorthEast, new Coordinate {row = -1, col = 1}},
            {Directions.SouthEast, new Coordinate {row = 1, col = 1}},
            {Directions.NorthWest, new Coordinate {row = -1, col = -1}},
            {Directions.SouthWest, new Coordinate {row = 1, col = -1}},
            {Directions.Stay, new Coordinate {row = 0, col = 0}}
        };


        public static Coordinate NewCoordinates(Coordinate curCoord, Coordinate step)
        {
            // returns the new coordinates
            Coordinate newCoord = new Coordinate()
            {
                row = curCoord.row + step.row,
                col = curCoord.col + step.col
            }; 
            return newCoord;
        }

        public static bool IsCoordinateValid(Coordinate coord, int height, int width)
        {
            // checks if this is a valid position within the grid
            return coord.row >= 0 && coord.row < height && coord.col >= 0 && coord.col < width;
        }

        public static HashSet<Directions> GetDirectionsToLook(Coordinate coord, int height, int width)
        {
            // returns valid directions (in-bounds) from the current coordinate
            HashSet<Directions> validDirs = new HashSet<Directions>();

            foreach (Directions dir in DirToCoord.Keys)
            {
                Coordinate tempCoord = new Coordinate();
                tempCoord.row = coord.row + DirToCoord[dir].row;
                tempCoord.col = coord.col +  DirToCoord[dir].col;
                if (IsCoordinateValid(tempCoord, height, width))
                {
                    validDirs.Add(dir);
                }
            }

            return validDirs;
        }

        public static HashSet<Coordinate> GetNewCoordinatesFromDirs(Coordinate curCoord, HashSet<Directions> validDirs)
        {
            // returns new valid coordinates based on valid directions
            HashSet<Coordinate> validCoords = new HashSet<Coordinate>();
            foreach (Directions dir in validDirs)
            {
                Coordinate tempCoord = new Coordinate();
                tempCoord.row = curCoord.row + DirToCoord[dir].row;
                tempCoord.col = curCoord.col + DirToCoord[dir].col;
                validCoords.Add(tempCoord);
            }

            return validCoords;
        }

        public static HashSet<Coordinate> GetNewCoordinates(Coordinate curCoord, int height, int width)
        {
            HashSet<Directions> validDirs = GetDirectionsToLook(curCoord, height, width);
            return GetNewCoordinatesFromDirs(curCoord, validDirs);
        }

        public static Directions GetDirection(Coordinate curCoord, Coordinate newCoord)
        {
            // get the direction one moves from current to new coordinate
            Coordinate moveCoord = new Coordinate();
            moveCoord.row = newCoord.row - curCoord.row;
            moveCoord.col = newCoord.col - curCoord.col;
            foreach (var dir in DirToCoord)
            {
                if (dir.Value == moveCoord)
                {
                    return dir.Key;
                }
            }

            return Directions.Stay;     //default
        }
    }

}