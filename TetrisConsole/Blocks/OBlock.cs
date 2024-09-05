namespace TetrisConsole.Blocks;

public sealed class OBlock : Block
{
    private readonly Position[][] _tiles = [
        [new(0,0), new(0,1), new(0,2), new(0,3), new(1,0), new(1,1), new(1,2), new(1,3)]    
    ];

    public override int Id => 4;

    protected override Position[][] Tiles => _tiles;

    protected override Position StartOffset => new(0,8);
}
