using Chess_console.Board;


namespace Chess_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChessBoard board = new ChessBoard(8,8);

            Screen.PrintChessBoard(board);
             
        }
    }
}
