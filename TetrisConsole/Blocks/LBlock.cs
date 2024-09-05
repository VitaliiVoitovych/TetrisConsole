namespace TetrisConsole.Blocks;

//     ██
// ██████
public sealed class LBlock : Block
{
    private readonly Position[][] _tiles = [
        [new(0,4), new(0,5), new(1,0), new(1,1), new(1,2), new(1,3), new(1,4), new(1,5)],
        [new(0,2), new(0,3), new(1,2), new(1,3), new(2,2), new(2,3), new(2,4), new(2,5)],
        [new(1,0), new(1,1), new(1,2), new(1,3), new(1,4), new(1,5), new(2,0), new(2,1)],
        [new(0,0), new(0,1), new(0,2), new(0,3), new(1,2), new(1,3), new(2,2), new(2,3)]
    ];

    public override int Id => 3;

    protected override Position[][] Tiles => _tiles;

    protected override Position StartOffset => new(0,6);
}
