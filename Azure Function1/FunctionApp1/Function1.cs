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

namespace FunctionApp1
{
    public  class Function1
    {
        
        public readonly IDapperConnService _db;
        
        public Function1(IDapperConnService db)
        {
            _db = db;
        }

        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            try
            {
                string FullName, Username, Password, PhoneNumber, Email;

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                FullName = data.fullname;
                PhoneNumber = data.phonenumber;
                Username = data.username;
                Password = data.password;
                Email = data.email;

                await _db.SaveData(

                    storedProcedure: "[dbo].[PCES_USERS_INSERT_REGISTRATION]",
                    new { FullName, PhoneNumber, Username, Password, Email });

                return new OkObjectResult(data?.email);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }

        }
    }

}
