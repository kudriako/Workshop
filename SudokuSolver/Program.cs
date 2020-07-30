using System;

namespace Kudriako.SudokuSolver
{
    class Program
    {
        static int Main(string[] args)
        {
            var sample = new int[9,9] {
                {3, 0, 6, 5, 0, 8, 4, 0, 0},
                {5, 2, 0, 0, 0, 0, 0, 0, 0},
                {0, 8, 7, 0, 0, 0, 0, 3, 1},
                {0, 0, 3, 0, 1, 0, 0, 8, 0},
                {9, 0, 0, 8, 6, 3, 0, 0, 5},
                {0, 5, 0, 0, 9, 0, 6, 0, 0},
                {1, 3, 0, 0, 0, 0, 2, 5, 0},
                {0, 0, 0, 0, 0, 0, 0, 7, 4},
                {0, 0, 5, 2, 0, 6, 3, 0, 0}
            };

            if (sample.IsValid())
            {
                Console.WriteLine("Grid is valid.");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Grid is invalid.");
                return -1;
            }

            Console.WriteLine("Input");
            Console.WriteLine();
            WriteGrid(sample);

            var solver = new BacktrackingSolver();
            if (solver.Solve(sample))
            {
                Console.WriteLine("Solved.");
                Console.WriteLine();
                WriteGrid(sample);
            }
            else
            {
                Console.WriteLine("Cannot be solved.");
            }
            

            return 0;
        }

        public static void WriteGrid(int[,] grid)
        {
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
