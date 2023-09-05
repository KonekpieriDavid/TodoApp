namespace CustomerDetails2.Models
{
    public class Customer
    {
        
        public int CustomerId { get; set; }
        public string? CustomerFullName { get; set; }
        public string? CustomerPhoneNumber { get; set; }
        public string? CustomerEmailAddress { get; set; }
        public string? TransactionReference { get; set; }
        public decimal Amount { get; set; }
        public string? Currency { get; set; }
    }
}
