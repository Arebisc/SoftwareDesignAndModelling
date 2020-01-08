using BankingProject.Console.Interfaces.Bank;
using BankingProject.Console.Context;

namespace BankingProject.Console.Context.State{
    public class TypeAInterestState : InterestState
    {
        public double CalculateInterest(BankContext context, IAccount account)
        {
            var sum = account.Balance;   
            if (sum <= 800)
                return sum * 0.02;
            return sum * 0.04;
        }
    }
}