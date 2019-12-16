using BankingProject.Console.Interfaces.Bank;

namespace BankingProject.Console.Context.State{
    public class TypeCInterestState : InterestState
    {
        public double CalculateInterest(BankContext context, IAccount account)
        {
            return account.Balance * 0.035;
        }
    }
}