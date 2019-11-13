using System;
using System.Collections.Generic;
using System.Text;

namespace BankingProject.Console.Interfaces.Bank
{
    public interface IObservable
    {
        void Attach(IBankingOperationObserver bankingOperationObserver);
        void Detach(IBankingOperationObserver bankingOperationObserver);
        void Notify();
    }
}
