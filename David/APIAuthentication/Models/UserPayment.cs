namespace APIAuthentication.Models
{

    public class UserPayment
    {
        public Order order { get; set; }
        public Destination destination { get; set; }
    }

    public class Order
    {
        public string CustomerFullName { get; set; } = string.Empty;
        public string CustomerPhoneNumber { get; set; } = string.Empty;
        public string CustomerEmailAddress { get; set; } = string.Empty;
        public string TransactionReferance { get; set; } = string.Empty;

        public int Amount { get; set; } = int.MaxValue;

        public string Currency { get; set; } = string.Empty;
    }

    public class Destination
    {
        public string? Channel { get; set; }
        public string Provider { get; set; } = string.Empty;
        public string WalletID { get; set; } = string.Empty;

    }

}
