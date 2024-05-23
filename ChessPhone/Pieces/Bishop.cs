public class Bishop : BasePiece
{
    private bool _canWalkMultipleSteps = true;
    private List<(int, int)> _walks = new List<(int, int)>()
    {
        (1,1), (-1,-1), (1,-1), (-1,1),
    };

    public Bishop(int maxLength) : base(maxLength){
    }      

    public override List<(int, int)> Walks => _walks;
    public override bool CanWalkMultipleSteps => _canWalkMultipleSteps;
}