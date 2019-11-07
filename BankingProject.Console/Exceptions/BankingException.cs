using System;
using System.Collections.Generic;
using System.Text;

namespace BankingProject.Console.Exceptions
{
    public class BankingException : Exception
    {
        private static long _serialVersionUID = 1;

        public BankingException()
            : base()
        {

        }

        public BankingException(string message)
            : base(message)
        {

        }

        public BankingException(Exception exception)
            :base(exception.Message)
        {
            
        }
    }
}
