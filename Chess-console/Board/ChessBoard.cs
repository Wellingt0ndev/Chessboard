namespace Chess_console.Board
{
    public class ChessBoard
    {
        public int Line { get; set; }
        public int Column { get; set; }
        private Piece[,] pieces;
        
        public ChessBoard(int line, int column)
        {
            Line = line;
            Column = column;
            pieces = new Piece[line, column];
        }
    }
}
