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
    public class BasicAccountTest 
    {

        [TestCase("33333","Basic Account",100,AccountType.Free,250,false)]
        [TestCase("33333","Basic Account",100,AccountType.Basic,- 100,false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 250, true)]
        public void BasicAccountDepositRuleTest(string accountNumber,string name,decimal balance,
                                            AccountType accountType,decimal amount,bool expectedResult)
        {
            IDeposit deposit = new NoLimitDepositRule();

            AccountDepositResponse response = deposit.Deposit(new Account()
                                                {
                                                    AccountNumber = accountNumber,
                                                    Name = name,
                                                    Balance = balance,
                                                    Type = accountType,
                                                }, amount);

            Assert.AreEqual(expectedResult,response.Success);
        }

        [TestCase("33333","Basic Account",1500,AccountType.Basic,- 1000,1500,false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Free, -100, 100, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 100, 100, false)]
        [TestCase("33333", "Basic Account", 150, AccountType.Basic, -50, 100, true)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -150, -60, true)]
        public void BasicAccountWithdrawRuleTest(string accountNumber, string name, decimal balance,
                                    AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw withdraw = new BasicAccountWithdrawRule();

            AccountWithdrawResponse response= withdraw.Withdraw(new Account()
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