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


        /*
        // Here is where we get our record from the database

        public Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return _db.GetMultiple<Customer, dynamic>(StoredProcedure: "[dbo].[PCES_GetAllOrder]", new { });
        }*/
        public Tuple<IEnumerable<Status>, IEnumerable<OrdersData>> GetAllOder(Filter orderfil)
        {
            string? Status;
            if (string.IsNullOrEmpty(orderfil.Status)) // below are the parameters needed to do the inserting to the db

            { Status = null; }
            else { Status = orderfil.Status; }
            DateTime? StartDate;
            if (string.IsNullOrEmpty(orderfil.StartDate)) { StartDate = null; } else { StartDate = DateTime.Parse(orderfil.StartDate); }
            DateTime? EndDate;
            if (string.IsNullOrEmpty(orderfil.EndDate)) { EndDate = null; } else { EndDate = DateTime.Parse(orderfil.EndDate); }

            var (counts, filteredData) = _db.GetMultiple(StoredProcedure: "[dbo].[PCES_GetAllOrder_Filter]", new
            {
                orderfil.PageNo,
                orderfil.PageSize,
                StartDate,
                EndDate,
                Status

            });
            var result = new Tuple<IEnumerable<Status>, IEnumerable<OrdersData>>(counts, filteredData);

            return result;

        }
        public Task InsertCustomers(OrdersData customer)
        {
            int? OrderId = customer.OrderId;
            DateTime? Date = customer.Date;
            string? TransactionReference = customer.TransactionReference;
            string? Currency = customer.Currency;
            decimal? Amount = customer.Amount;
            string? Status = customer.Status;
            var result = _db.SaveData(StoredProcedure: "[dbo].[PCES_OrderTable_INSERT]",

          new
          {
              OrderId,
              Date,
              TransactionReference,
              Currency,
              Amount,
              Status,


          }
          );

            return result;

        }

        public async Task<IEnumerable<Customer>> GetAllOderdata(OrderDataFilter orderfil)
        {
            string? Status;
            if (string.IsNullOrEmpty(orderfil.Status)) { Status = null; } else { Status = orderfil.Status; }
            DateTime? StartDate;
            if (string.IsNullOrEmpty(orderfil.StartDate)) { StartDate = null; } else { StartDate = DateTime.Parse(orderfil.StartDate); }
            DateTime? EndDate;
            if (string.IsNullOrEmpty(orderfil.EndDate)) { EndDate = null; } else { EndDate = DateTime.Parse(orderfil.EndDate); }

            var filteredCsv = await _db.loadData<Customer, dynamic>(StoredProcedure: "PCES_GetAllOrder_Csvfilter", new
            {

                StartDate,
                EndDate,
                Status

            });


            return filteredCsv;
        }



        public IResult FilterDataCvs(IEnumerable<Customer> OrderDataFilter)
        {
            string fileName = "customer.csv";
            var processFormat = OrderDataFilter.ToList();

            using (var writer = new StreamWriter(fileName))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(processFormat);
            }
            //return readText;
            byte[] readText = File.ReadAllBytes(fileName);
            return Results.File(readText, "text/csv", fileName);

        }




        //here is where we insert our data using csv file which can be downloaded
        public IResult InsertCustomersCvs(OrdersData customer)
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
