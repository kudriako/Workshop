using System;

namespace Kudriako.SudokuSolver
{
    public class GridWriter
    {
        public void WriteGrid(int[,] grid)
        {
            if(grid.Rank != 2)
                throw new ArgumentException("Invalid rank of grid. Should be 2.", nameof(grid));
            if(grid.GetLength(0) != 9)
                throw new ArgumentException("Invalid height of grid. Should be 9.", nameof(grid));
            if(grid.GetLength(1) != 9)
                throw new ArgumentException("Invalid width of grid. Should be 9.", nameof(grid));
            for(int row = 0; row < 9; row++)
            {
                for(int col = 0; col < 9; col++)
                {
                    Console.Write(grid[row,col]);
                    if (col % 3 == 2)
                        Console.Write(' ');
                }
                if (row % 3 == 2)
                    Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}