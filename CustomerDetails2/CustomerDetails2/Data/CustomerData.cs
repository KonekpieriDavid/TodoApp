using CustomerDetails2.DBAccess;
using CustomerDetails2.Models;
using System.Formats.Asn1;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.IO;



namespace CustomerDetails2.Data
{
    public class CustomerData : ICustomerData

    {
        private readonly ISqlDataAccess _db;
        public CustomerData(ISqlDataAccess db)
        {
            _db = db;

        }
        // below are the parameters needed to do the inserting to the db
        public Task InsertCustomers(Customer customer)
        {
            int? CustomerId = customer.CustomerId;
            string? CustomerFullName = customer.CustomerFullName;
            string? CustomerPhoneNumber = customer.CustomerPhoneNumber;
            string? CustomerEmailAddress = customer.CustomerEmailAddress;
            string? TransactionReference = customer.TransactionReference;
            decimal? Amount = customer.Amount;
            string? Currency = customer.Currency;
            var result = _db.SaveData(StoredProcedure: "dbo.PCES_TransactionAPITest_INSERT",

          new
          {
              CustomerId,
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

        public Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return _db.loadData<Customer, dynamic>(StoredProcedure: "dbo.PCES_GetAllCustomers", new { });
        }



        //here is where we insert our data using csv file which can be downloaded
        public IResult InsertCustomersCvs(Customer customer)
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
