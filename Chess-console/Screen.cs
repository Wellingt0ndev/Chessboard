using Chess_console.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_console
{
    public class Screen
    {
        public static void PrintChessBoard(ChessBoard board)
        {
            for(int i = 0; i < board.Line; i++)
            {
                for (int j = 0; j < board.Column; j++)
                {
                    if(board.Piece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(board.Piece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
