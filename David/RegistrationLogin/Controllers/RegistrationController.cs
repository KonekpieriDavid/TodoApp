using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistrationLogin.Models;
using RegistrationLogin.Data;


using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace RegistrationLogin.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        
    }
   
    public static class UserEndpoints
    {
       
        public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
        {
           

            //MapPost Method to send data to the stored procedure
            routes.MapPost("/api/Register/", async Task<IResult> (Registration registrationModel, IUserData data) =>
            {
                var result = await data.InsertUsers(registrationModel);
                if(result == 1)
                {
                    return Results.Ok("user inserted");
                }
                else
                {
                    return Results.BadRequest("user not inserted");
                } 
               
            }
            )
            .WithName("CreateUser")
        .Produces<Registration>(StatusCodes.Status201Created);







        }
        public static void MapGetUserEndpoints(this IEndpointRouteBuilder routes)
        {
            //MapGet Method to retrieve data to the database
            routes.MapGet("/api/Users/", async (IUserData data) =>
            {
                var res = await data.GetUsers();
                return res;
            }
            )
            .WithName("GetUser")
        .Produces<Registration>(StatusCodes.Status201Created);







        }

    }
}
