using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.BLL.Model
{
    public class HumanPlayer : IPlayer
    {
        public char Choice { get; set; }
        public char OppChoice { get; set; }

        public string Name { get; set; }
        public int GetMove(char[,] board)
        {
            int location;
            Console.Write($"\n ({Choice}): Enter the location at which you want to insert ? ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out location) && location >= 1 && location <= 9)
                {

                        return location;
                }
                else
                {
                    Console.Write(" Please enter valid location no. between (1-9) : ");
                }
            }
        }
    }
}
