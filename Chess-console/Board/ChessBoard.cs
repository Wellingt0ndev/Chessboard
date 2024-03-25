using Board;

namespace Board
{
    public class ChessBoard
    {
        public int Line { get; set; }
        public int Column { get; set; }
        private Piece[,] Pieces;
        
        public ChessBoard(int line, int column)
        {
            Line = line;
            Column = column;
            Pieces = new Piece[line, column];
        }

        public Piece Piece(int line, int column)
        {
            return Pieces[line, column];
        }
        public Piece Piece(Position pos)
        {
            return Pieces[pos.Line, pos.Column];
        }

        public bool IsTherePiece(Position pos)
        {
            ValidatePosition(pos);
            return Piece(pos) != null;
        }

        public void MovePiece(Piece piece, Position position)
        {
            if (IsTherePiece(position))
            {
                throw new BoardException("There's already a piece in that position!");
            }
            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public bool ValidPosition(Position pos)
        {
            if(pos.Line<0 ||pos.Line >= Line || pos.Column<0 ||pos.Column >= Column) 
                return false;
            return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (!ValidPosition(pos))
                throw new BoardException("Invalid position");
        }


    }
}
