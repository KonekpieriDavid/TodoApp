using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Dapper;
using Microsoft.WindowsAzure.Storage;
using Azure.FunctionApp1.DataAccess;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using  MojoAuth.NET;
using System.Threading;

namespace FunctionApp1
{
   

  
    public  class Function1
       
    {
        private readonly IDapperConnService _db;

        public Function1(IDapperConnService db)
        {
            _db = db;
        }

        [FunctionName("SendOTP")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
               
     


                var key = Environment.GetEnvironmentVariable("Signup key");

                var secret = Environment.GetEnvironmentVariable("API Secret");
                var mojoAuthHttpClient = new MojoAuthHttpClient(key, secret);





                string FullName,  UserName, PasswordHash, PhoneNumber, Email;

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                FullName = data.FullName;
                PhoneNumber = data.PhoneNumber;
                UserName = data.UserName;
                PasswordHash = data.PasswordHash;
                Email = data.Email;
                
                var store=await  _db.SaveData(

                    storedProcedure: "[dbo].[PCES_USERS_INSERT_REGISTRATION]",
                    new { FullName, PhoneNumber,  UserName,  PasswordHash, Email });

               //var resp = await mojoAuthHttpClient.SendEmailOTP(Email);
                 if (store>0)
                {
                    var resp= await mojoAuthHttpClient.SendEmailOTP(Email);
                    return  new OkObjectResult(resp);

                }

                
               

                 //return new Response  OkObjectResult();
                return new BadRequestResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }


          

           
        }
    }
}
