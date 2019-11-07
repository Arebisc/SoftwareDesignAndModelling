using BankingProject.Console.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingProject.Console
{
    public class Account
    {

        private string _id = null;
        private string _name = null;
        private string _surname = null;
        private double _balance = 0;

        public Account(string id, string name, string surname)
        {
            this._id = id;
            this._name = name;
            this._surname = surname;
        }

        /**
         * Deposit funds to Account
         * @param ammount
         */
        public void Deposit(double ammount)
        {
            if (ammount< 0)
            {
                throw new BankingException("ammount wp�aty musi by� nieujemna");
            }

            _balance += ammount;
        }

        /**
         * Withwdraw from account
         * @param amount
         * @throws BankingException
         */
        public void Withwdraw(double amount)
        {
            if (_balance < amount)
            {
                throw new BankingException("Pr�ba wyp�aty ponad balance na rachunku");
            }
            if (amount < 0)
            {
                throw new BankingException("ammount wyp�aty musi by� nieujemna");
            }

            _balance -= amount;
        }

        /**
         * amount of funds available
         * @return
         */
        public double Balance
        { 
            get 
            {
                return _balance;
            }
        }

        public string Owner
        {
            get
            {
                return _name + " " + _surname;
            }
        }

        /**
         * Requesting a transfer to another account
         * @param Account
         * @param ammount
         */
        public void TransferTo(Account Account, double ammount)
        {
            if (ammount > _balance)
            {
                throw new BankingException("Trying to transfer more funds than available");
            }

            _balance -= ammount;
            Account.TransferFrom(this, ammount);
        }

        /**
         * Accepting a transfer from another account
         * @param account
         * @param ammount
         */
        private void TransferFrom(Account account, double ammount)
        {
            _balance += ammount;
        }

        /**
         * Account description
         */
        public override string ToString()
        {
            return "Nr: " + _id + ", owner: " + Owner + ", balance: " + Balance;
        }
    }
}
