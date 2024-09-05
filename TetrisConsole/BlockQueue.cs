using TetrisConsole.Blocks;

namespace TetrisConsole;

public sealed class BlockQueue
{
    private readonly Block[] _blocks = [
        new IBlock(),
        new JBlock(),
        new LBlock(),
        new OBlock(),
        new SBlock(),
        new TBlock(),
        new ZBlock()
    ];

    public Block NextBlock { get; private set; }

    public BlockQueue()
    {
        NextBlock = RandomBlock();
    }

    public Block RandomBlock()
    {
        return _blocks[Random.Shared.Next(_blocks.Length)];
    }

    public Block GetAndUpdateNextBlock()
    {
        var block = NextBlock;

        do
        {
            NextBlock = RandomBlock();
        }
        while (block.Id == NextBlock.Id);

        return block;
    }
}
