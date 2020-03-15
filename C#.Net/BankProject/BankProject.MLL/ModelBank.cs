using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.MLL
{
    public class ModelBank
    {
        public int AccountNo { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public readonly DateTime Created_on;

        public ModelBank(int accNo, string name, decimal amount,DateTime dt)
        {
            AccountNo = accNo; 
            Name = name;
            Balance = amount;
            Created_on = dt;
        }
    }
}