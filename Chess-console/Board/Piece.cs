using Board;

namespace Board
{
    public class Piece
    {
        public Position Position { get; set; }
        public Color Color { get;protected set; }
        public int NumberOfMovements { get;protected set; }
        public ChessBoard Board { get; set; }

        public Piece(ChessBoard board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            NumberOfMovements = 0;
        }

    }
}
