
using OrderDetails.DBAccess;
using OrderDetails.Model;
using System.Formats.Asn1;
using System.Globalization;

namespace OrderDetails.Data
{
    public class OrderData
    {
        private readonly ISqlDataAccess _db;
        public OrderData(ISqlDataAccess db)
        {
            _db = db;
        }
        // below are the parameters needed to do the inserting to the db
        public Task InsertOrder(Order order)
        {
            int? OrderId = order.OrderId;
            string? CustomerFullName = Order.CustomerFullName;
            string? CustomerPhoneNumber = Order.CustomerPhoneNumber;
            string? CustomerEmailAddress = Order.CustomerEmailAddress;
            string? TransactionReference = Order.TransactionReference;
            decimal? Amount = Order.Amount;
            string? Currency = Order.Currency;
            string? Date = Order.Date;
            var result = _db.SaveData(StoredProcedure: "dbo.PCES_TransactionAPITest_INSERT",

          new
          {
              OrderId,
              CustomerFullName,
              CustomerPhoneNumber,
              CustomerEmailAddress,
              TransactionReference,
              Amount,
              Currency


          }
          );

            return result;

        }


        // Here is where we get our record from the database

        public Task<IEnumerable<Order>> GetAllCustomers()
        {
            return _db.loadData<Order, dynamic>(StoredProcedure: "dbo.PCES_GetAllCustomers", new { });
        }



        //here is where we insert our data using csv file which can be downloaded
        public IResult InsertCustomersCvs(Order customer)
        {
            string fileName = "customer.csv";


            using (var writer = new StreamWriter(fileName))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecord(customer);
            }
            //return readText;
            byte[] readText = File.ReadAllBytes(fileName);
            return Results.File(readText, "text/csv", fileName);

        }

    }
}
