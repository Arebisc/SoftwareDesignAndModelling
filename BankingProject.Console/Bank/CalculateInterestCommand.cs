using BankingProject.Console.Interfaces.Bank;
using BankingProject.Console.Context;

namespace BankingProject.Console.Bank{
    public class CalculateInterestCommand : IBankingOperation
    {

        private readonly Account _account;
        private readonly BankContext _context;

        private CalculateInterestCommand(){}

        public CalculateInterestCommand(Account account, BankContext context){
            this._account = account;
            this._context = context;
        }
        
        public void Execute()
        {
            _account.AddInterest(
                _context.CalculateInterest(_account)
            );
        }
    }
}