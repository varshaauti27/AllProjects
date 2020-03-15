using SGBank.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Model.Interfaces
{
    public interface IDeposit
    {
        AccountDepositResponse Deposit(Account account, decimal ammount);
    }
}
