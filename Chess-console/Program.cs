using Chess;
using Board;


namespace Chess_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessBoard chessBoard = new ChessBoard(8, 8);

                chessBoard.MovePiece(new Tower(chessBoard, Color.Black), new Position(0, 0));
                chessBoard.MovePiece(new Tower(chessBoard, Color.Black), new Position(1, 3));
                chessBoard.MovePiece(new Tower(chessBoard, Color.White), new Position(3, 5));
                chessBoard.MovePiece(new King(chessBoard, Color.Black), new Position(0, 2));

                Screen.PrintChessBoard(chessBoard);
            }
            catch(BoardException  e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
