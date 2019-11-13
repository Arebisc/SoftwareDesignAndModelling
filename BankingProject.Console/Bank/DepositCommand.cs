using BankingProject.Console.Interfaces.Bank;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingProject.Console.Bank
{
    public class DepositCommand: IBankingOperation
    {
        private readonly Account _account;
        private readonly double _amount;

        public DepositCommand(Account account, double amount)
        {
            _account = account;
            _amount = amount;
        }

        public void Execute()
        {
            _account.Withwdraw(_amount);
        }
    }
}
