using ChessPhone.Enums;
using ChessPhone.Interfaces;

namespace ChessPhone.Business
{
    /* ChessStrategy class houses and executes the main business logic
     * Walk = movement of a piece from one coordinate(x1,y1) to another possible coordinate(x2,y2)
     */
    public class ChessStrategy : IChessStrategy
    {
        private char[,] _keypad;
        private List<(int,int)> _walks;
        private BasePiece _basePieceStrategy;
        private List<(int, int)> _possibleWalks = new List<(int, int)>();

        public ChessStrategy(PieceType pieceType, int phNumberLength)
        {
            switch (pieceType)
            {
                case PieceType.Pawn:
                    _basePieceStrategy = new Pawn(phNumberLength);
                    break;
                case PieceType.Bishop:
                    _basePieceStrategy = new Bishop(phNumberLength);
                    break;
                case PieceType.Knight:
                    _basePieceStrategy = new Knight(phNumberLength);
                    break;
                case PieceType.Rook:
                    _basePieceStrategy = new Rook(phNumberLength);
                    break;
                case PieceType.Queen:
                    _basePieceStrategy = new Queen(phNumberLength);
                    break;
                case PieceType.King:
                    _basePieceStrategy = new King(phNumberLength);
                    break;
            }

            if (_basePieceStrategy == null)
                throw new ArgumentException($"Failed to initialize: {pieceType}.");

            _keypad = _basePieceStrategy.KeyPad;

            if (_keypad == null || _keypad.GetLength(0) <= 0 || _keypad.GetLength(1) <= 0)
                throw new ArgumentException("Invalid keypad.");

            _walks = _basePieceStrategy.Walks;

            if (_walks == null || _walks.Count == 0)
                throw new ArgumentException("Walks are undefined.");
        }

        public long GetWalkCount()
        {
            long phoneNumbersCount = 0;
            var walks = GetAllWalks();
            for (int pointX = 0; pointX < _keypad.GetLength(0); pointX++)
            {
                for (int pointY = 0; pointY < _keypad.GetLength(1); pointY++)
                {
                    GeneratePhoneNumbers(pointX, pointY, string.Empty, walks, ref phoneNumbersCount);
                }
            }
            return phoneNumbersCount;
        }

        private Dictionary<(int, int), List<(int, int)>> GetAllWalks()
        {
            Dictionary<(int, int), List<(int, int)>> dict = new();
            for (var i = 0; i < _keypad.GetLength(0); i++)
            {
                for (var j = 0; j < _keypad.GetLength(1); j++)
                {
                    dict[(i, j)] = GetNextCoordinates(i, j);
                }
            }
            return dict;
        }

        //Get all possible walks from a given coordinate
        private List<(int, int)> GetNextCoordinates(int pointX, int pointY)
        {
            if (!Validators.Validators.IsValidCoordinates(pointX, pointY, _keypad.GetLength(0), _keypad.GetLength(1)))
            {
                throw new ArgumentException($"Invalid coordinates. X:{pointX} Y:{pointY}");
            }

            if (_possibleWalks.Count == 0)
            {
                var maxWalkLength = _basePieceStrategy.CanWalkMultipleSteps ? Math.Max(_keypad.GetLength(0), _keypad.GetLength(1)) - 1 : 1;
                if (!Validators.Validators.IsValidWalk(_walks, maxWalkLength))
                {
                    throw new AggregateException("Invalid walk.");
                }

                var itemList = new List<int>();
                for (int i = 1; i <= maxWalkLength; i++)
                {
                    itemList.Add(i);
                }

                foreach (var p in itemList)
                {
                    foreach (var q in _walks)
                    {
                        _possibleWalks.Add((q.Item1 * p, q.Item2 * p));
                    }
                }
            }
            return _possibleWalks.Where(m => Validators.Validators.IsValidCoordinates(pointX + m.Item1, pointY + m.Item2, _keypad.GetLength(0), _keypad.GetLength(1)))
                                                                  .Select(m => (pointX + m.Item1, pointY + m.Item2)).ToList();
        }

        /* This method generates the phone numbers by making recursion calls and keeps track of the count.
           Does the necessary validation as required.
        */
        private void GeneratePhoneNumbers(int i, int j, string digit, Dictionary<(int, int), List<(int, int)>> dict, ref long countCombinations)
        {
            var generatedNumber = digit + _keypad[i, j];
            var futureCoordinate = dict[(i, j)];

            //Console.Write($"output: {generatedNumber} ");
            if (!IsValidNumberGenerated(generatedNumber))
            {
                return;
            }

            if (IsMaxLength(generatedNumber))
            {
                countCombinations++;
                return;
            }

            if (NoMoreWalks(futureCoordinate))
            {
                return;
            }

            ExploreFutureCoordinates(futureCoordinate, generatedNumber, dict, ref countCombinations);
        }

        private bool IsValidNumberGenerated(string generatedNumber)
        {
            return Validators.Validators.IsValidNumber(generatedNumber);
        }

        private bool IsMaxLength(string generatedNumber)
        {
            return generatedNumber.Length == _basePieceStrategy.MaxWalkLength;
        }

        private bool NoMoreWalks(List<(int, int)> futureCoordinate)
        {
            return futureCoordinate == null || futureCoordinate.Count == 0;
        }

        private void ExploreFutureCoordinates(List<(int, int)> futureCoordinate, string generatedNumber, Dictionary<(int, int), List<(int, int)>> dict, ref long countCombinations)
        {
            foreach (var position in futureCoordinate)
            {
                GeneratePhoneNumbers(position.Item1, position.Item2, generatedNumber, dict, ref countCombinations);
            }
        }
    }
}
