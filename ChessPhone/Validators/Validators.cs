using System.Text.RegularExpressions;

namespace ChessPhone.Validators
{
    public class Validators
    {
        //Todo: Digits that cannot be start digit, can be accepted as user input 
        private static HashSet<char> _cannotStartWithChars = new HashSet<char>() { '0', '1' };
        private static readonly Regex  _regex = new Regex("^\\d+$");

        public static bool IsValidCoordinates(int pointX, int pointY, int row, int column)
        {
            return pointX >= 0 && pointX < row && pointY >= 0 && pointY < column;
        }

        public static bool IsValidNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            if (_cannotStartWithChars.Contains(value.ToCharArray()[0]))
                return false;
            if (!_regex.IsMatch(value))
                return false;
            return true;
        }

        public static bool IsValidWalk(List<(int, int)> walks, int size)
        {
            if (size <= 0)
                return false;

            if (walks == null || walks.Count < 1)
                return false;

            return true;
        }
    }
}
