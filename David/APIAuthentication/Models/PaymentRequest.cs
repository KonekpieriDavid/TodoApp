namespace APIAuthentication.Models
{
    public class PaymentRequest
    {
        public order order { get; set; }
        public PaymentChannel paymentChannel { get; set; }
    }
    public class order
    {
        public string PaymentPageId { get; set; } = string.Empty;
        public string CustomerFullName { get; set; } = string.Empty;
        public string CustomerPhoneNumber { get; set; } = string.Empty;
        public string CustomerEmailAddress { get; set; } = string.Empty;
        public string TransactionReference { get; set; } = string.Empty;
        public int Amount { get; set; } 
        public string Currency { get; set; } = string.Empty;
        public string RedirctURL { get; set; } = string.Empty;
    }
    public class PaymentChannel
    {
      public string Channel { get; set; } = string.Empty;
        public string Provider { get; set; }
        public string WalletId { get; set; } = string.Empty;

    }
}
