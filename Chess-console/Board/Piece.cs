using Board;

namespace Board
{
    public class Piece
    {
        public Position Position { get; set; }
        public Color Color { get;protected set; }
        public int NumberOfMovements { get;protected set; }
        public Chessboard Board { get; set; }

        public Piece(Chessboard board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            NumberOfMovements = 0;
        }

        public void IncreaseMovements()
        {
            NumberOfMovements++;
        }

    }
}
