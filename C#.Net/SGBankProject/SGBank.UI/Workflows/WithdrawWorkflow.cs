using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class WithdrawWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            AccountManager manager = AccountManagerFactory.Create();

            Console.WriteLine("Withdraw Amount");
            Console.WriteLine("--------------------------");

            Console.Write("Enter Account Number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Enter withdraw amount: ");
            decimal amount = decimal.Parse(Console.ReadLine(), NumberStyles.Number);

            AccountWithdrawResponse response = manager.Withdraw(accountNumber, amount);

            if (response.Success)
            {
                Console.WriteLine("\nWithdraw completed!\n");
                Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
                Console.WriteLine($"Old balance: {response.OldBalance:c}");
                Console.WriteLine($"Amount Withdraw: {response.Amount:c}");
                Console.WriteLine($"New balance: {response.Account.Balance:c}");
            }
            else
            {
                Console.WriteLine("\nAn error occurred: ");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}
