namespace Kudriako.SudokuSolver
{
    public static class GridExtensions
    {
        public const int GridSize = 9;

        public static bool IsValid(this int[,] grid)
        {
            if (grid == null)
                return false;
            if (grid.Rank != 2)
                return false;
            if (grid.GetLength(0) != 9)
                return false;
            if (grid.GetLength(1) != 9)
                return false;
            return true;
        }

        public static bool IsNumberAllowed(this int[,] grid, int row, int column, int n)
        {
            for(int i = 0; i < 9; i++)
            {
                if (grid[i, column] == n)
                    return false;
            }
            for(int j = 0; j < 9; j++)
            {
                if (grid[row, j] == n)
                    return false;
            }
            for(int i = 0, r = 3 * (row / 3); i < 3; i++)
            {
                for(int j = 0, c = 3 * (column / 3); j < 3; j++)
                if (grid[r + i, c + j] == n)
                {
                    return false;
                }
            }
            return true;
        }
    }
}