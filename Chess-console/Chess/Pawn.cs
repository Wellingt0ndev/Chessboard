using Board;

namespace Chess
{
    public class Pawn : Piece
    {
        private ChessMatch match;

        public Pawn(Chessboard board, Color color, ChessMatch match) : base(board, color)
        {
            this.match = match;
        }
        public override string ToString()
        {
            return "P";
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Line, Board.Column];
            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.SetValues(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line - 2, Position.Column);
                Position p2 = new Position(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(p2) && CanMove(p2) && Board.ValidPosition(pos) && CanMove(pos) && NumberOfMovements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // #Special move en passant
                if (Position.Line == 3)
                {
                    Position esquerda = new Position(Position.Line, Position.Column - 1);
                    if (Board.ValidPosition(esquerda) && CanMove(esquerda) && Board.Piece(esquerda) == match.EnPassant)
                    {
                        mat[esquerda.Line - 1, esquerda.Column] = true;
                    }
                    Position direita = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(direita) && CanMove(direita) && Board.Piece(direita) == match.EnPassant)
                    {
                        mat[direita.Line - 1, direita.Column] = true;
                    }
                }
            }
            else
            {
                pos.SetValues(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line + 2, Position.Column);
                Position p2 = new Position(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(p2) && CanMove(p2) && Board.ValidPosition(pos) && CanMove(pos) && NumberOfMovements == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.SetValues(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && CanMove(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // #Special move en passant
                if (Position.Line == 4)
                {
                    Position esquerda = new Position(Position.Line, Position.Column - 1);
                    if (Board.ValidPosition(esquerda) && CanMove(esquerda) && Board.Piece(esquerda) == match.EnPassant)
                    {
                        mat[esquerda.Line + 1, esquerda.Column] = true;
                    }
                    Position direita = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(direita) && CanMove(direita) && Board.Piece(direita) == match.EnPassant)
                    {
                        mat[direita.Line + 1, direita.Column] = true;
                    }
                }
            }

            return mat;
        }
    }
}