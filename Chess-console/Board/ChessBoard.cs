namespace Chess_console.Board
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

        public void MovePiece(Piece piece, Position position)
        {
            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }
    }
}
