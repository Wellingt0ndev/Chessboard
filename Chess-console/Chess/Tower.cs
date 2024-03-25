using Chess_console.Board;

namespace Chess
{
    public class Tower : Piece
    {
        public Tower(ChessBoard board, Color color) : base(board, color)
        {
        }

        public override string? ToString()
        {
            return "T";
        }
    }
}
