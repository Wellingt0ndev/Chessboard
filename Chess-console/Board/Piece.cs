using Board;

namespace Board
{
    public abstract class Piece
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

        public bool AreTherePossibleMoves()
        {
            bool[,] mat = PossibleMovements();
            for (int i = 0; i < Board.Line; i++)
            {
                for(int j = 0; j < Board.Column; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool CanMove(Position position)
        {
            Piece p = Board.Piece(position);
            return p == null || p.Color != Color;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMovements()[position.Line, position.Column];
        }

        public abstract bool[,] PossibleMovements();

    }
}
