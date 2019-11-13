using System;
using System.Collections.Generic;
using System.Text;

namespace BankingProject.Console.Interfaces.Bank
{
    public interface IBankingOperationObserver
    {
        void Update(IObservable observableObject);
    }
}
