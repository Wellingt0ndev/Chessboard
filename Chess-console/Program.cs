using Chess;
using Board;


namespace Chess_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChessPosition pos = new ChessPosition('a', 1);

            Console.WriteLine(pos);

            Console.WriteLine(pos.ToPosition());
        }
    }
}
