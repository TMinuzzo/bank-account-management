namespace BankAccount.API.Models
{
    // Request Model used to receiva dataS
    public class MakePaymentModel
    {
        public int Source { get; set; }
        
        public string Destination { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }
    }
}
