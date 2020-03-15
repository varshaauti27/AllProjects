using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankProject.MLL;


namespace BankProject.Data
{

    public class BankData
    {
        readonly Dictionary<int, ModelBank> allAccount = new Dictionary<int, ModelBank>();
        string path = "BankData.txt";
        int _nextAccountNo = 0;

        public BankData()
        {
            _nextAccountNo += 1;
        }

        public BankData(string path)
        {
            if (File.Exists(path))
            {
                List<ModelBank> list = ReadAllGames();
                foreach (ModelBank m in list)
                {
                    allAccount.Add(m.AccountNo, m);
                    _nextAccountNo = m.AccountNo;
                }
            }
            else
            {
                allAccount.Add(1, new ModelBank(1, "Varsha", 100, DateTime.Parse("1/1/2020")));
                allAccount.Add(2, new ModelBank(2, "Ashish", 150, DateTime.Parse("1/1/2020")));
                allAccount.Add(3, new ModelBank(3, "Tanvi", 200, DateTime.Parse("1/1/2020")));
                _nextAccountNo = allAccount.Count;
                WriteAccountToFile(allAccount);
            }
            _nextAccountNo += 1;
        }

        private List<ModelBank> ReadAllGames()
        {
            List<ModelBank> b = new List<ModelBank>();
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    
                    b.Add(MapLineToBankData(line));
                }
            }
            return b;
        }

        private ModelBank MapLineToBankData(string line)
        {
            string[] data = line.Split('|');
            ModelBank bank = new ModelBank(int.Parse(data[0]), data[1], decimal.Parse(data[2]), DateTime.Parse(data[3]));
            return bank;
        }

        private string MapBankDataToLine(ModelBank value)
        {
            return value.AccountNo + " | " + value.Name + " | " + value.Balance + " | " + value.Created_on;
        }

        public Dictionary<int, ModelBank> GetAllBankAccounts()
        {
            return allAccount;
        }

        public int Create(string name, decimal initialAmount)
        {
            ModelBank newAccount = new ModelBank(_nextAccountNo, name, initialAmount,DateTime.Now);
            allAccount.Add(_nextAccountNo, newAccount);
            int accNo = _nextAccountNo;
            _nextAccountNo++;
            WriteAccountToFile(allAccount);
            return accNo;
        }

        private void WriteAccountToFile(Dictionary<int,ModelBank> accounts)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var item in accounts)
                {
                    writer.WriteLine(MapBankDataToLine(item.Value));
                }
            }
        }

        public ModelBank Display(int accNo)
        {
            ModelBank acc = null;

            /* if (allAccount.ContainsKey(accNo))
             {
                 acc = allAccount[accNo];
             }
             */
            acc = allAccount.Values.FirstOrDefault(account => account.AccountNo == accNo);
            
            return acc;
        }

        public bool IsAccExist(int accNo)
        {
            if (allAccount.ContainsKey(accNo))
                return true;
            return false;
        }

        public decimal GetCurrBalance(int accNo)
        {
            return allAccount[accNo].Balance;
        }

        public bool WithdrawDeposit(int accNo, decimal amount, string act)
        {
            bool isSuccess;
            decimal balance = allAccount[accNo].Balance;
            if (act.Equals("W"))
            {
                if (balance < amount)
                {
                    isSuccess = false;
                }
                else
                {
                    balance -= amount;
                    allAccount[accNo].Balance = balance;
                    isSuccess = true;
                }
            }
            else
            {
                balance += amount;
                allAccount[accNo].Balance = balance;
                isSuccess = true;
            }
            if (isSuccess)
                WriteAccountToFile(allAccount);
            return isSuccess;
        }

        public bool RemoveAcc(int accNo)
        {
            bool isRemoved = false;
            if (allAccount.Remove(accNo))
            {
                isRemoved = true;
                WriteAccountToFile(allAccount);
            }
            return isRemoved;
        }
    }
}