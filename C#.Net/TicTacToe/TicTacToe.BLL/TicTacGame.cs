using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.BLL
{
    public class TicTacGame
    {
        static char[,] board = new char[,] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };

        public char[,] GetBoard()
        {
            return board;
        }

        public bool ResetBoard()
        {
            char[] charArr = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int cnt = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = charArr[cnt++];
                }
            }
            return true;
        }

        public int WhoIsFirst()
        {
            Random r = new Random();
            return r.Next(1, 3);
        }

        public bool CheckIsEmptyLocation(int location)
        {
            bool isEmpty = false;
            switch (location)
            {
                case 1:
                    {
                        if (board[0, 0].Equals('1'))
                            isEmpty = true;
                        break;
                    }
                case 2:
                    {
                        if (board[0, 1].Equals('2'))
                            isEmpty = true;
                        break;
                    }
                case 3:
                    {
                        if (board[0, 2].Equals('3'))
                            isEmpty = true;
                        break;
                    }
                case 4:
                    {
                        if (board[1, 0].Equals('4'))
                            isEmpty = true;
                        break;
                    }
                case 5:
                    {
                        if (board[1, 1].Equals('5'))
                            isEmpty = true;
                        break;
                    }
                case 6:
                    {
                        if (board[1, 2].Equals('6'))
                            isEmpty = true;
                        break;
                    }
                case 7:
                    {
                        if (board[2, 0].Equals('7'))
                            isEmpty = true;
                        break;
                    }
                case 8:
                    {
                        if (board[2, 1].Equals('8'))
                            isEmpty = true;
                        break;
                    }
                case 9:
                    {
                        if (board[2, 2].Equals('9'))
                            isEmpty = true;
                        break;
                    }
                default:
                    break;
            }
            return isEmpty;
        }

        public bool IsEmptyLocation()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!(board[i, j].Equals('X')) && 
                        (!(board[i,j].Equals('O'))))
                        return true;
                }
            }
            return false;
        }

        public int NextPlayer(int currentPlayer)
        {
            if (currentPlayer == 1)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }

        public void UpdateBoard(int location, char choice)
        {
            switch (location)
            {
                case 1:
                    {
                        board[0, 0] = choice;
                        break;
                    }
                case 2:
                    {
                        board[0, 1] = choice;
                        break;
                    }
                case 3:
                    {
                        board[0, 2] = choice;
                        break;
                    }
                case 4:
                    {
                        board[1, 0] = choice;
                        break;
                    }
                case 5:
                    {
                        board[1, 1] = choice;
                        break;
                    }
                case 6:
                    {
                        board[1, 2] = choice;
                        break;
                    }
                case 7:
                    {
                        board[2, 0] = choice;
                        break;
                    }
                case 8:
                    {
                        board[2, 1] = choice;
                        break;
                    }
                case 9:
                    {
                        board[2, 2] = choice;
                        break;
                    }
                default:
                    break;
            }
        }

        public bool IsWinnerFound()
        {
            bool isFound = false;
            //Doagonal Check...
            if (!(board[0, 0].Equals('1')) && board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2])
            {
                isFound = true;
            }
            else if (!(board[0, 2].Equals('3')) && board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0])
            {
                isFound = true;
            }
            //Row Checking.....
            else if (!(board[0, 0].Equals('1')) && board[0, 0] == board[0, 1] && board[0, 2] == board[0, 0])
            {
                isFound = true;
            }
            else if (!(board[1, 0].Equals('4')) && board[1, 0] == board[1, 1] && board[1, 2] == board[1, 0])
            {
                isFound = true;
            }
            else if (!(board[2, 0].Equals('7')) && board[2, 0] == board[2, 1] && board[2, 2] == board[2, 0])
            {
                isFound = true;
            }
            //Columns Checking......
            else if (!(board[0, 0].Equals('1')) && board[0, 0] == board[1, 0] && board[2, 0] == board[0, 0])
            {
                isFound = true;
            }
            else if (!(board[0, 1].Equals('2')) && board[0, 1] == board[1, 1] && board[2, 1] == board[0, 1])
            {
                isFound = true;
            }
            else if (!(board[0, 2].Equals('3')) && board[0, 2] == board[1, 2] && board[2, 2] == board[0, 2])
            {
                isFound = true;
            }
            return isFound;
        }
    }
}
