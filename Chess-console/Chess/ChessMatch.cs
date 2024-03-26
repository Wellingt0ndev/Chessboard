using Board;

namespace Chess
{
    public class ChessMatch
    {
        public Chessboard Board { get;private set; }
        private int Turn;
        private Color CurrentPlayer;
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new Chessboard(8,8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
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
            Board.MovePiece(new Tower(Board, Color.Black), new ChessPosition('c', 1).ToPosition());
            Board.MovePiece(new Tower(Board, Color.Black), new ChessPosition('e', 1).ToPosition());
            Board.MovePiece(new King(Board, Color.Black), new ChessPosition('d', 1).ToPosition());
            Board.MovePiece(new Tower(Board, Color.White), new ChessPosition('c', 8).ToPosition());
            Board.MovePiece(new Tower(Board, Color.White), new ChessPosition('e', 8).ToPosition());
            Board.MovePiece(new King(Board, Color.White), new ChessPosition('d', 8).ToPosition());
            
        }
    }
}
