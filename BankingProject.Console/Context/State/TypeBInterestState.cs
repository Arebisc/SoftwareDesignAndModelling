using BankingProject.Console.Interfaces.Bank;
using BankingProject.Console.Context;

namespace BankingProject.Console.Context.State{
    public class TypeBInterestState : InterestState
    {
        public double CalculateInterest(BankContext context, IAccount account)
        {
            var sum = account.Balance;   
            if (sum <= 1000)
                return sum * 0.03;
            return sum * 0.05;
        }
    }
}