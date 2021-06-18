namespace BankAccount.API.Models
{
    // Request Model used to receiva data
    public class MakeDepositModel
    {
        public int Destination { get; set; }

        public decimal Amount { get; set; }
    }
}
