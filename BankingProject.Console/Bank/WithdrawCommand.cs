using BankingProject.Console.Interfaces.Bank;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingProject.Console.Bank
{
    public class WithdrawCommand : IBankingOperation
    {
        private readonly IAccount _account;
        private readonly double _amount;

        public WithdrawCommand(IAccount account, double amount)
        {
            _account = account;
            _amount = amount;
        }

        public void Execute()
        {
            _account.Withdraw(_amount);            
        }
    }
}
