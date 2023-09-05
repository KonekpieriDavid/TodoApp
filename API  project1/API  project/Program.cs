global using DataAccess.Data;
global using DataAccess.Models;
using DataAccess.DBAccess;
using Microsoft.AspNetCore.Builder;
using System.Linq.Expressions;

namespace MinimalAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton< ISqlDataAccess, SqlDataAccess>();
         
            builder.Services.AddSingleton<IOrdersData, OrdersData>();

            builder.Services.AddSingleton<ITransactionData, TransactionData>();

            // Add services to the container.

            builder.Services.AddControllers();

            
            var app = builder.Build();

            app.MapGet("/Orders/{Page}/{Size}", async (int Page, int Size, IOrdersData Data) =>
            {
                try
                {
                   var result=await Data.GetOrders (Page, Size);
                    if (result == null)
                        return Results.NotFound();

                    return Results.Ok(result);

                }
                catch(Exception ex)
                {

                    return Results.Problem(ex.ToString());
                }
            }   );

            app.MapGet("/Transactions/{Page}/{Size}", async (int Page, int Size, ITransactionData Data) =>
            {
                try
                {
                    var result = await Data.GetTransactions(Page, Size);
                    if (result == null)
                        return Results.NotFound();

                    return Results.Ok(result);

                }
                catch (Exception ex)
                {

                    return Results.Problem(ex.ToString());
                }
            });


            app.UseHttpsRedirection();

            app.Run();
        }
    }
}