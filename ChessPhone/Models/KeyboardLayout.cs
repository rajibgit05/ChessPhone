using ChessPhone.Interfaces;

namespace ChessPhone.Models
{

    //Todo: Can accept the keypad format as user input
    public class KeyPadFormat : IKeyPadFormat
    {
        public KeyPadFormat()
        {
            KeyPad = new char[,]
                 {
                    { '1', '2', '3' },
                    { '4', '5', '6' },
                    { '7', '8', '9' },
                    { '*', '0', '#' }
                 };
        }

        public KeyPadFormat(char[,] keypad)
        {
            if (keypad != null && keypad.Length > 0)
                KeyPad = keypad;
        }

        public char[,]? KeyPad { get; }
    }
}
