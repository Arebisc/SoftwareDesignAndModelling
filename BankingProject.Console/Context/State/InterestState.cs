using BankingProject.Console.Interfaces.Bank;
using BankingProject.Console.Context;

namespace BankingProject.Console.Context.State{
    public interface InterestState{
        double CalculateInterest(BankContext context, IAccount account);
    }
}