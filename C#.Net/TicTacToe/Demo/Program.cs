using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] board = new int[,] {  };
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(board.Length+ " ");
            board[2, 1] = 1000;
            for (int i = 0; i < 3; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("\t | " +board[i,j]+$"{(i,j)}" );
                }

            }
            
            //Console.WriteLine(board[1,1]);
            Console.ReadLine();
        }
    }
}
