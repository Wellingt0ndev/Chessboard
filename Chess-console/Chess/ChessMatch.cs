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

        public Piece ExecuteTheMoviment(Position origin, Position destiny)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncreaseMovements();
            Piece capturedPiece =  Board.RemovePiece(destiny);
            Board.InsertPiece(p, destiny);
            if(capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
            // #Special move Castle Kingside
            if (p is King && destiny.Column == origin.Column + 2)
            {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destinyT = new Position(origin.Line, origin.Column + 1);
                Piece T = Board.RemovePiece(originT);
                T.IncreaseMovements();
                Board.InsertPiece(T, destinyT);
            }

            // #Special move Castle Queenside
            if (p is King && destiny.Column == origin.Column - 2)
            {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destinyT = new Position(origin.Line, origin.Column - 1);
                Piece T = Board.RemovePiece(originT);
                T.IncreaseMovements();
                Board.InsertPiece(T, destinyT);
            }

            // #Special move en passant
            if (p is Pawn)
            {
                if (origin.Column != destiny.Column && capturedPiece == null)
                {
                    Position posP;
                    if (p.Color == Color.White)
                    {
                        posP = new Position(destiny.Line + 1, destiny.Column);
                    }
                    else
                    {
                        posP = new Position(destiny.Line - 1, destiny.Column);
                    }
                    capturedPiece = Board.RemovePiece(posP);
                    Captured.Add(capturedPiece);
                }
            }
            return capturedPiece;
        }

        public void UndoTheMovement(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = Board.RemovePiece(destiny);
            p.DecreaseMovements();
            if(capturedPiece != null)
            {
                Board.InsertPiece(capturedPiece, destiny);
                Captured.Remove(capturedPiece);
            }
            Board.InsertPiece(p, destiny);
            // #Special move Castle Kingside
            if (p is King && destiny.Column == origin.Column + 2)
            {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destinyT = new Position(origin.Line, origin.Column + 1);
                Piece T = Board.RemovePiece(destinyT);
                T.DecreaseMovements();
                Board.InsertPiece(T, originT);
            }

            // #Special move Castle Queenside
            if (p is King && destiny.Column == origin.Column - 2)
            {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destinyT = new Position(origin.Line, origin.Column - 1);
                Piece T = Board.RemovePiece(destinyT);
                T.DecreaseMovements();
                Board.InsertPiece(T, originT);
            }

            // #jogadaespecial en passant
            if (p is Pawn)
            {
                if (origin.Column != destiny.Column && capturedPiece == EnPassant)
                {
                    Piece Pawn = Board.RemovePiece(destiny);
                    Position posP;
                    if (p.Color == Color.White)
                    {
                        posP = new Position(3, destiny.Column);
                    }
                    else
                    {
                        posP = new Position(4, destiny.Column);
                    }
                    Board.InsertPiece(Pawn, posP);
                }
            }
        }
    

        public void MakePlay(Position origin, Position destiny)
        {
            Piece capturedPiece = ExecuteTheMoviment(origin, destiny);
            if (IsItCheck(CurrentPlayer))
            {
                UndoTheMovement(origin,destiny,capturedPiece);
                throw new BoardException("You can't put yourself in check");
            }
        Piece p = Board.Piece(destiny);

        // #jogadaespecial promocao
        if (p is Pawn)
        {
            if ((p.Color == Color.White && destiny.Line == 0) || (p.Color == Color.Black && destiny.Line == 7))
            {
                p = Board.RemovePiece(destiny);
                Pieces.Remove(p);
                Piece Queen = new Queen(Board, p.Color);
                Board.InsertPiece(Queen, destiny);
                Pieces.Add(Queen);
            }
        }
        if (IsItCheck(Opponent(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            if (CheckmateTest(Opponent(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
            Turn++;
            PlayerChanges();
            }
            
            // #jogadaespecial en passant
            if(p is Pawn &&(destiny.Line == origin.Line -2 || destiny.Line == origin.Line + 2)) 
            {
                EnPassant = p;
            }
            else
            {
                EnPassant = null;
            }

        }

        public void ValidateOriginPosition(Position position)
        {
            if(Board.Piece(position) == null)
            {
                throw new BoardException("There is no part in the chosen origin position!");
            }if(CurrentPlayer != Board.Piece(position).Color)
            {
                throw new BoardException("The origin piece chosen is not yours!");
            }
            if(!Board.Piece(position).AreTherePossibleMoves())
            {
                throw new BoardException("There are no possible moves for the chosen origin piece!");
            }
        }

        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!Board.Piece(origin).PossibleMoviment(destiny))
            {
                throw new BoardException("Destination position invalid!");
            }
        }

        private void PlayerChanges()
        {
            if(CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in Captured)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInPlay(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private Color Opponent(Color color)
        {
            if(color == Color.White)
                return Color.Black;
            else
                return Color.White;
        }

        private Piece KingPiece(Color color)
        {
            foreach (Piece x in PiecesInPlay(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool IsItCheck(Color color)
        {
            Piece k = KingPiece(color);
            if(k == null)
            {
                throw new BoardException("There is no " + color + " king on the board");
            }
            foreach(Piece x in PiecesInPlay(Opponent(color)))
            {
                bool[,] mat = x.PossibleMovements();
                if(mat[k.Position.Line, k.Position.Column])
                {
                    return true;               
                }
            }
            return false;
        }

        public bool CheckmateTest(Color color)
        {
            if (!IsItCheck(color))
            {
                return false;
            }
            foreach(Piece x in PiecesInPlay(color))
            {
                bool[,] mat = x.PossibleMovements();
                for(int i = 0;i < Board.Line; i++)
                {
                    for(int j = 0;j < Board.Column; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = ExecuteTheMoviment(origin, destiny);
                            bool checkTest = IsItCheck(color);
                            UndoTheMovement(origin, destiny, capturedPiece);
                            if (!checkTest)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PutNewPiece(char Column, int Line, Piece piece)
        {
            Board.InsertPiece(piece, new ChessPosition(Column, Line).ToPosition());
            Pieces.Add(piece);
        }

        private void AddPieces()
        {            
            PutNewPiece('a', 1, new Rook(Board, Color.White));
            PutNewPiece('b', 1, new Knight(Board, Color.White));
            PutNewPiece('c', 1, new Bishop(Board, Color.White));
            PutNewPiece('d', 1, new Queen(Board, Color.White));
            PutNewPiece('e', 1, new King(Board, Color.White, this));
            PutNewPiece('f', 1, new Bishop(Board, Color.White));
            PutNewPiece('g', 1, new Knight(Board, Color.White));
            PutNewPiece('h', 1, new Rook(Board, Color.White));
            PutNewPiece('a', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('b', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('c', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('d', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('e', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('f', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('g', 2, new Pawn(Board, Color.White, this));
            PutNewPiece('h', 2, new Pawn(Board, Color.White, this));

            PutNewPiece('a', 8, new Rook(Board, Color.Black));
            PutNewPiece('b', 8, new Knight(Board, Color.Black));
            PutNewPiece('c', 8, new Bishop(Board, Color.Black));
            PutNewPiece('d', 8, new Queen(Board, Color.Black));
            PutNewPiece('e', 8, new King(Board, Color.Black, this));
            PutNewPiece('f', 8, new Bishop(Board, Color.Black));
            PutNewPiece('g', 8, new Knight(Board, Color.Black));
            PutNewPiece('h', 8, new Rook(Board, Color.Black));
            PutNewPiece('a', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('b', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('c', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('d', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('e', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('f', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('g', 7, new Pawn(Board, Color.Black, this));
            PutNewPiece('h', 7, new Pawn(Board, Color.Black, this));

        }
    }
}
