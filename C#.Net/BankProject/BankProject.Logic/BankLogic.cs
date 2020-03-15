using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankProject.Data;
using BankProject.MLL;

namespace BankProject.Logic
{
    public class BankLogic
    {
        BankData bankData;

        public BankLogic()
        {
            bankData = new BankData();
        }
        public BankLogic(string path)
        { 
            bankData = new BankData(path);
        }

        public string CreateAccount(string name, decimal amount)
        {
            if (amount * 2 < 500)
            {
                amount *= 2;
            }
            else
            {
                amount = (amount - 500) + (500 * 2);
            }

            int no = bankData.Create(name, amount); // Double initial deposit
            return $" Account Created Successfully. Your Account No : {no}"; //Return Account No...
        }

        public string DisplayAccount(int accNo)
        {
            string output ;
            ModelBank modelBank;
            modelBank = bankData.Display(accNo);
            if (modelBank == null)
            {
                output = $" No Account Found with Account no {accNo}";
            }
            else
            {
                output = $" Account No: {modelBank.AccountNo} \t Name :{modelBank.Name} \t Balance : {modelBank.Balance} \t Created ON : {modelBank.Created_on}";
            }
            return output;
        }

        public bool IsAccountExist(int accNo)
        {
            return bankData.IsAccExist(accNo);
        }

        public bool WithdrawAmount(int accNo,decimal amount,string act)
        {
            return bankData.WithdrawDeposit(accNo,amount,act);
        }

        public decimal GetCurrentBalance(int accNo)
        {
            return bankData.GetCurrBalance(accNo);
        }

        public List<ModelBank> SearchAccWithBalanceOver(decimal ammountOver)
        {
            Dictionary<int, ModelBank> _allAcc = bankData.GetAllBankAccounts();
            List<ModelBank> _searchData = new List<ModelBank>();
            /*
            foreach (var model in _allAcc)
            {
                if (model.Value.Balance >= ammountOver)
                {
                    _searchData.Add(model.Value);
                }
            }
            */
            _searchData = _allAcc.Values.Where(account => account.Balance >= ammountOver).ToList();
            return _searchData;
        }

        public bool RemoveAccountFromAll(int accNo)
        {
            return bankData.RemoveAcc(accNo);
        }

        public List<ModelBank> SearchAccByName(string name)
        {
            List<ModelBank> _search = new List<ModelBank>();
            Dictionary<int, ModelBank> _allAcc = bankData.GetAllBankAccounts();

            _search = _allAcc.Values.Where(account => account.Name == name).ToList();

            return _search;
        }
    }
}
