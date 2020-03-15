using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        string _filePath = "Accounts.txt";

        public FileAccountRepository(string path)
        {
            _filePath = path;
        }

        private List<Account> List()
        {
            List<Account> _all = new List<Account>();
            if (File.Exists(_filePath))
            {
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    reader.ReadLine();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] prop = line.Split(',');
                        AccountType type = AccountType.Free;
                        switch (prop[3])
                        {
                            case "F":
                            case "f":
                                type = AccountType.Free;
                                break;
                            case "B":
                            case "b":
                                type = AccountType.Basic;
                                break;
                            case "P":
                            case "p":
                                type = AccountType.Premium;
                                break;
                        }
                        _all.Add(new Account { AccountNumber = prop[0], Name = prop[1], Balance = decimal.Parse(prop[2]), Type = type });
                    }
                }
            }

            return _all;
        }
        public Account LoadAccount(string accountNumber)
        {
            var _allAccounts = List();
            return _allAccounts.Where(i => i.AccountNumber.Equals(accountNumber)).FirstOrDefault();
        }

        public void SaveAccount(Account account)
        {
            var accounts = List();

            int index = accounts.FindIndex(i => i.AccountNumber.Equals(account.AccountNumber));
            if (index != -1)
                accounts[index] = account;

            CreateAccountFile(accounts);
        }

        private void CreateAccountFile(List<Account> accounts)
        {
            if (File.Exists(_filePath))
                File.Delete(_filePath);

            using (StreamWriter sr = new StreamWriter(_filePath))
            {
                sr.WriteLine("FirstName,LastName,Major,GPA");
                foreach (var acc in accounts)
                {
                    sr.WriteLine(CreateCsvForAccount(acc));
                }
            }
        }

        private string CreateCsvForAccount(Account acc)
        {
            string type = "";
            switch (acc.Type)
            {
                case AccountType.Free:
                    type = "F";
                    break;
                case AccountType.Basic:
                    type = "B";
                    break;
                case AccountType.Premium:
                    type = "P";
                    break;
            }
            return string.Format("{0},{1},{2},{3}",
                   acc.AccountNumber, acc.Name, acc.Balance, type);
        }
    }
}
