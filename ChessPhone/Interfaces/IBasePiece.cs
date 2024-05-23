namespace ChessPhone.Interfaces
{
    public interface IBasePiece
    {
        char[,] KeyPad { get; }
        List<(int, int)>? Walks { get; }
        bool CanWalkMultipleSteps { get; }
        int MaxWalkLength { get; }
    }
}
