using Board;

namespace Chess
{
    public class ChessMatch
    {
        public Chessboard Board { get;private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        public HashSet<Piece> Pieces { get; set; }
        public HashSet<Piece> Captured { get; set; }
        public bool Check {  get; private set; }
        public Piece EnPassant { get; private set; }


        public ChessMatch()
        {
            Board = new Chessboard(8,8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Check = false;
            EnPassant = null;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            AddPieces();
        }


        public void ExecuteTheMoviment(Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncreaseMovements();
            Piece capturedPiece =  Board.RemovePiece(destiny);
            Board.MovePiece(p, destiny);
        }

        private void AddPieces()
        {
            Board.MovePiece(new Rook(Board, Color.Black), new ChessPosition('c', 1).ToPosition());
            Board.MovePiece(new Rook(Board, Color.Black), new ChessPosition('e', 1).ToPosition());
            Board.MovePiece(new King(Board, Color.Black), new ChessPosition('d', 1).ToPosition());
            Board.MovePiece(new Rook(Board, Color.White), new ChessPosition('c', 8).ToPosition());
            Board.MovePiece(new Rook(Board, Color.White), new ChessPosition('e', 8).ToPosition());
            Board.MovePiece(new King(Board, Color.White), new ChessPosition('d', 8).ToPosition());
            
        }
    }
}
