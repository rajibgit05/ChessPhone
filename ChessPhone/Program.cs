using ChessPhone.Business;
using ChessPhone.Enums;
using System.Diagnostics;

class Program
{
    /* 
     * This program takes the following input.
     *    1. Length of digits between 0 and 10.
     *    2. Choice of chess pieces between 1 and 6.
     * Then it calculates and displays the count of combinations and the duration it took to evaluate in ms.  
     * 
     * The input and output goes in a while loop till user wish to exit by pressing any key other than y or Y 
     * This program is tested for up to 10 digit phone numbers.
     */
    static void Main()
    {
        Console.WriteLine("Please enter desired length (1-10) of digits.");
        var input = Console.ReadLine();

        int phNumberLength;
        if (!int.TryParse(input, out phNumberLength) || phNumberLength<0 || phNumberLength>10)
        {
            Console.WriteLine("Phone number length is not valid.\n");
            return;
        }

        var shouldContinue = true;

        // Condition to exit: When user types anything apart from 'y' or 'Y'.
        while (shouldContinue)
        {
            Console.WriteLine($"Please choose between (1-6) for the following piece types:");
            foreach (var piece in Enum.GetValues(typeof(PieceType)))
            {
                Console.WriteLine($"             {(int)piece} => {piece}");
            }
            input = Console.ReadLine();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            int pieceOption;

            //Checking valid option for chess piece
            if (int.TryParse(input, out pieceOption) &&
                pieceOption >= 1 && pieceOption <= 6 &&
                Enum.IsDefined(typeof(PieceType), pieceOption))
            {
                var pieceType = (PieceType)pieceOption;
                Console.WriteLine($"Chess Piece: {(PieceType)pieceOption}. Calculation started at: {DateTime.Now}");


                ChessStrategy chessStrategy = new ChessStrategy(pieceType, phNumberLength);
                var count = chessStrategy.GetWalkCount();
                sw.Stop();
                Console.WriteLine("################################################################################");
                Console.WriteLine($"Count for {(PieceType)pieceOption} of length({phNumberLength}) is: {count}.\r\n" +
                                  $"Calculation ended at: {DateTime.Now}.\r\n" +
                                  $"Took {sw.ElapsedMilliseconds} ms.");
                Console.WriteLine("################################################################################");
            }
            else
            {
                Console.WriteLine($"{input}: Piece type is not valid.");
            }
            Console.WriteLine("Do you want to continue Y/N ?");
            shouldContinue = Console.ReadLine()?.ToUpper() == "Y" ? true : false;
        } 
    } 
}