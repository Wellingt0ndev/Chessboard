using Board;


namespace Chess
{
    public class King : Piece
    {
        public King(Chessboard board, Color color) : base( board, color)
        {
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
