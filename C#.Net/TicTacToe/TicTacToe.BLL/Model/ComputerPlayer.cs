using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe.BLL.Model
{
    public class ComputerPlayer : IPlayer
    {
        public char Choice { get; set; }
        public char OppChoice { get; set; }
        public string Name { get ; set; }

        public int GetMove(char[,] board)
        {
            Random r = new Random();
            Thread.Sleep(60);
            int myWinlocation = 0;
            int OppWinlocation = 0;
            myWinlocation = GetWinLocation(board, Choice,OppChoice);
            if (myWinlocation == 0)
            {
                OppWinlocation = GetWinLocation(board, OppChoice,Choice);
            }
            else
            {
                Console.WriteLine($"\n {Name}({Choice}): Computer Choose Location : {myWinlocation}");
                return myWinlocation;
            }

            if (OppWinlocation == 0)
            {
                int loc = r.Next(1, 10);
                Console.WriteLine($"\n {Name}({Choice}): Computer Choose Location : {loc}");
                return loc;
            }
            else
            {
                Console.WriteLine($"\n {Name}({Choice}): Computer Choose Location : {OppWinlocation}");
                return OppWinlocation;
            }
        }

        private int GetWinLocation(char[,] board,char winChoice,char choice)
        {
            int no = 0;

            if (board[0, 0] == '1' && board[0, 1] == '2' && board[0, 2] == '3' &&
                board[1, 0] == '4' && board[1, 1] == '5' && board[1, 2] == '6' &&
                board[2, 0] == '7' && board[2, 1] == '8' && board[2, 2] == '9')
            {
                no = 5;
                return no;
            }
            
            //Row Check....
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == winChoice) || (board[i, 1] == winChoice) || (board[i, 2] == winChoice))
                {
                    if (board[i, 0] == winChoice && board[i, 1] == winChoice && board[i,2]!=choice)
                    {
                        no = int.Parse(board[i, 2].ToString());
                        return no;
                    }
                    if (board[i, 1] == winChoice && board[i, 2] == winChoice && board[i, 0] != choice)
                    {
                        no = int.Parse(board[i, 0].ToString());
                        return no;
                    }
                    if (board[i, 0] == winChoice && board[i, 2] == winChoice && board[i, 1] != choice)
                    {
                        no = int.Parse(board[i, 1].ToString());
                        return no;
                    }
                }
            }
            //Columns Check....
            for (int i = 0; i < 3; i++)
            {
                if ((board[0, i] == winChoice) || (board[1, i] == winChoice) || (board[2, i] == winChoice))
                {
                    if (board[0, i] == winChoice && board[1, i] == winChoice && board[2, i] != choice)
                    {
                        no = int.Parse(board[2, i].ToString());
                        return no;
                    }
                    if (board[1, i] == winChoice && board[2, i] == winChoice && board[0, i] != choice)
                    {
                        no = int.Parse(board[0, i].ToString());
                        return no;
                    }
                    if (board[0, i] == winChoice && board[2, i] == winChoice && board[1, i] != choice)
                    {
                        no = int.Parse(board[1, i].ToString());
                        return no;
                    }
                }
            }

            //Diagonal check....
            if ((board[0, 0] == winChoice) || (board[1, 1] == winChoice) || (board[2, 2] == winChoice))
            {
                if ((board[0, 0] == winChoice) && (board[1, 1] == winChoice) && board[2, 2] != choice)
                {
                    no = int.Parse(board[2, 2].ToString());
                    return no;
                }
                if ((board[0, 0] == winChoice) && (board[2, 2] == winChoice) && board[1, 1] != choice)
                {
                    no = int.Parse(board[1, 1].ToString());
                    return no;
                }
                if ((board[1, 1] == winChoice) && (board[0, 0] == winChoice) && board[2, 2] != choice)
                {
                    no = int.Parse(board[2, 2].ToString());
                    return no;
                }
            }

            if ((board[0, 2] == winChoice) || (board[1, 1] == winChoice) || (board[2, 0] == winChoice))
            {
                if ((board[0, 2] == winChoice) && (board[1, 1] == winChoice) && board[2, 0] != choice)
                {
                    no = int.Parse(board[2, 0].ToString());
                    return no;
                }
                if ((board[0, 2] == winChoice) && (board[2, 0] == winChoice) && board[1, 1] != choice)
                {
                    no = int.Parse(board[1, 1].ToString());
                    return no;
                }
                if ((board[1, 1] == winChoice) && (board[0, 2] == winChoice) && board[2, 0] != choice)
                {
                    no = int.Parse(board[2, 0].ToString());
                    return no;
                }
            }

            return no;
        } 
    }
}
