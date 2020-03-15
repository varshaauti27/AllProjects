using Ninject;
using NUnit.Framework;
using SGBank.BLL;
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
    public class FreeAccountTests
    {
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = DIContainer.Kernel.Get<AccountManager>();//AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("12345");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("12345", response.Account.AccountNumber);
        }

        [TestCase("12345", "Free Account", 100, AccountType.Free, 250, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -100, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, 50, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, true)]
        public void FreeAccountDepositRuleTest(string accountNumber, string name, decimal balance,
                                                AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit depositRule = new FreeAccountDepositRule();

            AccountDepositResponse response = depositRule.Deposit(new Account()
                                                                 { 
                                                                    AccountNumber = accountNumber, 
                                                                    Name = name, 
                                                                    Balance = balance, 
                                                                    Type = accountType 
                                                                 }, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -250, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, 250, false)]
        [TestCase("12345", "Free Account", 90, AccountType.Free, -95, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -50, true)]
        public void FreeAccountWithdrawRuleTest(string accountNumber, string name, decimal balance,
                                               AccountType accountType, decimal amount, bool expectedResult)
        {
            IWithdraw withdrawRule = new FreeAccountWithdrawRule();

            AccountWithdrawResponse response = withdrawRule.Withdraw(new Account()
                                                                    {
                                                                        AccountNumber = accountNumber,
                                                                        Name = name,
                                                                        Balance = balance,
                                                                        Type = accountType
                                                                    }, amount);
            Assert.AreEqual(expectedResult, response.Success);
        }
    }
}
