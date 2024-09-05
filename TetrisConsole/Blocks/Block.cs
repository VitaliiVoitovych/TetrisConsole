namespace TetrisConsole.Blocks;

public abstract class Block
{
    private int _rotateState = 0;
    private readonly Position _offset;

    public abstract int Id { get; }
    protected abstract Position[][] Tiles { get; }
    protected abstract Position StartOffset { get; }
    public int RotateState { get => _rotateState; set => _rotateState = value; }

    protected Block()
    {
        _offset = new Position(StartOffset.Row, StartOffset.Column);
    }

    public void Rotate()
    {
        _rotateState = (_rotateState + 1) % Tiles.Length;
    }

    public void Move(int row, int column)
    {
        _offset.Row += row;
        _offset.Column += column;
    }

    public void Reset()
    {
        _rotateState = 0;
        _offset.Row = StartOffset.Row;
        _offset.Column = StartOffset.Column;
    }

    public IEnumerable<Position> TilesPositions()
    {
        foreach (var tile in Tiles[_rotateState])
        {
            yield return new Position(tile.Row + _offset.Row, tile.Column + _offset.Column);
        }
    }
}
