public class Knight : BasePiece
{
    private bool _canWalkMultipleSteps = false;
    private List<(int, int)> _walks = new List<(int, int)>()
    {
     (1,2),(1,-2),(-1,2),(-1,-2),(2,1),(2,-1),(-2,1),(-2,-1),
    };

    public Knight(int maxLength) : base(maxLength){
    }
    
    public override List<(int, int)> Walks => _walks;
    public override bool CanWalkMultipleSteps => _canWalkMultipleSteps;
}