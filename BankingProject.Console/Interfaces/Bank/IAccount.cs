using BankingProject.Console.Bank;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingProject.Console.Interfaces.Bank
{
    public interface IAccount
    {
        void Deposit(double ammount);
        void Withwdraw(double amount);
        double Balance { get; }
        public string Owner { get; }
        void TransferTo(IAccount account, double ammount);
        void TransferFrom(IAccount account, double ammount);
    }
}
