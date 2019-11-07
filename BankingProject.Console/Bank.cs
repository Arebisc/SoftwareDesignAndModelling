using BankingProject.Console.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingProject.Console
{
    public class Bank
    {

        private Dictionary<string, Account> _accounts = null;

        public Bank()
        {
            _accounts = new Dictionary<string, Account>();
        }

        /**
         * Creating an account
         * @param id
         * @param owner's name
         * @param owner's surname
         */
        public void CreateAccount(string id, string name, string surname)
        {
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
        private Dictionary<string, Account>.Enumerator ListAccounts()
        {
            return _accounts.GetEnumerator();
        }

        /**
         * Transfer z rachunku na Account
         * @param accountFrom
         * @param accountTo
         * @param ammount
         */
        public void Transfer(Account accountFrom, Account accountTo, double ammount)
        {
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
            var accountFrom = Account(idFrom);
            var accountTo = Account(idTo);

            accountFrom.TransferTo(accountTo, ammount);
        }

        public static void Start(string[] args)
        {
            var bank = new Bank();
            bank.CreateAccount("123", "Jan", "Kowalski");
            bank.CreateAccount("23", "Anna", "Nowak");

            var Account123 = bank.Account("123");
            var Account23 = bank.Account("23");

            Account123.Deposit(1000);
            Account123.Withwdraw(200);
            Account123.TransferTo(Account23, 100);
        }
    }
}
