using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.BLL;
using TicTacToe.BLL.Model;


namespace TicTacToe.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayer player1, player2;
            TicTacGame ttg = new TicTacGame();
            //string playerName = "";
            //char player1Choice = 'X', player2Choice = 'O';
            //char choice;
            int loc;


            char[,] gameBoard = ttg.GetBoard();

            int whosTurn;
            IPlayer currentPlayer;

            do
            {
                DisplayBoard(gameBoard);
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write(" Is Player 1 is HUMAN or COMPUTER ?? (H/C) : ");
                if (Console.ReadLine().Equals("H"))
                {
                    player1 = new HumanPlayer();
                    Console.Write(" Enter Player 1 Name : ");
                    player1.Name = Console.ReadLine().ToUpper();
                
                }
                else
                {
                    player1 = new ComputerPlayer();
                    player1.Name = "COMPUTER 1";
                }

                Console.Write(" Is Player 2 is HUMAN or COMPUTER ?? (H/C) : ");
                if (Console.ReadLine().Equals("H"))
                {
                    player2 = new HumanPlayer();
                    Console.Write(" Enter Player 2 Name : ");
                    player2.Name = Console.ReadLine().ToUpper();
                 
                }
                else
                {
                    player2 = new ComputerPlayer();
                    player2.Name = "COMPUTER 2";
                }


                player1.Choice = 'X';
                player1.OppChoice = 'O';
                player2.Choice = 'O';
                player2.OppChoice = 'X';

                //Determine who goes first...
                whosTurn = ttg.WhoIsFirst();

                if (whosTurn == 2)
                {
                    currentPlayer = player2;
                }
                else
                {
                    currentPlayer = player1;
                }
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine($"\n Player{whosTurn} ({currentPlayer.Choice}) goes Fisrt !!!!!");

                while (true)
                {
                    while (true)
                    {
                        //Console.Clear();
                        loc = currentPlayer.GetMove(gameBoard);                     
                        if (!ttg.CheckIsEmptyLocation(loc))
                        {
                            Console.WriteLine($" Location {loc} already used.");
                            continue;
                        }
                        
                        break;
                    }
                    ttg.UpdateBoard(loc, currentPlayer.Choice);
                    DisplayBoard(gameBoard);

                    if (ttg.IsWinnerFound())
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n ================ WINNER is PLAYER {whosTurn} : {currentPlayer.Name} ({currentPlayer.Choice})================");
                        ttg.ResetBoard();
                        break;
                    }
                    else
                    {
                        //Check Empty Locations ....
                        if (!ttg.IsEmptyLocation())
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\n ==================== GAME OVER (TIE)!!! ================");
                            ttg.ResetBoard();
                            break;
                        }
                    }
                    whosTurn = ttg.NextPlayer(whosTurn);
                    if (whosTurn == 1)
                    {
                        currentPlayer = player1;
                    }
                    else
                    {
                        currentPlayer = player2;
                    }
                }

                /*
                while (true)
                {
                    Console.Write($"\n Player {whosTurn}({choice}): Enter the location at which you want to insert ? ");
                    if (int.TryParse(Console.ReadLine(), out location) && location >= 1 && location <=9)
                    {
                        if (!ttg.CheckIsEmptyLocation(location))
                        {
                            Console.WriteLine($" Location {location} already used.");
                            continue;
                        }
                        ttg.UpdateBoard(location, choice);
                        DisplayBoard(gameBoard);
                        if (ttg.IsWinnerFound())
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\n ================ WINNER is PLAYER {whosTurn} ================");
                            ttg.ResetBoard();
                            break;
                        }
                        else
                        { 
                            //Check Empty Locations ....
                            if(!ttg.IsEmptyLocation())
                            {
                                Console.WriteLine($"\n ==================== GAME OVER (TIE)!!! ================");
                                ttg.ResetBoard();
                                break;
                            }
                        }
                        whosTurn = ttg.NextPlayer(whosTurn);
                        if (whosTurn == 1)
                        {
                            choice = player1.Choice;
                        }
                        else
                        {
                            choice = player2.Choice;
                        }
                    }
                    else
                    {
                        Console.Write(" Please enter valid location no. between (1-9) : ");
                    }
                }
                */
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n Press Q to Quit. ");
            } while (!Console.ReadLine().Equals('Q'));
            Console.ReadKey();
        }

        private static void DisplayBoard(char[,] gameBoard)
        {
            Console.Write("\n\t +-----------------------+\n");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("\t |   ");
                    if (gameBoard[i, j].Equals('X'))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (gameBoard[i, j].Equals('O'))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    
                    Console.Write(gameBoard[i, j]);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write("   |");
                Console.Write("\n\t +-----------------------+\n");
            } 
        }
    }
}
