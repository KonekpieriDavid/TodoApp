using CustomersDetails.DBAccess;
using CustomersDetails.Models;
using System.Xml.Linq;

namespace CustomersDetails.Services
{
    public class CustomerService
    {
        private readonly ISqlDataAccess _db;
        static List<Customer> Customers { get; }
        static int nextId = 2;
       

        public CustomerService(ISqlDataAccess db)
        {
            _db = db;

        }

        public static List<Customer> GetAll() => Customers;

        public static Customer? Get(int CustomerId) => Customers.FirstOrDefault(C => C.CustomerId == CustomerId);

        public static void Add(Customer Customer)
        {
            Customer.CustomerId = nextId++;
            Customers.Add(Customer);
        }

        public Task InsertUsers(Customer customer) =>

       _db.SaveData(StoredProcedure: "dbo.PCES_TransactionAPITest_INSERT",

       new
       {
           CustomerId = customer.CustomerId,
           CustomerFullName = customer.CustomerFullName,
           CustomerPhoneNumber = customer.CustomerPhoneNumber,
           CustomerEmailAddress = customer.CustomerEmailAddress,
           TransactionReference = customer.TransactionReference,
           Amount = customer.Amount,
           Currency = customer.Currency,


       });

        public static void Delete(int CustomerId)
        {
            var Customer = Get(CustomerId);
            if (Customer is null)
                return;

            Customers.Remove(Customer);
        }

   


    }
}
