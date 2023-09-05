namespace CustomerDetails2.Models
{
    public class Customer
    {

        public int OrderId { get; set; }
        public DateTime? Date { get; set; }
        public string? TransactionReference { get; set; }
        public string? Currency { get; set; }
        public decimal Amount { get; set; }
        public string? Status { get; set; }
    }
}
