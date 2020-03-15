using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class BasicAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account
                                            { 
                                              AccountNumber = "33333", 
                                              Name = "Basic Account", 
                                              Balance = 100M, 
                                              Type = AccountType.Basic 
                                            };
        public Account LoadAccount(string accountNumber)
        {
            if (_account.Equals(accountNumber))
            {
                return _account;
            }
            else
            {
                return null;
            }
        }

        public void SaveAccount(Account account)
        {
            _account = account;
        }
    }
}