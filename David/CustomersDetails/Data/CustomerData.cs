
using CustomersDetails.DBAccess;
using CustomersDetails.Models;


using System;
using System.Collections.Generic;


namespace CustomersDetails.Data
{
    public class CustomerData : ICustomerData
    {
        private readonly ISqlDataAccess _db;
        public CustomerData(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task InsertCustomers(Customer customer)
        {
            int? CustomerId = customer.CustomerId;
            string? CustomerFullName = customer.CustomerFullName;
            string? CustomerPhoneNumber = customer.CustomerPhoneNumber;
            string? CustomerEmailAddress = customer.CustomerEmailAddress;
            string? TransactionReference = customer.TransactionReference;
            decimal? Amount = customer.Amount;
            string? Currency = customer.Currency;

            var result= _db.SaveData(StoredProcedure: "dbo.PCES_TransactionAPITest_INSERT",

           new
           {
               CustomerId, 
               CustomerFullName ,
               CustomerPhoneNumber, 
               CustomerEmailAddress ,
               TransactionReference ,
               Amount ,
               Currency 


           }
           );

            return result;      
        }
           
    }
}
