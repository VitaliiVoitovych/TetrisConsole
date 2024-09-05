namespace TetrisConsole.Blocks;

public sealed class TBlock : Block
{
    private readonly Position[][] _tiles = [
        [new(0,2), new(0,3), new(1,0), new(1,1), new(1,2), new(1,3), new(1,4), new(1,5)],
        [new(0,2), new(0,3), new(1,2), new(1,3), new(1,4), new(1,5), new(2,2), new(2,3)],
        [new(1,0), new(1,1), new(1,2), new(1,3), new(1,4), new(1,5), new(2,2), new(2,3)],
        [new(0,2), new(0,3), new(1,0), new(1,1), new(1,2), new(1,3), new(2,2), new(2,3)]
    ];

    public override int Id => 6;

    protected override Position[][] Tiles => _tiles;

    protected override Position StartOffset => new(0,6);
}
