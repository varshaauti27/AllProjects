using HangMan.BLL;
using HangMan.BLL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hangman.UI
{
    public class GameFlow
    {
        string Seperator = @"==========================================";
        public void Start()
        {
            GameManager gm;
            PlayRoundResponse response;
            Console.WriteLine(" ============= HangMan =============== ");
            bool toContinue = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                try
                {
                    DisplayHangMan(0);

                    //clear All 
                    response = null;
                    gm = null;
                    gm = GameManagerFactory.Create();
                    while (true)
                    {
                        char c;
                        while (true)
                        {
                            Console.SetCursorPosition(50, Console.WindowHeight / 3 + 8);

                            Console.Write(" Enter Character : ");
                            if (char.TryParse(Console.ReadLine().ToUpper(), out c))
                            {
                                if (!(Regex.IsMatch(c.ToString(), "^[a-zA-Z]*$")))
                                {
                                    Console.SetCursorPosition(50, Console.WindowHeight / 3 + 10);
                                    Console.Write(" Please Enter Valid Char : ");
                                    continue;
                                }
                                if (response != null && (response.Miss.Contains(c) || response.Guess.Contains(c)))
                                {
                                    Console.SetCursorPosition(50, Console.WindowHeight / 3 + 8);
                                    for (int i = 0; i < 50; ++i)
                                    {
                                        Console.Write(" ", i);
                                    }
                                    continue;
                                }

                                break;
                            }
                            else
                            {
                                Console.SetCursorPosition(50, Console.WindowHeight / 3 + 10);
                                Console.Write(" Please Enter Valid Char : ");
                                continue;
                            }
                        }

                        response = gm.PlayRound(c);


                        DisplayHangMan(response.Miss.Count);
                        DisplayResult(response.UpdatedString, response.Guess, response.Miss);

                        if (response.Miss.Count >= 7)
                        {
                            Console.SetCursorPosition(50, Console.WindowHeight / 3 + 10);

                            Console.Write(Seperator);
                            Console.SetCursorPosition(50, Console.WindowHeight / 3 + 12);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" Game Over : You Loss...reached max attempt");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(50, Console.WindowHeight / 3 + 14);
                            Console.WriteLine(Seperator);

                            break;
                        }
                        else if (response.Result == GameResult.Win)
                        {
                            Console.SetCursorPosition(50, Console.WindowHeight / 3 + 10);
                            Console.Write(Seperator);
                            Console.SetCursorPosition(50, Console.WindowHeight / 3 + 12);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" Game Over : You Win !!!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(50, Console.WindowHeight / 3 + 14);
                            Console.WriteLine(Seperator);
                            break;
                        }
                        Console.SetCursorPosition(50, Console.WindowHeight / 3 + 14);
                        Console.WriteLine(Seperator);
                    }

                    Console.SetCursorPosition(50, Console.WindowHeight / 3 + 16);
                    Console.Write(" Do you want to Continue (Y/N) ?? ");
                    string input = Console.ReadLine();
                    if (input.ToUpper().Equals("N"))
                    {
                        toContinue = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(" Error in GameFlow(Start) : " + e);
                }
            } while (toContinue);
        }

        private void DisplayResult(char[] updatedString, List<char> guess, List<char> miss)
        {
            //Word 
            Console.SetCursorPosition(50, Console.WindowHeight / 3);
            Console.WriteLine(Seperator);
            Console.SetCursorPosition(50, Console.WindowHeight / 3 + 2);
            Console.Write(" Word :\t");
            foreach (char i in updatedString)
            {
                Console.Write(i + " ");
            }
            //For Guess 
            Console.SetCursorPosition(50, Console.WindowHeight / 3 + 4);
            Console.Write(" Guess :\t");
            foreach (char e in guess)
            {
                Console.Write(e + ", ");
            }
            //For Miss 
            Console.SetCursorPosition(50, Console.WindowHeight / 3 + 6);
            Console.Write(" Miss :\t");
            foreach (char e in miss)
            {
                Console.Write(e + ", ");
            }
        }

        private void DisplayLogo()
        {
            string logo = @"
                                     _    _                                         
                                    | |  | |                                        
                                    | |__| | __ _ _ __   __ _ _ __ ___   __ _ _ __  
                                    |  __  |/ _` | '_ \ / _` | '_ ` _ \ / _` | '_ \ 
                                    | |  | | (_| | | | | (_| | | | | | | (_| | | | |
                                    |_|  |_|\__,_|_| |_|\__, |_| |_| |_|\__,_|_| |_|
                                                         __/ |                      
                                                        |___/                       
";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(logo);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DisplayHangMan(int count)
        {
            Console.Clear();
            DisplayLogo();
            switch (count)
            {
                case 0:
                    {
                        Console.WriteLine("\n" +
                                            "\n            _________" +
                                            "\n           |         |" +
                                            "\n           |         |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n    _______|_____________" +
                                            "\n   /       |            /|" +
                                            "\n  /____________________/ |" +
                                            "\n |                     | /" +
                                            "\n |_____________________|/ ");
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine(
                                            "\n            _________" +
                                            "\n           |         |" +
                                            "\n           |         |" +
                                            "\n           |        ( )" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n    _______|_____________" +
                                            "\n   /       |            /|" +
                                            "\n  /____________________/ |" +
                                            "\n |                     | /" +
                                            "\n |_____________________|/ ");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine(
                                            "\n            _________" +
                                            "\n           |         |" +
                                            "\n           |         |" +
                                            "\n           |        ( )" +
                                            "\n           |         |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n    _______|_____________" +
                                            "\n   /       |            /|" +
                                            "\n  /____________________/ |" +
                                            "\n |                     | /" +
                                            "\n |_____________________|/ ");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine(
                                            "\n            _________" +
                                            "\n           |         |" +
                                            "\n           |         |" +
                                            "\n           |        ( )" +
                                            "\n           |         |" +
                                            "\n           |        \\ " +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n    _______|_____________" +
                                            "\n   /       |            /|" +
                                            "\n  /____________________/ |" +
                                            "\n |                     | /" +
                                            "\n |_____________________|/ ");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine(
                                            "\n            _________" +
                                            "\n           |         |" +
                                            "\n           |         |" +
                                            "\n           |        ( )" +
                                            "\n           |         |" +
                                            "\n           |        \\ / " +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n    _______|_____________" +
                                            "\n   /       |            /|" +
                                            "\n  /____________________/ |" +
                                            "\n |                     | /" +
                                            "\n |_____________________|/ ");
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine(
                                            "\n            _________" +
                                            "\n           |         |" +
                                            "\n           |         |" +
                                            "\n           |        ( )" +
                                            "\n           |         |" +
                                            "\n           |        \\ / " +
                                            "\n           |         |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n    _______|_____________" +
                                            "\n   /       |            /|" +
                                            "\n  /____________________/ |" +
                                            "\n |                     | /" +
                                            "\n |_____________________|/ ");
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine(
                                            "\n            _________" +
                                            "\n           |         |" +
                                            "\n           |         |" +
                                            "\n           |        ( )" +
                                            "\n           |         |" +
                                            "\n           |        \\ / " +
                                            "\n           |         |" +
                                            "\n           |        /" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n    _______|_____________" +
                                            "\n   /       |            /|" +
                                            "\n  /____________________/ |" +
                                            "\n |                     | /" +
                                            "\n |_____________________|/ ");
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine(
                                            "\n            _________" +
                                            "\n           |         |" +
                                            "\n           |         |" +
                                            "\n           |        ( )" +
                                            "\n           |         |" +
                                            "\n           |        \\ / " +
                                            "\n           |         |" +
                                            "\n           |        / \\" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n    _______|_____________" +
                                            "\n   /       |            /|" +
                                            "\n  /____________________/ |" +
                                            "\n |                     | /" +
                                            "\n |_____________________|/ ");
                        break;
                    }
                default:
                    {
                        Console.WriteLine(
                                            "\n            _________" +
                                            "\n           |         |" +
                                            "\n           |         |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n           |" +
                                            "\n    _______|_____________" +
                                            "\n   /       |            /|" +
                                            "\n  /____________________/ |" +
                                            "\n |                     | /" +
                                            "\n |_____________________|/ ");
                        break;
                    }
            }
        }
    }
}