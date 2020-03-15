using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    [TestFixture]
    public class PremiumAccountTest
    {
        [TestCase("22222", "Premium Account", 100, AccountType.Basic, 250, false)]
        [TestCase("22222", "Premium Account", 100, AccountType.Premium, -100, false)]
        [TestCase("22222", "Premium Account", 100, AccountType.Premium, 250, true)]
        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance,
                                                   AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit deposit = new PremiumAccountDepositRule();

            AccountDepositResponse response = deposit.Deposit(new Account()
            {
                AccountNumber = accountNumber,
                Name = name,
                Balance = balance,
                Type = accountType,
            }, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("22222", "Premium Account", 1500, AccountType.Premium, -1000, 500, true)]
        [TestCase("22222", "Premium Account", 100, AccountType.Free, -100, 100, false)]
        [TestCase("22222", "Premium Account", 100, AccountType.Premium, 100, 100, false)]
        [TestCase("22222", "Premium Account", 150, AccountType.Premium, -50, 100, true)]
        [TestCase("22222", "Premium Account", 100, AccountType.Premium, -700, 100, false)]
        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance,
                                   AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw withdraw = new PremiumAccountWithdrawRule();

            AccountWithdrawResponse response = withdraw.Withdraw(new Account()
            {
                AccountNumber = accountNumber,
                Name = name,
                Balance = balance,
                Type = accountType,
            }, amount);

            Assert.AreEqual(expectedResult, response.Success);

            if (response.Success)
            {
                Assert.AreEqual(newBalance, response.Account.Balance);
            }
        }

    }
}
