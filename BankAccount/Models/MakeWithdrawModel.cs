namespace BankAccount.API.Models
{
    // Request Model used to receiva dataS
    public class MakeWithdrawModel
    {
        public int Source { get; set; }

        public decimal Amount { get; set; }
    }
}
