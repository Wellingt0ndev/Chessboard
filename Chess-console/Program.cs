using Chess_console.Board;
using Chess;


namespace Chess_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChessBoard board = new ChessBoard(8,8);

           
            board.MovePiece(new Tower(board, Color.Black), new Position(0, 0));
            board.MovePiece(new Tower(board, Color.Black), new Position(1, 3));
            board.MovePiece(new King(board, Color.Black), new Position(2, 4));

            Screen.PrintChessBoard(board);

             
        }
    }
}
