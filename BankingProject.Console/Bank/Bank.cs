using BankingProject.Console.Exceptions;
using BankingProject.Console.Interfaces.Bank;
using BankingProject.Console.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BankingProject.Console.Bank
{
    public class Bank: IBank, IObservable
    {
        private IDictionary<string, Account> _accounts = null;
        private readonly IList<IBankingOperationObserver> _bankingOperationObservers;

        private readonly BankContext _bankContext;

        public Bank()
        {
            _accounts = new Dictionary<string, Account>();
            _bankingOperationObservers = new List<IBankingOperationObserver>();
            _bankContext = new BankContext();
        }


        public void Start()
        {
            var bank = new Bank();
            bank.CreateAccount("123", "Jan", "Kowalski");
            bank.CreateAccount("23", "Anna", "Nowak");

            var Account123 = bank.Account("123");
            var Account23 = bank.Account("23");

            Account123.Deposit(1000);
            Account123.Withdraw(200);
            Account123.TransferTo(Account23, 100);
        }

        /**
         * Transfer z rachunku na Account
         * @param accountFrom
         * @param accountTo
         * @param ammount
         */
        public void Transfer(IAccount accountFrom, IAccount accountTo, double ammount)
        {
            Notify();
            accountFrom.TransferTo(accountTo, ammount);
        }

        /**
         * Transfer from one account to another
         * @param idFrom
         * @param idTo
         * @param ammount
         */
        public void Transfer(string idFrom, string idTo, double ammount)
        {
            Notify();
            var accountFrom = Account(idFrom);
            var accountTo = Account(idTo);

            accountFrom.TransferTo(accountTo, ammount);
        }

        /**
         * Creating an account
         * @param id
         * @param owner's name
         * @param owner's surname
         */
        public void CreateAccount(string id, string name, string surname)
        {
            Notify();
            if (Account(id) != null)
            {
                throw new BankingException("This Account ID already exists!");
            }

            var account = new Account(id, name, surname);
            _accounts.Add(id, account);
        }


        /**
         * Searches for Account with a given id number
         * @param id
         */
        private Account Account(string id)
        {
            return _accounts[id];
        }

        /**
         * Returns an iterator for account list
         */
        private IEnumerator<KeyValuePair<string, Account>> ListAccounts()
        {
            return _accounts.GetEnumerator();
        }

        public void Attach(IBankingOperationObserver bankingOperationObserver)
        {
            Debug.WriteLine("Attaching observer to Bank");
            _bankingOperationObservers.Add(bankingOperationObserver);
        }

        public void Detach(IBankingOperationObserver bankingOperationObserver)
        {
            Debug.WriteLine("Detaching observer from Bank");
            _bankingOperationObservers.Remove(bankingOperationObserver);
        }

        public void Notify()
        {
            Debug.WriteLine("Notifying observers...");

            foreach (var observer in _bankingOperationObservers)
            {
                observer.Update(this);
            }
        }
    }
}
