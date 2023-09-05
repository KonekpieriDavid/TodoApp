namespace PaymentPlatformV2.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }

        public decimal Amount { get; set; }

        public decimal Fess { get; set; }


        public decimal Total { get; set; }
         public DateTime CreatedWhenUTC { get; set; }
        public String Description { get; set; }
        public String Payer { get; set; }
        public int OrderStatusId { get; set; }

        public String Createdby { get; set; }
        public DateTime CreatedDate { get; set; }
        public String UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public  DateTime UpdatedDateUTC { get; set; }



                         
        
     



        
    }
}
