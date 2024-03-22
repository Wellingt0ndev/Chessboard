namespace Chess_console.Board
{
    public class Piece
    {
        public Position Position { get; set; }
        public Color Color { get;protected set; }
        public int NumberOfMovements { get;protected set; }
        public ChessBoard Board { get; set; }

        public Piece(Position position,ChessBoard board, Color color)
        {
            Position = position;
            Board = board;
            Color = color;
            NumberOfMovements = 0;
        }

    }
}
