using System;
using System.Collections.Generic;
using System.Text;

namespace BankingProject.Console.Interfaces.Bank
{
    public interface IBank
    {
        void Start();
        void Transfer(IAccount accountFrom, IAccount accountTo, double ammount);
        void Transfer(string idFrom, string idTo, double ammount);
        void CreateAccount(string id, string name, string surname);
    }
}
