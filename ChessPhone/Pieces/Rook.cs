public class Rook : BasePiece
{
    private bool _canWalkMultipleSteps = true;
    private List<(int, int)> _walks = new List<(int, int)>()
    {
        (1,0),(0,1),(-1,0),(0,-1)
    };

    public Rook(int maxLength) : base(maxLength) { 
    }
    
    public override List<(int, int)> Walks => _walks;
    public override bool CanWalkMultipleSteps => _canWalkMultipleSteps;
}