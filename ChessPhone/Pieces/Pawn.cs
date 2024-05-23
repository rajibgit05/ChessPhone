public class Pawn : BasePiece   
{
    private bool _canWalkMultipleSteps = false;
    private List<(int, int)> _walks = new List<(int, int)>()
    {
        (1,0)
    };

    public Pawn(int maxLength) : base( maxLength){
    }

    public override List<(int, int)> Walks => _walks;
    public override bool CanWalkMultipleSteps => _canWalkMultipleSteps;
}