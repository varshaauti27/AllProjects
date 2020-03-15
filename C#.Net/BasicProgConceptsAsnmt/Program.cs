using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicProgConceptsAsnmt
{
    class Program
    {
        public enum GameStatus
        {
            playerWin = 1, computerWin = 2, tie = 3, invalid
        }

        public string Win { get; set; }
        static void Main(string[] args)
        {
            int noOfRounds = 0;
            bool playAgain = true;
            int userChoice = 0, computerChoice = 0, winCnt = 0, tieCnt = 0, comWincnt = 0;
            string userInput = "", compInput = "";

            Random rng = new Random();

            Console.WriteLine("============== ROCK PAPER SCISSOR ==============");
            do
            {
                winCnt = tieCnt = comWincnt = 0;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n Enter No of Rounds you wanted to play(1-10): ");
                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out noOfRounds) || !(noOfRounds <= 10 && noOfRounds > 0))
                    {
                        Console.WriteLine(" Please enter valid no of rounds(1-10)");
                        Thread.Sleep(60);
                        System.Environment.Exit(1);
                    }
                    else
                    {
                        break;
                    }
                }
                GameStatus gs;
                for (int i = 0; i < noOfRounds; i++)
                {
                    Console.Write("\n Enter Your choice : 1) Rock 2) Paper 3) Scissors :: ");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out userChoice) && (userChoice > 0 && userChoice <= 3))
                        {
                            userInput = GetInput(userChoice - 1);
                            break;
                        }
                        else
                        {
                            Console.WriteLine(" Wrong Choice !!!! Try again.... ");
                        }
                    }

                    computerChoice = rng.Next(0, 3);
                    compInput = GetInput(computerChoice);

                    gs = GetGameStatus(userInput, compInput);
                    if (gs == GameStatus.playerWin)
                    {
                        winCnt++;
                    }
                    else if (gs == GameStatus.computerWin)
                    {
                        comWincnt++;
                    }
                    else
                    {
                        tieCnt++;
                    }
                }
                
                string format = "{0,20} {1,-10}";
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine(format, " TOTAL ROUNDS : ", noOfRounds);
                Console.WriteLine(format, " TIES : ", tieCnt);
                Console.WriteLine(format, " USER WINS : ", winCnt);
                Console.WriteLine(format, " COMPUTER WINS : ", comWincnt);
                Console.WriteLine("------------------------------------------------------------");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" Do you want to continue(Y/N)? ");

                if (Console.ReadLine().ToUpper().Equals("N"))
                {
                    Console.WriteLine(" Thanks for playing !!!!!!");
                    playAgain = false;
                    // break;
                }
            } while (playAgain);

            Console.ReadLine();
        }

        private static string GetInput(int userChoice)
        {
            string[] strArr = { "ROCK", "PAPER", "SCISSOR" };
            return strArr[userChoice];
        }

        public static GameStatus GetGameStatus(string userInput, string compInput)
        {
            GameStatus gs;
            if (userInput == "ROCK" && compInput == "SCISSOR")
            {
                Console.WriteLine(" User wins ");
                 gs= GameStatus.playerWin;
            }
            else if (userInput == "ROCK" && compInput == "PAPER")
            {
                Console.WriteLine(" Computer wins.");
                gs = GameStatus.computerWin;
            }
            else if (userInput == "PAPER" && compInput == "ROCK")
            {
                Console.WriteLine(" User wins.");
                gs = GameStatus.computerWin;
            }
            else if (userInput == "PAPER" && compInput == "SCISSOR")
            {
                Console.WriteLine(" Computer Wins.");
               
                gs=GameStatus.computerWin;            }
            else if (userInput == "SCISSOR" && compInput == "ROCK")
            {
                Console.WriteLine(" Computer Wins.");
                gs=GameStatus.computerWin;
            }
            else if (userInput == "SCISSOR" && compInput == "PAPER")
            {
                Console.WriteLine(" User wins.");

                gs=GameStatus.playerWin;
            }
            else
            {
                Console.WriteLine(" TIE !!!!");
                gs=GameStatus.tie;
            }
            return gs;

        }

    }

}