using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankProject.Logic;
using BankProject.MLL;

namespace BankProject
{
    class Program
    {
        static BankLogic b;
        static string path = @"BankData.txt";

        public Program()
        {
           
        }

        static void Main(string[] args)
        {

            int option;
            string output;
            bool toContinue = true, isSearch;
            List<ModelBank> searchAccount;
            try
            {
                b = new BankLogic(path);
            }
            catch (FileNotFoundException e)
            {
                b = new BankLogic();
                Console.WriteLine(" File Not Found : " + e.Message);
            }
            catch (IOException ex)
            {
                b = new BankLogic();
                Console.WriteLine(" I/O Exception : "+ ex.Message);
            }
            catch (Exception ex)
            {
                b = new BankLogic();
                Console.WriteLine(" Exception : " + ex.Message);
            }

            do
            {
                output = "";
                searchAccount = null;
                isSearch = false;
                string name;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n "+ "====================================================="
                    + "\n Select from Following Options : ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n 1) Display Account " +
                                  "\t 2) Withdraw Amount " +
                                  "\n 3) Deposit Amount " +
                                  "\t 4) Create Account " +
                                  "\n 5) Search Account with balance over $10000 " +
                                  "\n 6) Search Account with Name " +
                                  "\n 7) Delete Account " +
                                  "\t 8) Quit");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n Enter your option : ");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 7)
                    {
                        switch (option)
                        {
                            case 1:     //Display Accounts
                                {
                                    output = DisplayAccount();
                                }
                                break;
                            case 2:     //Withdraw
                                {
                                    output = WithdrawOrDeposit("W");
                                    break;
                                }
                            case 3:     //Deposit
                                {
                                    output = WithdrawOrDeposit("D");
                                    break;
                                }
                            case 4:     //Create Account
                                {
                                    output = CreateNewAccount();
                                    break;
                                }
                            case 5:     
                                {
                                    searchAccount = b.SearchAccWithBalanceOver(1000M);
                                    isSearch = true;
                                    break;
                                }
                            case 6:
                                {
                                    Console.Write(" Enter Account holder name : ");
                                    name = Console.ReadLine();
                                    searchAccount = b.SearchAccByName(name);
                                    isSearch = true;
                                    break;
                                }
                            case 7:
                                {
                                    output = RemoveAccount();
                                    break;
                                }
                            case 8:     //Quit
                                {
                                    Console.WriteLine("\n Press any key to Quit. ");
                                    Console.ReadKey();
                                    System.Environment.Exit(1);
                                    break;
                                }
                            default:
                                break;

                        }
                        if (isSearch && searchAccount != null && searchAccount.Count > 0)
                        {
                            Console.WriteLine("\n------------------------------------------------------------------------------------------");
                            Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-40}", "Acc No", "Name", "Balance", "Created On");
                            Console.WriteLine("------------------------------------------------------------------------------------------");
                            foreach (var item in searchAccount)
                            {
                                Console.WriteLine("{0,-10}{1,-20}{2,-20}{3,-40}", item.AccountNo, item.Name, item.Balance, item.Created_on);
                                Console.WriteLine("------------------------------------------------------------------------------------------");
                            }
                        }
                        else if (isSearch)
                        {
                            Console.WriteLine(" No Account found !!!");
                        }
                        Console.WriteLine(output);

                        break;
                    }
                    else
                    {
                        Console.Write("\n Please choose valid option between(1-5)");
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n Do you want to continue(Y/N)?? :");
                if (Console.ReadLine().ToUpper().Equals("N"))
                {
                    toContinue = false;
                }
            } while (toContinue);
        }

        private static string RemoveAccount()
        {
            int accNo;
            string result;
            try
            {
                Console.Write("\n Enter Account Number : ");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out accNo))
                    {
                        if (b.IsAccountExist(accNo))
                        {
                            if (b.RemoveAccountFromAll(accNo))
                            {
                                result = $" Account {accNo} Deleted Successfully. ";
                            }
                            else
                            {
                                result = $" Account {accNo} Not deleted. ";
                            }
                        }
                        else
                        {
                            result = $" Account {accNo} doesn't exist. ";
                        }
                        break;
                    }
                    else
                    {
                        Console.Write(" Please enter valid account no : ");
                    }
                }
            }
            catch (Exception ex)
            {
                result = " Error Occured(Remove Account) : " + ex.Message;
            }
            return result;
        }

        private static string CreateNewAccount()
        {
            string name,result;
            decimal initialDeposit;

            try
            {
                Console.Write(" Enter Account Holders Name : ");
                name = Console.ReadLine();

                Console.Write(" Enter Initial Amount : ");
                while (true)
                {
                    if (decimal.TryParse(Console.ReadLine(), out initialDeposit))
                    {
                        break;
                    }
                    else
                    {
                        Console.Write(" Please Enter valid Amount : ");
                    }
                }
                result = b.CreateAccount(name, initialDeposit);
            }
            catch (Exception ex)
            {
                result = " Error Occured(Create Account) : " + ex.Message;
            }

            return result;
        }
        private static string WithdrawOrDeposit(string action)
        {
            int accNo, amount;
            string result;
            try
            {
                Console.Write("\n Enter Account Number : ");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out accNo))
                    {
                        if (b.IsAccountExist(accNo))
                        {
                            Console.Write(" Enter Amount : ");
                            while (true)
                            {
                                if (int.TryParse(Console.ReadLine(), out amount))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.Write(" Please Enter valid Amount : ");
                                }
                            }
                            bool s;
                            if (action.Equals("W"))
                            {
                                s = b.WithdrawAmount(accNo, amount, "W");
                            }
                            else
                            {
                                s = b.WithdrawAmount(accNo, amount, "D");
                            }
                            if (s)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                result = $"\n Transaction Successfull. Your Current Balance : {b.GetCurrentBalance(accNo)}";
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                result = $"\n Insufficient Balance in your Account({accNo}). Your current Balance : {b.GetCurrentBalance(accNo)}";
                            }
                        }
                        else
                        {
                            result = "\n Account Doesn't exist.";
                        }
                        break;
                    }
                    else
                    {
                        Console.Write("Please enter valid Account No : ");
                    }
                }
            }
            catch (Exception e)
            {
                result = " Error Occured(Withdraw Account) : " + e.Message;
            }

            return result;
        }

        private static string DisplayAccount()
        {
            int accNo;
            string result;
            try
            {
                Console.Write("\n Enter Account Number : ");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out accNo))
                    {
                        result = $"\n Account Details({accNo}): " +
                                  "\n-------------------------------------------------------------------------------\n";
                        result += b.DisplayAccount(accNo) + "\n-------------------------------------------------------------------------------\n";
                        break;
                    }
                    else
                    {
                        Console.Write("Please enter valid Account No : ");
                    }
                }
            }
            catch(Exception e)
            {
                result = " Error Occured : " + e.Message;
            }

            return result;
        }
    }
}
