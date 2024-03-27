using Board;

namespace Chess
{
    public class Knight : Piece
    {
        public Knight(Chessboard board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "H";
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Line, Board.Column];

            Position pos = new Position(0, 0);

            pos.SetValues(Position.Line - 1, Position.Column - 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.SetValues(Position.Line - 2, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.SetValues(Position.Line - 2, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.SetValues(Position.Line - 1, Position.Column + 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.SetValues(Position.Line + 1, Position.Column + 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.SetValues(Position.Line + 2, Position.Column + 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.SetValues(Position.Line + 2, Position.Column - 1);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.SetValues(Position.Line + 1, Position.Column - 2);
            if (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }
    }
}