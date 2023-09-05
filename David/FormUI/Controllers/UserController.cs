using FormUI.Model;
using FormUI.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Dapper;
namespace FormUI.Controllers
{

    public class UserController : ControllerBase
    {
        public UserController()
        {

        }
    }

    public static class UserEndpoints
    {

        public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
        {


            //MapPost Method to send data to the stored procedure

            routes.MapPost("/api/Registration/", (Register model, IUserData data) =>
            {
                return data.InsertRegister(model);
            })

            .WithName("CreateUser")
            .Produces<Register>(StatusCodes.Status201Created);







        }
    }


}





