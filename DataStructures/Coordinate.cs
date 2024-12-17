using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.DataStructures
{
    public class Coordinate : IEquatable<Coordinate>
    {
        public int row {get; set;}
        public int col {get; set;}

        // Implement the Equals method for IEquatable<T>
        public bool Equals(Coordinate other)
        {
            return this.row == other.row && this.col == other.col;
        }

        // Override Object.Equals for compatibility
        public override bool Equals(object obj)
        {
            if (obj is Coordinate otherCoordinate)
            {
                return Equals(otherCoordinate); 
            }
            return false;
        }

        // Override Object.GetHashCode to ensure consistency with Equals
        public override int GetHashCode()
        {
            // Combine the hash codes of properties
            return HashCode.Combine(row, col);
        }
    }
}