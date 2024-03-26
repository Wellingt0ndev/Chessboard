using Chess;
using Board;


namespace Chess_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {         
                ChessMatch match = new ChessMatch();
                while(!match.Finished)
                {
                    Console.Clear();
                    Screen.PrintChessBoard(match.Board);
                    Console.WriteLine(match);
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadChessPosition().ToPosition();

                    match.ExecuteTheMoviment(origin, destiny);

                }                
            }
            catch(BoardException  e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
