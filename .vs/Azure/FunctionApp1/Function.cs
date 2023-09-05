using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MojoAuth.NET;
using System.Threading;
using Azure.FunctionApp1.DataAccess;
using static System.Net.WebRequestMethods;
using MojoAuth.NET.Core;
using System.Net.Sockets;

namespace FunctionApp1
{
    public class Function

    {
        private readonly IDapperConnService _db;
        public Function(IDapperConnService db)
        {
            _db = db;
        }
        [FunctionName("VerifyOTP")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                //  var resp = StateId;
                // var resp = OTP;
                var key = Environment.GetEnvironmentVariable("Signup key");

                var secret = Environment.GetEnvironmentVariable("API Secret");


                var mojoAuthHttpClient = new MojoAuthHttpClient(key, secret);




                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);

                var stateId = data?.stateId;
                var otp = data?.OTP;

                var resp = await mojoAuthHttpClient.VerifyOTP(stateId, otp);
                /** if (data > 0)

                 {


                 } **/

                // return new BadRequestResult();
                return new OkObjectResult(resp);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }

        }
    }
}
