namespace OrderDetails.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public string? CustomerFullName { get; set; }
        public string? CustomerPhoneNumber { get; set; }
        public string? CustomerEmailAddress { get; set; }
        public string? TransactionReference { get; set; }
        public decimal Amount { get; set; }
        public string? Currency { get; set; }
        public  DateOnly Date { get; set; }
        public string? Status { get; set; }
    }
}
