using Dapper;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
 




namespace PaymentPlatformV2.Controllers
{
    [Route("api/Controller")]
    [ApiController]



    public class OrdersController : ControllerBase { 



    public readonly IConfiguration _configuration;
    public OrdersController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

        [HttpGet]
        [Route("GetAllOrders")]

        public GetOrders()


        {


            var Sql = "select * from Orders";
            var Orders = new List<Orders>();
            using (var connection = new SqlConnection(connString)) ;

        }        connection.Open();
            )
                using (var command = connection.CreateCommand()) ;
                using (var command = new SqlCommand(sql, connection)) ;

                using (var reader = command.ExecuteReader()) ;

                   return Orders = new Orders()
               
                    {


                        OrderId = reader.GetInt32(reader.GetOrdinal("OrderId")),
                        UserId = reader.GetInt32(Reader.getOrdinal("UserId")),
                        Amount = reader.GetDecimal(reader.GetOrdinal("Amount")),
                        Fess = reader.GetDecimal(Reader.GetOrdinal("Fess")),
                        Total = reader.GetDecimal(Reader.GetOrdinal("Total")),
                        CreatedWhenUTC = Reader.GetDatetime(Date)(Reader.GetOrdinal("CreatedWhwnUTC")),
                        Description = reader.getString(Reader.GetOrdinal("Description")),
                        Payer = reader.GetString(Reader.GetOrdinal("Payer")),
                        OrderstatusId = reader.GetInt32(Reader.GetOrdinal("OrderStatusId")),
                        Createdby = reader.GetString(Reader.GetOrdinal("Createdby")),
                       CreatedDate = reader.GetDatetime(Reader.Getordinal("Createddate")),
                       Updatedby = reader.GetString(Reader.GetOrdinal("Updatedby")),
                       Updateddate = reader.GetDateTime(Date)(Reader.GetOrdinal("UpdatedDate")),
                       UpdateddateUTC = reader.GetDateTime(Reader.GetOrdinal("UpdatedDateUTC"))



                   };
                       Orders.Add( Order()   
        }
    }
}
                   


 


