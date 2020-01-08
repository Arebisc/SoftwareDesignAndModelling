using BankingProject.Console.Context.State;
using BankingProject.Console.Bank;
namespace BankingProject.Console.Context
{
    public class BankContext
    {
        private InterestState state;

        public void SetState(InterestState newState){
            this.state = newState;
        }

        public double CalculateInterest(Account account){
            return state.CalculateInterest(this, account);
        }
    }
}