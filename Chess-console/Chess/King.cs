using Chess_console.Board;


namespace Chess
{
    public class King : Piece
    {
        public King(ChessBoard board, Color color) : base( board, color)
        {
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
