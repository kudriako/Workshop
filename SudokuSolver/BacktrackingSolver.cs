using System.Linq;
using System.Collections.Generic;

namespace Kudriako.SudokuSolver
{
    public class BacktrackingSolver
    {

        public bool Solve(int[,] grid)
        {
            var positions = GetPositions(grid).ToArray();
            return Check(grid, positions, 0);
        }

        private bool Check(int[,] grid, Position[] positions, int index)
        {
            if (index >= positions.Length)
                return true;
            int row = positions[index].Row;
            int col = positions[index].Column;
            for(int n = 1; n <= 9; n++)
            {
                if(grid.IsNumberAllowed(row, col, n))
                {
                    grid[row, col] = n;
                    if (Check(grid, positions, index + 1))
                        return true;
                }
            }
            grid[row, col] = 0;
            return false;
        }

        protected virtual IEnumerable<Position> GetPositions(int[,] grid)
        {
            for(int i = 0; i < GridExtensions.GridSize; i++)
            {
                for(int j = 0; j < GridExtensions.GridSize; j++)
                {
                    if (grid[i, j] == 0)
                        yield return new Position(i, j);
                }
            }
        }

        public struct Position 
        {
            public Position(int row, int column)
            {
                Row = row;
                Column = column;
            }

            public readonly int Row;
            public readonly int Column;
        }

    }
}