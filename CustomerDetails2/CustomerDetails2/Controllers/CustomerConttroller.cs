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
       
        public static void MapCustomerEndpoints (this IEndpointRouteBuilder routes)
    {
   
            //MapPost Method to send data to the stored procedure

        routes.MapPost("/api/Customer/", (Customer model, ICustomerData data) =>
        {
            return data.InsertCustomers(model);
        })

        .WithName("CreateCustomer")
        .Produces<Customer>(StatusCodes.Status201Created);

            //MapPost to  return a cvs file

            routes.MapPost("/api/CustomerCsv/", (Customer model, ICustomerData data) =>
            {
                var result = data.InsertCustomersCvs(model);
                return result;
            })
              .WithName("CreateCustomerCvs")
                .Produces<Customer>(StatusCodes.Status201Created);


            //MapGet Method  to return  record from a table

            routes.MapGet("/api/Customer", (  ICustomerData data) =>
            {
                var result = data.GetAllCustomers();
                return result;
              
            })
              .WithName("GetAllCustomers")
              .Produces<Customer[]>(StatusCodes.Status200OK);
        }


}}


/* routes.MapGet("/api/Customer", () =>
    {
        return new [] { new Customer() };
    })
    .WithName("GetAllCustomers")
    .Produces<Customer[]>(StatusCodes.Status200OK); 


/*routes.MapGet("/api/Customer/{id}", (int id) =>
{
    //return new Customer { ID = id };
})
.WithName("GetCustomerById")
.Produces<Customer>(StatusCodes.Status200OK);*/

/*routes.MapPut("/api/Customer/{id}", (int id, Customer input) =>
{
    return Results.NoContent();
})
.WithName("UpdateCustomer")
.Produces(StatusCodes.Status204NoContent);*/

/* routes.MapDelete("/api/Customer/{id}", (int id) =>
      {
          //return Results.Ok(new Customer { ID = id });
      })
      .WithName("DeleteCustomer")
      .Produces<Customer>(StatusCodes.Status200OK);*/