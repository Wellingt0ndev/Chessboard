using Board;
using Chess;

namespace Chess_console
{
    public class Screen
    {
        public static void PrintMatch(ChessMatch match)
        {
            PrintChessBoard(match.Board);
            Console.WriteLine();
            PrintsCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.Turn);
            if (!match.Finished)
            {
                Console.WriteLine("Waiting for a move: " + match.CurrentPlayer);
                if (match.Check)
                    Console.WriteLine("Check!");
            }
            else
            {
                Console.WriteLine("Checkmate!");
                Console.WriteLine("Winner: " + match.CurrentPlayer);
            }            
        }

        private static void PrintsCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured pieces:");
            Console.Write("White: ");
            PrintSet(match.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(match.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;     
            Console.WriteLine();
        }
        public static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[");
            foreach (Piece x in set) 
            { 
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void PrintChessBoard(Chessboard board)
        {
            for (int i = 0; i < board.Line; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Column; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintChessBoard(Chessboard board,bool [,] possiblePosition) 
        {
            ConsoleColor OriginalBackground = Console.BackgroundColor;
            ConsoleColor NewBackground = ConsoleColor.DarkGray;
        
            for (int i = 0; i < board.Line; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Column; j++)
                {
                    if (possiblePosition[i, j])
                    {
                        Console.BackgroundColor = NewBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = OriginalBackground;
                    }
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = OriginalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor=OriginalBackground;
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor consoleColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = consoleColor;
                }
                Console.Write(" ");
            }
        }               
    }
}
