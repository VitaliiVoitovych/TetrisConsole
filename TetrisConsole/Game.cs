using TetrisConsole.Blocks;

namespace TetrisConsole;

public sealed class Game
{
    private Block _currentBlock = null!;

    public Block CurrentBlock
    {
        get => _currentBlock;
        set
        {
            _currentBlock = value;
            _currentBlock.Reset();
        }
    }

    private readonly Dictionary<int, ConsoleColor> _tilesColor = new Dictionary<int, ConsoleColor>
    {
        {1, ConsoleColor.Cyan },
        {2, ConsoleColor.DarkBlue },
        {3, ConsoleColor.DarkYellow },
        {4, ConsoleColor.Yellow },
        {5, ConsoleColor.DarkGreen },
        {6, ConsoleColor.DarkMagenta },
        {7, ConsoleColor.DarkRed },
    };

    public Grid Grid { get; }
    public BlockQueue BlockQueue { get; }
    public bool GameOver { get; private set; } = false;

    public Game()
    {
        Grid = new Grid(23, 20);
        BlockQueue = new BlockQueue();
        CurrentBlock = BlockQueue.GetAndUpdateNextBlock();
    }

    public void Start()
    {
        while (!GameOver)
        {
            Draw();
            Update();
            Thread.Sleep(100);
        }

        Console.SetCursorPosition(25, 5);
        Console.WriteLine("Game Over");
        Console.ReadLine();
    }

    private void Draw()
    {
        Console.Clear();
        DrawBlock();
        DrawGrid();
    }

    private void Update()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.LeftArrow)
            {
                MoveBlockLeft();
            }
            else if (key == ConsoleKey.RightArrow)
            {
                MoveBlockRight();
            }
            else if (key == ConsoleKey.UpArrow)
            {
                RotateBlock();
            }
        }
        MoveBlockDown();
    }

    private void DrawBlock()
    {
        foreach (var tile in CurrentBlock.TilesPositions())
        {
            Console.SetCursorPosition(tile.Column, tile.Row);
            Console.ForegroundColor = _tilesColor[CurrentBlock.Id];
            Console.Write("█");
        }
    }

    private void DrawGrid()
    {
        for (int i = 0; i < Grid.Columns + 1; i++)
        {
            Console.SetCursorPosition(i, Grid.Rows);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("█");
        }

        for (int i = 0; i < Grid.Rows + 1; i++)
        {
            Console.SetCursorPosition(Grid.Columns, i);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("██");
        }

        for (int row = 0; row < Grid.Rows; row++)
        {
            for (int column = 0; column < Grid.Columns; column++)
            {
                if (Grid[row, column] > 0)
                {
                    Console.SetCursorPosition(column, row);
                    Console.ForegroundColor = _tilesColor[Grid[row, column]];
                    Console.Write("█");
                }
            }
        }
    }

    private bool IsGameOver()
    {
        return !(Grid.IsRowEmpty(0) && Grid.IsRowEmpty(1));
    }

    private bool BlockFits()
    {
        foreach (var tile in CurrentBlock.TilesPositions())
        {
            if (!Grid.IsEmpty(tile.Row, tile.Column))
            {
                return false;
            }
        }

        return true;
    }

    private void MoveBlockLeft()
    {
        CurrentBlock.Move(0, -2);

        if (!BlockFits()) CurrentBlock.Move(0, 2);
    }

    private void MoveBlockRight()
    {
        CurrentBlock.Move(0, 2);

        if (!BlockFits()) CurrentBlock.Move(0, -2);
    }

    private void MoveBlockDown()
    {
        CurrentBlock.Move(1, 0);

        if (!BlockFits())
        {
            CurrentBlock.Move(-1, 0);
            PlaceBlock();
        }
    }

    private void PlaceBlock()
    {
        foreach (var tile in CurrentBlock.TilesPositions())
        {
            Grid[tile.Row, tile.Column] = CurrentBlock.Id;
        }

        Grid.ClearFullRows();

        if (IsGameOver())
        {
            GameOver = true;
        }
        else
        {
            CurrentBlock = BlockQueue.GetAndUpdateNextBlock();
        }
    }

    private void RotateBlock()
    {
        var currentState = CurrentBlock.RotateState;
        CurrentBlock.Rotate();

        if (!BlockFits())
        {
            CurrentBlock.RotateState = currentState;
        }
    }
}
