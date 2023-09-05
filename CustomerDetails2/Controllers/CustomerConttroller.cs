using CustomerDetails2.Data;
using CustomerDetails2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
using Newtonsoft.Json;
using static NuGet.Packaging.PackagingConstants;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using NuGet.Protocol.Plugins;
using Dapper;
using System.Drawing.Printing;

namespace CustomerDetails2.Controllers
{
    public class CustomerConttroller : ControllerBase
    {


        public CustomerConttroller()
        {

        }

    }


public static class CustomerEndpoints
{
       
        public static void MapCustomerEndpoints (this IEndpointRouteBuilder routes) { 
    
   
            //MapPost Method to send data to the stored procedure

        routes.MapPost("/api/Customer/", (OrdersData Customer , ICustomerData data) =>
        {
            return data.InsertCustomers(Customer);
        })

        .WithName("CreateCustomer")
        .Produces<Customer>(StatusCodes.Status201Created);


       

            //MapPost to  return a cvs file

          /*  routes.MapPost("/api/CustomerCsv/", (Customer model, ICustomerData data) =>
            {
                var result = data.GetAllOder(model);
                return result;
            })
              .WithName("CreateCustomerCvs")
                .Produces<Customer>(StatusCodes.Status201Created);*/



            routes.MapPost("/api/OrdersFilter/", (Filter orderFilter, ICustomerData data) =>
            {
                var result = data.GetAllOder(orderFilter);
                return result;
            })
              .WithName("GetAllOrder")
                .Produces<Customer>(StatusCodes.Status201Created);


            //Csv file export download
            routes.MapPost("/api/OrdersFilterCsv/", async([FromBody]OrderDataFilter orderFilter, ICustomerData data) =>
            {
                var resultdata =await data.GetAllOderdata(orderFilter);
                var response = data.FilterDataCvs(resultdata);

                return response;
            })
              .WithName("GetAllOderdata")
                .Produces<Customer>(StatusCodes.Status201Created);



            //MapGet Method  to return  record from a table
            /*
                        routes.MapGet("/api/Customer", ( ICustomerData data) =>
                        {
                            var result = data.GetAllCustomers();
                            return result;

                        })
                          .WithName("GetAllCustomers")
                          .Produces<Customer[]>(StatusCodes.Status200OK);*/
        }
     }


}

