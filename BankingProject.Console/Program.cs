namespace BankingProject.Console
{
    // TODO Command and Observer pattern
    class Program
    {
        static void Main(string[] args) 
        {
            var bank = new Bank.Bank();
            bank.Start();
        }
    }
}
