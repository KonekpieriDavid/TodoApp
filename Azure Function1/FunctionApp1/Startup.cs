using Microsoft.Azure.WebJobs.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Azure.FunctionApp1.DataAccess;

namespace Azure.FunctionApp1
{
    public class Startup  :IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.Services.TryAddScoped<IDapperConnService  > ();
           
            
        }

        
    }
}
