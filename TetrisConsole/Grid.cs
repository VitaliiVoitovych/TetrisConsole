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

    public bool IsRowFull(int row)
    {
        for (int column = 0; column < Columns; column++)
        {
            if (_grid[row, column] == 0)
            {
                return false;                
            }
        }
        return true;
    }

    public void ClearRow(int row)
    {
        for (int column = 0; column < Columns; column++)
        {
            _grid[row, column] = 0;
        }
    }

    public void MoveRowDown(int row, int numRows)
    {
        for (int column = 0; column < Columns; column++)
        {
            _grid[row + numRows, column] = _grid[row, column];
            _grid[row, column] = 0;
        }
    }

    public void ClearFullRows()
    {
        var cleared = 0;

        for (int row = Rows - 1; row >=0 ; row--)
        {
            if (IsRowFull(row))
            {
                ClearRow(row);
                cleared++;
            }
            else if (cleared > 0)
            {
                MoveRowDown(row, cleared);
            }
        }
    }
}
