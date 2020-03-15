using SGBank.BLL;
using SGBank.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class DepositWorkflow
    {
        public void Execute()
        {
            AccountManager accountManager = AccountManagerFactory.Create();

            Console.Write("Enter Account Number : ");
            string accountNumber = Console.ReadLine();

            Console.Write("Enter a depost amount : ");
            decimal amount = decimal.Parse(Console.ReadLine());

            AccountDepositResponse response = accountManager.Deposit(accountNumber, amount);

            if (response.Success)
            {
                Console.WriteLine("Deposit Completed !!");
                Console.WriteLine($"Account Number : {response.Account.AccountNumber}");
                Console.WriteLine($"Old Balance : {response.OldBalance:c}");
                Console.WriteLine($"Amount deposited : {response.Amount:c}");
                Console.WriteLine($"New Balance : {response.Account.Balance:c}");

            }
            else
            {
                Console.WriteLine("An error occured : ");
                Console.WriteLine(response.Message);
            }
        }
    }
}
