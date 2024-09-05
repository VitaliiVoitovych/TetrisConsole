namespace TetrisConsole;

public sealed class Grid
{
    private readonly int[,] _grid;

    public int Rows { get; }
    public int Columns { get; }

    public int this[int row, int columns]
    {
        get => _grid[row, columns];
        set => _grid[row, columns] = value;
    }

    public Grid(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        _grid = new int[rows, columns];
    }

    public bool IsInside(int row, int column)
    {
        return row >= 0 && row < Rows && column >= 0 && column < Columns;
    }

    public bool IsEmpty(int row, int column)
    {
        return IsInside(row, column) && _grid[row, column] == 0;
    }
}
