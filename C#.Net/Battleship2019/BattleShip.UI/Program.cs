using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    class Program
    {
        static Board[] boardArr = new Board[2] { new Board(), new Board() };
        static readonly char[] letters = { 'Z','A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        static void Main(string[] args)
        {
            string[] players = new string[2];
            int whosTurn = 0, opponent = 0;
            bool playAgain = true;
            Random rng = new Random();

            //Display Splash Screen...
            //SplashScreen splashScreen = new SplashScreen(@"C:\Users\deepa\OneDrive\Documents\GitHub\net-mpls-0120-classwork-varshaauti27\Battleship2019\MARBLES.BMP");
            // splashScreen.Show(true);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Player(1) Enter Name : ");
            players[0] = Console.ReadLine();
            Console.Write(" Player(2) Enter Name : ");
            players[1] = Console.ReadLine();

            do
            {
                //Reset Board...
                Array.Clear(boardArr, 0, 2);

                //Create new Board for each player
                boardArr = new Board[2] { new Board(), new Board() };

                //Take input for player One....
                Console.Clear();
                PlaceShipOnBoard(boardArr[0], 1, players[0]);
                DispayBoard(0);

                Console.WriteLine("\n Press Any KEY to Continue...");
                Console.ReadKey();

                //Take input for player Two.....
                Console.Clear();
                PlaceShipOnBoard(boardArr[1], 2, players[1]);
                DispayBoard(1);

                Console.WriteLine("\n Press Any KEY to Continue...");
                Console.ReadKey();

                //Randomly Decide who goes first..
                whosTurn = rng.Next(0, 2);
                if (whosTurn == 0)
                {
                    opponent = 1;
                }

                FireShotResponse shotResponse;
                do
                {
                    shotResponse = PlayGame(whosTurn, opponent);
                    if (shotResponse.ShotStatus == ShotStatus.Invalid || shotResponse.ShotStatus == ShotStatus.Duplicate)
                    {
                        Console.Write("\n Shot Response : " + shotResponse.ShotStatus);
                        continue;
                    }
                    else if (shotResponse.ShotStatus == ShotStatus.Hit || shotResponse.ShotStatus == ShotStatus.Miss || shotResponse.ShotStatus == ShotStatus.HitAndSunk)
                    {
                        if (shotResponse.ShotStatus == ShotStatus.HitAndSunk)
                        {
                            Console.Write("\n " + shotResponse.ShipImpacted);
                        }
                        DispayBoard(opponent);

                        //Swap Players
                        int temp;
                        temp = whosTurn;
                        whosTurn = opponent;
                        opponent = temp;
                    }
                    else //Victory...
                    {
                        DispayBoard(opponent);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n Player : {players[whosTurn].ToUpper()} Won the game by sinking all the ships.");  
                        break;
                    }
                } while (true);//
                

                Console.WriteLine("\n Do you want to play again ?(Y/N):");
                string userInput = Console.ReadLine();
                if (userInput.ToUpper().Equals("N"))
                {
                    playAgain = false;
                }
            }
            while (playAgain);

            Console.ReadLine();
        }

        private static void PlaceShipOnBoard(Board board, int playerNo, string playerName)
        {
            ShipType[] shipType = {     ShipType.Destroyer,
                                        ShipType.Submarine,
                                        ShipType.Cruiser,
                                        ShipType.Battleship,
                                        ShipType.Carrier };
            Coordinate coordinate;
            ShipPlacement shipPlacement;
            int direction;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\n Player({playerNo}) : {playerName} >> Place Your Ships :");
            for (int i = 0; i < 5; i++)
            {
                while (i < 5)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"\n {shipType[i]} : ");
                    Console.ForegroundColor = ConsoleColor.White;

                    //Get Coordinate and Validate coordinates...
                    coordinate = GetCoordinate();

                    ShipDirection shipDirection;
                    Console.Write(" Enter Direction : 1) Up   2) Down 3) Left 4) Right : ");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out direction) && direction > 0 && direction < 5)
                        {
                            if (direction == 1)
                            {
                                shipDirection = ShipDirection.Up;
                            }
                            else if (direction == 2)
                            {
                                shipDirection = ShipDirection.Down;
                            }
                            else if (direction == 3)
                            {
                                shipDirection = ShipDirection.Left;
                            }
                            else
                            {
                                shipDirection = ShipDirection.Right;
                            }
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" Please Enter valid value : ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }

                    var request = new PlaceShipRequest()
                    {
                        Coordinate = coordinate,
                        Direction = shipDirection,
                        ShipType = shipType[i]
                    };

                    shipPlacement = board.PlaceShip(request);

                    if (shipPlacement != ShipPlacement.Ok && i < 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($" Unable to place ship at given coordinate. Reason : {shipPlacement} ");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    break;
                }
            }
        }

        private static Coordinate GetCoordinate()
        {
            Coordinate c;
            //char firstChar;
            int firstChar, secondChar;
            string userInput;
            while (true)
            {
                Console.Write(" Enter Coordinate(A1-J10): ");
                userInput = Console.ReadLine();
                if (Regex.IsMatch(userInput, "^[a-jA-J]\\d[10]*$"))
                {
                    userInput = userInput.ToUpper();
                    firstChar = Array.IndexOf(letters, userInput.ElementAt(0)); //(char)userInput.ElementAt(0);
                    secondChar = int.Parse(userInput.ElementAt(1).ToString());
                    if (!(firstChar < 0 && secondChar > 10))
                    {
                        c = new Coordinate(firstChar, secondChar);
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" WRONG INPUT !!!! Please Enter valid coordinate value.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" WRONG INPUT !!!! Please Enter valid coordinate value.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return c;
        }

        private static void DispayBoard(int boardIndex)
        {
            ShotHistory sh;
            string display = "";
            Console.ReadKey();
            Console.Clear();
            //Console.WriteLine("\n");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            
            Console.WriteLine($"\n =============================== Player {boardIndex + 1} ===============================");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("\n ------------------------------------------------------------------------");
                for (int j = 1; j <= 10; j++)
                {
                    sh = boardArr[boardIndex].CheckCoordinate(new Coordinate(i, j));
                   // display = $"{letters[i]}{j}";
                    display = $"{j}{letters[i]}";
                    Console.Write(" | ");
                    if (sh == ShotHistory.Hit)
                    {
                       // Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Red;
                        display = " H ";
                    }
                    else if (sh == ShotHistory.Miss)
                    {
                        //Console.ForegroundColor = ConsoleColor.DarkYellow;
                        //Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        display = " M ";
                    }

                    Console.Write(String.Format("{0,4}", display));
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                Console.Write(" | ");
            }
            Console.WriteLine("\n ------------------------------------------------------------------------");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static FireShotResponse PlayGame(int whosTurn, int opponent)
        {
            Console.WriteLine($"\n Player({whosTurn + 1}) its your turn now....\n");
            FireShotResponse fireShotResponse;
            fireShotResponse = boardArr[opponent].FireShot(GetCoordinate());
            return fireShotResponse;
        }
    }
}

