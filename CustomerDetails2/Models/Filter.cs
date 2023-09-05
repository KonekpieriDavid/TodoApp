namespace CustomerDetails2.Models
{
    public class Filter
    {
        public int PageNo { get; set; }
        public string?  StartDate { get; set; }
        public string?  EndDate{ get; set; }
        public string? Status { get; set; }
        public int PageSize { get; set; }
    }
    public class OrderDataFilter
    {
       
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? Status { get; set; }
      
    }

    public class OrdersData
    {
        public int Num_row { get; set; }

        public int OrderId { get; set; }
        public DateTime? Date { get; set; }
        public string? TransactionReference { get; set; }
        public string? Currency { get; set; }

        public decimal? Amount { get; set; }
               
	    public string? Status { get; set; }
	  
	  

    }
    public class Status
    {
        public string? Success { get; set; }
        public string? failed { get; set; }
        public int? Total { get; set; }
    }
}
