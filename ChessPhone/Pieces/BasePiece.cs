using ChessPhone.Interfaces;
using ChessPhone.Models;
public class BasePiece: IBasePiece
{
    private int _maxLength;
    private char[,] _keypad;

    public char[,] KeyPad => _keypad;
    public virtual List<(int, int)>? Walks { get; }
    public virtual bool CanWalkMultipleSteps { get; }
    public virtual int MaxWalkLength => _maxLength;

    public BasePiece(int length)
    {
        _maxLength = length;
        _keypad = new KeyPadFormat().KeyPad;


        if (_keypad == null || _keypad.Length == 0 || _keypad.GetLength(1) == 0)
        {
            throw new ArgumentNullException(nameof(_keypad), "Invalid keypad layout");
        }

        if (Walks == null || Walks.Count == 0)
        {
            throw new ArgumentNullException(nameof(Walks), "Walks are not defined.");
        }
    }
}