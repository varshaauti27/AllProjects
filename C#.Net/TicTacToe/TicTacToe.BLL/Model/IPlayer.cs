using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.BLL.Model
{
    public interface IPlayer
    {
        char Choice { get; set; }
        char OppChoice { get; set; }
        string Name { get; set; }
        int GetMove(char[,] b);
    }
}
